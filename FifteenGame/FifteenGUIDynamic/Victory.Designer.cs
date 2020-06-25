namespace FifteenGUIDynamic
{
	partial class Victory
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Victory));
			this.duration = new System.Windows.Forms.Label();
			this.step = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// duration
			// 
			this.duration.AutoSize = true;
			this.duration.Font = new System.Drawing.Font("Times New Roman", 20F);
			this.duration.Location = new System.Drawing.Point(12, 509);
			this.duration.Name = "duration";
			this.duration.Size = new System.Drawing.Size(93, 31);
			this.duration.TabIndex = 7;
			this.duration.Text = "Время:";
			// 
			// step
			// 
			this.step.AutoSize = true;
			this.step.Font = new System.Drawing.Font("Times New Roman", 20F);
			this.step.Location = new System.Drawing.Point(303, 509);
			this.step.Name = "step";
			this.step.Size = new System.Drawing.Size(227, 31);
			this.step.TabIndex = 6;
			this.step.Text = "Количество ходов:";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(18, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(641, 483);
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// Victory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(671, 549);
			this.Controls.Add(this.duration);
			this.Controls.Add(this.step);
			this.Controls.Add(this.pictureBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Victory";
			this.Text = "Victory";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Victory_FormClosing_1);
			this.Load += new System.EventHandler(this.Victory_Load_1);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label duration;
		private System.Windows.Forms.Label step;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}