
namespace FireCrypt.NewVolumeWizard.UserControls
{
	partial class VolumeLocation
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button finishBtn;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		
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
			this.finishBtn = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// finishBtn
			// 
			this.finishBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.finishBtn.Enabled = false;
			this.finishBtn.Location = new System.Drawing.Point(403, 282);
			this.finishBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.finishBtn.Name = "finishBtn";
			this.finishBtn.Size = new System.Drawing.Size(87, 30);
			this.finishBtn.TabIndex = 0;
			this.finishBtn.Text = "Finish";
			this.finishBtn.UseVisualStyleBackColor = true;
			this.finishBtn.Click += new System.EventHandler(this.FinishBtnClick);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(23, 124);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(138, 32);
			this.button2.TabIndex = 1;
			this.button2.Text = "Browse";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(23, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(451, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Volume Location";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(23, 98);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(149, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Create New";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(23, 57);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(451, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "...";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(23, 183);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(149, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Choose Existing";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(23, 209);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(138, 32);
			this.button1.TabIndex = 4;
			this.button1.Text = "Browse";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// VolumeLocation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.finishBtn);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "VolumeLocation";
			this.Size = new System.Drawing.Size(503, 325);
			this.ResumeLayout(false);

		}
	}
}
