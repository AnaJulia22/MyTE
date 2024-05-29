namespace ProjetoMyTe.AppWeb.Models.Entities
{
    public class QuinzenaViewModel
    {
        public DateTime InicioDaQuinzena { get; set; }
        public DateTime FimDaQuinzena { get; set; }
        public List<DateTime>? DiasDoMes { get; set; }
        public List<DateTime>? FinaisDeSemana { get; set; }

        public DateTime GetDia(int valor)
        {
            var dia = DiasDoMes![valor-1];
            return dia;
        }
    }
}
