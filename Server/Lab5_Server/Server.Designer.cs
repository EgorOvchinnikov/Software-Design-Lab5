namespace Lab5_Server
{
    partial class Server
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
            richTextBox1 = new RichTextBox();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbOperation = new ComboBox();
            txtSecondNumber = new TextBox();
            txtFirstNumber = new TextBox();
            btnClearText = new Button();
            btnClearImage = new Button();
            btnClearStruct = new Button();
            radioSocket = new RadioButton();
            radioSendmessage = new RadioButton();
            radioClipboard = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(314, 277);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(341, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(314, 277);
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
            groupBox1.Location = new Point(661, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(215, 157);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Структура";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 118);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 5;
            label3.Text = "Операция:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 76);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 4;
            label2.Text = "Второе число:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 37);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 3;
            label1.Text = "Первое число:";
            // 
            // cmbOperation
            // 
            cmbOperation.FormattingEnabled = true;
            cmbOperation.Items.AddRange(new object[] { "+", "-", "*" });
            cmbOperation.Location = new Point(100, 115);
            cmbOperation.Name = "cmbOperation";
            cmbOperation.Size = new Size(109, 23);
            cmbOperation.TabIndex = 2;
            // 
            // txtSecondNumber
            // 
            txtSecondNumber.Location = new Point(100, 73);
            txtSecondNumber.Name = "txtSecondNumber";
            txtSecondNumber.Size = new Size(109, 23);
            txtSecondNumber.TabIndex = 1;
            // 
            // txtFirstNumber
            // 
            txtFirstNumber.Location = new Point(100, 34);
            txtFirstNumber.Name = "txtFirstNumber";
            txtFirstNumber.Size = new Size(109, 23);
            txtFirstNumber.TabIndex = 0;
            // 
            // btnClearText
            // 
            btnClearText.Location = new Point(12, 306);
            btnClearText.Name = "btnClearText";
            btnClearText.Size = new Size(144, 23);
            btnClearText.TabIndex = 3;
            btnClearText.Text = "Очистить текст";
            btnClearText.UseVisualStyleBackColor = true;
            btnClearText.Click += btnClearText_Click;
            // 
            // btnClearImage
            // 
            btnClearImage.Location = new Point(341, 306);
            btnClearImage.Name = "btnClearImage";
            btnClearImage.Size = new Size(144, 23);
            btnClearImage.TabIndex = 4;
            btnClearImage.Text = "Очистить изображение";
            btnClearImage.UseVisualStyleBackColor = true;
            btnClearImage.Click += btnClearImage_Click;
            // 
            // btnClearStruct
            // 
            btnClearStruct.Location = new Point(661, 187);
            btnClearStruct.Name = "btnClearStruct";
            btnClearStruct.Size = new Size(144, 23);
            btnClearStruct.TabIndex = 5;
            btnClearStruct.Text = "Очистить структуру\r\n";
            btnClearStruct.UseVisualStyleBackColor = true;
            btnClearStruct.Click += btnClearStruct_Click;
            // 
            // radioSocket
            // 
            radioSocket.AutoSize = true;
            radioSocket.Location = new Point(761, 356);
            radioSocket.Name = "radioSocket";
            radioSocket.Size = new Size(57, 19);
            radioSocket.TabIndex = 2;
            radioSocket.Text = "Сокет";
            radioSocket.UseVisualStyleBackColor = true;
            // 
            // radioSendmessage
            // 
            radioSendmessage.AutoSize = true;
            radioSendmessage.Location = new Point(761, 331);
            radioSendmessage.Name = "radioSendmessage";
            radioSendmessage.Size = new Size(97, 19);
            radioSendmessage.TabIndex = 1;
            radioSendmessage.Text = "SendMessage";
            radioSendmessage.UseVisualStyleBackColor = true;
            // 
            // radioClipboard
            // 
            radioClipboard.AutoSize = true;
            radioClipboard.Location = new Point(761, 306);
            radioClipboard.Name = "radioClipboard";
            radioClipboard.Size = new Size(105, 19);
            radioClipboard.TabIndex = 0;
            radioClipboard.Text = "Буфер обмена";
            radioClipboard.UseVisualStyleBackColor = true;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 395);
            Controls.Add(radioSocket);
            Controls.Add(radioSendmessage);
            Controls.Add(btnClearStruct);
            Controls.Add(radioClipboard);
            Controls.Add(btnClearImage);
            Controls.Add(btnClearText);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Controls.Add(richTextBox1);
            Name = "Server";
            Text = "Server";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Label label1;
        private ComboBox cmbOperation;
        private TextBox txtSecondNumber;
        private TextBox txtFirstNumber;
        private Label label3;
        private Label label2;
        private Button btnClearText;
        private Button btnClearImage;
        private Button btnClearStruct;
        private RadioButton radioSocket;
        private RadioButton radioSendmessage;
        private RadioButton radioClipboard;
    }
}
