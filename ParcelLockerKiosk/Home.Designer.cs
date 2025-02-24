namespace ParcelLockerKiosk
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.btnProceed = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.AdminBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProceed
            // 
            this.btnProceed.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnProceed.BackColor = System.Drawing.Color.Transparent;
            this.btnProceed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProceed.BackgroundImage")));
            this.btnProceed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProceed.FlatAppearance.BorderSize = 0;
            this.btnProceed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnProceed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProceed.Font = new System.Drawing.Font("Poor Richard", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProceed.ForeColor = System.Drawing.Color.White;
            this.btnProceed.Location = new System.Drawing.Point(633, 639);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(222, 68);
            this.btnProceed.TabIndex = 22;
            this.btnProceed.UseVisualStyleBackColor = false;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.Transparent;
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Location = new System.Drawing.Point(12, 41);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(311, 82);
            this.btnAdmin.TabIndex = 23;
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // AdminBtn
            // 
            this.AdminBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AdminBtn.BackColor = System.Drawing.Color.Transparent;
            this.AdminBtn.FlatAppearance.BorderSize = 0;
            this.AdminBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AdminBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.AdminBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdminBtn.Location = new System.Drawing.Point(667, 64);
            this.AdminBtn.Name = "AdminBtn";
            this.AdminBtn.Size = new System.Drawing.Size(190, 149);
            this.AdminBtn.TabIndex = 24;
            this.AdminBtn.UseVisualStyleBackColor = false;
            this.AdminBtn.Click += new System.EventHandler(this.AdminBtn_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.AdminBtn);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnProceed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button AdminBtn;
    }
}