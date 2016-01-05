
namespace FireCrypt.NewVolumeWizard.UserControls
{
	partial class WelcomePage
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button nextBtn;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox3;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.label1 = new System.Windows.Forms.Label();
			this.nextBtn = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(25, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(437, 30);
			this.label1.TabIndex = 0;
			this.label1.Text = "Create a new FireCrypt Volume";
			// 
			// nextBtn
			// 
			this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nextBtn.Enabled = false;
			this.nextBtn.Location = new System.Drawing.Point(387, 300);
			this.nextBtn.Name = "nextBtn";
			this.nextBtn.Size = new System.Drawing.Size(87, 27);
			this.nextBtn.TabIndex = 1;
			this.nextBtn.Text = "Next";
			this.nextBtn.UseVisualStyleBackColor = true;
			this.nextBtn.Click += new System.EventHandler(this.NextBtnClick);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(252, 77);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(210, 25);
			this.textBox1.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(125, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(121, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Volume Name";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(125, 110);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Set Password";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(252, 108);
			this.textBox2.Name = "textBox2";
			this.textBox2.PasswordChar = '•';
			this.textBox2.Size = new System.Drawing.Size(210, 25);
			this.textBox2.TabIndex = 4;
			this.textBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox2KeyUp);
			this.textBox2.Leave += new System.EventHandler(this.TextBox3Leave);
			this.textBox2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBox2PreviewKeyDown);
			this.textBox2.Validated += new System.EventHandler(this.TextBox3Validated);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(125, 141);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(121, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Confirm Password";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(252, 139);
			this.textBox3.Name = "textBox3";
			this.textBox3.PasswordChar = '•';
			this.textBox3.Size = new System.Drawing.Size(210, 25);
			this.textBox3.TabIndex = 6;
			this.textBox3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox3KeyUp);
			this.textBox3.Leave += new System.EventHandler(this.TextBox3Leave);
			this.textBox3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBox2PreviewKeyDown);
			this.textBox3.Validated += new System.EventHandler(this.TextBox3Validated);
			// 
			// WelcomePage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.nextBtn);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "WelcomePage";
			this.Size = new System.Drawing.Size(491, 343);
			this.Load += new System.EventHandler(this.WelcomePageLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
