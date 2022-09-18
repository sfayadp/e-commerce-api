namespace e_commerce_api.DTO.Descuentos
{
    public class DescuentoDTO
    {
        public int IdDTO { get; set; }
        public string NombreDTO { get; set; } = null!;
        public string CodigoDTO { get; set; } = null!;
        public decimal ValorPorcentajeDTO { get; set; }
    }
}
