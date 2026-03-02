using System;

public class Program
{
    public static void Main(string[] args)
    {
        string opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("---FOLHA DE PAGAMENTO---");
            Console.Write("Digite o Nome: ");
            string nome = Console.ReadLine();

            decimal salarioBruto;
            do
            {
                Console.Write("Digite o Salário Bruto: ");
                salarioBruto = decimal.Parse(Console.ReadLine());
            } while (salarioBruto <= 0);

            Console.WriteLine("\n...Processando...\n");

            decimal descontoINSS = CalcularINSS(salarioBruto);
            decimal descontoIRRF = CalcularIRRF(salarioBruto, descontoINSS);
            decimal salarioLiquido = salarioBruto - descontoINSS - descontoIRRF;

            ExibirHolerite(nome, salarioBruto, descontoINSS, descontoIRRF, salarioLiquido);

            Console.Write("\n>Novo cálculo? [S/N]: ");
            opcao = Console.ReadLine().ToUpper();

        } while (opcao == "S");
    }

    static decimal CalcularINSS(decimal salarioBruto)
    {
        if (salarioBruto <= 1300)
            return salarioBruto * 0.075m;
        else if (salarioBruto <= 2500)
            return salarioBruto * 0.09m;
        else if (salarioBruto <= 3900)
            return salarioBruto * 0.12m;
        else
            return salarioBruto * 0.14m;
    }

    static decimal CalcularIRRF(decimal salarioBruto, decimal descontoINSS)
    {
        decimal baseCalculo = salarioBruto - descontoINSS;

        if (baseCalculo > 1900)
            return baseCalculo * 0.075m;
        else
            return 0;
    }

    static void ExibirHolerite(string nome, decimal bruto, decimal inss, decimal irrf, decimal liquido)
    {
        Console.WriteLine("===============================");
        Console.WriteLine($"Funcionário: {nome}");
        Console.WriteLine($"(+) Salário Bruto: R$ {bruto:F2}");
        Console.WriteLine($"(-) Desconto INSS: R$ {inss:F2}");
        Console.WriteLine($"(-) Desconto IRRF: R$ {irrf:F2}");
        Console.WriteLine("===============================");
        Console.WriteLine($"(=) Salário Líquido: R$ {liquido:F2}");
    }
}