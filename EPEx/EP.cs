using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Threading;

namespace EP
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class EP : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button b00;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private Button[,] BL;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button bRand;
        private System.Windows.Forms.Button btnAnimate;
        private int[] table;
        private NumericUpDown nudSize;
        private Button btnResize;
        private int size = 3;

        public EP()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            // Draws the painel
            DrawPanel();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.b00 = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.bRand = new System.Windows.Forms.Button();
            this.btnAnimate = new System.Windows.Forms.Button();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.btnResize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            this.SuspendLayout();
            // 
            // b00
            // 
            this.b00.BackColor = System.Drawing.Color.White;
            this.b00.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b00.Location = new System.Drawing.Point(8, 8);
            this.b00.Name = "b00";
            this.b00.Size = new System.Drawing.Size(56, 56);
            this.b00.TabIndex = 2;
            this.b00.Text = "X";
            this.b00.UseVisualStyleBackColor = false;
            this.b00.Visible = false;
            this.b00.Click += new System.EventHandler(this.b00_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolve.Location = new System.Drawing.Point(56 * size + 20, 10);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(200, 40);
            this.btnSolve.TabIndex = 3;
            this.btnSolve.Text = "Solução";
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(10, Math.Max(56 * size + 20, 245));
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(56 * size + 210, 80 + 10 * size);
            this.txtResult.TabIndex = 4;
            // 
            // bRand
            // 
            this.bRand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRand.Location = new System.Drawing.Point(56 * size + 20, 60);
            this.bRand.Name = "bRand";
            this.bRand.Size = new System.Drawing.Size(200, 40);
            this.bRand.TabIndex = 5;
            this.bRand.Text = "Sortear";
            this.bRand.Click += new System.EventHandler(this.bRand_Click);
            //
            // btnAnimate
            this.btnAnimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnimate.Location = new System.Drawing.Point(56 * size + 20, 110);
            this.btnAnimate.Name = "btnAnimate";
            this.btnAnimate.Size = new System.Drawing.Size(200, 40);
            this.btnAnimate.TabIndex = 5;
            this.btnAnimate.Text = "Animar";
            this.btnAnimate.Click += new System.EventHandler(this.btnAnimate_Click);
            //
            // 
            // nudSize
            // 
            this.nudSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSize.Location = new System.Drawing.Point(56 * size + 20, 160);
            this.nudSize.Maximum = 9;
            this.nudSize.Minimum = 3;
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(200, 40);
            this.nudSize.TabIndex = 6;
            this.nudSize.Value = size;
            // 
            // btnResize
            // 
            this.btnResize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResize.Location = new System.Drawing.Point(56 * size + 20, 195);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(200, 40);
            this.btnResize.TabIndex = 7;
            this.btnResize.Text = "Redimensionar";
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // EP
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(56 * size + 230, 90 + 10 * size + Math.Max(56 * size + 20, 245));
            this.Controls.Add(this.btnResize);
            this.Controls.Add(this.btnAnimate);
            this.Controls.Add(this.nudSize);
            this.Controls.Add(this.bRand);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.b00);
            this.Name = "EP";
            this.Text = "Quebra Cabeça";
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new EP());
        }

        /// <summary>
        /// Draws the game panel
        /// </summary>
        private void DrawPanel()
        {
            table = new int[size * size];
            for (int i = 0; i < size * size; i++)
            {
                table[i] = i;
            }
            //table = new int[] { 4, 2, 8, 0, 7, 3, 5, 6, 1 };

            // Creating the labels
            BL = new Button[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Button B = new Button();
                    B.Parent = b00.Parent;
                    B.Font = b00.Font;
                    B.Size = b00.Size;
                    B.Left = i * 56 + 10;
                    B.Top = j * 56 + 10;
                    B.BackColor = b00.BackColor;
                    B.Text = (table[j * size + i] != 0 ? table[j * size + i].ToString() : "");
                    B.Visible = true;
                    B.Click += new System.EventHandler(this.b00_Click);
                    BL[i, j] = B;
                }
            }

        }


        /// <summary>
        /// Click template for all buttons 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b00_Click(object sender, System.EventArgs e)
        {
            Button b = sender as Button;
            int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // search for button
                    if (BL[i, j] == b)
                    {
                        // Move to clear position 
                        x2 = x1 = i;
                        y2 = y1 = j;
                        if ((i > 0) && (BL[i - 1, j].Text == ""))
                            x2--;
                        if ((i < size - 1) && (BL[i + 1, j].Text == ""))
                            x2++;
                        if ((j > 0) && (BL[i, j - 1].Text == ""))
                            y2--;
                        if ((j < size - 1) && (BL[i, j + 1].Text == ""))
                            y2++;
                    }
                }
            }
            // Chances clear with clicked
            string temp = BL[x1, y1].Text;
            BL[x1, y1].Text = BL[x2, y2].Text;
            BL[x2, y2].Text = temp;
        }


        /// <summary>
        /// Solves the puzzle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSolve_Click(object sender, System.EventArgs e)
        {
            // Clears memo
            txtResult.Text = "";

            // First, update table structure with buttons configuration
            int k = 0;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    table[k++] = (BL[j, i].Text == "" ? 0 : Convert.ToInt32(BL[j, i].Text));

            // Now the agent looks for the parameter target
            int[] solution = new int[size * size];
            for (int i = 0; i < size * size; i++)
            {
                solution[i] = i;
            }
            EightPuzzle ComputerAgent = new EightPuzzle(table, solution);

            // Writes the solution to the tet box
            int[] res = ComputerAgent.GetSolution();
            if (res == null)
                txtResult.Text += "Tamanho limite de busca alcançado.";
            else
            {
                foreach (int i in res)
                    txtResult.Text += i.ToString() + ",";
                txtResult.Text += "#";
                txtResult.Text = txtResult.Text.Replace(",#", "");
            }
        }

        private int FindPosition(int value)
        {
            for (int i = 0; i < size * size; i++)
            {
                if (table[i] == value)
                    return i;
            }
            return -1;
        }

        List<int> GetNeighbours(int index)
        {
            List<int> neighbours = new List<int>();
            if (index - size > 0)
                neighbours.Add(index - size);
            if (index + size < size * size)
                neighbours.Add(index + size);
            if (index - 1 >= 0 && index / size == (index - 1) / size)
                neighbours.Add(index - 1);
            if (index + 1 < size * size && index / size == (index + 1) / size)
                neighbours.Add(index + 1);
            return neighbours;
        }

        /// <summary>
        /// Animate the solution
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnimate_Click(object sender, System.EventArgs e)
        {
            btnSolve_Click(sender, e);
            string result = txtResult.Text;
            string[] steps = result.Split(',');
            int x2, x1, y2, y1;
            int timeInterval = (int)Math.Ceiling((double)Math.Min(steps.Length * 1000, 10000) / (double)steps.Length);
            foreach (string step in steps)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (BL[i, j].Text == step.Trim())
                        {
                            x2 = x1 = i;
                            y2 = y1 = j;
                            if ((i > 0) && (BL[i - 1, j].Text == ""))
                                x2--;
                            if ((i < size - 1) && (BL[i + 1, j].Text == ""))
                                x2++;
                            if ((j > 0) && (BL[i, j - 1].Text == ""))
                                y2--;
                            if ((j < size - 1) && (BL[i, j + 1].Text == ""))
                                y2++;
                            string temp = BL[x1, y1].Text;
                            BL[x1, y1].Text = BL[x2, y2].Text;
                            BL[x2, y2].Text = temp;
                            i = j = size;
                        }
                    }
                }
                this.Update();
                Thread.Sleep(timeInterval);
            }
        }

        /// <summary>
        /// Random configure the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bRand_Click(object sender, System.EventArgs e)
        {
            int current = FindPosition(0);
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 1000 * size * size; i++)
            {
                List<int> neighbours = GetNeighbours(current);
                int randomNeighbour = neighbours[r.Next(neighbours.Count)];
                int temp = table[randomNeighbour];
                table[randomNeighbour] = table[current];
                table[current] = temp;
                current = randomNeighbour;
            }
            int k = 0;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    BL[j, i].Text = (table[k] == 0 ? "" : table[k].ToString());
                    k++;
                }

        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            size = Convert.ToInt32(nudSize.Value);
            this.Controls.Clear();
            InitializeComponent();
            DrawPanel();
        }
    }
}
