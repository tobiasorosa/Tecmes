namespace Tecmes.Models.Production
{
    public class ProductionOrderViewModel
    {
        public int Id { get; set; }
        public string Produto { get; set; } 
        public int Quantidade { get; set; }
        public bool Produzido { get; set; }
        public int Vendido { get; set; }
    }
}
