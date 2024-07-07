using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO;
using bytebank_ATENDIMENTO.bytebank.Util;
using System.Collections;
using System.Security.AccessControl;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

List<ContaCorrente> lista = new List<ContaCorrente>()
{
    new ContaCorrente("123456-X", 95) { Saldo = 100 },
    new ContaCorrente("951258-X", 95) { Saldo = 200 },
    new ContaCorrente("987321-W", 94) { Saldo = 60 }
};

void atendimentoCliente()
{
    try
    {
        char opcao = '0';

        while (opcao != '6')
        {
            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("---Atendimento---");
            Console.WriteLine("---1-Cadastro---");
            Console.WriteLine("---2-Lista de contas---");
            Console.WriteLine("---3-remover lista---");
            Console.WriteLine("---4-ordenar contas---");
            Console.WriteLine("---5-pesquisar conta---");
            Console.WriteLine("---6-sair do sistema---");
            Console.WriteLine("-----------------");
            Console.WriteLine("\n\n");
            Console.WriteLine("digite a opção desejada:");
            try
            {
                opcao = Console.ReadLine()[0];
            }
            catch (Exception ex)
            {

                throw new ByteMyException(ex.Message);
            }

            switch (opcao)
            {
                case '1':
                    cadastrar();
                    break;
                case '2':
                    listar();
                    break;
                default:
                    Console.WriteLine("opção não implementada");
                    break;
            }
        }
    }
    catch (ByteMyException ex) {

        Console.WriteLine($"{ex.Message}");
    }
}

void listar()
{
    Console.WriteLine("-----------------");
    Console.WriteLine("-----Lista de contas --------");
    Console.WriteLine("-----------------");
    Console.WriteLine("\n");

    if (lista.Count < 0)
    {
        Console.WriteLine("não há contas");
        Console.ReadKey();
        return;
    }

    foreach (ContaCorrente item in lista)
    {
        Console.WriteLine("-----------------");
        Console.WriteLine("----Dados da conta --------");
        Console.WriteLine("numero conta:" + item.Conta);
        Console.WriteLine("saldo:" + item.Saldo);
        Console.WriteLine("titular:" + item.Titular.Nome);
        Console.WriteLine("cpf:" + item.Titular.Cpf);
        Console.WriteLine("profissao do:" + item.Titular.Profissao);
        Console.WriteLine("-----------------");
        Console.ReadKey();
    }
}

void cadastrar()
{
    Console.Clear();
    Console.WriteLine("-----------------");
    Console.WriteLine("---Cadastro de contas ---");
    Console.WriteLine("-----------------");
    Console.WriteLine("\n");
    Console.WriteLine("----informe dados da conta-------");

    Console.Write("Numero da conta:");
    string numeroConta = Console.ReadLine();

    Console.Write("Numero da agencia:");
    int numeroAgencia = int.Parse(Console.ReadLine());

    ContaCorrente conta = new ContaCorrente(numeroConta, numeroAgencia);

    Console.Write("informe o saldo inicial:");
    conta.Saldo = double.Parse(Console.ReadLine());

    Console.Write("informe o nome do titular:");
    conta.Titular.Nome = Console.ReadLine();

    Console.Write("informe o cpf do titular:");
    conta.Titular.Cpf = Console.ReadLine();

    Console.Write("informe a profissao:");
    conta.Titular.Profissao = Console.ReadLine();

    lista.Add(conta);

    Console.Write("dados cadastrados");
    Console.ReadKey();

}

atendimentoCliente();

#region fisrt

int idade = 30;
int idade1 = 40;
int idade2 = 25;

Array amostra = Array.CreateInstance(typeof(double), 5);

amostra.SetValue(5.9, 0);
amostra.SetValue(3.5, 1);
amostra.SetValue(23.5, 2);
amostra.SetValue(7.7, 3);
amostra.SetValue(1.2, 4);

//TestaArrayInt();
//TestaBusca();
//testaMediana(amostra);
//TestaArrayConta();

void TestaArrayInt()
{
    int[] idades = new int[3];

    idades[0] = idade;
    idades[1] = idade1;
    idades[2] = idade2;

    Console.WriteLine($"Tamanho do array {idades.Length}");

    int acumulador = 0;

    for (int i = 0; i <idades.Length; i++)
    {
        int idade = idades[i];

        Console.WriteLine($"indice [{i}] = {idades[i]}");

        acumulador += idade;
    }

    int media = acumulador / idades.Length;
    Console.WriteLine($"media = {media}");
}

void TestaBusca()
{
    string[] arrayPalavras = new string[5];

    for (int i = 0; i< arrayPalavras.Length; i++)
    {
        Console.Write($"Digite {i+1} a palavra:");
        arrayPalavras[i] = Console.ReadLine();
    }

    Console.Write("Digite a palavra a ser encontrada:");
    var busca = Console.ReadLine();

    foreach(string current in arrayPalavras)
    {
        if (current.Equals(busca)){
            Console.WriteLine($"Palavra encontrada = {busca}");
            break;
        }
 
    }
}

void testaMediana(Array array)
{
    if((array == null) || (array.Length == 0)){
        Console.WriteLine("Array vazio");
    }

    double[] numeroOrder = (double[])array.Clone();
    Array.Sort(numeroOrder);

    int tamanho = numeroOrder.Length;
    int meio = tamanho / 2;

    double mediana = (tamanho % 2 != 0) ? numeroOrder[meio] : (numeroOrder[meio] + numeroOrder[meio - 1]) / 2;

    Console.WriteLine($"Mediana é igual a {mediana}");
}

//int[] valores = { 10, 57, 34, 35 };

//for (int i = 0; i < valores.Length; i++)
//{
   // Console.WriteLine(valores[i]);
//}

double mediaAmostra(double[] parametros)
{
    double media = 0;
    double acumulador = 0;

    if (parametros == null || parametros.Length == 0)
    {
        Console.WriteLine("Amostra de dados nula ou vazia.");
        return 0;
    }
    else
    {
        for(int i = 0; i < parametros.Length; i++)
        {
            acumulador += parametros[i];
        }

        media = acumulador / parametros.Length;
    }

    return media;
}

void TestaArrayContasCorrentes()
{
    ContaCorrente[] lista = new ContaCorrente[]
    {
        //new ContaCorrente(845),
        //new ContaCorrente(343),
        //new ContaCorrente(643),
        //new ContaCorrente(545),
        //new ContaCorrente(734),
        //new ContaCorrente(233),
    };

    for(int i = 0;i < lista.Length; i++)
    {
        ContaCorrente contaAtual = lista[i];
        Console.WriteLine($"Indice{i} - Conta: {contaAtual.Conta}");
    }
}

void TestaArrayConta()
{
    ListaDeContasCorrentes lista = new ListaDeContasCorrentes();
    //lista.Adicionar(new ContaCorrente(845));
    //lista.Adicionar(new ContaCorrente(343));

    //var conta = new ContaCorrente(2323);
    //lista.Adicionar(conta);
    //lista.ExibeLista();
    //lista.remover(conta);
    //lista.ExibeLista();

    for (int i = 0; i< lista.Tamanho; i++)
    {
        ContaCorrente contas = lista[i];
        //Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Numero_agencia}");
    }
}

#endregion

#region second
//List<ContaCorrente> lista = new List<ContaCorrente>()
//{
//    new ContaCorrente("123456-X", 95) { Saldo = 100 },
//    new ContaCorrente("951258-X", 95) { Saldo = 200 },
//    new ContaCorrente("987321-W", 94) { Saldo = 60 }
//};

//List<ContaCorrente> listaDeContas2 = new List<ContaCorrente>()
//{
//    new ContaCorrente("5679787-A", 874),
//    new ContaCorrente("4456668-B", 874),
//    new ContaCorrente("7781438-C", 874)
//};

//List<ContaCorrente> listaDeContas3 = new List<ContaCorrente>()
//{
//    new ContaCorrente("5679787-E", 951),
//    new ContaCorrente("4456668-F", 321),
//    new ContaCorrente("7781438-G", 719)
//};

//listaDeContas2.AddRange(listaDeContas3);
//listaDeContas2.Reverse();

//for (int i = 0; i < listaDeContas2.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{listaDeContas2[i].Conta}]");
//}

//Console.WriteLine("\n\n");

//var range = listaDeContas3.GetRange(0, 1);

//for (int i = 0; i < range.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
//}

//Console.WriteLine("\n\n");


//listaDeContas3.Clear();

//for (int i = 0; i < listaDeContas3.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{listaDeContas3[i].Conta}]");
//}

#endregion

#region third

//generica<int> teste = new generica<int>();

//teste.mostrarMensagem(10);

//generica<string> teste2 = new generica<string>();

//teste2.mostrarMensagem("ola");

//public class generica<T>
//{ 
//    public void mostrarMensagem(T t)
//    {
//        Console.WriteLine($"Exibindo {t}");
//    }
//}

//List<string> nomesDosEscolhidos = new List<string>()
//            {
//                "Bruce Wayne",
//                "Carlos Vilagran",
//                "Richard Grayson",
//                "Bob Kane",
//                "Will Farrel",
//                "Lois Lane",
//                "General Welling",
//                "Perla Letícia",
//                "Uxas",
//                "Diana Prince",
//                "Elisabeth Romanova",
//                "Anakin Wayne"
//            };

//foreach (string current in nomesDosEscolhidos)
//{
//    if (current.Equals("Anakin Wayne"))
//    {
//        Console.WriteLine($"vc encontrou");
//    }
//}


//VerificaNomes(nomesDosEscolhidos, "Elisabeth Romanova");
//bool VerificaNomes(List<string> nomesDosEscolhidos, string escolhido)
//{
//    return nomesDosEscolhidos.Contains(escolhido);
//}

//SortedList<int, string> times = new SortedList<int, string>();
//times.Add(0, "Flamengo");
//times.Add(1, "Santos");
//times.Add(2, "Juventus");

//foreach (var item in times.Values)
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine("\n\n");

//Stack<string> minhlaPilhaDeLivros = new Stack<string>();
//minhlaPilhaDeLivros.Push("Harry Porter e a Ordem da Fênix");
//minhlaPilhaDeLivros.Push("A Guerra do Velho.");
//minhlaPilhaDeLivros.Push("Protocolo Bluehand");
//minhlaPilhaDeLivros.Push("Crise nas Infinitas Terras.");

//Console.WriteLine(minhlaPilhaDeLivros.Peek()); // Retorna o elemento do topo.
//Console.WriteLine(minhlaPilhaDeLivros.Pop()); //Remove o elemento do topo

//foreach (string item in minhlaPilhaDeLivros)
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine("\n\n");

//Queue<string> filaAtenndimento = new Queue<string>();
//filaAtenndimento.Enqueue("André Silva");
//filaAtenndimento.Enqueue("Lou Ferrigno");
//filaAtenndimento.Enqueue("Gal Gadot");

//filaAtenndimento.Dequeue(); //Remove o primeiro elemento da fila.

//foreach (string item in filaAtenndimento)
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine("\n\n");

//HashSet<int> _numeros = new HashSet<int>();
//_numeros.Add(0);
//_numeros.Add(1);
//_numeros.Add(1);
//_numeros.Add(1);

//Console.WriteLine(_numeros.Count);

//foreach (var item in _numeros)
//{
//    Console.WriteLine(item);
//}

#endregion

