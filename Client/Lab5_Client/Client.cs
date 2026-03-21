using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Net.Sockets;
using System.IO; 


namespace Lab5_Client
{
    public partial class Client : Form
    {
        //Функции Win API для работы с буфером обмена
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint RegisterClipboardFormat(string lpszFormat);

        [DllImport("user32.dll")]
        public static extern bool OpenClipboard(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool EmptyClipboard();

        [DllImport("user32.dll")]
        public static extern bool CloseClipboard();

        [DllImport("user32.dll")]
        public static extern IntPtr SetClipboardData(uint uFormat, IntPtr data);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetClipboardData(uint uFormat);

        [DllImport("user32.dll")]
        public static extern bool IsClipboardFormatAvailable(uint format);

        // глобальная переменная для хранения данных о формате
        uint format;

        // Для SendMessage
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(String lpClassName, String lpWindowName);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

        public const int WM_COPYDATA = 0x4A;

        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }

        public const int WM_USER = 0x0400;
        public const int WM_START_APP = WM_USER + 100;  // Команда запуска калькулятора

        // Структура с пользовательскими данными
        public struct TDataRec
        {
            public int firstNum;
            public int secondNum;
            public int operation;
        }

        public Client()
        {
            InitializeComponent();
        }

        private void btnClearText_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void btnClearStruct_Click(object sender, EventArgs e)
        {
            txtFirstNumber.Text = "";
            txtSecondNumber.Text = "";
            cmbOperation.SelectedIndex = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            format = RegisterClipboardFormat("CF_SD");
        }


        /////////////////////////Буфер обмена////////////////////////////

        private void btnCopyText_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }

        private void btnPasteText_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.Text = Clipboard.GetText();
            }
        }

        private void btnCopyImage_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(pictureBox1.Image);
        }

        private void btnPasteImage_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                pictureBox1.Image = new Bitmap(Clipboard.GetImage());
            }
        }

        private void btnCopyStruct_Click(object sender, EventArgs e)
        {
            TDataRec data;
            data.firstNum = Convert.ToInt32(txtFirstNumber.Text);
            data.secondNum = Convert.ToInt32(txtSecondNumber.Text);
            data.operation = cmbOperation.SelectedIndex;

            OpenClipboard(IntPtr.Zero);
            EmptyClipboard();
            IntPtr ptrData = Marshal.AllocHGlobal(Marshal.SizeOf(data));    // Выделяем глобальную память под данные
            Marshal.StructureToPtr(data, ptrData, false);   // заносим структуру по указателю выделенной памяти
            SetClipboardData(format, ptrData);  // устанавливаем данные в буфере обмена по заявленному формату
            CloseClipboard();
        }

        private void btnPasteStruct_Click(object sender, EventArgs e)
        {
            OpenClipboard(IntPtr.Zero);
            if (IsClipboardFormatAvailable(format))
            {
                IntPtr ptrData = GetClipboardData(format);  // Получаем данные в указатель
                TDataRec retrievedData = (TDataRec)Marshal.PtrToStructure(ptrData, typeof(TDataRec));   // формируем структуру на основе указателя
                // назначаем элементам интерфейса данные
                txtFirstNumber.Text = retrievedData.firstNum.ToString();
                txtSecondNumber.Text = retrievedData.secondNum.ToString();
                cmbOperation.SelectedIndex = retrievedData.operation;
            }
            CloseClipboard();
        }


        /////////////////////////SendMessage////////////////////////////

        private void btnSendText_Click(object sender, EventArgs e)
        {
            int receiverHandle = FindWindow(null, "Server");    // Получаем идентификатор окна Приложения куда переслать данные
            if (receiverHandle == 0)
            {
                MessageBox.Show("получатель сообщения CopyData не найден!");
                return;
            }
            COPYDATASTRUCT cds; // Объявление структуры для передачи данных
            // заполнение идентификатора
            cds.dwData = IntPtr.Zero;   // идентификация содержания сообщения (cdtString = 0)
            cds.cbData = Encoding.Default.GetBytes(richTextBox1.Text).Length;   // В случае текста указываем длинну
            cds.lpData = Marshal.AllocHGlobal(cds.cbData);  // Выделяем глобальный участок памяти для передачи
            try
            {
                IntPtr ptr = cds.lpData;    // Ставим указатель на строку
                byte[] messageBytes = Encoding.Default.GetBytes(richTextBox1.Text); // Формируем массив байтов сообщения
                Marshal.Copy(messageBytes, 0, ptr, messageBytes.Length);    // копируем данные массива в указатель
                SendMessage(receiverHandle, WM_COPYDATA, 0, ref cds);   // передаем сообщение методом SendMessage
            }
            finally
            {
                Marshal.FreeHGlobal(cds.lpData);    // освобождение памяти
            }
        }

        private void btnSendImage_Click(object sender, EventArgs e)
        {
            int receiverHandle = FindWindow(null, "Server");
            if (receiverHandle == 0)
            {
                MessageBox.Show("получатель сообщения CopyData не найден!");
                return;
            }

            byte[] imageData;   // Определяем массив для хранения байтов изображения
            // Используя MemoryStream
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox1.Image.Save(ms, ImageFormat.Bmp);    // Сохраняем изображение pictureBox1 в ms в формате bmp
                imageData = ms.ToArray();   // назначаем imageData значения ms (MemoryStream)
            }

            COPYDATASTRUCT cds; // Объявление структуры для передачи данных
            // заполнение идентификатора
            cds.dwData = (IntPtr)1; // идентификация содержания сообщения    (cdtImage = 1)
            cds.cbData = (imageData != null ? imageData.Length : 0);    // указываем длинну данных
            cds.lpData = Marshal.AllocHGlobal(cds.cbData);  // Выделяем глобальный участок памяти для передачи
            try
            {
                IntPtr ptr = cds.lpData;    // Ставим указатель на данные изображения
                if (imageData != null)
                {
                    Marshal.Copy(imageData, 0, ptr, imageData.Length);  // копируем данные массива в указатель
                }
                SendMessage(receiverHandle, WM_COPYDATA, 0, ref cds);   // передаем сообщение методом SendMessage
            }
            finally
            {
                Marshal.FreeHGlobal(cds.lpData);    // в завершении высвобожаем память
            }
        }

        private void btnSendStruct_Click(object sender, EventArgs e)
        {
            int receiverHandle = FindWindow(null, "Server");
            if (receiverHandle == 0)
            {
                MessageBox.Show("получатель сообщения CopyData не найден!");
                return;
            }
            COPYDATASTRUCT cds; // Объявление структуры для передачи данных
            TDataRec dataStruct;    // Создаем структуру данных
            // Заполняем структуру данных
            dataStruct.firstNum = Convert.ToInt32(txtFirstNumber.Text);
            dataStruct.secondNum = Convert.ToInt32(txtSecondNumber.Text);
            dataStruct.operation = Convert.ToInt32(cmbOperation.SelectedIndex);

            cds.dwData = (IntPtr)2; // идентификация содержания сообщения (cdtRecord = 2)
            cds.cbData = Marshal.SizeOf(dataStruct);    // указываем длинну данных
            cds.lpData = Marshal.AllocHGlobal(cds.cbData);  // Выделяем глобальный участок памяти для передачи
            try
            {
                IntPtr ptr = cds.lpData;    // Ставим указатель на данные 
                Marshal.StructureToPtr(dataStruct, ptr, false); // Переводим структуру в формат работы в режиме указателя 
                SendMessage(receiverHandle, WM_COPYDATA, 0, ref cds);   // передаем сообщение методом SendMessage
            }
            finally
            {
                Marshal.FreeHGlobal(cds.lpData);    // в завершении высвобожаем память
            }
        }


        /////////////////////////Сокет////////////////////////////

        public TcpClient client;
        public NetworkStream stream;

        private void btnSetConnection_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient("127.0.0.1", 8888);
                stream = client.GetStream();    // установление потока данных из соединения
                label4.Text = "Соединение установлено";
            }
            catch
            {
                label4.Text = "Ошибка клиента";
            }
        }

        private byte[] CreateHeader(string dataType, int dataSize)
        {
            byte[] typeBytes = Encoding.ASCII.GetBytes(dataType);   // преобразование типа данных в массив байтов
            byte[] sizeBytes = BitConverter.GetBytes(dataSize); // преобразование размера данных в массив байтов
            byte[] header = new byte[8];    // массив байтов для заголовка
            Array.Copy(typeBytes, header, 4);   // копирование типа данных в заголовок
            Array.Copy(sizeBytes, 0, header, 4, 4); // копирование размера данных в заголовок
            return header;
        }

        private void btnSendTextSocket_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(richTextBox1.Text);    // преобразование текста в массив байтов
                byte[] header = CreateHeader("TEXT", data.Length);  // создание заголовка
                stream.Write(header, 0, header.Length); // отправка серверу заголовка
                stream.Write(data, 0, data.Length); // отправка серверу данных
                label5.Text = "Текст отправлен";

                stream.Close();
                client.Close();
                client = null;
                stream = null;
                label4.Text = "Соединение закрыто";
            }
            catch
            {
                label5.Text = "Ошибка отправки текста";
            }
        }

        private void btnSendImageSocket_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, ImageFormat.Png);    // сохранение картинки в memoryStream
                    byte[] imageData = ms.ToArray();    // преобразование memoryStream в массив байтов
                    byte[] header = CreateHeader("IMAG", imageData.Length); // создание заголовка
                    stream.Write(header, 0, header.Length); // отправка серверу заголовка
                    stream.Write(imageData, 0, imageData.Length);   // отправка серверу данных
                    label6.Text = "Картинка отправлена";

                    stream.Close();
                    client.Close();
                    client = null;
                    stream = null;
                    label4.Text = "Соединение закрыто";
                }
            }
            catch
            {
                label6.Text = "Ошибка отправки картинки";
            }
        }

        private void btnSendStructSocket_Click(object sender, EventArgs e)
        {
            try
            {
                // заполнение структуры
                TDataRec data;
                data.firstNum = Convert.ToInt32(txtFirstNumber.Text);
                data.secondNum = Convert.ToInt32(txtSecondNumber.Text);
                data.operation = cmbOperation.SelectedIndex;

                byte[] structData = new byte[Marshal.SizeOf(typeof(TDataRec))]; // выделение массива байтов для структуры
                IntPtr ptr = Marshal.AllocHGlobal(structData.Length);   // выделение неуправляемой памяти для структуры
                Marshal.StructureToPtr(data, ptr, false);   // копирование структуры в память
                Marshal.Copy(ptr, structData, 0, structData.Length);    // копирование из памяти в массив байтов
                Marshal.FreeHGlobal(ptr);   // освобождение памяти

                byte[] header = CreateHeader("STRU", structData.Length);    // создание заголовка
                stream.Write(header, 0, header.Length); // отправка серверу заголовка
                stream.Write(structData, 0, structData.Length); // отправка серверу данных
                label7.Text = "Структура отправлена";

                stream.Close();
                client.Close();
                client = null;
                stream = null;
                label4.Text = "Соединение закрыто";
            }
            catch
            {
                label7.Text = "Ошибка отправки структуры";
            }
        }

        private void btnSendCalcCommand_Click(object sender, EventArgs e)
        {
            int receiverHandle = FindWindow(null, "Server");
            if (receiverHandle == 0)
            {
                MessageBox.Show("получатель сообщения не найден!");
                return;
            }
            COPYDATASTRUCT cds;
            cds.dwData = IntPtr.Zero;
            cds.cbData = 0;
            cds.lpData = IntPtr.Zero;

            SendMessage(receiverHandle, WM_START_APP, 0, ref cds);
        }
    }
}
