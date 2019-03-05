namespace CE01_EventHandlers
{
    partial class InputForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputForm));
            this.txtBox_title = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBox_year = new System.Windows.Forms.TextBox();
            this.rdoBtn_like = new System.Windows.Forms.RadioButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rdoBtn_dislike = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_new = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBox_genre = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_saveChanges = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBox_title
            // 
            this.txtBox_title.Location = new System.Drawing.Point(110, 358);
            this.txtBox_title.Name = "txtBox_title";
            this.txtBox_title.Size = new System.Drawing.Size(482, 31);
            this.txtBox_title.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(105, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(105, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Year";
            // 
            // txtBox_year
            // 
            this.txtBox_year.Location = new System.Drawing.Point(110, 445);
            this.txtBox_year.Name = "txtBox_year";
            this.txtBox_year.Size = new System.Drawing.Size(482, 31);
            this.txtBox_year.TabIndex = 2;
            // 
            // rdoBtn_like
            // 
            this.rdoBtn_like.BackColor = System.Drawing.Color.Transparent;
            this.rdoBtn_like.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rdoBtn_like.Checked = true;
            this.rdoBtn_like.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rdoBtn_like.ImageIndex = 0;
            this.rdoBtn_like.ImageList = this.imageList1;
            this.rdoBtn_like.Location = new System.Drawing.Point(183, 611);
            this.rdoBtn_like.Name = "rdoBtn_like";
            this.rdoBtn_like.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.rdoBtn_like.Size = new System.Drawing.Size(133, 163);
            this.rdoBtn_like.TabIndex = 4;
            this.rdoBtn_like.TabStop = true;
            this.rdoBtn_like.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rdoBtn_like.UseVisualStyleBackColor = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "up.png");
            this.imageList1.Images.SetKeyName(1, "down.png");
            // 
            // rdoBtn_dislike
            // 
            this.rdoBtn_dislike.BackColor = System.Drawing.Color.Transparent;
            this.rdoBtn_dislike.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rdoBtn_dislike.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rdoBtn_dislike.ImageIndex = 1;
            this.rdoBtn_dislike.ImageList = this.imageList1;
            this.rdoBtn_dislike.Location = new System.Drawing.Point(377, 611);
            this.rdoBtn_dislike.Name = "rdoBtn_dislike";
            this.rdoBtn_dislike.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.rdoBtn_dislike.Size = new System.Drawing.Size(133, 163);
            this.rdoBtn_dislike.TabIndex = 6;
            this.rdoBtn_dislike.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rdoBtn_dislike.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(221, 791);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Like";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(407, 791);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dislike";
            // 
            // btn_new
            // 
            this.btn_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(158)))), ((int)(((byte)(159)))));
            this.btn_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new.ForeColor = System.Drawing.Color.White;
            this.btn_new.Location = new System.Drawing.Point(99, 912);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(504, 90);
            this.btn_new.TabIndex = 12;
            this.btn_new.Text = "Save New";
            this.btn_new.UseVisualStyleBackColor = false;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(105, 503);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Genre";
            // 
            // txtBox_genre
            // 
            this.txtBox_genre.Location = new System.Drawing.Point(110, 531);
            this.txtBox_genre.Name = "txtBox_genre";
            this.txtBox_genre.Size = new System.Drawing.Size(482, 31);
            this.txtBox_genre.TabIndex = 16;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(73)))), ((int)(((byte)(65)))));
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(462, 209);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(130, 42);
            this.btn_cancel.TabIndex = 17;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(73)))), ((int)(((byte)(65)))));
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.ForeColor = System.Drawing.Color.White;
            this.btn_clear.Location = new System.Drawing.Point(360, 1023);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(243, 66);
            this.btn_clear.TabIndex = 19;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            // 
            // btn_saveChanges
            // 
            this.btn_saveChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(99)))), ((int)(((byte)(103)))));
            this.btn_saveChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveChanges.ForeColor = System.Drawing.Color.White;
            this.btn_saveChanges.Location = new System.Drawing.Point(99, 1023);
            this.btn_saveChanges.Name = "btn_saveChanges";
            this.btn_saveChanges.Size = new System.Drawing.Size(243, 66);
            this.btn_saveChanges.TabIndex = 18;
            this.btn_saveChanges.Text = "Save Changes";
            this.btn_saveChanges.UseVisualStyleBackColor = false;
            this.btn_saveChanges.Click += new System.EventHandler(this.btn_saveChanges_Click);
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(693, 1364);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_saveChanges);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.txtBox_genre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdoBtn_dislike);
            this.Controls.Add(this.rdoBtn_like);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBox_year);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InputForm";
            this.Text = "InputForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBox_year;
        private System.Windows.Forms.RadioButton rdoBtn_like;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.RadioButton rdoBtn_dislike;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBox_genre;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_saveChanges;
    }
}