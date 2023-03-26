using System;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task<string> MetodoA()
    {
        int delay = RandomDelay();
        await Task.Delay(delay);
        return $"Metodo A finalizado em  {delay}";
    }

    static async Task<string> MetodoB()
    {
        int delay = RandomDelay();
        await Task.Delay(delay);
        return $"Metodo B finalizado em {delay}";
    }

    static async Task<string> MetodoC(string a, string b)
    {
        await Task.Delay(RandomDelay());
        return $"Metodo C finalizado e esperou o: {a } + {b }";
    }

    static int RandomDelay()
    {
        Random rnd = new Random();
        return rnd.Next(1000,5000);
    }



    static async Task Main(string[] args)
    {
        Task<string> taskA = MetodoA();
        Task<string> taskB = MetodoB();

        Task<string> tarefaConcluida = await Task.WhenAny(taskA, taskB);

        string resultado = await tarefaConcluida;

        Console.WriteLine(resultado);
        Console.WriteLine(resultado == taskA.Result ? taskB.Result : taskA.Result);

        Task<string> taskC = MetodoC(taskA.Result, taskB.Result);

        Console.WriteLine(taskC.Result);

        Console.WriteLine("Fim do programa!");
        Console.ReadKey();
    }
}
