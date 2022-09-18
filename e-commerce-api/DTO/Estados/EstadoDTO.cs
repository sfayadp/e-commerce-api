namespace e_commerce_api.DTO.Estados
{
    public class EstadoDTO
    {
        public int IdDTO { get; set; }
        public string NombreDTO { get; set; } = null!;
        public string DescripcionDTO { get; set; } = null!;
        public DateTime FechaCreacionDTO { get; set; }
    }
}
