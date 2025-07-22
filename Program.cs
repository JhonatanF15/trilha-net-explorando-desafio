using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(p1);
hospedes.Add(p2);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 5);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");

// --- Teste: Reserva acima da capacidade (deve lançar exceção) ---
try
{
    List<Pessoa> hospedesExcedente = new List<Pessoa>
    {
        new Pessoa("Hóspede 1"),
        new Pessoa("Hóspede 2"),
        new Pessoa("Hóspede 3")
    };
    Reserva reservaExcedente = new Reserva(diasReservados: 2);
    reservaExcedente.CadastrarSuite(suite);
    reservaExcedente.CadastrarHospedes(hospedesExcedente);
}
catch (Exception ex)
{
    Console.WriteLine($"Exceção esperada (excesso de hóspedes): {ex.Message}");
}

// --- Teste: Cálculo do valor da diária com desconto (10 dias ou mais) ---
Reserva reservaDesconto = new Reserva(diasReservados: 12);
reservaDesconto.CadastrarSuite(suite);
reservaDesconto.CadastrarHospedes(hospedes);
Console.WriteLine($"Valor diária com desconto (12 dias): {reservaDesconto.CalcularValorDiaria()}");

// --- Teste: Caso limite (0 hóspedes) ---
Reserva reservaZeroHospedes = new Reserva(diasReservados: 3);
reservaZeroHospedes.CadastrarSuite(suite);
reservaZeroHospedes.CadastrarHospedes(new List<Pessoa>());
Console.WriteLine($"Hóspedes (zero): {reservaZeroHospedes.ObterQuantidadeHospedes()}");

// --- Teste: Caso limite (0 dias) ---
Reserva reservaZeroDias = new Reserva(diasReservados: 0);
reservaZeroDias.CadastrarSuite(suite);
reservaZeroDias.CadastrarHospedes(hospedes);
Console.WriteLine($"Valor diária (0 dias): {reservaZeroDias.CalcularValorDiaria()}");