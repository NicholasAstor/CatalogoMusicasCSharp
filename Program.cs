using System;
using src;
using src.MusicPlayer.Services;
using src.crud.Repositories;

class Program
{
    static MusicRepo musicRepo = new MusicRepo();
    static MusicPlayerService? playerService = null;

    static void Main(string[] args)
    {
        Author justinBieber = new Author("Justin Bieber", "Canadense", false, "Cantor pop canadense");
        string babyPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string filePath = Path.Combine(babyPath, "src", "MusicPlayer", "songs", "baby.mp3");        
        Music baby = new Music("", "Baby", 210, Gender.Pop, justinBieber, filePath, "2010");
        
        Author fiftyCent = new Author("50 Cent", "Americano", false, "Rapper americano");
        string pimpPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string filePathPimp = Path.Combine(pimpPath, "src", "MusicPlayer", "songs", "pimp.mp3");
        Music pimp = new Music("", "P.I.M.P", 298, Gender.Rap, fiftyCent, filePathPimp, "2003");
        
        Author brunoEMarrone = new Author("Bruno & Marrone", "Brasileiros", true, "Dupla sertaneja");
        string bijuteriaPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string filePathBijuteria = Path.Combine(bijuteriaPath, "src", "MusicPlayer", "songs", "bijuteria.mp3");
        Music bijuteria = new Music("", "Bijuteria", 252, Gender.Sertanejo, brunoEMarrone, filePathBijuteria, "2001");



        // Adiciona ao repositório
        musicRepo.Save(baby);
        musicRepo.Save(pimp);
        musicRepo.Save(bijuteria);
        
        
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=== Catálogo de Músicas ===");
            Console.WriteLine("1. Cadastrar música");
            Console.WriteLine("2. Listar todas as músicas");
            Console.WriteLine("3. Buscar música por nome");
            Console.WriteLine("4. Buscar músicas por autor");
            Console.WriteLine("5. Tocar música");
            Console.WriteLine("6. Pausar música");
            Console.WriteLine("7. Continuar música");
            Console.WriteLine("8. Parar música");
            Console.WriteLine("9. Remover música por ID");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            Console.Clear();

            switch (opcao)
            {
                case "1":
                    CadastrarMusica();
                    break;
                case "2":
                    ListarMusicas();
                    break;
                case "3":
                    BuscarPorNome();
                    break;
                case "4":
                    BuscarPorCantor();
                    break;
                case "5":
                    ListarMusicas();
                    TocarMusica();
                    break;
                case "6":
                    playerService?.Pause();
                    Console.WriteLine("Música pausada.");
                    break;
                case "7":
                    playerService?.Resume();
                    Console.WriteLine("Música retomada.");
                    break;
                case "8":
                    playerService?.Stop();
                    Console.WriteLine("Música parada.");
                    break;
                case "9":
                    RemoverMusica();
                    break;
                case "0":
                    playerService?.Stop();
                    isRunning = false;
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void CadastrarMusica()
    {
        Console.WriteLine("=== Cadastro de Música ===");
        Console.Write("Nome da música: ");
        string nome = Console.ReadLine();

        Console.Write("Letra (opcional): ");
        string letra = Console.ReadLine();

        Console.Write("Ano: ");
        string ano = Console.ReadLine();

        Console.Write("Duração em segundos: ");
        long duracao = long.Parse(Console.ReadLine());

        Console.Write("Caminho do arquivo MP3: ");
        string filePath = Console.ReadLine();

        Console.Write("Nome do autor: ");
        string nomeAutor = Console.ReadLine();

        Console.Write("Nacionalidade do autor: ");
        string nacionalidade = Console.ReadLine();

        Console.Write("É uma banda? (s/n): ");
        bool isBanda = Console.ReadLine().ToLower() == "s";

        Console.Write("Descrição do autor: ");
        string descricao = Console.ReadLine();

        Console.WriteLine("Gêneros: Jazz, Pagode, Rock, Pop, Sertanejo, Reagge, Reggaton, Classic, Blues, Rap, Funk");
        Console.Write("Escolha o gênero: ");
        string generoStr = Console.ReadLine();
        Gender genero;
        if (!Enum.TryParse(generoStr, out genero))
        {
            Console.WriteLine("Gênero inválido. Usando 'Pop' como padrão.");
            genero = Gender.Pop;
        }

        Author autor = new Author(nomeAutor, nacionalidade, isBanda, descricao);
        Music musica = new Music(letra, nome, duracao, genero, autor, filePath, ano);

        musicRepo.Save(musica);

        Console.WriteLine("Música cadastrada com sucesso!");
    }

    static void ListarMusicas()
    {
        Console.WriteLine("=== Lista de Músicas ===");
        
        foreach (var musica in musicRepo.GetAll())
        {
            MostrarMusica(musica);
        }
    }

    static void BuscarPorNome()
    {
        Console.Write("Nome da música: ");
        string nome = Console.ReadLine();

        var musica = musicRepo.GetByName(nome.ToLower());
        if (musica != null)
            MostrarMusica(musica);
        else
            Console.WriteLine("Música não encontrada.");
    }

    static void BuscarPorCantor()
    {
        Console.Write("Nome do cantor: ");
        string nome = Console.ReadLine();

        var musicas = musicRepo.GetByAuthor(nome.ToLower());
        if (musicas.Count > 0)
            musicas.ForEach(MostrarMusica);
        else
            Console.WriteLine("Nenhuma música encontrada para esse autor.");
    }

    static void TocarMusica()
    {
        Console.Write("ID da música para tocar: ");
        if (long.TryParse(Console.ReadLine(), out long id))
        {
            var musica = musicRepo.GetById(id);
            if (musica != null)
            {
                if (musica.FilePath == null)
                {
                    Console.WriteLine("Esta música não possui arquivo associado e não pode ser tocada.");
                    return;
                }

                playerService?.Stop(); // para outra música se estiver tocando
                playerService = new MusicPlayerService(musica);
                playerService.Play();
                Console.WriteLine($"Tocando: {musica.Name}");
            }
            else
            {
                Console.WriteLine("Música não encontrada.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    static void RemoverMusica()
    {
        Console.Write("ID da música para remover: ");
        if (long.TryParse(Console.ReadLine(), out long id))
        {
            musicRepo.DeleteById(id);
            Console.WriteLine("Música removida.");
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    static void MostrarMusica(Music musica)
    {
        string tocavel = musica.FilePath != null ? "[Tocável]" : "[Não tocável]";
        Console.WriteLine($"{musica.ToString()} - {tocavel}");
    }

}
