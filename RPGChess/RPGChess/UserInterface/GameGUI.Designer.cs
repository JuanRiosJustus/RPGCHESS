using RPGChess.Utility;
using System.Windows.Forms;

namespace RPGChess.UserInterface
{
    partial class GameGUI
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


        private System.Windows.Forms.Panel Display;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Display = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Display
            // 
            this.Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Display.Location = new System.Drawing.Point(0, 0);
            this.Display.Name = "panel1";
            this.Display.Size = new System.Drawing.Size(774, 462);
            this.Display.TabIndex = 1;
            this.Display.BackColor = System.Drawing.Color.SaddleBrown;
            this.Display.Paint += new System.Windows.Forms.PaintEventHandler(Canvas_Paint);
            // 
            // GameGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.ClientSize = new System.Drawing.Size(Universal.Client_x, Universal.Client_y);
            this.Controls.Add(this.Display);
            this.Name = "GameGUI";
            this.Text = "Game";
            this.KeyPreview = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(GameGUI_Press);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Closing_Button);
            this.ResumeLayout(false);

        }
        #endregion

    }
}