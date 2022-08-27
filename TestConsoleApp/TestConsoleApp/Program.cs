// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using TestConsoleApp;

Console.WriteLine("Hello, World!");
bool needToContinue = true;
TransactionRepository repository = new();

while (needToContinue)
{
    Console.WriteLine("Enter a command");
    string? inputString = Console.ReadLine();

    if (!string.IsNullOrEmpty(inputString))
    {
        bool isCommandValid = TryToExecuteCommand(inputString!);
        if (isCommandValid)
        {
            Console.WriteLine("[OK]");
            Console.ReadLine();

        }
    }

    Console.Clear();
    continue;
}

bool TryToExecuteCommand(string wannaBeCommand)
{
    wannaBeCommand = wannaBeCommand.ToLower();
    if (wannaBeCommand == "add")
    {
        ExecuteAdding();
        return true;
    }

    if (wannaBeCommand == "get")
    {
        ExecuteGetting();
        return true;
    }

    if (wannaBeCommand == "exit")
    {
        ExitProgram();
        return true;
    }

    return false;
}

void ExitProgram()
{
    needToContinue = false;
}

void ExecuteGetting()
{
    int id = ReadIdFromConsole();
    try
    {
        Transaction transaction = repository.Get(id);
        
       Console.WriteLine(JsonConvert.SerializeObject(transaction));
    }
    catch (ArgumentException exception)
    {
        Console.WriteLine($"Error occured;\nMessage:{exception.Message}");
    }

}


void ExecuteAdding()
{
    int id = ReadIdFromConsole();
    DateTime date = ReadDateFromConsole();
    decimal amount = ReadAmountFromConsole();
    try
    {
        repository.Add(new Transaction(id, date, amount));
       
    }
    catch (ArgumentException exception)
    {
        Console.WriteLine($"Error occured;\nMessage:{exception.Message}");
    }
}

int ReadIdFromConsole()
{
    while (true)
    {
        int id;

        Console.Clear();
        Console.Write("Введите Id:");
        string? idString = Console.ReadLine();

        if (string.IsNullOrEmpty(idString))
        {
            continue;
        }

        try
        {
            id = int.Parse(idString!);
        }
        catch
        {
            continue;
        }

        if (id > 0)
        {
            return id;
        }
    }

}

DateTime ReadDateFromConsole()
{
    while (true)
    {
        DateTime date;

        Console.Clear();
        Console.Write("Введите дату:");
        string? idString = Console.ReadLine();

        if (string.IsNullOrEmpty(idString))
        {
            continue;
        }

        try
        {
            date = DateTime.Parse(idString!);
        }
        catch
        {
            continue;
        }
        return date;
    }
}

decimal ReadAmountFromConsole()
{
    while (true)
    {
        decimal amount;

        Console.Clear();
        Console.Write("Введите сумму:");
        string? idString = Console.ReadLine();

        if (string.IsNullOrEmpty(idString))
        {
            continue;
        }

        try
        {
            amount = decimal.Parse(idString!);
        }
        catch
        {
            continue;
        }
        return amount;
    }
}