namespace ProjetoMyTe.AppWeb.Models.Entities
{
    public class Colaborador
    {
        public string? Id { get; set; }
        public int CargoId { get; set; }
        //public bool Administrador { get; set; }
        public string? Nome { get; set; }
        public Cargo? CargoAtuacao { get; set; } //propriedade de navegação
        public ICollection<RegistroHoras>? RegistrosHoras { get; set; }

    }
}
