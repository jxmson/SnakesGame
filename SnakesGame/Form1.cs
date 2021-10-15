using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging; // add for jpg compressor

namespace SnakesGame
{
    public partial class frmSnakes : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        int maxWidth; int maxHeight;
        int score, highScore;
        Random r = new Random();
        bool goLeft, goRight, goUp, goDown;
        public frmSnakes()
        {
            InitializeComponent();
            new Settings();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left && Settings.directions != "right")
                goLeft = true;

            if (e.KeyCode == Keys.Right && Settings.directions != "left")
                goRight = true;

            if (e.KeyCode == Keys.Up && Settings.directions != "down")
                goUp= true;

            if (e.KeyCode == Keys.Down && Settings.directions != "up")
                goDown= true;
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goLeft = false;

            if (e.KeyCode == Keys.Right)
                goRight = false;

            if (e.KeyCode == Keys.Up)
                goUp = false;

            if (e.KeyCode == Keys.Down)
                goDown = false; ;
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void TakeScreenshot(object sender, EventArgs e)
        {
            Label caption = new Label();
            caption.Text = "I scored " + score + " and my Highscore is " + highScore;
            caption.Font = new Font("Ariel", 12, FontStyle.Bold);
            caption.ForeColor = Color.DarkBlue;
            caption.AutoSize = false;
            caption.Width = pctCanvas.Width;
            caption.Height = 30;
            caption.TextAlign = ContentAlignment.MiddleCenter;
            pctCanvas.Controls.Add(caption);

            SaveFileDialog s = new SaveFileDialog();
            s.FileName = "Snake Game Screenshot";
            s.DefaultExt = "jpg";
            s.Filter = "JPG Image File | *.jpg";
            s.ValidateNames = true;

            if(s.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(pctCanvas.Width);
                int height = Convert.ToInt32(pctCanvas.Height);
                Bitmap bmp = new Bitmap(width, height);
                pctCanvas.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(s.FileName, ImageFormat.Jpeg);
                pctCanvas.Controls.Remove(caption);
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft)
                Settings.directions = "left";
            if (goDown)
                Settings.directions = "down";
            if (goRight)
                Settings.directions = "right";
            if (goUp)
                Settings.directions = "up";

            for (int i = Snake.Count-1; i >= 0; i--)
            {
                if(i==0)
                {
                    switch(Settings.directions)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                    }
                    if(Snake[i].X < 0)
                        Snake[i].X = maxWidth;

                    if (Snake[i].X > maxWidth)
                        Snake[i].X = 0;

                    if (Snake[i].Y < 0)
                        Snake[i].Y= maxHeight;

                    if (Snake[i].Y > maxHeight)
                        Snake[i].Y = 0;

                    if(Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        EatFood();
                    }
                    for (int j = 1 ; j < Snake.Count; j++)
                    {
                        if(Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }

                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
            pctCanvas.Invalidate();
        }

        private void UpdateGraphics(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush snakeColour;
            for (int i = 0; i < Snake.Count; i++)
            {
                if(i == 0)
                {
                    snakeColour = Brushes.Black;
                }
                else
                {
                    snakeColour = Brushes.DarkGreen;
                }
                g.FillEllipse(snakeColour, new Rectangle(Snake[i].X * Settings.Width, Snake[i].Y * Settings.Height, Settings.Width, Settings.Height));

            }
            g.FillEllipse(Brushes.DarkRed, new Rectangle(food.X * Settings.Width, food.Y * Settings.Height, Settings.Width, Settings.Height));
        }
        private void RestartGame()
        {
            maxHeight = pctCanvas.Height / Settings.Height - 1;
            maxWidth = pctCanvas.Width / Settings.Width - 1;
            Snake.Clear();
            btnStart.Enabled = btnScreenshot.Enabled = false;
            score = 0;
            lblScore.Text = "Score: " + score;
            lblHighScore.Text = "Highscore: " + highScore;

            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head);

            for (int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            food = new Circle { X = r.Next(2, maxWidth), Y = r.Next(2, maxHeight)};
            tmrSnake.Start();
        }
        private void EatFood()
        {
            score += 1;
            lblScore.Text = "Score: " + score;
            Circle body = new Circle { X = Snake[Snake.Count - 1].X, Y = Snake[Snake.Count - 1].Y };
            Snake.Add(body);
            food = new Circle { X = r.Next(2, maxWidth), Y = r.Next(2, maxHeight) };

        }
        private void GameOver()
        {
            tmrSnake.Stop();
            btnScreenshot.Enabled = btnStart.Enabled = true;

            if(score > highScore)
            {
                highScore = score;
                lblHighScore.Text = "High score: " + Environment.NewLine + highScore;
                lblHighScore.ForeColor = Color.Maroon;
                lblHighScore.TextAlign = ContentAlignment.MiddleCenter;
            }
        }
    }
}
