using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Campos
        private double numero;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="numero">Numero a asignar.</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="strNumero">Numero a asignar en formato string.</param>
        public Numero(string numero)
        {
            this.numero = ValidarNumero(numero);
        }
        #endregion

        #region Propiedades
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Valida que la la cadena recibida contenga caracteres numericos.
        /// </summary>
        /// <param name="strNumero">Cadena a validar</param>
        /// <returns>Retorna el valor de ser posible o 0 en caso contrario</returns>
        private static double ValidarNumero(string strNumero)
        {
            double retorno;
            bool isNum = double.TryParse(strNumero, out retorno);
            if (isNum == true)
                return retorno;
            else
                return 0;
        }

        /// <summary>
        /// Convierte una cadena de caracteres binarios en un string decimal.
        /// </summary>
        /// <param name="binario">Dato en binario a corvertir</param>
        /// <returns>Cadena con el resultado decimal, o "valor invalido" si falla.</returns>
        public string BinarioADecimal(string binario)
        {
            int numero = 0, x, y;
            bool v = true;
            for (x = binario.Length - 1, y = 0; x >= 0; x--, y++)
            {
                if (binario[x] == '0' || binario[x] == '1')
                {
                    numero += (int)(int.Parse(binario[x].ToString()) * Math.Pow(2, y));
                }
                else
                {
                    v = false;
                    break;
                }
            }
            if (v)
                return numero.ToString();
            else
                return "Valor invalido";
        }

        /// <summary>
        ///  Método que convierte un número Decimal en un binario ASCII.
        /// </summary>
        /// <param name="numero">Numero a convertir.</param>
        /// <returns></returns>
        public string DecimalABinario(double numero)
        {
            string binario = "";
            int entero = (int)numero;
            while (entero >= 2)
            {
                binario = (entero % 2).ToString() + binario;
                entero = (int)entero / 2;
            }
            return entero.ToString() + binario;
        }

        /// <summary>
        /// Método que convierte un número Decimal en un binario ASCII
        /// </summary>
        /// <param name="numero">Numero a convertir.</param>
        /// <returns>Valor binario ASCII resultado de la conversion.</returns>
        public string DecimalABinario(string numero)
        {
            string error = "Valor invalido";
            double retorno = 0;
            if (Double.TryParse(numero, out retorno))
                return DecimalABinario(retorno);
            else
                return error;
        }

        #endregion

        #region Sobrecarga

        /// <summary>
        /// Sobrecarga de oprador +.
        /// </summary>
        /// <param name="n1">Dato de tipo Numero</param>
        /// <param name="n2">Dato de tipo Numero</param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga de oprador -.
        /// </summary>
        /// <param name="n1">Dato de tipo Numero</param>
        /// <param name="n2">Dato de tipo Numero</param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga de oprador *.
        /// </summary>
        /// <param name="n1">Dato de tipo Numero</param>
        /// <param name="n2">Dato de tipo Numero</param>
        /// <returns>Resultado de operacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador /
        /// </summary>
        /// <param name="n1">Dato de tipo Numero</param>
        /// <param name="n2">Dato de tipo Numero</param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = 0;
            if (n2.numero != 0)
                retorno = n1.numero / n2.numero;
            return retorno;
        }
        #endregion
    }
}
