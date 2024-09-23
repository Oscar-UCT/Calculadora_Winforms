using System;
using System.Windows.Forms;

namespace Calculadora_ahorasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        decimal numeroPrimario = 0;
        decimal numeroSecundario = 0;

        // numeroPrimarioAlfaNum innecesario por que numeroPrimario se basa sobre lo ingresado en la casilla primaria
        string numeroSecundarioAlfaNum = "";

        string operadorSeleccionado = "";

        bool esperandoNumeroSecundario;

        private void resultado_TextChanged(object sender, EventArgs e)
        {

        }



        private void cero_btn_Click(object sender, EventArgs e)
        {
            AgregarNumero("0");
        }

        private void uno_btn_Click(object sender, EventArgs e)
        {
            AgregarNumero("1");
        }

        private void dos_btn_Click(object sender, EventArgs e)
        {
            AgregarNumero("2");
        }

        private void tres_btn_Click(object sender, EventArgs e)
        {
            AgregarNumero("3");
        }

        private void cuatro_btn_Click(object sender, EventArgs e)
        {
            AgregarNumero("4");
        }

        private void cinco_btn_Click(object sender, EventArgs e)
        {
            AgregarNumero("5");
        }

        private void seis_btn_Click(object sender, EventArgs e)
        {
            AgregarNumero("6");
        }

        private void siete_btn_Click(object sender, EventArgs e)
        {
            AgregarNumero("7");
        }

        private void ocho_btn_Click(object sender, EventArgs e)
        {
            AgregarNumero("8");
        }

        private void nueve_btn_Click(object sender, EventArgs e)
        {
            AgregarNumero("9");
        }




        private void suma_btn_Click(object sender, EventArgs e)
        {
            Operacion("+");
        }

        private void resta_btn_Click(object sender, EventArgs e)
        {
            Operacion("-");
        }

        private void division_btn_Click(object sender, EventArgs e)
        {
            Operacion("/");
        }

        private void multiplicar_btn_Click(object sender, EventArgs e)
        {
            Operacion("*");
        }




        private void resultado_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (esperandoNumeroSecundario) // significaria que está en el último tramo del proceso -> valido para seguir
                {
                    numeroSecundario = decimal.Parse(numeroSecundarioAlfaNum);
                    switch (operadorSeleccionado)
                    {
                        case "+":
                            salidaSecundaria.Text = $"{numeroPrimario} + {numeroSecundario}";

                            numeroPrimario += numeroSecundario;

                            salidaPrimaria.Text = numeroPrimario.ToString();
                            break;

                        case "-":
                            salidaSecundaria.Text = $"{numeroPrimario} - {numeroSecundario}";

                            numeroPrimario -= numeroSecundario;

                            salidaPrimaria.Text = numeroPrimario.ToString();
                            break;

                        case "/":
                            if (numeroSecundario != 0)
                            {
                                salidaSecundaria.Text = $"{numeroPrimario} / {numeroSecundario}";

                                numeroPrimario /= numeroSecundario;

                                salidaPrimaria.Text = numeroPrimario.ToString();
                            }
                            else
                            {
                                salidaSecundaria.Text = $"Número no definido.";
                            }
                            break;

                        case "*":
                            salidaSecundaria.Text = $"{numeroPrimario} * {numeroSecundario}";

                            numeroPrimario *= numeroSecundario;

                            salidaPrimaria.Text = numeroPrimario.ToString();
                            break;
                    }
                }
            }
            catch (OverflowException)
            {
            }
        }

        private void borrar_Click(object sender, EventArgs e)
        {
            salidaPrimaria.Text = "0";

            salidaSecundaria.Text = "";

            operadorSeleccionado = "";

            esperandoNumeroSecundario = false;

            numeroSecundarioAlfaNum = "";
        }

        private void valorPrevio_TextChanged(object sender, EventArgs e)
        {

        }


        private void Operacion(string operador)
        {
            try
            {
                if (salidaPrimaria.Text != "0")
                {
                    numeroPrimario = decimal.Parse(salidaPrimaria.Text);

                    salidaSecundaria.Text = salidaPrimaria.Text;

                    salidaPrimaria.Text = "0";

                    esperandoNumeroSecundario = true;

                    operadorSeleccionado = operador;
                }
            }
            catch (OverflowException) { }
        }

        private void AgregarNumero(string digito)
        {
            try
            {
                if (esperandoNumeroSecundario)
                {
                    if (salidaPrimaria.Text == "0")
                    {
                        numeroSecundarioAlfaNum = digito;
                        salidaPrimaria.Text = digito;
                    }
                    else
                    {
                    numeroSecundarioAlfaNum += digito;

                    salidaPrimaria.Text += digito;

                    }
                }
                else if (salidaPrimaria.Text == "0")
                {
                    salidaPrimaria.Text = digito;
                }
                else
                {
                    salidaPrimaria.Text += digito;
                }
            }
            catch (OverflowException)
            {
            }
        }
    }
}
