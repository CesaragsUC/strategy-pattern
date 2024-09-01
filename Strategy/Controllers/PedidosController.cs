using Microsoft.AspNetCore.Mvc;
using Strategy.Factory;
using Strategy.Interfaces;
using Strategy.Models;

namespace Strategy.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class PedidosController(IPedidoService pedidoService) : Controller
    {

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        [Route("create/{meioPagamento:int}")]
        public async Task<IActionResult> Add(MeioPagamento meioPagamento)
        {
            var pedido = new Pedido
            {
                Id = Guid.NewGuid(),
                Produtos = ObterProdutos(),
                Pagamento = new Pagamento
                {
                    MeioPagamento = meioPagamento,
                    CartaoCredito = "1234 1234 1234 1234",
                    Status = "Aguardando Pagamento",
                    Valor = ObterProdutos().Sum(p => p.Valor)

                }
            };

            var pagamento = await pedidoService.RealizarPagamento(pedido);

            return Ok(pagamento);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }

        [HttpPost]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }


        private List<Produto> ObterProdutos()
        {
            return new List<Produto>
            {
                new Produto{Nome = "Tenis Adidas", Valor = new Random().Next(500)},
                new Produto{Nome = "Camisa Boliche", Valor = new Random().Next(500)},
                new Produto{Nome = "Raquete Tenis", Valor = new Random().Next(500)}
            };
        }
    }
}
