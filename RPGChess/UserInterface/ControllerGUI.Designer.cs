namespace RPGChess.UserInterface
{
    partial class ControllerGUI
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

        private System.Windows.Forms.TextBox Display;
        private System.Windows.Forms.TextBox PartyDisplay;

        private System.Windows.Forms.ComboBox TileSelector;
        private System.Windows.Forms.Button Accept_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Basic_Attack_Button;
        private System.Windows.Forms.Button Basic_Ability_Button;
        private System.Windows.Forms.Button Ultimate_Ability_Button;
        private System.Windows.Forms.TextBox InfoBox;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Display = new System.Windows.Forms.TextBox();
            this.PartyDisplay = new System.Windows.Forms.TextBox();
            this.TileSelector = new System.Windows.Forms.ComboBox();
            this.Accept_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Basic_Attack_Button = new System.Windows.Forms.Button();
            this.Basic_Ability_Button = new System.Windows.Forms.Button();
            this.Ultimate_Ability_Button = new System.Windows.Forms.Button();
            this.InfoBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Display
            // 
            this.Display.Location = new System.Drawing.Point(12, 12);
            this.Display.Multiline = true;
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(183, 128);
            this.Display.TabIndex = 0;
            //this.Display.TextChanged += new System.EventHandler(this.Display_TextChanged);
            // 
            // PartyDisplay
            // 
            this.PartyDisplay.Location = new System.Drawing.Point(205, 12);
            this.PartyDisplay.Multiline = true;
            this.PartyDisplay.Name = "PartyDisplay";
            this.PartyDisplay.Size = new System.Drawing.Size(183, 128);
            this.PartyDisplay.TabIndex = 11;
            // 
            // TileSelector
            // 
            this.TileSelector.FormattingEnabled = true;
            this.TileSelector.Location = new System.Drawing.Point(12, 179);
            this.TileSelector.Name = "TileSelector";
            this.TileSelector.Size = new System.Drawing.Size(375, 21);
            this.TileSelector.TabIndex = 8;
            //this.TileSelector.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Accept_Button
            // 
            this.Accept_Button.Location = new System.Drawing.Point(13, 273);
            this.Accept_Button.Name = "Accept_Button";
            this.Accept_Button.Size = new System.Drawing.Size(182, 36);
            this.Accept_Button.TabIndex = 9;
            this.Accept_Button.Text = "Accept";
            this.Accept_Button.UseVisualStyleBackColor = true;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(201, 273);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(187, 36);
            this.Cancel_Button.TabIndex = 10;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // Basic_Attack_Button
            // 
            this.Basic_Attack_Button.Location = new System.Drawing.Point(35, 206);
            this.Basic_Attack_Button.Name = "Basic_Attack_Button";
            this.Basic_Attack_Button.Size = new System.Drawing.Size(104, 61);
            this.Basic_Attack_Button.TabIndex = 12;
            this.Basic_Attack_Button.Text = "Basic Attack";
            this.Basic_Attack_Button.UseVisualStyleBackColor = true;
            //this.Basic_Attack_Button.Click += new System.EventHandler(this.button3_Click);
            // 
            // Basic_Ability_Button
            // 
            this.Basic_Ability_Button.Location = new System.Drawing.Point(145, 206);
            this.Basic_Ability_Button.Name = "Basic_Ability_Button";
            this.Basic_Ability_Button.Size = new System.Drawing.Size(104, 61);
            this.Basic_Ability_Button.TabIndex = 13;
            this.Basic_Ability_Button.Text = "Basic Ability";
            this.Basic_Ability_Button.UseVisualStyleBackColor = true;
            // 
            // Ultimate_Ability_Button
            // 
            this.Ultimate_Ability_Button.Location = new System.Drawing.Point(255, 206);
            this.Ultimate_Ability_Button.Name = "Ultimate_Ability_Button";
            this.Ultimate_Ability_Button.Size = new System.Drawing.Size(104, 61);
            this.Ultimate_Ability_Button.TabIndex = 14;
            this.Ultimate_Ability_Button.Text = "Ultimate Ability";
            this.Ultimate_Ability_Button.UseVisualStyleBackColor = true;
            // 
            // InfoBox
            // 
            this.InfoBox.Location = new System.Drawing.Point(13, 153);
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.Size = new System.Drawing.Size(374, 20);
            this.InfoBox.TabIndex = 15;
            //this.InfoBox.TextChanged += new System.EventHandler(null);
            // 
            // ControllerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 321);
            this.Controls.Add(this.InfoBox);
            this.Controls.Add(this.Ultimate_Ability_Button);
            this.Controls.Add(this.Basic_Ability_Button);
            this.Controls.Add(this.Basic_Attack_Button);
            this.Controls.Add(this.PartyDisplay);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Accept_Button);
            this.Controls.Add(this.TileSelector);
            this.Controls.Add(this.Display);
            this.Name = "ControllerGUI";
            this.Text = "ControllerGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

    }
}