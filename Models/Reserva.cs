namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarSuite(Suite suite) {
            Suite = suite;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new ArgumentException("A capacidade de hóspedes não pode exceder a capacidade da suite.");
            }
        }


        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor  = 0;
            decimal percDesconto = DiasReservados >= 10 ? 10 : 0;

            if (DiasReservados > 0)
            {
                valor = (DiasReservados * Suite.ValorDiaria) * (1 - (percDesconto/100));
            }

            return valor;
        }
    }
}