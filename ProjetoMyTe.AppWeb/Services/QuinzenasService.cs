using ProjetoMyTe.AppWeb.Models.Entities;

namespace ProjetoMyTe.AppWeb.Services
{
    public class QuinzenasService
    {
        
        public QuinzenaViewModel CriarQuinzena()
        {
            var inicioDaQuinzena = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var qtdeDiasDoMes = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            var fimDaQuinzena = inicioDaQuinzena.AddDays(qtdeDiasDoMes - 1);
            
            if (DateTime.Now.Day > 15) inicioDaQuinzena = inicioDaQuinzena.AddDays(15);
            else fimDaQuinzena = inicioDaQuinzena.AddDays(14);
            
            var quinzena = new QuinzenaViewModel
            {
                InicioDaQuinzena = inicioDaQuinzena,
                FimDaQuinzena = fimDaQuinzena,
                DiasDoMes = ListarTodosOsDias(inicioDaQuinzena, fimDaQuinzena),
                FinaisDeSemana = ListarOsFinaisDeSemana(inicioDaQuinzena, fimDaQuinzena),
                DiasUteis = ListarDiasUteis(inicioDaQuinzena, fimDaQuinzena)
                
            };
            return quinzena;
        }

               
        private List<DateTime> ListarTodosOsDias(DateTime inicioDaQuinzena, DateTime fimDaQuinzena)
        {
            var listaDias = new List<DateTime>();
            for (var dia = inicioDaQuinzena; dia <= fimDaQuinzena; dia = dia.AddDays(1))
            {
                listaDias.Add(dia);
            }
            return listaDias;
        }
        private List<DateTime> ListarOsFinaisDeSemana(DateTime inicioDaQuinzena, DateTime fimDaQuinzena)
        {
            var listaDiasFinaisDeSemana = new List<DateTime>();
            for (var dia = inicioDaQuinzena; dia <= fimDaQuinzena; dia = dia.AddDays(1))
            {
                if (dia.DayOfWeek == DayOfWeek.Sunday || dia.DayOfWeek == DayOfWeek.Saturday)
                {
                    listaDiasFinaisDeSemana.Add(dia);
                }
            }
            return listaDiasFinaisDeSemana;
        }

        private List<DateTime> ListarDiasUteis(DateTime inicioDaQuinzena, DateTime fimDaQuinzena)
        {
            var listaDiasUteis = new List<DateTime>();
            for (var dia = inicioDaQuinzena; dia <= fimDaQuinzena; dia = dia.AddDays(1))
            {
                if (dia.DayOfWeek != DayOfWeek.Sunday && dia.DayOfWeek != DayOfWeek.Saturday)
                {
                    listaDiasUteis.Add(dia);
                }
            }
            return listaDiasUteis;
        }
    }
}
