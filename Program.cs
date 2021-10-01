using System;

namespace CadastroSeries
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "S")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisializarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }   

            Console.WriteLine("Obrigado por usar nossa serviços.");
            Console.ReadLine();
        }
    
        private static void ListarSerie()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Listar();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadsatrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.RetornarExcluido();

                Console.WriteLine("#ID {0}: - {1} - Excluido? {2}", serie.RetornarId(), serie.RetornarTitulo(), (excluido ? "Sim" : "Não"));
                
            }

        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
             string entradaDescricao = Console.ReadLine();

             Serie novaSerie = new Serie(
                 id: repositorio.ProximoId(),
                 genero: (Genero)entradaGenero,
                 titulo: entradaTitulo,
                 ano: entradaAno,
                 descricao: entradaDescricao);

              repositorio.Inserir(novaSerie);
        }
        


        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o #ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
             string entradaDescricao = Console.ReadLine();

             Serie atualizaSerie = new Serie(
                 id: indiceSerie,
                 genero: (Genero)entradaGenero,
                 titulo: entradaTitulo,
                 ano: entradaAno,
                 descricao: entradaDescricao);

             repositorio.Atualizar(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o #ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        private static void VisializarSerie()
        {
            Console.WriteLine("Digite o #ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornarPorId(indiceSerie);

            Console.WriteLine(serie);

        }

        private static string ObterOpcaoUsuario()
        {

            Console.WriteLine();
            Console.WriteLine("Escolha sua série!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Ver série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("S - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
