using System;
using System.Windows.Forms;
using System.Drawing;

namespace FireCrypt
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ListBox cryptList;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenuStrip notifyIconMenu;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ContextMenuStrip newOrExistingCtxM;
		private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addExistingToolStripMenuItem;
		private System.Windows.Forms.Button button6;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cryptList = new System.Windows.Forms.ListBox();
            this.cryptListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.newOrExistingCtxM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addExistingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button6 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.pluginListStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.getMorePluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cryptListMenu.SuspendLayout();
            this.notifyIconMenu.SuspendLayout();
            this.newOrExistingCtxM.SuspendLayout();
            this.pluginListStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cryptList
            // 
            this.cryptList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cryptList.BackColor = System.Drawing.Color.Black;
            this.cryptList.ContextMenuStrip = this.cryptListMenu;
            this.cryptList.ForeColor = System.Drawing.Color.White;
            this.cryptList.FormattingEnabled = true;
            this.cryptList.ItemHeight = 19;
            this.cryptList.Location = new System.Drawing.Point(23, 86);
            this.cryptList.Name = "cryptList";
            this.cryptList.Size = new System.Drawing.Size(163, 327);
            this.cryptList.TabIndex = 0;
            this.cryptList.SelectedIndexChanged += new System.EventHandler(this.CryptListSelectedIndexChanged);
            // 
            // cryptListMenu
            // 
            this.cryptListMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cryptListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem});
            this.cryptListMenu.Name = "cryptListMenu";
            this.cryptListMenu.Size = new System.Drawing.Size(128, 30);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.ExportToolStripMenuItemClick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(22, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(110, 439);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(476, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "(c) 2015-2016, 0xFireball";
            this.label2.Click += new System.EventHandler(this.Label2Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(308, 151);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '•';
            this.textBox1.Size = new System.Drawing.Size(320, 26);
            this.textBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(217, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(534, 179);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 27);
            this.button3.TabIndex = 7;
            this.button3.Text = "Unlock Vault";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(308, 179);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 27);
            this.button4.TabIndex = 9;
            this.button4.Text = "Import";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(375, 179);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(65, 27);
            this.button5.TabIndex = 10;
            this.button5.Text = "Paste";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(217, 86);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label4.Size = new System.Drawing.Size(411, 37);
            this.label4.TabIndex = 11;
            this.label4.Text = "No Item Selected";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(308, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(320, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Volume Locked.";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(217, 447);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Version [not set]";
            this.label1.Click += new System.EventHandler(this.Label1Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.notifyIconMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "FireCryptEx";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.NotifyIcon1BalloonTipClicked);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1MouseDoubleClick);
            // 
            // notifyIconMenu
            // 
            this.notifyIconMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.notifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.notifyIconMenu.Name = "contextMenuStrip1";
            this.notifyIconMenu.Size = new System.Drawing.Size(109, 30);
            this.notifyIconMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1Opening);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // checkBox1
            // 
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(308, 223);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(320, 24);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Map volume as network drive";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Black;
            this.comboBox1.Enabled = false;
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(486, 244);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(65, 27);
            this.comboBox1.TabIndex = 17;
            // 
            // newOrExistingCtxM
            // 
            this.newOrExistingCtxM.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.newOrExistingCtxM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewToolStripMenuItem,
            this.addExistingToolStripMenuItem});
            this.newOrExistingCtxM.Name = "newOrExistingCtxM";
            this.newOrExistingCtxM.Size = new System.Drawing.Size(168, 56);
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.addNewToolStripMenuItem.Text = "Add New";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.AddNewToolStripMenuItemClick);
            // 
            // addExistingToolStripMenuItem
            // 
            this.addExistingToolStripMenuItem.Name = "addExistingToolStripMenuItem";
            this.addExistingToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.addExistingToolStripMenuItem.Text = "Add Existing";
            this.addExistingToolStripMenuItem.Click += new System.EventHandler(this.AddExistingToolStripMenuItemClick);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(461, 406);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(167, 31);
            this.button6.TabIndex = 19;
            this.button6.Text = "Remove License";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(217, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 47);
            this.label6.TabIndex = 21;
            this.label6.Text = "TRIAL: 0 DAYS REMAINING";
            this.label6.Visible = false;
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(534, 42);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(93, 31);
            this.button7.TabIndex = 22;
            this.button7.Text = "Plugins";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // pluginListStrip
            // 
            this.pluginListStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.pluginListStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getMorePluginsToolStripMenuItem});
            this.pluginListStrip.Name = "contextMenuStrip1";
            this.pluginListStrip.Size = new System.Drawing.Size(198, 30);
            // 
            // getMorePluginsToolStripMenuItem
            // 
            this.getMorePluginsToolStripMenuItem.Name = "getMorePluginsToolStripMenuItem";
            this.getMorePluginsToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.getMorePluginsToolStripMenuItem.Text = "Get More Plugins";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(654, 490);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cryptList);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MetroBorderThickness = 4;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "FireCryptEx";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TitleColor = System.Drawing.Color.SteelBlue;
            this.TitleFontStyle = new System.Drawing.Font("Segoe UI Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.cryptListMenu.ResumeLayout(false);
            this.notifyIconMenu.ResumeLayout(false);
            this.newOrExistingCtxM.ResumeLayout(false);
            this.pluginListStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        private System.Windows.Forms.ContextMenuStrip cryptListMenu;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private Button button7;
        private ContextMenuStrip pluginListStrip;
        private ToolStripMenuItem getMorePluginsToolStripMenuItem;
    }    
}
