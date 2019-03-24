namespace FinalProject_v1
{
    partial class RecipeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipeForm));
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.pictureBox_recipeImage = new System.Windows.Forms.PictureBox();
            this.txtBox_title = new System.Windows.Forms.TextBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_recipeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.White;
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 25;
            this.listBox2.Location = new System.Drawing.Point(94, 636);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(486, 450);
            this.listBox2.TabIndex = 8;
            // 
            // pictureBox_recipeImage
            // 
            this.pictureBox_recipeImage.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_recipeImage.Location = new System.Drawing.Point(94, 210);
            this.pictureBox_recipeImage.Name = "pictureBox_recipeImage";
            this.pictureBox_recipeImage.Size = new System.Drawing.Size(486, 349);
            this.pictureBox_recipeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_recipeImage.TabIndex = 9;
            this.pictureBox_recipeImage.TabStop = false;
            // 
            // txtBox_title
            // 
            this.txtBox_title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBox_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_title.Location = new System.Drawing.Point(94, 173);
            this.txtBox_title.Name = "txtBox_title";
            this.txtBox_title.Size = new System.Drawing.Size(486, 31);
            this.txtBox_title.TabIndex = 10;
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.Transparent;
            this.btn_back.Location = new System.Drawing.Point(94, 118);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(111, 49);
            this.btn_back.TabIndex = 11;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(104, 1178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 49);
            this.button2.TabIndex = 12;
            this.button2.Text = "Home";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 588);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 31);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ingredients";
            // 
            // RecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(674, 1340);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.txtBox_title);
            this.Controls.Add(this.pictureBox_recipeImage);
            this.Controls.Add(this.listBox2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RecipeForm";
            this.Text = "RecipeForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_recipeImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.PictureBox pictureBox_recipeImage;
        private System.Windows.Forms.TextBox txtBox_title;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}