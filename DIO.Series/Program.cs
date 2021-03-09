using System;

namespace DIO.Series
{
    class Program
    {
        static DIO.Series.Classes.SerieRepositorio  repositorio = new Classes.SerieRepositorio();
        static DIO.Series.Classes.FilmeRepositorio repositorioFilmes = new Classes.FilmeRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        ListarFilmes();
                        break;
                    case "3":
                        InserirSerie();
                        break;
                    case "4":
                        InserirFilme();
                        break;    
                    case "5":
                        AtualizarSerie();
                        break;
                    case "6":
                        AtualizarFilme();
                        break;    
                    case "7":
                        ExcluirSerie();
                        break;
                    case "8":
                        ExcluirFilme();
                        break;
                    case "9":
                        VisualizarSerie();
                        break;
                    case "10": 
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Agradecemos por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar série");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
                //Caso esteja excluído vai retornar informando que está excluído e caso não esteja, não retorna nada
            }
        }

         private static void ListarFilmes()
        {
            Console.WriteLine("Listar Filme");

            var lista = repositorioFilmes.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }

            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
                //Caso esteja excluído vai retornar informando que está excluído e caso não esteja, não retorna nada
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
                       
            int entradaCategoria = 1;

            //https://docs.microsoft.com/en-us/dotnet/api/system.enum.getvalues?view=netcore-3.1
            //Pega os itens listados no Enum
            //https://docs.microsoft.com/en-us/dotnet/api/system.enum.getname?view=netcore-3.1
            //Lista o gênero com valor i para o usuário
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        categoria: (Categoria)entradaCategoria,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);    
        }

        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo Filme");
           
            int entradaCategoria = 2;

            //https://docs.microsoft.com/en-us/dotnet/api/system.enum.getvalues?view=netcore-3.1
            //Pega os itens listados no Enum
            //https://docs.microsoft.com/en-us/dotnet/api/system.enum.getname?view=netcore-3.1
            //Lista o gênero com valor i para o usuário
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorioFilmes.ProximoId(),
                                        categoria: (Categoria)entradaCategoria,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorioFilmes.Insere(novoFilme);    
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série que deseja excluir: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("Tem certeza que gostaria de excluir essa série?");
            Console.WriteLine("1 - Digite 1 para confirmar a exclusão");
            Console.WriteLine("2 - Digite 2 para retornar ao menu");

            switch(Console.ReadLine())
            {
                case "1":
                repositorio.Exclui(indiceSerie);
                Console.WriteLine();
                Console.WriteLine("Sua Série foi excluída com sucesso!!!");
                break;

                case "2":
                ObterOpcaoUsuario();
                break;

                default:
                throw new ArgumentOutOfRangeException();
            }
            Console.WriteLine();
        }

                private static void ExcluirFilme()
        {
            Console.WriteLine("Digite o id do filme que deseja excluir: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            Console.WriteLine("Tem certeza que gostaria de excluir esse filme?");
            Console.WriteLine("1 - Digite 1 para confirmar a exclusão");
            Console.WriteLine("2 - Digite 2 para retornar ao menu");

            switch(Console.ReadLine())
            {
                case "1":
                repositorioFilmes.Exclui(indiceFilme);
                Console.WriteLine();
                Console.WriteLine("Seu Filme foi excluído com sucesso!!!");
                break;
                
                case "2":
                ObterOpcaoUsuario();
                break;

                default:
                throw new ArgumentOutOfRangeException();
            }
            Console.WriteLine();
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série que gostaria de visualizar: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void VisualizarFilme()
        {
            Console.WriteLine("Digite o id do filme que gostaria de visualizar: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorioFilmes.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }


        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());
         
            int entradaCategoria = 1;

            //https://docs.microsoft.com/en-us/dotnet/api/system.enum.getvalues?view=netcore-3.1
            //Pega os itens listados no Enum
            //https://docs.microsoft.com/en-us/dotnet/api/system.enum.getname?view=netcore-3.1
            //Lista o gênero com valor i para o usuário

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        categoria: (Categoria)entradaCategoria,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void AtualizarFilme()
        {
            Console.WriteLine("Digite o id do filme");
            int indiceFilme = int.Parse(Console.ReadLine());
          
            int entradaCategoria = 2;

            //https://docs.microsoft.com/en-us/dotnet/api/system.enum.getvalues?view=netcore-3.1
            //Pega os itens listados no Enum
            //https://docs.microsoft.com/en-us/dotnet/api/system.enum.getname?view=netcore-3.1
            //Lista o gênero com valor i para o usuário
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        categoria: (Categoria)entradaCategoria,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorioFilmes.Atualiza(indiceFilme, atualizaFilme);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Listar filmes");
            Console.WriteLine("3 - Inserir nova série");
            Console.WriteLine("4 - Inserir novo filme");
            Console.WriteLine("5 - Atualizar série");
            Console.WriteLine("6 - Atualizar filme");
            Console.WriteLine("7 - Excluir série");
            Console.WriteLine("8 - Excluir filme");
            Console.WriteLine("9 - Visualizar série");
            Console.WriteLine("10 - Visualizar filme");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}