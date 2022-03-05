namespace DIO.Bank
{
    class Program
	{
		static List<Conta> ListContas = new List<Conta>();
		static void Main(string[] args)
		{
			string OpcaoUsuario = ObterOpcaoUsuario();

			while (OpcaoUsuario.ToUpper() != "X")
			{
				switch (OpcaoUsuario)
				{
					case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						Transferir();
						break;
					case "4":
						Sacar();
						break;
					case "5":
						Depositar();
						break;
                    case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				OpcaoUsuario = ObterOpcaoUsuario();
			}
			
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void Depositar()
		{
			Console.Write("Digite o número da conta: ");
			int IndiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double ValorDeposito = double.Parse(Console.ReadLine());

            ListContas[IndiceConta].Depositar(ValorDeposito);
		}

		private static void Sacar()
		{
			Console.Write("Digite o número da conta: ");
			int IndiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double ValorSaque = double.Parse(Console.ReadLine());

            ListContas[IndiceConta].Sacar(ValorSaque);
		}

		private static void Transferir()
		{
			Console.Write("Digite o número da conta de origem: ");
			int IndiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int IndiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double ValorTransferencia = double.Parse(Console.ReadLine());

            ListContas[IndiceContaOrigem].Transferir(ValorTransferencia, ListContas[IndiceContaDestino]);
		}

		private static void InserirConta()
		{
			Console.WriteLine("Inserir nova conta");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int EntradaTipoConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Cliente: ");
			string EntradaNome = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double EntradaSaldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double EntradaCredito = double.Parse(Console.ReadLine());

			Conta NovaConta = new Conta(tipoConta: (TipoConta)EntradaTipoConta,
										saldo: EntradaSaldo,
										credito: EntradaCredito,
										nome: EntradaNome);

			ListContas.Add(NovaConta);
		}

		private static void ListarContas()
		{
			Console.WriteLine("Listar contas");

			if (ListContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < ListContas.Count; i++)
			{
				Conta conta = ListContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Bank a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar contas");
			Console.WriteLine("2- Inserir nova conta");
			Console.WriteLine("3- Transferir");
			Console.WriteLine("4- Sacar");
			Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string OpcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return OpcaoUsuario;
		}
	}
}

