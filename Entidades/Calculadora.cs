using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Metodo que valida operadores
        /// </summary>
        /// <param name="operador">string a validar</param>
        /// <returns>operador validado por defecto retorna +</returns>
        private string ValidarOperador(string operador)
        {
            if (operador != "-" && operador != "*" && operador != "/")
            {
                operador = "+";
            }
            return operador;
        }

        /// <summary>
        /// Metodo que realiza la operacion aritmetica.
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Operando</param>
        /// <returns>Resultado de la operacion</returns>
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            operador = this.ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    retorno = num1 + num2;
                    break;
                case "-":
                    retorno = num1 - num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "/":
                    retorno = num1 / num2;                    
                    break;
            }
            return retorno;
        }
        #endregion
    }
}
