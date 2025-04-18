using Livraria.Models;
using Livraria.Services;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .SetBasePath("C:\\Users\\heito\\Desktop\\TRAINEE - AULAS\\DOTNET\\source\\repos\\c\\04 aula")
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var configuration = builder.Build();

string connectionString = configuration.GetConnectionString("ConexaoPadrao");

AutorService autorService = new AutorService(connectionString);

int opcao;
do
{
    Console.Clear();
    Console.WriteLine("==== MENU ====");
    Console.WriteLine("1 - Cadastrar Autor");
    Console.WriteLine("2 - Listar Autores");
    Console.WriteLine("3 - Atualizar Autor");
    Console.WriteLine("4 - Remover Autor");
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

    foreach (Autor c in Autores)
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