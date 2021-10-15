namespace SnakesGame
{
    partial class frmSnakes
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
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.pctCanvas = new System.Windows.Forms.PictureBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblHighScore = new System.Windows.Forms.Label();
            this.tmrSnake = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pctCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.Location = new System.Drawing.Point(631, 68);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(90, 40);
            this.btnScreenshot.TabIndex = 0;
            this.btnScreenshot.Text = "Screenshot";
            this.btnScreenshot.UseVisualStyleBackColor = true;
            this.btnScreenshot.Click += new System.EventHandler(this.TakeScreenshot);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(631, 22);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 40);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.StartGame);
            // 
            // pctCanvas
            // 
            this.pctCanvas.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pctCanvas.Location = new System.Drawing.Point(5, 12);
            this.pctCanvas.Name = "pctCanvas";
            this.pctCanvas.Size = new System.Drawing.Size(601, 680);
            this.pctCanvas.TabIndex = 2;
            this.pctCanvas.TabStop = false;
            this.pctCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdateGraphics);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(628, 121);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(35, 13);
            this.lblScore.TabIndex = 4;
            this.lblScore.Text = "Score";
            // 
            // lblHighScore
            // 
            this.lblHighScore.AutoSize = true;
            this.lblHighScore.Location = new System.Drawing.Point(628, 149);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(58, 13);
            this.lblHighScore.TabIndex = 5;
            this.lblHighScore.Text = "High score";
            // 
            // tmrSnake
            // 
            this.tmrSnake.Interval = 40;
            this.tmrSnake.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // frmSnakes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(748, 725);
            this.Controls.Add(this.lblHighScore);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pctCanvas);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnScreenshot);
            this.Name = "frmSnakes";
            this.Text = "Snakes Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.pctCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScreenshot;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pctCanvas;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblHighScore;
        private System.Windows.Forms.Timer tmrSnake;
    }
}

