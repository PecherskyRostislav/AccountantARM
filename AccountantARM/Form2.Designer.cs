namespace AccountantARM
{
    partial class Form2
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
            this.label9 = new System.Windows.Forms.Label();
            this.pdfoTB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.militaryTB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.esvTB = new System.Windows.Forms.TextBox();
            this.changeBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backBtn.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.backBtn.Location = new System.Drawing.Point(338, 151);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(153, 41);
            this.backBtn.TabIndex = 16;
            this.backBtn.Text = "Повернутись";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(338, 32);
            this.label9.TabIndex = 21;
            this.label9.Text = "Податок на доходи фізичних осіб (%)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pdfoTB
            // 
            this.pdfoTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pdfoTB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pdfoTB.Location = new System.Drawing.Point(365, 9);
            this.pdfoTB.Name = "pdfoTB";
            this.pdfoTB.Size = new System.Drawing.Size(126, 30);
            this.pdfoTB.TabIndex = 22;
            this.pdfoTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label11.Location = new System.Drawing.Point(12, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(338, 23);
            this.label11.TabIndex = 25;
            this.label11.Text = "Військовий збір";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // militaryTB
            // 
            this.militaryTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.militaryTB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.militaryTB.Location = new System.Drawing.Point(365, 52);
            this.militaryTB.Name = "militaryTB";
            this.militaryTB.Size = new System.Drawing.Size(126, 30);
            this.militaryTB.TabIndex = 26;
            this.militaryTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label12.Location = new System.Drawing.Point(12, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(338, 23);
            this.label12.TabIndex = 27;
            this.label12.Text = "Єдиний внесок";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // esvTB
            // 
            this.esvTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.esvTB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.esvTB.Location = new System.Drawing.Point(365, 99);
            this.esvTB.Name = "esvTB";
            this.esvTB.Size = new System.Drawing.Size(126, 30);
            this.esvTB.TabIndex = 28;
            this.esvTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_KeyPress);
            // 
            // changeBtn
            // 
            this.changeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.changeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.changeBtn.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.changeBtn.Location = new System.Drawing.Point(12, 151);
            this.changeBtn.Name = "changeBtn";
            this.changeBtn.Size = new System.Drawing.Size(157, 41);
            this.changeBtn.TabIndex = 29;
            this.changeBtn.Text = "Змiнити";
            this.changeBtn.UseVisualStyleBackColor = false;
            this.changeBtn.Click += new System.EventHandler(this.changeBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refreshBtn.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.refreshBtn.Location = new System.Drawing.Point(175, 151);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(157, 41);
            this.refreshBtn.TabIndex = 30;
            this.refreshBtn.Text = "Оновити";
            this.refreshBtn.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(506, 204);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.changeBtn);
            this.Controls.Add(this.esvTB);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.militaryTB);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pdfoTB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.backBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поточні податки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox pdfoTB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox militaryTB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox esvTB;
        private System.Windows.Forms.Button changeBtn;
        private System.Windows.Forms.Button refreshBtn;
    }
}