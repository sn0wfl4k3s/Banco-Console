using System.Text;

namespace Banco.Domain;

internal class Conta
{
    public Guid Id { get; set; }
    public required string Titular { get; set; }
    public double Saldo { get; set; }
    public int Numero { get; set; }

    public void Transfer(Conta final, double valor)
    {
        if (valor > Saldo)
            throw new Exception("Conta não possui saldo suficiente para esta transação");

        Saldo -= valor;

        final.Saldo += valor;
    }

    public override string? ToString()
    {
        var sb = new StringBuilder();

        sb.Append($"Conta..: {Numero}\n");
        sb.Append($"Titular: {Titular}\n");
        sb.Append($"Saldo..: R$ {Saldo:0.00}\n");

        return sb.ToString();
    }
}
