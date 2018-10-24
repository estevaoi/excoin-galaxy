using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExCoinGalaxy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExCoinGalaxy.Controllers
{
    [Route("api/[controller]")]
    public class ConversorController : Controller
    {
        private static string produtoR;
        private string prodR;
        private static int[] num;

        public string Romano { get; set; }

        [HttpPost]
        [Route("post")]
        public JsonResult postFunction([FromBody] ConversorViewModel nameModel)
        {                       
            var entrada = nameModel;
            var frase = entrada.Atributo;
            var texto0 = frase.ToLower();
            var texto = texto0.TrimEnd();

            var statusS = "alert-danger";
            var valorR = "I have no idea what you are talking about";

            /*
             * Tratar quanto custa um produto
             */
            if (texto.Contains("how much is"))
            {
                var tx1 = texto.Replace("how much is", "");
                var produtos = tx1.Replace("?", "");

                string[] prods = produtos.TrimStart(' ').Split(' ');

                foreach (string prod in prods)
                {
                    string contents = GetRoman(prod);
                    prodR += contents;
                }

                string numDecimal = postFunction(prodR);

                statusS = "alert-success";
                valorR = produtos + " is: " + numDecimal + " (" + prodR + ")";
            }

            /*
             * Tratar quanto de crédito é um determinado produto
             */
            else if (texto.Contains("how many credits is"))
            {
                var tx1 = texto.Replace("how many credits is", "");
                var produtos = tx1.Replace("?", "");

                string[] prods = produtos.TrimStart(' ').Split(' ');

                foreach (string prod in prods)
                {
                    string contents = GetRoman(prod);
                    prodR += contents;
                }

                string[] numIsol = prodR.TrimStart(' ').Split(' ');

                string numDecimal = postFunction(numIsol[0]);

                int totalPecas = Convert.ToInt32(numDecimal);
                int valorPecas = Convert.ToInt32(numIsol[1]);

                statusS = "alert-warning";
                valorR = produtos + "is: " + (totalPecas * valorPecas) + " credits (" + prodR + ") (" + totalPecas + " * "+ valorPecas + ") ";
            }

            return Json(new { statusSaida = statusS, valorRomano = valorR, valorBinario = "" });
        }

        private static string GetRoman(string nome)
        {

            if (nome == "glob")
            {
                produtoR = "I";
            }
            else if (nome == "prok")
            {
                produtoR = "V";
            }
            else if (nome == "pish")
            {
                produtoR = "X";
            }
            else if (nome == "tegj")
            {
                produtoR = "L";
            }
            else if (nome == "silver")
            {
                produtoR = " " + 17;
            }
            else if (nome == "iron")
            {
                produtoR = " " + 182;
            }
            else if (nome == "gold")
            {
                produtoR = " " + 14450;
            }
            else
            {
                produtoR = "";
            }
            return produtoR;
        }

        private static string DecifrarNumero(string letra)
        {

            var numero = "";

            if (letra == "I")
            {
                numero = "1";
            }
            else if (letra == "V")
            {
                numero = "5";
            }
            else if (letra == "X")
            {
                numero = "10";
            }
            else if (letra == "L")
            {
                numero = "50";
            }
            else if (letra == "C")
            {
                numero = "100";
            }
            else if (letra == "D")
            {
                numero = "500";
            }
            else if (letra == "M")
            {
                numero = "1000";
            }

            return numero;
        }

        private static string postFunction(string romano)
        {

            if (romano.Contains("IIII") || romano.Contains("XXXX") || romano.Contains("CCCC") || romano.Contains("MMMM"))
            {
                return "Invalid roman number";
            }

            int totalroman = 0, i, n = romano.Length;
            num = new int[10];

            for (i = 0; i < n; i++)
            {
                if (romano[i] == 'I')
                {
                    num[i] = 1;
                }
                else if (romano[i] == 'V')
                {
                    num[i] = 5;
                }
                else if (romano[i] == 'X')
                {
                    num[i] = 10;
                }
                else if (romano[i] == 'L')
                {
                    num[i] = 50;
                }
                else if (romano[i] == 'C')
                {
                    num[i] = 100;
                }
                else if (romano[i] == 'D')
                {
                    num[i] = 500;
                }
                else if (romano[i] == 'M')
                {
                    num[i] = 1000;
                }
            }           

            for (i = 0; i < n; i++)
            {
                if (num[i] < num[i + 1])
                {
                    totalroman = totalroman - num[i];
                }else
                {
                    totalroman = totalroman + num[i];
                }
            }

            return Convert.ToString(totalroman);
        }


    }
}
