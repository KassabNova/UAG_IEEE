using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Canvas : Form
    {
        public Canvas()
        {
            InitializeComponent();
            AddButtons();
        }

        private void InitializeComponent()
        {
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(12, 29);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(340, 50);
            this.pnlButtons.TabIndex = 0;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(355, 99);
            this.Controls.Add(this.pnlButtons);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

    

        private void AddButtons()
        {
            int xPos = 0;
            int yPos = 0;
            // Declare and assign number of buttons = 26 
            System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[26];
            // Create (26) Buttons: 
            for (int i = 0; i < 26; i++)
            {
                // Initialize one variable 
                btnArray[i] = new System.Windows.Forms.Button();
            }
            int n = 0;

            while (n < 26)
            {
                btnArray[n].Tag = n + 1; // Tag of button 
                btnArray[n].Width = 24; // Width of button 
                btnArray[n].Height = 20; // Height of button 
                if (n == 13) // Location of second line of buttons: 
                {
                    xPos = 0;
                    yPos = 20;
                }
                // Location of button: 
                btnArray[n].Left = xPos;
                btnArray[n].Top = yPos;
                // Add buttons to a Panel: 
                pnlButtons.Controls.Add(btnArray[n]); // Let panel hold the Buttons 
                xPos = xPos + btnArray[n].Width; // Left of next button 
                                                 // Write English Character: 
                btnArray[n].Text = ((char)(n + 65)).ToString();

            
                // the Event of click Button 
                btnArray[n].Click += new System.EventHandler(ClickButton);
                n++;
            }
            /*btnAddButton.Enabled = false;     // not need now to this button now 
            label1.Visible = true;*/
        }

        // Result of (Click Button) event, get the text of button 
        public void ClickButton(Object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            MessageBox.Show("You clicked character [" + btn.Text + "]");
        }
    }
}
