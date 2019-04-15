using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public LaCalculadora()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento que cierra la aplicacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que convierte el el resultado a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnABinario_Click(object sender, EventArgs e)
        {
            Numero numaux = new Numero();
            string auxiliar = lblResultado.Text;
            if (auxiliar != "" && auxiliar != "Resultado")
            {
                lblResultado.Text = numaux.DecimalABinario(auxiliar);
            }
            else
                lblResultado.Text = "Valor invalido";
        }

        /// <summary>
        /// Evento que convierte el el resultado a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnADecimal_Click(object sender, EventArgs e)
        {
            Numero numaux = new Numero();
            string auxiliar = lblResultado.Text;
            if (auxiliar != "" && auxiliar != "RESULTADO")
            {
                lblResultado.Text = numaux.BinarioADecimal(auxiliar);
            }
            else
                lblResultado.Text = "Valor invalido";
        }
        /// <summary>
        /// Metodo que limpia los TextBox, el operador, y lblResultado.
        /// </summary>
        private void Limpiar()
        {
            textNumero1.Text = "";
            textNumero2.Text = "";
            comboOperador.SelectedItem = 0;
            lblResultado.Text = "RESULTADO";
        }

        /// <summary>
        /// Evento que llama al metodo Limpiar().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Metodo que verifica que los parametros sean distintos de null
        /// y llama al metodo operar de la clase calculadora
        /// </summary>
        /// <param name="numero1">primer parametro para la operacion</param>
        /// <param name="numero2">segundo operando para el calcul matematico</param>
        /// <param name="operador">tipo de operacion</param>
        /// <returns>Resultado de la operacion.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Calculadora auxCalcu = new Calculadora();
            double retorno = 0;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            retorno = auxCalcu.Operar(num1, num2, operador);
            return retorno;
        }

        /// <summary>
        /// Evento que realiza la operacion segun los datos ingresados mostrando el resultado en el labelText.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = textNumero1.Text;
            string numero2 = textNumero2.Text;
            int operador = comboOperador.SelectedIndex;
            string retorno = "";
            double resultado = 0, aux = 0;
            if (!(Object.ReferenceEquals(numero1, null)) && !(Object.ReferenceEquals(numero2, null)))
            {
                textNumero1.Text = (Double.TryParse(textNumero1.Text, out aux)) ? textNumero1.Text : "0";
                textNumero2.Text = (Double.TryParse(textNumero2.Text, out aux)) ? textNumero2.Text : "0";
                if (operador != -1)
                {
                    if (operador == 2 && (double.Parse(numero2) == 0))
                    {
                        retorno = "No se puede dividir por cero";
                        lblResultado.Text = retorno;
                    }
                    else
                    {
                        resultado = Operar(numero1, numero2, comboOperador.Items[operador].ToString());
                        lblResultado.Text = resultado.ToString();
                    }
                }                
            }
        }
    }
}
