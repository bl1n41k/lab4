namespace FifteenGUIDynamic
{
	partial class ReSize
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
			this.label1 = new System.Windows.Forms.Label();
			this.Size2 = new System.Windows.Forms.Button();
			this.Size3 = new System.Windows.Forms.Button();
			this.Size4 = new System.Windows.Forms.Button();
			this.Size5 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(250, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Выберите размер поля";
			// 
			// Size2
			// 
			this.Size2.AutoSize = true;
			this.Size2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Size2.Location = new System.Drawing.Point(36, 60);
			this.Size2.Name = "Size2";
			this.Size2.Size = new System.Drawing.Size(35, 36);
			this.Size2.TabIndex = 1;
			this.Size2.Text = "2";
			this.Size2.UseVisualStyleBackColor = true;
			this.Size2.Click += new System.EventHandler(this.Size2_Click);
			// 
			// Size3
			// 
			this.Size3.AutoSize = true;
			this.Size3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Size3.Location = new System.Drawing.Point(90, 60);
			this.Size3.Name = "Size3";
			this.Size3.Size = new System.Drawing.Size(35, 36);
			this.Size3.TabIndex = 2;
			this.Size3.Text = "3";
			this.Size3.UseVisualStyleBackColor = true;
			this.Size3.Click += new System.EventHandler(this.Size3_Click);
			// 
			// Size4
			// 
			this.Size4.AutoSize = true;
			this.Size4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Size4.Location = new System.Drawing.Point(146, 60);
			this.Size4.Name = "Size4";
			this.Size4.Size = new System.Drawing.Size(35, 36);
			this.Size4.TabIndex = 3;
			this.Size4.Text = "4";
			this.Size4.UseVisualStyleBackColor = true;
			this.Size4.Click += new System.EventHandler(this.Size4_Click);
			// 
			// Size5
			// 
			this.Size5.AutoSize = true;
			this.Size5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Size5.Location = new System.Drawing.Point(201, 60);
			this.Size5.Name = "Size5";
			this.Size5.Size = new System.Drawing.Size(35, 36);
			this.Size5.TabIndex = 4;
			this.Size5.Text = "5";
			this.Size5.UseVisualStyleBackColor = true;
			this.Size5.Click += new System.EventHandler(this.Size5_Click);
			// 
			// ReSize
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(274, 121);
			this.Controls.Add(this.Size5);
			this.Controls.Add(this.Size4);
			this.Controls.Add(this.Size3);
			this.Controls.Add(this.Size2);
			this.Controls.Add(this.label1);
			this.MaximumSize = new System.Drawing.Size(290, 160);
			this.MinimumSize = new System.Drawing.Size(290, 160);
			this.Name = "ReSize";
			this.Text = "ReSize";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Size2;
		private System.Windows.Forms.Button Size3;
		private System.Windows.Forms.Button Size4;
		private System.Windows.Forms.Button Size5;
	}
}