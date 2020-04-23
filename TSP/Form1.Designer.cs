namespace TSP
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.generationsCounter = new System.Windows.Forms.Label();
			this.loadButton = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.trainNum = new System.Windows.Forms.Label();
			this.showTimer = new System.Windows.Forms.Timer(this.components);
			this.popIndexLabel = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.bestSolutionBtn = new System.Windows.Forms.Button();
			this.bestSolutionLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox1.Location = new System.Drawing.Point(12, 32);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(729, 583);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(803, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Points";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(807, 66);
			this.textBox1.Margin = new System.Windows.Forms.Padding(5);
			this.textBox1.Name = "textBox1";
			this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.textBox1.Size = new System.Drawing.Size(220, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// generationsCounter
			// 
			this.generationsCounter.AutoSize = true;
			this.generationsCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.generationsCounter.Location = new System.Drawing.Point(803, 612);
			this.generationsCounter.Name = "generationsCounter";
			this.generationsCounter.Size = new System.Drawing.Size(93, 20);
			this.generationsCounter.TabIndex = 3;
			this.generationsCounter.Text = "genCounter";
			// 
			// loadButton
			// 
			this.loadButton.Location = new System.Drawing.Point(807, 94);
			this.loadButton.Name = "loadButton";
			this.loadButton.Size = new System.Drawing.Size(220, 23);
			this.loadButton.TabIndex = 4;
			this.loadButton.Text = "Load";
			this.loadButton.UseVisualStyleBackColor = true;
			this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(807, 157);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(220, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// trackBar1
			// 
			this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBar1.Location = new System.Drawing.Point(807, 241);
			this.trackBar1.Maximum = 1000;
			this.trackBar1.Minimum = 2;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(220, 45);
			this.trackBar1.SmallChange = 10;
			this.trackBar1.TabIndex = 6;
			this.trackBar1.Value = 20;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// trainNum
			// 
			this.trainNum.AutoSize = true;
			this.trainNum.Location = new System.Drawing.Point(807, 222);
			this.trainNum.Name = "trainNum";
			this.trainNum.Size = new System.Drawing.Size(0, 13);
			this.trainNum.TabIndex = 7;
			// 
			// showTimer
			// 
			this.showTimer.Interval = 25;
			this.showTimer.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// popIndexLabel
			// 
			this.popIndexLabel.AutoSize = true;
			this.popIndexLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.popIndexLabel.Location = new System.Drawing.Point(12, 9);
			this.popIndexLabel.Name = "popIndexLabel";
			this.popIndexLabel.Size = new System.Drawing.Size(0, 20);
			this.popIndexLabel.TabIndex = 8;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(810, 134);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(53, 17);
			this.checkBox1.TabIndex = 9;
			this.checkBox1.Text = "Show";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// bestSolutionBtn
			// 
			this.bestSolutionBtn.Location = new System.Drawing.Point(807, 292);
			this.bestSolutionBtn.Name = "bestSolutionBtn";
			this.bestSolutionBtn.Size = new System.Drawing.Size(220, 23);
			this.bestSolutionBtn.TabIndex = 10;
			this.bestSolutionBtn.Text = "Show best solution";
			this.bestSolutionBtn.UseVisualStyleBackColor = true;
			this.bestSolutionBtn.Click += new System.EventHandler(this.clearBtn_Click);
			// 
			// bestSolutionLabel
			// 
			this.bestSolutionLabel.AutoSize = true;
			this.bestSolutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.bestSolutionLabel.Location = new System.Drawing.Point(803, 592);
			this.bestSolutionLabel.Name = "bestSolutionLabel";
			this.bestSolutionLabel.Size = new System.Drawing.Size(137, 20);
			this.bestSolutionLabel.TabIndex = 11;
			this.bestSolutionLabel.Text = "bestSolutionLabel";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1130, 644);
			this.Controls.Add(this.bestSolutionLabel);
			this.Controls.Add(this.bestSolutionBtn);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.popIndexLabel);
			this.Controls.Add(this.trainNum);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.loadButton);
			this.Controls.Add(this.generationsCounter);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label generationsCounter;
		private System.Windows.Forms.Button loadButton;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label trainNum;
		private System.Windows.Forms.Timer showTimer;
		private System.Windows.Forms.Label popIndexLabel;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button bestSolutionBtn;
		private System.Windows.Forms.Label bestSolutionLabel;
	}
}

