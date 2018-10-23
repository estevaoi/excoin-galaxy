using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExCoinGalaxy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExCoinGalaxy.Controllers
{
    [Route("api/[controller]")]
    public class ConversorController : Controller
    {
        private string produtoR;
        private string prodR;

        [HttpPost]
        [Route("post")]
        public JsonResult postFunction([FromBody] ConversorViewModel nameModel)
        {

            var entrada = nameModel;
            var frase = entrada.Atributo;
            var texto = frase.ToLower().Trim();

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
                    prodR += prod + "-";
                }

                //prodR = ConverterProduto(produtos);

                statusS = "alert-success";
                valorR = "Quanto custa: " + prodR;
            }

            /*
             * Tratar quanto de crédito é um determinado produto
             */
            else if (texto.Contains("how many credits is"))
            {

                var produtos1 = texto.Replace("how many credits is", "");
                var produtos = produtos1.Replace("?", "");

                statusS = "alert-warning";
                valorR = "Quanto de crédito: " + produtos;
            }

            return Json(new { statusSaida = statusS, valorRomano = valorR, valorBinario = true });
        }

        private void ConverterProduto(string produto)
        {
            if (produto == "glob")
            {
                produtoR = "I";
            }
            else
            {
                produtoR = "EE";
            }
        }
    }
}
