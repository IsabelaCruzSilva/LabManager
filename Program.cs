using Microsoft.Data.Sqlite;
using LabManager.Database; 
using LabManager.Repositories;
using LabManager.Models;

var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);
var computerRepository = new ComputerRepository(databaseConfig); 
var labRepository = new LabRepository(databaseConfig);

var modelName = args[0]; 
var modelAction = args[1]; 


if (modelName == "Computer")
{
    if(modelAction == "List")
    {
        Console.WriteLine("List Computer");
        foreach (var computer in computerRepository.GetAll())
        {
            Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor); 
        }
        
    }

    if(modelAction == "New")
    {

        Console.WriteLine("Computer New");
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args [4]; 
        
        var computer = new Computer(id, ram, processor); 
        computerRepository.Save(computer); 

    }

    if(modelAction == "Update")
    {
        Console.WriteLine("Computer Update");
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args [4]; 

       if(computerRepository.ExistsById(id))
        {
            var computer = new Computer(id, ram, processor);
            computerRepository.Update(computer);
        }
        else
        {
            Console.WriteLine($"O computador com id {id} não existe!");
        }
    }


    if(modelAction == "Delete")
    {
        Console.WriteLine("Computer Delete");
        var id = Convert.ToInt32(args[2]);

        if(computerRepository.ExistsById(id))
        {
            computerRepository.Delete(id);
        }
        else
        {
            Console.WriteLine($"O computador com id {id} não existe!");
        }
    }

    if(modelAction == "Show")
    {
        Console.WriteLine("Computer Show");

        var id = Convert.ToInt32(args[2]);

        if(computerRepository.ExistsById(id))
        {
        var computer = computerRepository.GetById(id); 
        Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}"); 
        }
        else
        {
            Console.WriteLine($"O computador {id} não existe"); 
        }
    }
}

//---------------------------------------------------------------------------------------------------------------------


if(modelName == "Lab")
{

    if(modelAction == "List")
    {
        Console.WriteLine("List Labs");
        foreach(var lab in labRepository.GetAll())
        {
            Console.WriteLine($"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}");
        }
    }

    if(modelAction == "New")
    {
        Console.WriteLine("Lab New");
        var id = Convert.ToInt32(args[2]);
        var number = args[3];
        var name = args[4];
        var block = args[5];
        var lab = new Lab(id, number, name, block);
        labRepository.Save(lab);
    }

    if(modelAction == "Update")
    {
        Console.WriteLine("Lab Update");
        var id = Convert.ToInt32(args[2]);
        var number = args[3];
        var name = args[4];
        var block = args[5];

        if(labRepository.ExistsById(id))
        {
            var lab = new Lab(id, number, name, block);
            labRepository.Update(lab);
        }
        else
        {
            Console.WriteLine($"O laboratório com id {id} não existe!");
        }
        
    }


    if(modelAction == "Delete")
    {
        Console.WriteLine("Lab Delete");
        var id = Convert.ToInt32(args[2]);
        
        if(labRepository.ExistsById(id))
        {
            labRepository.Delete(id);
        }
        else
        {
            Console.WriteLine($"O laboratório com id {id} não existe!");
        }
 
    }

    if(modelAction == "Show")
    {
        Console.WriteLine("Lab Show");
        var id = Convert.ToInt32(args[2]);

        if(labRepository.ExistsById(id))
        {
            var lab = labRepository.GetById(id);
            Console.WriteLine($"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}");
        }
        else
        {
            Console.WriteLine($"O laboratório com id {id} não existe!");
        }
    }
}

