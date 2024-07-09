using bytebank.Modelos.Conta;

namespace bytebank_ATENDIMENTO
{
    internal class Atendimento
    {
        #nullable disable

        private List<ContaCorrente> lista = new List<ContaCorrente>()
{
    new ContaCorrente("123456-X", 95){Saldo=100,Titular = new Cliente{Cpf="11111",Nome ="Henrique"}},
    new ContaCorrente("951258-X", 95){Saldo=200,Titular = new Cliente{Cpf="22222",Nome ="Pedro"}},
    new ContaCorrente("987321-W", 94){Saldo=60,Titular = new Cliente{Cpf="33333",Nome ="Marisa"}}
};

        public void atendimentoCliente()
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
                        case '3':
                            remover();
                            break;
                        case '4':
                            ordenar();
                            break;
                        case '5':
                            pesquisar();
                            break;
                        case '6':
                            encerrar();
                            break;
                        default:
                            Console.WriteLine("opção não implementada");
                            break;
                    }
                }
            }
            catch (ByteMyException ex)
            {

                Console.WriteLine($"{ex.Message}");
            }
        }

        private void encerrar()
        {
           Console.WriteLine("encerrando");
            Console.ReadKey();
        }

        void pesquisar()
        {
            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("------Pesquisar Contas --------");
            Console.WriteLine("-----------------");
            Console.WriteLine("\n");
            Console.WriteLine("Deseja pesquisar 1 numero da conta ou 2 cpf ou  3 numero da agencia?");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.WriteLine("informa o numero da conta:");
                        string numero = Console.ReadLine();
                        ContaCorrente consulta = ConsultaNumero(numero);
                        Console.WriteLine(consulta.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("informa o cpf da conta:");
                        string numero = Console.ReadLine();
                        ContaCorrente consulta = ConsultaCpf(numero);
                        Console.WriteLine(consulta.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("informa o numero da agencia:");
                        int numero = int.Parse(Console.ReadLine());
                        var consulta = consultaAgencia(numero);
                        exibListaDeContas(consulta);
                        Console.ReadKey();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("opção não implementada");
                        break;
                    }
            }

        }

        void exibListaDeContas(List<ContaCorrente> consulta)
        {
            if (consulta == null)
            {
                Console.WriteLine("consulta nao retornou dados");
            }
            else
            {
                foreach (var item in consulta)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        List<ContaCorrente> consultaAgencia(int numero)
        {
            var consulta =
             (
                from conta in lista
                where conta.Numero_agencia == numero
                select conta).ToList();

            return consulta;
        }

        ContaCorrente ConsultaCpf(string? numero)
        {
            //ContaCorrente conta = null;
            //for (int i = 0; i < lista.Count; i++)
            //{
            //    if (lista[i].Titular.Cpf.Equals(numero))
            //    {
            //        conta = lista[i];
            //    }
            //}

            //return conta;

            return lista.Where(conta => conta.Titular.Cpf == numero).FirstOrDefault();

        }

        ContaCorrente ConsultaNumero(string? numero)
        {
            //ContaCorrente conta = null;
            //for (int i = 0; i < lista.Count; i++)
            //{
            //    if (lista[i].Conta.Equals(numero))
            //    {
            //        conta = lista[i];
            //    }
            //}

            //return conta;

            var consulta =
         (
            from conta in lista
            where conta.Conta.Equals(numero)
            select conta).ToList();

            return lista.Where(conta => conta.Conta == numero).FirstOrDefault();
        }

        void ordenar()
        {
            lista.Sort();
            Console.WriteLine("lista ordenada");
            Console.ReadKey();
        }

        void remover()
        {
            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("------Remover contas --------");
            Console.WriteLine("-----------------");
            Console.WriteLine("\n");

            Console.Write("informe a conta:");
            string numero = Console.ReadLine();
            ContaCorrente conta = null;

            foreach (var item in lista)
            {
                if (item.Conta.Equals(numero))
                {
                    conta = item;
                }
            }

            if (conta != null)
            {
                lista.Remove(conta);
                Console.WriteLine("conta removida");
            }
            else
            {
                Console.WriteLine("conta não encontrada");
            }

            Console.ReadKey();
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
                //Console.WriteLine("-----------------");
                //Console.WriteLine("----Dados da conta --------");
                //Console.WriteLine("numero conta:" + item.Conta);
                //Console.WriteLine("saldo:" + item.Saldo);
                //Console.WriteLine("titular:" + item.Titular.Nome);
                //Console.WriteLine("cpf:" + item.Titular.Cpf);
                //Console.WriteLine("profissao do:" + item.Titular.Profissao);
                Console.WriteLine(item.ToString());
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

            //Console.Write("Numero da conta:");
            //string numeroConta = Console.ReadLine();

            Console.Write("Numero da agencia:");
            int numeroAgencia = int.Parse(Console.ReadLine());

            ContaCorrente conta = new ContaCorrente(numeroAgencia);

            Console.Write($"Numero da conta nova: {conta.Conta} : ");
            Console.WriteLine("\n");

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
    }
}
