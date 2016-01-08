
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
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ContextMenuStrip newOrExistingCtxM;
		private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addExistingToolStripMenuItem;
		private System.Windows.Forms.Label label6;
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
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.newOrExistingCtxM = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addExistingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label6 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.metroMenuStrip1 = new EPFramework.Forms.MetroMenuStrip();
			this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addNewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.addExistingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.freeVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			this.newOrExistingCtxM.SuspendLayout();
			this.metroMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cryptList
			// 
			this.cryptList.FormattingEnabled = true;
			this.cryptList.ItemHeight = 19;
			this.cryptList.Location = new System.Drawing.Point(23, 86);
			this.cryptList.Name = "cryptList";
			this.cryptList.Size = new System.Drawing.Size(163, 327);
			this.cryptList.TabIndex = 0;
			this.cryptList.SelectedIndexChanged += new System.EventHandler(this.CryptListSelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
			this.label2.Location = new System.Drawing.Point(476, 450);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(163, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "(c) 2015-2016, 0xFireball";
			this.label2.Click += new System.EventHandler(this.Label2Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(308, 151);
			this.textBox1.Name = "textBox1";
			this.textBox1.PasswordChar = '•';
			this.textBox1.Size = new System.Drawing.Size(320, 26);
			this.textBox1.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(217, 151);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Password";
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
			this.label4.Location = new System.Drawing.Point(217, 86);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(411, 37);
			this.label4.TabIndex = 11;
			this.label4.Text = "No Item Selected";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(308, 297);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(320, 18);
			this.label5.TabIndex = 12;
			this.label5.Text = "Volume Locked.";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(217, 447);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(231, 23);
			this.label1.TabIndex = 14;
			this.label1.Text = "Version [not set]";
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "FireCrypt";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.NotifyIcon1BalloonTipClicked);
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1MouseDoubleClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.exitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(109, 30);
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
			this.comboBox1.Enabled = false;
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
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.DarkRed;
			this.label6.Location = new System.Drawing.Point(208, 363);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(411, 40);
			this.label6.TabIndex = 18;
			this.label6.Text = "TRIAL: 0 Days Remaining";
			// 
			// button6
			// 
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button6.Location = new System.Drawing.Point(461, 406);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(167, 31);
			this.button6.TabIndex = 19;
			this.button6.Text = "Remove License";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.Button6Click);
			// 
			// metroMenuStrip1
			// 
			this.metroMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.metroMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.metroMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.menuToolStripMenuItem,
			this.aboutToolStripMenuItem});
			this.metroMenuStrip1.Location = new System.Drawing.Point(20, 30);
			this.metroMenuStrip1.Name = "metroMenuStrip1";
			this.metroMenuStrip1.Size = new System.Drawing.Size(615, 33);
			this.metroMenuStrip1.TabIndex = 20;
			this.metroMenuStrip1.Text = "metroMenuStrip1";
			// 
			// menuToolStripMenuItem
			// 
			this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.addNewToolStripMenuItem1,
			this.addExistingToolStripMenuItem1});
			this.menuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
			this.menuToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
			this.menuToolStripMenuItem.Text = "Menu";
			// 
			// addNewToolStripMenuItem1
			// 
			this.addNewToolStripMenuItem1.Name = "addNewToolStripMenuItem1";
			this.addNewToolStripMenuItem1.Size = new System.Drawing.Size(194, 30);
			this.addNewToolStripMenuItem1.Text = "Add New";
			this.addNewToolStripMenuItem1.Click += new System.EventHandler(this.AddNewToolStripMenuItem1Click);
			// 
			// addExistingToolStripMenuItem1
			// 
			this.addExistingToolStripMenuItem1.Name = "addExistingToolStripMenuItem1";
			this.addExistingToolStripMenuItem1.Size = new System.Drawing.Size(194, 30);
			this.addExistingToolStripMenuItem1.Text = "Add Existing";
			this.addExistingToolStripMenuItem1.Click += new System.EventHandler(this.AddExistingToolStripMenuItem1Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.aboutToolStripMenuItem1,
			this.freeVersionToolStripMenuItem});
			this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(75, 29);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// aboutToolStripMenuItem1
			// 
			this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
			this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(194, 30);
			this.aboutToolStripMenuItem1.Text = "About";
			this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.AboutToolStripMenuItem1Click);
			// 
			// freeVersionToolStripMenuItem
			// 
			this.freeVersionToolStripMenuItem.Name = "freeVersionToolStripMenuItem";
			this.freeVersionToolStripMenuItem.Size = new System.Drawing.Size(194, 30);
			this.freeVersionToolStripMenuItem.Text = "Free Version";
			this.freeVersionToolStripMenuItem.Click += new System.EventHandler(this.FreeVersionToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(655, 493);
			this.Controls.Add(this.metroMenuStrip1);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.label6);
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
			this.DisplayHeader = false;
			this.DisplayTitle = true;
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.metroMenuStrip1;
			this.Name = "MainForm";
			this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
			this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
			this.Text = "FireCryptEx";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.contextMenuStrip1.ResumeLayout(false);
			this.newOrExistingCtxM.ResumeLayout(false);
			this.metroMenuStrip1.ResumeLayout(false);
			this.metroMenuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        private EPFramework.Forms.MetroMenuStrip metroMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem freeVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addExistingToolStripMenuItem1;
    }
}
