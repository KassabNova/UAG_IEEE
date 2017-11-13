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
    {   //Class variables
        int xPos = 0;
        int yPos = 0;
        int maxLimit = 9;
        int minLimit = 0;


        Random rnd = new Random();//Random object for mines
        System.Windows.Forms.Button[,] btnArray = new System.Windows.Forms.Button[10, 10];

        //Form names canvas
        public Canvas()
        {
            InitializeComponent();
            AddCeldas();
        }

        //Initialize form components
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Canvas));
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btn_reinicio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(6, 48);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(212, 215);
            this.pnlButtons.TabIndex = 0;
            // 
            // btn_reinicio
            // 
            this.btn_reinicio.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_reinicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_reinicio.Image = ((System.Drawing.Image)(resources.GetObject("btn_reinicio.Image")));
            this.btn_reinicio.Location = new System.Drawing.Point(96, 12);
            this.btn_reinicio.Name = "btn_reinicio";
            this.btn_reinicio.Size = new System.Drawing.Size(30, 30);
            this.btn_reinicio.TabIndex = 1;
            this.btn_reinicio.UseVisualStyleBackColor = false;
            this.btn_reinicio.Click += new System.EventHandler(this.button1_Click);
            // 
            // Canvas
            // 
            this.ClientSize = new System.Drawing.Size(222, 265);
            this.Controls.Add(this.btn_reinicio);
            this.Controls.Add(this.pnlButtons);
            this.Name = "Canvas";
            this.ResumeLayout(false);

        }
        
        //Game starts
        public void AddCeldas()
        {
            int row;
            int col;
            //Reset X and Y Pos
            xPos = 0;
            yPos = 0;
            // Declare and assign number of buttons 

            // Create Buttons: 
            for (row = 0; row < 10; row++)
            { for (col = 0; col < 10; col++)
                    // Initialize one variable 
                    btnArray[row, col] = new System.Windows.Forms.Button();
            }

            //Draw to screen the buttons
            for (row = 0; row < 10; row++)
            {
                for (col = 0; col < 10; col++)
                {
                    //Sets the button properties
                    btnArray[row, col].Tag = 0; // Tag of button 
                    btnArray[row, col].Name = row.ToString() + "," + col.ToString(); // Tag of button 
                    btnArray[row, col].Width = 20; // Width of button 
                    btnArray[row, col].Height = 20; // Height of button 
                    btnArray[row, col].Enabled = true;
                    btnArray[row, col].BackColor = SystemColors.ButtonHighlight; // Color of button 

                    // Adding mines with a Random object
                    int minaRand = rnd.Next(0, 100);
                    if (minaRand < 15)
                    {
                        btnArray[row, col].Tag = -1; // Tag of button 
                        btnArray[row, col].Text = "_";
                        btnArray[row, col].ForeColor = SystemColors.ActiveCaptionText;
                        //btnArray[row, col].Image = Image.FromFile("C:/Users/CKassab/source/repos/UAG_IEEE/UAGsweeper/mina.jpg");

                    }
                    btnArray[row, col].Left = xPos;
                    btnArray[row, col].Top = yPos;

                    // Add buttons to a Panel: 
                    pnlButtons.Controls.Add(btnArray[row, col]); // Let panel hold the Buttons 
                    xPos = xPos + btnArray[row, col].Width + 1; // Left of next button 


                    //Creating  event Click handler
                    btnArray[row, col].Click += new System.EventHandler(ClickReveal);

                }
                xPos = 0;
                yPos = yPos + btnArray[row, xPos].Height + 1;
            }
        }

        // Result of (Click Button) event, then does the following instructions
        public void ClickReveal(Object sender, System.EventArgs e)
        {

            Button btn = (Button)sender;
            btn.Enabled = false;
            btn.BackColor = SystemColors.AppWorkspace;
            //if clicked on a mine
            if (btn.Text == "_")
            {
                //clickedMine method
                clickMina(btn);
            }
            else
            {

                string[] buttonLocation = btn.Name.Split(',');
                int row = Int32.Parse(buttonLocation[0]);
                int col = Int32.Parse(buttonLocation[1]);
                CountMina(row, col);
            }


        }

        //Reset  Method on Smiley Button
        private void button1_Click(object sender, EventArgs e)
        {
            //Call to Reset Method
            Reset();
        }

        //Clicked Mine method
        private void clickMina(Object sender)
        {
            int row;
            int col;
            Button btn = (Button)sender;
            btn.Image = Image.FromFile("C:/Users/CKassab/source/repos/UAG_IEEE/UAGsweeper/mina.jpg");
            btn_reinicio.Image = Image.FromFile("C:/Users/CKassab/source/repos/UAG_IEEE/UAGsweeper/death.jpg");
            MessageBox.Show("You clicked a bomb! Allahu-Akbar!!!!");
            //Disables all buttons except mines
            for (row = 0; row < 10; row++)
            {
                for (col = 0; col < 10; col++)
                {

                    if (btnArray[row, col].Text == "_")
                    {
                        btnArray[row, col].Enabled = true;
                        btnArray[row, col].BackColor = SystemColors.ButtonHighlight;

                        btnArray[row, col].Image = Image.FromFile("C:/Users/CKassab/source/repos/UAG_IEEE/UAGsweeper/mina.jpg");
                    }
                    else
                    {
                        btnArray[row, col].Enabled = false;
                        btnArray[row, col].BackColor = SystemColors.AppWorkspace;
                        btnArray[row, col].ForeColor = SystemColors.AppWorkspace;

                    }

                }
            }
        }

        //Reset method
        private void Reset()
        {
            int row;
            int col;
            for (row = 0; row < 10; row++)
            {
                for (col = 0; col < 10; col++)
                {
                    //resets the button properties
                    btnArray[row, col].Enabled = true;
                    btnArray[row, col].Image = null;
                    btnArray[row, col].Text = "";
                    btnArray[row, col].ForeColor = SystemColors.AppWorkspace;
                    btnArray[row, col].BackColor = SystemColors.ButtonHighlight; // Color of button 

                    // Adding mines with a Random object
                    int minaRand = rnd.Next(0, 100);
                    if (minaRand < 22)
                    {
                        btnArray[row, col].Tag = -1; // Tag of button 
                        btnArray[row, col].Text = "_";
                        btnArray[row, col].ForeColor = SystemColors.ActiveCaptionText;

                    }
                }
            }
            btn_reinicio.Image = Image.FromFile("C:/Users/CKassab/source/repos/UAG_IEEE/UAGsweeper/smile.jpg");
        }

        //Mine count method. Inputs the
        private void CountMina(int cmRowVal, int cmColVal)
        {
            int cmRow = cmRowVal;
            int cmCol = cmColVal;

            int cuentaMinas = 0;
            

            if ((cmRow - 1) >= minLimit && (cmCol + 1) <= maxLimit) //Punto derecho arriba
            {
                if (btnArray[cmRow - 1, cmCol + 1].Text == "_")
                {
                    cuentaMinas += 1;
                }
            }
            if ((cmCol + 1) <= maxLimit) //Punto derecho
            {
                if (btnArray[cmRow, cmCol + 1].Text == "_")
                {
                    cuentaMinas += 1;
                }
            }
            if ((cmRow + 1) <= maxLimit && (cmCol + 1) <= maxLimit) //PuntoDerechoAbajo
            {
                if (btnArray[cmRow + 1, cmCol + 1].Text == "_")
                {
                    cuentaMinas += 1;
                }
            }
            if ((cmRow - 1) >= minLimit && (cmCol - 1) >= minLimit) //PuntoIzquierdoArriba
            {
                if (btnArray[cmRow - 1, cmCol - 1].Text == "_")
                {
                    cuentaMinas += 1;
                }
            }
            if ((cmCol - 1) >= minLimit) //PuntoIzquierdo
            {
                if (btnArray[cmRow, cmCol - 1].Text == "_")
                {
                    cuentaMinas += 1;
                }
            }
            if ((cmRow + 1) <= maxLimit && (cmCol - 1) >= minLimit) //PuntoIzquierdoAbajo
            {
                if (btnArray[cmRow + 1, cmCol - 1].Text == "_")
                {
                    cuentaMinas += 1;
                }
            }
            if ((cmRow - 1) >= minLimit) //PuntoArriba
            {
                if (btnArray[cmRow - 1, cmCol].Text == "_")
                {
                    cuentaMinas += 1;
                }
            }
            if ((cmRow + 1) <= maxLimit) //PuntoAbajo
            {
                if (btnArray[cmRow + 1, cmCol].Text == "_")
                {
                    cuentaMinas += 1;
                }
            }
            
            //If mine count was 0, then it calls FloodFill method
            if (cuentaMinas == 0) 
            {
                FloodFill(cmRow, cmCol);
            }
            else
            {
                btnArray[cmRow, cmCol].Text = cuentaMinas.ToString();
                btnArray[cmRow, cmCol].ForeColor = SystemColors.ActiveCaptionText;
            }

        }

        //Flood fill method for no mines in neighbour count
        public void FloodFill(int cmRow, int cmCol)
        {
            //Punto derecho arriba
            if ((cmRow - 1) >= minLimit && (cmCol + 1) <= maxLimit) 
            {
                if (btnArray[cmRow - 1, cmCol + 1].Enabled == true)
                {
                    btnArray[cmRow - 1, cmCol + 1].Enabled = false;
                    btnArray[cmRow - 1, cmCol + 1].ForeColor = SystemColors.ActiveCaptionText;
                    btnArray[cmRow - 1, cmCol + 1].BackColor = SystemColors.AppWorkspace;

                    CountMina(cmRow - 1, cmCol + 1);
                }
            }
            
            //Punto derecho
            if ((cmCol + 1) <= maxLimit) 
            {
                if (btnArray[cmRow, cmCol + 1].Enabled == true)
                {
                    btnArray[cmRow, cmCol + 1].Enabled = false;
                    btnArray[cmRow, cmCol + 1].ForeColor = SystemColors.ActiveCaptionText;
                    btnArray[cmRow, cmCol + 1].BackColor = SystemColors.AppWorkspace;

                    CountMina(cmRow, cmCol + 1);
                }
            }
            
            //PuntoDerechoAbajo
            if ((cmRow + 1) <= maxLimit && (cmCol + 1) <= maxLimit)
            {
                if (btnArray[cmRow + 1, cmCol + 1].Enabled == true)
                {
                    btnArray[cmRow + 1, cmCol + 1].Enabled = false;
                    btnArray[cmRow + 1, cmCol + 1].ForeColor = SystemColors.ActiveCaptionText;
                    btnArray[cmRow + 1, cmCol + 1].BackColor = SystemColors.AppWorkspace;

                    CountMina(cmRow + 1, cmCol + 1);
                }
            }
          
            //PuntoAbajo
            if ((cmRow + 1) <= maxLimit)
            {
                if (btnArray[cmRow + 1, cmCol].Enabled == true)
                {
                    btnArray[cmRow + 1, cmCol].Enabled = false;
                    btnArray[cmRow + 1, cmCol].ForeColor = SystemColors.ActiveCaptionText;
                    btnArray[cmRow + 1, cmCol].BackColor = SystemColors.AppWorkspace;

                    CountMina(cmRow + 1, cmCol);
                }
            }
           
            //PuntoIzquierdoAbajo
            if ((cmRow + 1) <= maxLimit && (cmCol - 1) >= minLimit)
            {
                if (btnArray[cmRow + 1, cmCol - 1].Enabled == true)
                {
                    btnArray[cmRow + 1, cmCol - 1].Enabled = false;
                    btnArray[cmRow + 1, cmCol - 1].ForeColor = SystemColors.ActiveCaptionText;
                    btnArray[cmRow + 1, cmCol - 1].BackColor = SystemColors.AppWorkspace;

                    CountMina(cmRow + 1, cmCol - 1);
                }
            }
            
            //PuntoIzquierdo
            if ((cmCol - 1) >= minLimit)
            {
                if (btnArray[cmRow, cmCol - 1].Enabled == true)
                {
                    btnArray[cmRow, cmCol - 1].Enabled = false;
                    btnArray[cmRow, cmCol - 1].ForeColor = SystemColors.ActiveCaptionText;
                    btnArray[cmRow, cmCol - 1].BackColor = SystemColors.AppWorkspace;

                    CountMina(cmRow, cmCol - 1);
                }
            }
           
            //PuntoIzquierdoArriba
            if ((cmRow - 1) >= minLimit && (cmCol - 1) >= minLimit)
            {
                if (btnArray[cmRow - 1, cmCol - 1].Enabled == true)
                {
                    btnArray[cmRow - 1, cmCol - 1].Enabled = false;
                    btnArray[cmRow - 1, cmCol - 1].ForeColor = SystemColors.ActiveCaptionText;
                    btnArray[cmRow - 1, cmCol - 1].BackColor = SystemColors.AppWorkspace;

                    CountMina(cmRow - 1, cmCol - 1);
                }
            }
            
            //PuntoArriba
            if ((cmRow - 1) >= minLimit)
            {
                if (btnArray[cmRow - 1, cmCol].Enabled == true)
                {
                    btnArray[cmRow - 1, cmCol].Enabled = false;
                    btnArray[cmRow - 1, cmCol].ForeColor = SystemColors.ActiveCaptionText;
                    btnArray[cmRow - 1, cmCol].BackColor = SystemColors.AppWorkspace;

                    CountMina(cmRow - 1, cmCol);
                }
            }
            
        }
        
    }
    
}
