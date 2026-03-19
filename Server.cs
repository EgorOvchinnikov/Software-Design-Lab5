using System.Runtime.InteropServices;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;

namespace Lab5_Server
{
    public partial class Server : Form
    {
        // Функции Win API для работы с буфером обмена
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AddClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern uint RegisterClipboardFormat(string Format);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetClipboardData(uint uFormat);

        [DllImport("user32.dll")]
        public static extern bool OpenClipboard(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool CloseClipboard();

        // глобальная переменная для хранения данных о формате
        uint format;

        //SendMessage
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }

        public const int WM_COPYDATA = 0x4A;
        public const int WM_CLIPBOARDUPDATE = 0x031D;
        public const int WM_USER = 0x0400;
        public const int WM_START_APP = WM_USER + 100; // Команда запуска калькулятора

        private TcpListener listener;


        public struct TDataRec
        {
            public int firstNum;
            public int secondNum;
            public int operation;
        }

        public Server()
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemoveClipboardFormatListener(this.Handle);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            format = RegisterClipboardFormat("CF_SD");
            AddClipboardFormatListener(this.Handle);
        }

        protected override void WndProc(ref Message m)
        {
            if (listener != null && radioSocket.Checked == false)
            {
                listener.Stop();
                listener = null;
            }
            if (radioClipboard.Checked) 
            {
                WndLogicClipboard(ref m);
            }
            else if (radioSendmessage.Checked)
            {
                WndLogicSendmessage(ref m);
            }
            else if (radioSocket.Checked)
            {
                LogicSocket();
            }
            else base.WndProc(ref m);

            if (m.Msg == WM_START_APP)
            {
                StartApp();
            }
        }

        private void WndLogicClipboard(ref Message m)
        {
            if (m.Msg == WM_CLIPBOARDUPDATE)
            {
                if (Clipboard.ContainsData("CF_SD"))
                {
                    OpenClipboard(IntPtr.Zero);
                    IntPtr ptrData = GetClipboardData(format);
                    TDataRec retrievedData = (TDataRec)Marshal.PtrToStructure(ptrData, typeof(TDataRec));
                    CloseClipboard();
                    txtFirstNumber.Text = retrievedData.firstNum.ToString();
                    txtSecondNumber.Text = retrievedData.secondNum.ToString();
                    cmbOperation.SelectedIndex = retrievedData.operation;
                }
                if (Clipboard.ContainsText())
                {
                    richTextBox1.Text = Clipboard.GetText().ToUpper();
                }
                if (Clipboard.ContainsImage())
                {
                    Bitmap image = new Bitmap(Clipboard.GetImage());
                    image.RotateFlip(RotateFlipType.Rotate90FlipX);
                    pictureBox1.Image = image;
                }
            }
            else base.WndProc(ref m);
        }

        private void WndLogicSendmessage(ref Message m)
        {
            if (m.Msg == WM_COPYDATA)
            {
                COPYDATASTRUCT cds = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
                if (cds.dwData == (IntPtr)0)
                {
                    byte[] data = new byte[cds.cbData];
                    Marshal.Copy(cds.lpData, data, 0, cds.cbData);
                    string message = Encoding.Default.GetString(data);
                    richTextBox1.Text = message.ToUpper();
                }
                else if (cds.dwData == (IntPtr)1)
                {
                    byte[] data = new byte[cds.cbData];
                    Marshal.Copy(cds.lpData, data, 0, cds.cbData);
                    Bitmap bm;
                    using (MemoryStream ms = new MemoryStream(data, 0, cds.cbData))
                    {
                        bm = new Bitmap(System.Drawing.Image.FromStream(ms));
                    }
                    bm.RotateFlip(RotateFlipType.Rotate180FlipY);
                    pictureBox1.Image = bm;
                }
                else if (cds.dwData == (IntPtr)2)
                {
                    TDataRec dataStruct;
                    dataStruct = (TDataRec)Marshal.PtrToStructure(cds.lpData, typeof(TDataRec));
                    txtFirstNumber.Text = dataStruct.firstNum.ToString();
                    txtSecondNumber.Text = dataStruct.secondNum.ToString();
                    cmbOperation.SelectedIndex = dataStruct.operation;
                }
            }
            else base.WndProc(ref m);
        }

        private void LogicSocket()
        {
            if (listener != null)
            {
                listener.Stop();
                listener = null;
            }

            listener = new TcpListener(IPAddress.Any, 8888);
            listener.Start();

            Task.Run(() =>
            {
                while (true)
                {
                    using (TcpClient client = listener.AcceptTcpClient())
                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] headerBuffer = new byte[8];
                        stream.Read(headerBuffer, 0, 8);

                        string dataType = Encoding.ASCII.GetString(headerBuffer, 0, 4);
                        int dataSize = BitConverter.ToInt32(headerBuffer, 4);

                        byte[] dataBuffer = new byte[dataSize];
                        int bytesRead = 0;
                        while (bytesRead < dataSize)
                        {
                            bytesRead += stream.Read(dataBuffer, bytesRead, dataSize - bytesRead);
                        }

                        if (dataType == "TEXT")
                        {
                            string text = Encoding.UTF8.GetString(dataBuffer);
                            richTextBox1.Text = text.ToUpper();
                        }
                        else if (dataType == "IMAG")
                        {
                            using (var ms = new MemoryStream(dataBuffer))
                            {
                                Image image = Image.FromStream(ms);
                                image.RotateFlip(RotateFlipType.Rotate90FlipY);
                                pictureBox1.Image = image;
                            }
                        }
                        else if (dataType == "STRU")
                        {
                            IntPtr ptr = Marshal.AllocHGlobal(dataBuffer.Length);
                            Marshal.Copy(dataBuffer, 0, ptr, dataBuffer.Length);
                            TDataRec receivedStruct = (TDataRec)Marshal.PtrToStructure(ptr, typeof(TDataRec));
                            Marshal.FreeHGlobal(ptr);

                            txtFirstNumber.Text = receivedStruct.firstNum.ToString();
                            txtSecondNumber.Text = receivedStruct.secondNum.ToString();
                            cmbOperation.SelectedIndex = receivedStruct.operation;
                        }
                    }
                }
            });
        }

        private void StartApp()
        {
            if (txtFirstNumber != null && txtSecondNumber != null && cmbOperation.SelectedIndex != -1)
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                string args = txtFirstNumber.Text + " " + cmbOperation.Text + " " + txtSecondNumber.Text;
                psi.FileName = "C:\\Users\\пользователь\\OneDrive\\Документы\\Visual Studio 2022\\Lab5_Calculator\\Lab5_Calculator\\bin\\Debug\\net8.0\\Lab5_Calculator.exe";
                psi.Arguments = args;
                Process.Start(psi);
            }
        }
    }
}
