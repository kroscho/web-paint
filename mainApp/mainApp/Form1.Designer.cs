namespace mainApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filterMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pcBox = new System.Windows.Forms.PictureBox();
            this.pluginsInfoMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterMenu,
            this.pluginsInfoMenuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(476, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filterMenu
            // 
            this.filterMenu.Name = "filterMenu";
            this.filterMenu.Size = new System.Drawing.Size(62, 26);
            this.filterMenu.Text = "Filters";
            this.filterMenu.Click += new System.EventHandler(this.filterMenu_Click);
            // 
            // pcBox
            // 
            this.pcBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcBox.Image = ((System.Drawing.Image)(resources.GetObject("pcBox.Image")));
            this.pcBox.Location = new System.Drawing.Point(0, 30);
            this.pcBox.Name = "pcBox";
            this.pcBox.Size = new System.Drawing.Size(476, 598);
            this.pcBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcBox.TabIndex = 1;
            this.pcBox.TabStop = false;
            // 
            // pluginsInfoMenuToolStripMenuItem
            // 
            this.pluginsInfoMenuToolStripMenuItem.Name = "pluginsInfoMenuToolStripMenuItem";
            this.pluginsInfoMenuToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.pluginsInfoMenuToolStripMenuItem.Text = "PluginsInfoMenu";
            this.pluginsInfoMenuToolStripMenuItem.Click += new System.EventHandler(this.pluginsInfoMenuToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 628);
            this.Controls.Add(this.pcBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Plugins";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filterMenu;
        private System.Windows.Forms.PictureBox pcBox;
        private System.Windows.Forms.ToolStripMenuItem pluginsInfoMenuToolStripMenuItem;
    }
}

