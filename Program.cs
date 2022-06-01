using Microsoft.Data.Sqlite;
using LabManager.Database; 
using LabManeger.Repositories;
using LabManager.Models;

var databaseConfig = new DatabaseConfig();

var databaseSetup = new DatabaseSetup(databaseConfig);

var computerRepository = new ComputerRepository(databaseConfig); 

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

        var computer = new Computer(id, ram, processor); 
        computerRepository.Update(computer); 
    }


    if(modelAction == "Delete")
    {
        Console.WriteLine("Computer Delete");
        var id = Convert.ToInt32(args[2]);
        computerRepository.Delete(id); 
    }

    if(modelAction == "Show")
    {
        Console.WriteLine("Computer Show");
        var id = Convert.ToInt32(args[2]);
        var computer = computerRepository.GetById(id); 
        Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor); 
    }

    
}