﻿namespace Strategy.Models;

public class Pedido
{
    public Guid Id { get; set; }
    public decimal Valor { get; set; }
    public List<Produto> Produtos { get; set; }

    public Pagamento Pagamento { get; set; }
}