namespace SignalRChat.Desktop
{
    partial class Form1
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            listBox1 = new ListBox();
            tb_roomname = new TextBox();
            tb_publicmessage = new TextBox();
            tb_privatemsg = new TextBox();
            cb_deleteroomname = new ComboBox();
            cb_addusertoroomname = new ComboBox();
            cb_publicmsgroomname = new ComboBox();
            btn_createroom = new Button();
            btn_deleteroom = new Button();
            btn_addusertroom = new Button();
            btn_sendpublicmessage = new Button();
            btn_sendprivatemessage = new Button();
            tb_privatemessageuseremail = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 46);
            label1.Name = "label1";
            label1.Size = new Size(115, 25);
            label1.TabIndex = 0;
            label1.Text = "Create Room";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 98);
            label2.Name = "label2";
            label2.Size = new Size(115, 25);
            label2.TabIndex = 1;
            label2.Text = "Delete Room";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 163);
            label3.Name = "label3";
            label3.Size = new Size(162, 25);
            label3.TabIndex = 2;
            label3.Text = "Add User To Room";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(60, 253);
            label4.Name = "label4";
            label4.Size = new Size(111, 25);
            label4.TabIndex = 3;
            label4.Text = "Select Room";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(60, 299);
            label5.Name = "label5";
            label5.Size = new Size(179, 25);
            label5.TabIndex = 4;
            label5.Text = "Send Public Message";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(64, 374);
            label6.Name = "label6";
            label6.Size = new Size(123, 25);
            label6.TabIndex = 5;
            label6.Text = "Receiver Email";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(60, 442);
            label7.Name = "label7";
            label7.Size = new Size(185, 25);
            label7.TabIndex = 6;
            label7.Text = "Send Private Message";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(60, 480);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(914, 229);
            listBox1.TabIndex = 7;
            // 
            // tb_roomname
            // 
            tb_roomname.Location = new Point(279, 46);
            tb_roomname.Name = "tb_roomname";
            tb_roomname.Size = new Size(150, 31);
            tb_roomname.TabIndex = 8;
            // 
            // tb_publicmessage
            // 
            tb_publicmessage.Location = new Point(279, 299);
            tb_publicmessage.Name = "tb_publicmessage";
            tb_publicmessage.Size = new Size(150, 31);
            tb_publicmessage.TabIndex = 9;
            // 
            // tb_privatemsg
            // 
            tb_privatemsg.Location = new Point(279, 442);
            tb_privatemsg.Name = "tb_privatemsg";
            tb_privatemsg.Size = new Size(150, 31);
            tb_privatemsg.TabIndex = 10;
            // 
            // cb_deleteroomname
            // 
            cb_deleteroomname.FormattingEnabled = true;
            cb_deleteroomname.Location = new Point(279, 95);
            cb_deleteroomname.Name = "cb_deleteroomname";
            cb_deleteroomname.Size = new Size(182, 33);
            cb_deleteroomname.TabIndex = 11;
            // 
            // cb_addusertoroomname
            // 
            cb_addusertoroomname.FormattingEnabled = true;
            cb_addusertoroomname.Location = new Point(279, 160);
            cb_addusertoroomname.Name = "cb_addusertoroomname";
            cb_addusertoroomname.Size = new Size(182, 33);
            cb_addusertoroomname.TabIndex = 12;
            // 
            // cb_publicmsgroomname
            // 
            cb_publicmsgroomname.FormattingEnabled = true;
            cb_publicmsgroomname.Location = new Point(279, 253);
            cb_publicmsgroomname.Name = "cb_publicmsgroomname";
            cb_publicmsgroomname.Size = new Size(182, 33);
            cb_publicmsgroomname.TabIndex = 13;
            // 
            // btn_createroom
            // 
            btn_createroom.Location = new Point(483, 37);
            btn_createroom.Name = "btn_createroom";
            btn_createroom.Size = new Size(166, 34);
            btn_createroom.TabIndex = 15;
            btn_createroom.Text = "create room";
            btn_createroom.UseVisualStyleBackColor = true;
            btn_createroom.Click += btn_createroom_Click;
            // 
            // btn_deleteroom
            // 
            btn_deleteroom.Location = new Point(483, 98);
            btn_deleteroom.Name = "btn_deleteroom";
            btn_deleteroom.Size = new Size(172, 34);
            btn_deleteroom.TabIndex = 16;
            btn_deleteroom.Text = "delete room";
            btn_deleteroom.UseVisualStyleBackColor = true;
            btn_deleteroom.Click += btn_deleteroom_Click;
            // 
            // btn_addusertroom
            // 
            btn_addusertroom.Location = new Point(483, 154);
            btn_addusertroom.Name = "btn_addusertroom";
            btn_addusertroom.Size = new Size(181, 34);
            btn_addusertroom.TabIndex = 17;
            btn_addusertroom.Text = "add user to room";
            btn_addusertroom.UseVisualStyleBackColor = true;
            btn_addusertroom.Click += btn_addusertroom_Click;
            // 
            // btn_sendpublicmessage
            // 
            btn_sendpublicmessage.Location = new Point(477, 299);
            btn_sendpublicmessage.Name = "btn_sendpublicmessage";
            btn_sendpublicmessage.Size = new Size(199, 34);
            btn_sendpublicmessage.TabIndex = 19;
            btn_sendpublicmessage.Text = "send public message";
            btn_sendpublicmessage.UseVisualStyleBackColor = true;
            btn_sendpublicmessage.Click += btn_sendpublicmessage_Click;
            // 
            // btn_sendprivatemessage
            // 
            btn_sendprivatemessage.Location = new Point(483, 440);
            btn_sendprivatemessage.Name = "btn_sendprivatemessage";
            btn_sendprivatemessage.Size = new Size(193, 34);
            btn_sendprivatemessage.TabIndex = 21;
            btn_sendprivatemessage.Text = "send private message";
            btn_sendprivatemessage.UseVisualStyleBackColor = true;
            btn_sendprivatemessage.Click += btn_sendprivatemessage_Click;
            // 
            // tb_privatemessageuseremail
            // 
            tb_privatemessageuseremail.Location = new Point(279, 368);
            tb_privatemessageuseremail.Name = "tb_privatemessageuseremail";
            tb_privatemessageuseremail.Size = new Size(150, 31);
            tb_privatemessageuseremail.TabIndex = 22;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 742);
            Controls.Add(tb_privatemessageuseremail);
            Controls.Add(btn_sendprivatemessage);
            Controls.Add(btn_sendpublicmessage);
            Controls.Add(btn_addusertroom);
            Controls.Add(btn_deleteroom);
            Controls.Add(btn_createroom);
            Controls.Add(cb_publicmsgroomname);
            Controls.Add(cb_addusertoroomname);
            Controls.Add(cb_deleteroomname);
            Controls.Add(tb_privatemsg);
            Controls.Add(tb_publicmessage);
            Controls.Add(tb_roomname);
            Controls.Add(listBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ListBox listBox1;
        private TextBox tb_roomname;
        private TextBox tb_publicmessage;
        private TextBox tb_privatemsg;
        private ComboBox cb_deleteroomname;
        private ComboBox cb_addusertoroomname;
        private ComboBox cb_publicmsgroomname;
        private Button btn_createroom;
        private Button btn_deleteroom;
        private Button btn_addusertroom;
        private Button btn_sendpublicmessage;
        private Button btn_sendprivatemessage;
        private TextBox tb_privatemessageuseremail;
    }
}

