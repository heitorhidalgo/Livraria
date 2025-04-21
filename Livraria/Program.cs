using Livraria.Models;
using Livraria.Services;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .SetBasePath("C:\\Users\\heito\\Desktop\\TRAINEE - AULAS\\DOTNET\\source\\repos\\c\\04 aula\\Livraria\\Livraria")
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var configuration = builder.Build();

string connectionString = configuration.GetConnectionString("ConexaoPadrao");

AutorService autorService = new AutorService(connectionString);

LivroService livroService = new LivroService(connectionString);

int opcao;
do
{
    Console.Clear();
    Console.WriteLine("==== MENU ====");
    Console.WriteLine("1 - Cadastrar Autor");
    Console.WriteLine("2 - Listar Autores");
    Console.WriteLine("3 - Atualizar Autor");
    Console.WriteLine("4 - Remover Autor");
    Console.WriteLine("5 - Cadastrar Livro");
    Console.WriteLine("6 - Listar Livros");
    Console.WriteLine("7 - Atualizar Livro");
    Console.WriteLine("8 - Remover Livro");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");
    opcao = int.Parse(Console.ReadLine());

    try
    {
        switch (opcao)
        {
            case 1: CadastrarAutor(); break;
            case 2: ListarAutores(); break;
            case 3: AtualizarAutor(); break;
            case 4: RemoverAutor(); break;
            case 5: CadastrarLivro(); break;
            case 6: ListarLivros(); break;
            case 7: AtualizarLivro(); break;
            case 8: RemoverLivro(); break;
            case 0: Console.WriteLine("Saindo..."); break;
            default: Console.WriteLine("Opção inválida!"); break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("\nOcorreu um Erro: " + ex.Message);
    }

    if (opcao != 0)
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

} while (opcao != 0);

void CadastrarAutor()
{
    Console.WriteLine("\n== Cadastro de Autor ==");
    Console.Write("Nome: ");
    string nome = Console.ReadLine();
    Console.Write("Nacionalidade: ");
    string nacionalidade = Console.ReadLine();

    autorService.AdicionarAutor(nome, nacionalidade);
    Console.WriteLine("Autor cadastrado com sucesso!");
}

void ListarAutores()
{
    Console.WriteLine("\n== Lista de Autores ==");
    List<Autor> autores = autorService.ListarAutores();

    foreach (Autor c in autores)
    {
        Console.WriteLine($"ID: {c.Id} | Nome: {c.Nome} | Nacionalidade: {c.Nacionalidade}");
    }
}
void AtualizarAutor()
{
    Console.WriteLine("\n== Atualizar Autor ==");
    Console.Write("ID do Autor: ");
    int id = int.Parse(Console.ReadLine());

    Autor autor = autorService.BuscarAutor(id);
    if (autor == null)
    {
        Console.WriteLine("Autor não encontrado.");
        return;
    }

    Console.Write("Novo Nome: ");
    autor.Nome = Console.ReadLine();
    Console.Write("Nova Nacionalidade: ");
    autor.Nacionalidade = Console.ReadLine();

    autorService.AtualizarAutor(autor);
    Console.WriteLine("Autor atualizado com sucesso!");
}
void RemoverAutor()
{
    Console.WriteLine("\n== Remover Autor ==");
    Console.Write("ID do Autor: ");
    int id = int.Parse(Console.ReadLine());

    autorService.RemoverAutor(id);
    Console.WriteLine("Autor removido com sucesso!");
}
void CadastrarLivro()
{
    Console.WriteLine("\n== Cadastro de Livro ==");
    Console.Write("Título: ");
    string título = Console.ReadLine();
    Console.Write("Genero: ");
    string genero = Console.ReadLine();
    Console.Write("Ano de Publicacao: ");
    int anoPublicacao = int.Parse(Console.ReadLine());
    Console.Write("Autor Id: ");
    int autorId = int.Parse(Console.ReadLine());

    livroService.AdicionarLivro(título, genero, anoPublicacao, autorId);
    Console.WriteLine("Livro cadastrado com sucesso!");
}
void ListarLivros()
{
    Console.WriteLine("\n== Lista de Livros ==");
    List<Livro> livros = livroService.ListarLivros();

    foreach (Livro c in livros)
    {
        Console.WriteLine($"ID: {c.Id} | Título: {c.Título} | Ano de Publicacao: {c.AnoPublicacao} | Autor Id: {c.AutorId}");
    }
}
void AtualizarLivro()
{
    Console.WriteLine("\n== Atualizar Livro ==");
    Console.Write("ID do Livro: ");
    int id = int.Parse(Console.ReadLine());

    Livro livro = livroService.BuscarLivro(id);
    if (livro == null)
    {
        Console.WriteLine("Livro não encontrado.");
        return;
    }

    Console.Write("Novo Titulo: ");
    livro.Título = Console.ReadLine();
    Console.Write("Novo Genero: ");
    livro.Genero = Console.ReadLine();
    Console.Write("Novo Ano de Publicacao: ");
    livro.AnoPublicacao = int.Parse(Console.ReadLine());
    Console.Write("Novo Autor ID: ");
    livro.AutorId = int.Parse(Console.ReadLine());

    livroService.AtualizarLivro(livro);
    Console.WriteLine("Livro atualizado com sucesso!");
}
void RemoverLivro()
{
    Console.WriteLine("\n== Remover Livro ==");
    Console.Write("ID do Livro: ");
    int id = int.Parse(Console.ReadLine());

    livroService.RemoverLivro(id);
    Console.WriteLine("Livro removido com sucesso!");
}