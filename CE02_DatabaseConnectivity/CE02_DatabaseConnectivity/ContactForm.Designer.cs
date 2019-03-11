namespace CE02_DatabaseConnectivity
{
    partial class ContactForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactForm));
            this.txtBox_titleName = new System.Windows.Forms.TextBox();
            this.txtBox_firstName = new System.Windows.Forms.TextBox();
            this.txtBox_lastName = new System.Windows.Forms.TextBox();
            this.txtBox_phoneNumber = new System.Windows.Forms.TextBox();
            this.txtBox_emailAddress = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_deleteContact = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBox_titleName
            // 
            this.txtBox_titleName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBox_titleName.Location = new System.Drawing.Point(90, 224);
            this.txtBox_titleName.Name = "txtBox_titleName";
            this.txtBox_titleName.ReadOnly = true;
            this.txtBox_titleName.Size = new System.Drawing.Size(492, 24);
            this.txtBox_titleName.TabIndex = 0;
            // 
            // txtBox_firstName
            // 
            this.txtBox_firstName.Location = new System.Drawing.Point(90, 394);
            this.txtBox_firstName.Name = "txtBox_firstName";
            this.txtBox_firstName.Size = new System.Drawing.Size(492, 31);
            this.txtBox_firstName.TabIndex = 1;
            // 
            // txtBox_lastName
            // 
            this.txtBox_lastName.Location = new System.Drawing.Point(90, 494);
            this.txtBox_lastName.Name = "txtBox_lastName";
            this.txtBox_lastName.Size = new System.Drawing.Size(492, 31);
            this.txtBox_lastName.TabIndex = 2;
            // 
            // txtBox_phoneNumber
            // 
            this.txtBox_phoneNumber.Location = new System.Drawing.Point(90, 596);
            this.txtBox_phoneNumber.Name = "txtBox_phoneNumber";
            this.txtBox_phoneNumber.Size = new System.Drawing.Size(492, 31);
            this.txtBox_phoneNumber.TabIndex = 3;
            // 
            // txtBox_emailAddress
            // 
            this.txtBox_emailAddress.Location = new System.Drawing.Point(90, 694);
            this.txtBox_emailAddress.Name = "txtBox_emailAddress";
            this.txtBox_emailAddress.Size = new System.Drawing.Size(492, 31);
            this.txtBox_emailAddress.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Family",
            "Friend",
            "Business",
            "Other"});
            this.comboBox1.Location = new System.Drawing.Point(90, 782);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(492, 33);
            this.comboBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(85, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(85, 466);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(85, 568);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Phone Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(85, 666);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Email Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(85, 754);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Relation";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(116, 961);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(448, 63);
            this.btn_save.TabIndex = 11;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 1054);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(448, 63);
            this.button1.TabIndex = 12;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_deleteContact
            // 
            this.btn_deleteContact.BackColor = System.Drawing.Color.Transparent;
            this.btn_deleteContact.FlatAppearance.BorderSize = 0;
            this.btn_deleteContact.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_deleteContact.ForeColor = System.Drawing.Color.Red;
            this.btn_deleteContact.Location = new System.Drawing.Point(116, 1152);
            this.btn_deleteContact.Name = "btn_deleteContact";
            this.btn_deleteContact.Size = new System.Drawing.Size(448, 63);
            this.btn_deleteContact.TabIndex = 13;
            this.btn_deleteContact.Text = "Delete Contact";
            this.btn_deleteContact.UseVisualStyleBackColor = false;
            this.btn_deleteContact.Click += new System.EventHandler(this.btn_deleteContact_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cancel.ForeColor = System.Drawing.Color.Red;
            this.btn_cancel.Location = new System.Drawing.Point(412, 119);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(170, 63);
            this.btn_cancel.TabIndex = 14;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // ContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(674, 1340);
            this.ControlBox = false;
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_deleteContact);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtBox_emailAddress);
            this.Controls.Add(this.txtBox_phoneNumber);
            this.Controls.Add(this.txtBox_lastName);
            this.Controls.Add(this.txtBox_firstName);
            this.Controls.Add(this.txtBox_titleName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ContactForm";
            this.Text = "ContactForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox_titleName;
        private System.Windows.Forms.TextBox txtBox_firstName;
        private System.Windows.Forms.TextBox txtBox_lastName;
        private System.Windows.Forms.TextBox txtBox_phoneNumber;
        private System.Windows.Forms.TextBox txtBox_emailAddress;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_deleteContact;
        private System.Windows.Forms.Button btn_cancel;
    }
}