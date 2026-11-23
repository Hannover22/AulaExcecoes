using ExercicioArquivos;

var path = @"C:\dev\";
var file = "contatos.dat";

bool PathValidation(string p)
{
    try
    {
        Directory.CreateDirectory(p);
        return true;
    }
    catch (DirectoryNotFoundException e)
    {
        Console.WriteLine(e);
        return false;
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        return false;
    }
}

bool FileValidation(string p)
{
    if (File.Exists(p))
        return true;
    try
    {
        if (PathValidation(p))
        {
            File.Create(p + file).Close();
            return true;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        return false;
    }
    return false;
}
string nome = null;
int telefone = 0;
char genero = 'a';
bool Menu()
{
    
    Console.Write("Digite o nome do contato: ");
    try
    {
        nome = Console.ReadLine();
    }
    catch(Exception e)
    {
        return false;
    }

    Console.Write("Digite o numero do contato: ");
    try
    {
        telefone = int.Parse(Console.ReadLine());
        if (telefone < 99999999)
        {
            return false;
        }
    }
    catch(Exception e)
    {
        return false;
    }
    Console.Write("Digite o genero do contato (H ou M): ");
    try
    {
        genero = char.Parse(Console.ReadLine());
        if (genero != 'H' && genero != 'M')
        {
            return false;
        }
    }
    catch(Exception e){
        return false;
    }
    return true;
}

void AddSimples(string s)
{
    File.AppendAllText(path + file, '\n' + s);
}

int Escolhas()
{
    Console.WriteLine("1 - Adicionar contatos no arquivo.");
    Console.WriteLine("2 - Mostrar contatos do arquivo.");
    Console.WriteLine("0 - Sair.");
    return int.Parse(Console.ReadLine());
}

void ShowContacts()
{
    var reader = new StreamReader(path + file);

    Console.WriteLine(reader.ReadToEnd());

    reader.Close();
}

while (true)
{
    switch (Escolhas()){
        case 1:
            while (true)
            {
                Console.WriteLine("Cadastre seu contato");
                if (Menu())
                {
                    Contato c = new Contato(nome, telefone, genero);
                    AddSimples(c.ToString());
                    break;
                }
                else
                {
                    continue;
                }
            }
            break;

        case 2:
            try
            {
                ShowContacts();
            }
            catch(Exception e)
            {
                break;
            }
            continue;
        case 0:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Nao entendi");
            continue;
    }
}