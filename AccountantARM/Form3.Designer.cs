namespace AccountantARM
{
    partial class Form3
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
            this.backBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTP = new System.Windows.Forms.DateTimePicker();
            this.okBtn = new System.Windows.Forms.Button();
            this.peopleCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backBtn.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.backBtn.Location = new System.Drawing.Point(171, 169);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(153, 41);
            this.backBtn.TabIndex = 17;
            this.backBtn.Text = "Повернутись";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label5.Location = new System.Drawing.Point(8, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(312, 23);
            this.label5.TabIndex = 19;
            this.label5.Text = "Дата видачi";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTP
            // 
            this.dateTP.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.dateTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTP.Location = new System.Drawing.Point(12, 41);
            this.dateTP.Name = "dateTP";
            this.dateTP.Size = new System.Drawing.Size(312, 30);
            this.dateTP.TabIndex = 18;
            // 
            // okBtn
            // 
            this.okBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.okBtn.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.okBtn.Location = new System.Drawing.Point(12, 169);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(153, 41);
            this.okBtn.TabIndex = 20;
            this.okBtn.Text = "Видати";
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // peopleCB
            // 
            this.peopleCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.peopleCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.peopleCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.peopleCB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.peopleCB.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.peopleCB.FormattingEnabled = true;
            this.peopleCB.Items.AddRange(new object[] {
            "Всiм"});
            this.peopleCB.Location = new System.Drawing.Point(12, 117);
            this.peopleCB.Name = "peopleCB";
            this.peopleCB.Size = new System.Drawing.Size(312, 30);
            this.peopleCB.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "Кому видати";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(336, 222);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.peopleCB);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTP);
            this.Controls.Add(this.backBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Видача зарплатнi";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTP;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.ComboBox peopleCB;
        private System.Windows.Forms.Label label1;
    }
}