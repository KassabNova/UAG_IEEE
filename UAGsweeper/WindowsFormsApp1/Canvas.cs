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
            AddCeldas();
        }

        private void InitializeComponent()
        {
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btn_reinicio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(6, 48);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(201, 205);
            this.pnlButtons.TabIndex = 0;
            // 
            // btn_reinicio
            // 
            this.btn_reinicio.Location = new System.Drawing.Point(92, 12);
            this.btn_reinicio.Name = "btn_reinicio";
            this.btn_reinicio.Size = new System.Drawing.Size(30, 30);
            this.btn_reinicio.TabIndex = 1;
            this.btn_reinicio.Text = "=)";
            this.btn_reinicio.UseVisualStyleBackColor = true;
            this.btn_reinicio.Click += new System.EventHandler(this.button1_Click);
            // 
            // Canvas
            // 
            this.ClientSize = new System.Drawing.Size(213, 265);
            this.Controls.Add(this.btn_reinicio);
            this.Controls.Add(this.pnlButtons);
            this.Name = "Canvas";
            this.ResumeLayout(false);

        }

    

        private void AddCeldas()
        {
            int xPos = 0;
            int yPos = 0;
            int row;
            int col;
           
            // Declare and assign number of buttons 
            System.Windows.Forms.Button[,]btnArray = new System.Windows.Forms.Button[10,10];
            // Create Buttons: 
            for ( row = 0; row < 10; row++)
            {   for(col= 0; col<10;col++)
                // Initialize one variable 
                btnArray[row,col] = new System.Windows.Forms.Button();
            }
          
            for ( row = 0;row< 10;row++)
            {
                for (col = 0; col < 10; col++)
                {
                    
                    // btnArray[row,col].Tag = row + 1; // Tag of button 
                    btnArray[row,col].Width = 20; // Width of button 
                    btnArray[row,col].Height = 20; // Height of button 

                    // Location of button: 
                    btnArray[row,col].Left = xPos;
                    btnArray[row,col].Top = yPos;

                    // Add buttons to a Panel: 
                    pnlButtons.Controls.Add(btnArray[row,col]); // Let panel hold the Buttons 
                    xPos = xPos + btnArray[row,col].Width; // Left of next button 

                    //Creating 
                    btnArray[row,col].Click += new System.EventHandler(ClickButton);
                 
                }
                xPos = 0;
                yPos = yPos + btnArray[row, xPos].Height;
            }
        }

        // Result of (Click Button) event, get the text of button 
        public void ClickButton(Object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Text = "@";
            if (btn.Text == "@")
            { 
            MessageBox.Show("You clicked a bomb! Allahu-Akbar!!!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
