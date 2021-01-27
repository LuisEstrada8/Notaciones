using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotacionesComple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Stack<String> operandos = new Stack<string>();
        private Stack<String> operadores = new Stack<string>();
        private Stack<String> stack_ptfx = new Stack<string>();
        private string[] operatorsAccepted = { "+", "-", "/", "*" };

        void proccessingEntry(string cadena)
        {
            this.prefijo.Text = this.toprefijo(cadena);
            this.subfijo.Text = this.toPostfijo(cadena);
        }


        string toprefijo(string cadena)
        {
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadena[i] == '(')
                {
                    operadores.Push(cadena[i].ToString());
                }
                else if (cadena[i] == ')')
                {
                    while (operadores.Count != 0 && operadores.Peek() != "(")
                    {
                        String op1 = operandos.Peek();
                        operandos.Pop();

                        String op2 = operandos.Peek();
                        operandos.Pop();

                        string op = operadores.Peek();
                        operadores.Pop();

                        String tmp = op + op2 + op1;
                        operandos.Push(tmp);
                    }
                    operadores.Pop();
                }
                else if (!this.operatorsAccepted.Contains(cadena[i].ToString()))
                {
                    operandos.Push(cadena[i] + "");
                }
                else
                {
                    while (operadores.Count != 0 && getOperatorPriority(cadena[i]) <= getOperatorPriority(operadores.Peek()[0]))
                    {

                        String op1 = operandos.Pop();
                        String op2 = operandos.Pop();

                        string op = operadores.Pop();

                        String tmp = op + op2 + op1;
                        operandos.Push(tmp);
                    }
                    operadores.Push(cadena[i].ToString());
                }
            }

            while (operadores.Count != 0)
            {
                String op1 = operandos.Peek();
                operandos.Pop();

                String op2 = operandos.Peek();
                operandos.Pop();

                string op = operadores.Peek();
                operadores.Pop();

                String tmp = op + op2 + op1;
                operandos.Push(tmp);
            }
            return this.rotateEntry(operandos.Peek());
        }

        string toPostfijo(string cadena)
        {
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadena[i] == '(')
                {
                    operadores.Push(cadena[i].ToString());
                }
                else if (cadena[i] == ')')
                {
                    while (operadores.Count != 0 && operadores.Peek() != "(")
                    {
                        String op1 = operandos.Peek();
                        operandos.Pop();

                        String op2 = operandos.Peek();
                        operandos.Pop();

                        string op = operadores.Peek();
                        operadores.Pop();

                        String tmp = op + op2 + op1;
                        operandos.Push(tmp);
                    }
                    operadores.Pop();
                }
                else if (!this.operatorsAccepted.Contains(cadena[i].ToString()))
                {
                    operandos.Push(cadena[i] + "");
                }
                else
                {
                    while (operadores.Count != 0 && getOperatorPriority(cadena[i]) <= getOperatorPriority(operadores.Peek()[0]))
                    {

                        String op1 = operandos.Pop();
                        String op2 = operandos.Pop();

                        string op = operadores.Pop();

                        String tmp = op + op2 + op1;
                        operandos.Push(tmp);
                    }
                    operadores.Push(cadena[i].ToString());
                }
            }

            while (operadores.Count != 0)
            {
                String op1 = operandos.Peek();
                operandos.Pop();

                String op2 = operandos.Peek();
                operandos.Pop();

                string op = operadores.Peek();
                operadores.Pop();

                String tmp = op + op2 + op1;
                operandos.Push(tmp);
            }
            return this.rotateEntry(operandos.Peek());
        }

        string rotateEntry(string entry)
        {
            char[] cadenaComoCaracteres = entry.ToCharArray();
            Array.Reverse(cadenaComoCaracteres);
            return new string(cadenaComoCaracteres);
        }

        

        int getOperatorPriority(char C)
        {
            if (C == '-' || C == '+')
                return 1;
            else if (C == '*' || C == '/')
                return 2;
            else
                return 0;
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuCustomLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            proccessingEntry(caja.Text);

            string cadena = caja.Text;
            normal.Text = cadena;
        }

        private void bunifuCustomLabel7_Click(object sender, EventArgs e)
        {

        }

        int Y = 0;
        int X = 0;

        int posY = 0;
        int posX = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {

                posX = e.X;
                posY = e.Y;
            }
            else
            {

                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);

            }
        }
    }
}
