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
            IntPtr ptrData = Marshal.AllocHGlobal(Marshal.SizeOf(data));
            Marshal.StructureToPtr(data, ptrData, false);
            SetClipboardData(format, ptrData);
            CloseClipboard();
        }

        private void btnPasteStruct_Click(object sender, EventArgs e)
        {
            OpenClipboard(IntPtr.Zero);
            if (IsClipboardFormatAvailable(format))
            {
                IntPtr ptrData = GetClipboardData(format);
                TDataRec retrievedData = (TDataRec)Marshal.PtrToStructure(ptrData, typeof(TDataRec));
                txtFirstNumber.Text = retrievedData.firstNum.ToString();
                txtSecondNumber.Text = retrievedData.secondNum.ToString();
                cmbOperation.SelectedIndex = retrievedData.operation;
            }
            CloseClipboard();
        }


        /////////////////////////SendMessage////////////////////////////

        private void btnSendText_Click(object sender, EventArgs e)
        {
            int receiverHandle = FindWindow(null, "Server");
            if (receiverHandle == 0)
            {
                MessageBox.Show("получатель сообщения CopyData не найден!");
                return;
            }
            COPYDATASTRUCT cds;
            cds.dwData = IntPtr.Zero;
            cds.cbData = Encoding.Default.GetBytes(richTextBox1.Text).Length;
            cds.lpData = Marshal.AllocHGlobal(cds.cbData);
            try
            {
                IntPtr ptr = cds.lpData;
                byte[] messageBytes = Encoding.Default.GetBytes(richTextBox1.Text);
                Marshal.Copy(messageBytes, 0, ptr, messageBytes.Length);
                SendMessage(receiverHandle, WM_COPYDATA, 0, ref cds);
            }
            finally
            {
                Marshal.FreeHGlobal(cds.lpData);
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

            byte[] imageData;
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox1.Image.Save(ms, ImageFormat.Bmp);
                imageData = ms.ToArray();
            }

            COPYDATASTRUCT cds;
            cds.dwData = (IntPtr)1;
            cds.cbData = (imageData != null ? imageData.Length : 0);
            cds.lpData = Marshal.AllocHGlobal(cds.cbData);
            try
            {
                IntPtr ptr = cds.lpData;
                if (imageData != null)
                {
                    Marshal.Copy(imageData, 0, ptr, imageData.Length);
                }
                SendMessage(receiverHandle, WM_COPYDATA, 0, ref cds);
            }
            finally
            {
                Marshal.FreeHGlobal(cds.lpData);
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
            COPYDATASTRUCT cds;
            TDataRec dataStruct;
            dataStruct.firstNum = Convert.ToInt32(txtFirstNumber.Text);
            dataStruct.secondNum = Convert.ToInt32(txtSecondNumber.Text);
            dataStruct.operation = Convert.ToInt32(cmbOperation.SelectedIndex);

            cds.dwData = (IntPtr)2;
            cds.cbData = Marshal.SizeOf(dataStruct);
            cds.lpData = Marshal.AllocHGlobal(cds.cbData);
            try
            {
                IntPtr ptr = cds.lpData;
                Marshal.StructureToPtr(dataStruct, ptr, false);
                SendMessage(receiverHandle, WM_COPYDATA, 0, ref cds);
            }
            finally
            {
                Marshal.FreeHGlobal(cds.lpData);
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
                stream = client.GetStream();
                label4.Text = "Соединение установлено";
            }
            catch
            {
                label4.Text = "Ошибка клиента";
            }
        }

        private byte[] CreateHeader(string dataType, int dataSize)
        {
            byte[] typeBytes = Encoding.ASCII.GetBytes(dataType);
            byte[] sizeBytes = BitConverter.GetBytes(dataSize);
            byte[] header = new byte[8];
            Array.Copy(typeBytes, header, 4);
            Array.Copy(sizeBytes, 0, header, 4, 4);
            return header;
        }

        private void btnSendTextSocket_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(richTextBox1.Text);
                byte[] header = CreateHeader("TEXT", data.Length);
                stream.Write(header, 0, header.Length);
                stream.Write(data, 0, data.Length);
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
                    pictureBox1.Image.Save(ms, ImageFormat.Png);
                    byte[] imageData = ms.ToArray();
                    byte[] header = CreateHeader("IMAG", imageData.Length);
                    stream.Write(header, 0, header.Length);
                    stream.Write(imageData, 0, imageData.Length);
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
                TDataRec data;
                data.firstNum = Convert.ToInt32(txtFirstNumber.Text);
                data.secondNum = Convert.ToInt32(txtSecondNumber.Text);
                data.operation = cmbOperation.SelectedIndex;

                byte[] structData = new byte[Marshal.SizeOf(typeof(TDataRec))];
                IntPtr ptr = Marshal.AllocHGlobal(structData.Length);
                Marshal.StructureToPtr(data, ptr, false);
                Marshal.Copy(ptr, structData, 0, structData.Length);
                Marshal.FreeHGlobal(ptr);

                byte[] header = CreateHeader("STRU", structData.Length);
                stream.Write(header, 0, header.Length);
                stream.Write(structData, 0, structData.Length);
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
