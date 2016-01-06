
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
			this.SuspendLayout();
			// 
			// cryptList
			// 
			this.cryptList.FormattingEnabled = true;
			this.cryptList.ItemHeight = 19;
			this.cryptList.Location = new System.Drawing.Point(13, 13);
			this.cryptList.Name = "cryptList";
			this.cryptList.Size = new System.Drawing.Size(163, 346);
			this.cryptList.TabIndex = 0;
			this.cryptList.SelectedIndexChanged += new System.EventHandler(this.CryptListSelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 366);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 31);
			this.button1.TabIndex = 1;
			this.button1.Text = "Add";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(100, 366);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 31);
			this.button2.TabIndex = 2;
			this.button2.Text = "Remove";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(466, 377);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(163, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "(c) 2015-2016, 0xFireball";
			this.label2.Click += new System.EventHandler(this.Label2Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(298, 78);
			this.textBox1.Name = "textBox1";
			this.textBox1.PasswordChar = '•';
			this.textBox1.Size = new System.Drawing.Size(320, 26);
			this.textBox1.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(207, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Password";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(524, 106);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(94, 27);
			this.button3.TabIndex = 7;
			this.button3.Text = "Unlock Vault";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(298, 106);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(65, 27);
			this.button4.TabIndex = 9;
			this.button4.Text = "Import";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(365, 106);
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
			this.label4.Location = new System.Drawing.Point(207, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(411, 37);
			this.label4.TabIndex = 11;
			this.label4.Text = "No Item Selected";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(298, 224);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(320, 18);
			this.label5.TabIndex = 12;
			this.label5.Text = "Volume Locked.";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(207, 374);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(231, 23);
			this.label1.TabIndex = 14;
			this.label1.Text = "Version [not set]";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(641, 409);
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
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "FireCrypt";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
