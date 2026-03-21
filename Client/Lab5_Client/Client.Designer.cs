namespace Lab5_Client
{
    partial class Client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            richTextBox1 = new RichTextBox();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbOperation = new ComboBox();
            txtSecondNumber = new TextBox();
            txtFirstNumber = new TextBox();
            groupBox2 = new GroupBox();
            btnPasteImage = new Button();
            btnPasteText = new Button();
            btnCopyText = new Button();
            btnCopyImage = new Button();
            groupBox4 = new GroupBox();
            btnPasteStruct = new Button();
            btnCopyStruct = new Button();
            groupBox5 = new GroupBox();
            btnSendStruct = new Button();
            btnSendText = new Button();
            btnSendImage = new Button();
            btnClearText = new Button();
            btnClearImage = new Button();
            btnClearStruct = new Button();
            btnSetConnection = new Button();
            label4 = new Label();
            groupBox3 = new GroupBox();
            label7 = new Label();
            btnSendStructSocket = new Button();
            label6 = new Label();
            btnSendImageSocket = new Button();
            label5 = new Label();
            btnSendTextSocket = new Button();
            btnSendCalcCommand = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 45);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(316, 231);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(345, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(316, 231);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbOperation);
            groupBox1.Controls.Add(txtSecondNumber);
            groupBox1.Controls.Add(txtFirstNumber);
            groupBox1.Location = new Point(674, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(220, 155);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Структура";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 114);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 5;
            label3.Text = "Операция:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 75);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 4;
            label2.Text = "Второе число:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 36);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 3;
            label1.Text = "Первое число:";
            // 
            // cmbOperation
            // 
            cmbOperation.FormattingEnabled = true;
            cmbOperation.Items.AddRange(new object[] { "+", "-", "*" });
            cmbOperation.Location = new Point(100, 111);
            cmbOperation.Name = "cmbOperation";
            cmbOperation.Size = new Size(103, 23);
            cmbOperation.TabIndex = 2;
            // 
            // txtSecondNumber
            // 
            txtSecondNumber.Location = new Point(100, 72);
            txtSecondNumber.Name = "txtSecondNumber";
            txtSecondNumber.Size = new Size(103, 23);
            txtSecondNumber.TabIndex = 1;
            // 
            // txtFirstNumber
            // 
            txtFirstNumber.Location = new Point(100, 33);
            txtFirstNumber.Name = "txtFirstNumber";
            txtFirstNumber.Size = new Size(103, 23);
            txtFirstNumber.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnPasteImage);
            groupBox2.Controls.Add(btnPasteText);
            groupBox2.Controls.Add(btnCopyText);
            groupBox2.Controls.Add(btnCopyImage);
            groupBox2.Location = new Point(12, 282);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(649, 59);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Буфер обмена";
            // 
            // btnPasteImage
            // 
            btnPasteImage.Location = new Point(501, 22);
            btnPasteImage.Name = "btnPasteImage";
            btnPasteImage.Size = new Size(142, 23);
            btnPasteImage.TabIndex = 1;
            btnPasteImage.Text = "Вставить из буфера";
            btnPasteImage.UseVisualStyleBackColor = true;
            btnPasteImage.Click += btnPasteImage_Click;
            // 
            // btnPasteText
            // 
            btnPasteText.Location = new Point(168, 22);
            btnPasteText.Name = "btnPasteText";
            btnPasteText.Size = new Size(142, 23);
            btnPasteText.TabIndex = 1;
            btnPasteText.Text = "Вставить из буфера";
            btnPasteText.UseVisualStyleBackColor = true;
            btnPasteText.Click += btnPasteText_Click;
            // 
            // btnCopyText
            // 
            btnCopyText.Location = new Point(6, 22);
            btnCopyText.Name = "btnCopyText";
            btnCopyText.Size = new Size(141, 23);
            btnCopyText.TabIndex = 0;
            btnCopyText.Text = "Скопировать в буфер";
            btnCopyText.UseVisualStyleBackColor = true;
            btnCopyText.Click += btnCopyText_Click;
            // 
            // btnCopyImage
            // 
            btnCopyImage.Location = new Point(333, 22);
            btnCopyImage.Name = "btnCopyImage";
            btnCopyImage.Size = new Size(141, 23);
            btnCopyImage.TabIndex = 0;
            btnCopyImage.Text = "Скопировать в буфер";
            btnCopyImage.UseVisualStyleBackColor = true;
            btnCopyImage.Click += btnCopyImage_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnPasteStruct);
            groupBox4.Controls.Add(btnCopyStruct);
            groupBox4.Location = new Point(675, 243);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(219, 98);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Буфер обмена";
            // 
            // btnPasteStruct
            // 
            btnPasteStruct.Location = new Point(6, 61);
            btnPasteStruct.Name = "btnPasteStruct";
            btnPasteStruct.Size = new Size(141, 23);
            btnPasteStruct.TabIndex = 1;
            btnPasteStruct.Text = "Вставить из буфера";
            btnPasteStruct.UseVisualStyleBackColor = true;
            btnPasteStruct.Click += btnPasteStruct_Click;
            // 
            // btnCopyStruct
            // 
            btnCopyStruct.Location = new Point(6, 28);
            btnCopyStruct.Name = "btnCopyStruct";
            btnCopyStruct.Size = new Size(141, 23);
            btnCopyStruct.TabIndex = 0;
            btnCopyStruct.Text = "Скопировать в буфер";
            btnCopyStruct.UseVisualStyleBackColor = true;
            btnCopyStruct.Click += btnCopyStruct_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(btnSendStruct);
            groupBox5.Controls.Add(btnSendText);
            groupBox5.Controls.Add(btnSendImage);
            groupBox5.Location = new Point(12, 347);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(882, 61);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "SendMessage";
            // 
            // btnSendStruct
            // 
            btnSendStruct.Location = new Point(669, 22);
            btnSendStruct.Name = "btnSendStruct";
            btnSendStruct.Size = new Size(141, 23);
            btnSendStruct.TabIndex = 0;
            btnSendStruct.Text = "Отправить структуру";
            btnSendStruct.UseVisualStyleBackColor = true;
            btnSendStruct.Click += btnSendStruct_Click;
            // 
            // btnSendText
            // 
            btnSendText.Location = new Point(6, 22);
            btnSendText.Name = "btnSendText";
            btnSendText.Size = new Size(141, 23);
            btnSendText.TabIndex = 0;
            btnSendText.Text = "Отправить текст";
            btnSendText.UseVisualStyleBackColor = true;
            btnSendText.Click += btnSendText_Click;
            // 
            // btnSendImage
            // 
            btnSendImage.Location = new Point(333, 22);
            btnSendImage.Name = "btnSendImage";
            btnSendImage.Size = new Size(141, 23);
            btnSendImage.TabIndex = 0;
            btnSendImage.Text = "Отправить картинку";
            btnSendImage.UseVisualStyleBackColor = true;
            btnSendImage.Click += btnSendImage_Click;
            // 
            // btnClearText
            // 
            btnClearText.Location = new Point(12, 12);
            btnClearText.Name = "btnClearText";
            btnClearText.Size = new Size(147, 23);
            btnClearText.TabIndex = 9;
            btnClearText.Text = "Очистить поле";
            btnClearText.UseVisualStyleBackColor = true;
            btnClearText.Click += btnClearText_Click;
            // 
            // btnClearImage
            // 
            btnClearImage.Location = new Point(345, 12);
            btnClearImage.Name = "btnClearImage";
            btnClearImage.Size = new Size(147, 23);
            btnClearImage.TabIndex = 10;
            btnClearImage.Text = "Очистить поле";
            btnClearImage.UseVisualStyleBackColor = true;
            btnClearImage.Click += btnClearImage_Click;
            // 
            // btnClearStruct
            // 
            btnClearStruct.Location = new Point(674, 12);
            btnClearStruct.Name = "btnClearStruct";
            btnClearStruct.Size = new Size(148, 23);
            btnClearStruct.TabIndex = 11;
            btnClearStruct.Text = "Очистить структуру";
            btnClearStruct.UseVisualStyleBackColor = true;
            btnClearStruct.Click += btnClearStruct_Click;
            // 
            // btnSetConnection
            // 
            btnSetConnection.Location = new Point(6, 22);
            btnSetConnection.Name = "btnSetConnection";
            btnSetConnection.Size = new Size(174, 23);
            btnSetConnection.TabIndex = 12;
            btnSetConnection.Text = "Установить соединение";
            btnSetConnection.UseVisualStyleBackColor = true;
            btnSetConnection.Click += btnSetConnection_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(188, 26);
            label4.Name = "label4";
            label4.Size = new Size(122, 15);
            label4.TabIndex = 13;
            label4.Text = "Статус подключения";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(btnSendStructSocket);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(btnSendImageSocket);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(btnSendTextSocket);
            groupBox3.Controls.Add(btnSetConnection);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(12, 414);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(882, 127);
            groupBox3.TabIndex = 14;
            groupBox3.TabStop = false;
            groupBox3.Text = "Сокет";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(670, 101);
            label7.Name = "label7";
            label7.Size = new Size(97, 15);
            label7.TabIndex = 19;
            label7.Text = "Статус отправки";
            // 
            // btnSendStructSocket
            // 
            btnSendStructSocket.Location = new Point(670, 75);
            btnSendStructSocket.Name = "btnSendStructSocket";
            btnSendStructSocket.Size = new Size(141, 23);
            btnSendStructSocket.TabIndex = 18;
            btnSendStructSocket.Text = "Отправить структуру";
            btnSendStructSocket.UseVisualStyleBackColor = true;
            btnSendStructSocket.Click += btnSendStructSocket_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(333, 101);
            label6.Name = "label6";
            label6.Size = new Size(97, 15);
            label6.TabIndex = 17;
            label6.Text = "Статус отправки";
            // 
            // btnSendImageSocket
            // 
            btnSendImageSocket.Location = new Point(333, 75);
            btnSendImageSocket.Name = "btnSendImageSocket";
            btnSendImageSocket.Size = new Size(141, 23);
            btnSendImageSocket.TabIndex = 16;
            btnSendImageSocket.Text = "Отправить картинку";
            btnSendImageSocket.UseVisualStyleBackColor = true;
            btnSendImageSocket.Click += btnSendImageSocket_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 101);
            label5.Name = "label5";
            label5.Size = new Size(97, 15);
            label5.TabIndex = 15;
            label5.Text = "Статус отправки";
            // 
            // btnSendTextSocket
            // 
            btnSendTextSocket.Location = new Point(6, 75);
            btnSendTextSocket.Name = "btnSendTextSocket";
            btnSendTextSocket.Size = new Size(141, 23);
            btnSendTextSocket.TabIndex = 1;
            btnSendTextSocket.Text = "Отправить текст";
            btnSendTextSocket.UseVisualStyleBackColor = true;
            btnSendTextSocket.Click += btnSendTextSocket_Click;
            // 
            // btnSendCalcCommand
            // 
            btnSendCalcCommand.Location = new Point(18, 581);
            btnSendCalcCommand.Name = "btnSendCalcCommand";
            btnSendCalcCommand.Size = new Size(224, 23);
            btnSendCalcCommand.TabIndex = 15;
            btnSendCalcCommand.Text = "Отправть команду на вычисление";
            btnSendCalcCommand.UseVisualStyleBackColor = true;
            btnSendCalcCommand.Click += btnSendCalcCommand_Click;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(906, 616);
            Controls.Add(btnSendCalcCommand);
            Controls.Add(groupBox3);
            Controls.Add(btnClearStruct);
            Controls.Add(btnClearImage);
            Controls.Add(btnClearText);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Controls.Add(richTextBox1);
            Name = "Client";
            Text = "Client";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cmbOperation;
        private TextBox txtSecondNumber;
        private TextBox txtFirstNumber;
        private GroupBox groupBox2;
        private Button btnPasteText;
        private Button btnCopyText;
        private Button btnPasteImage;
        private Button btnCopyImage;
        private GroupBox groupBox4;
        private Button btnPasteStruct;
        private Button btnCopyStruct;
        private GroupBox groupBox5;
        private Button btnSendText;
        private Button btnSendImage;
        private Button btnSendStruct;
        private Button btnClearText;
        private Button btnClearImage;
        private Button btnClearStruct;
        private Button btnSetConnection;
        private Label label4;
        private GroupBox groupBox3;
        private Button btnSendTextSocket;
        private Label label5;
        private Label label6;
        private Button btnSendImageSocket;
        private Label label7;
        private Button btnSendStructSocket;
        private Button btnSendCalcCommand;
    }
}
