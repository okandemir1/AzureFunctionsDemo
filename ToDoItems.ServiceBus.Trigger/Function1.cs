using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using ToDoItems.Models;

namespace ToDoItems.ServiceBus.Trigger
{
    public class Function1
    {
        //CosmosDbye aktaral�m
        //Var olan bir id ile g�nderme i�lemi yap�nca otomatik g�ncelliyor
        //[FunctionName("Function1")]
        //public async Task Run([ServiceBusTrigger("todoitemqueue", Connection = "ServiceBusConnectionString")] ToDoItem todoItem, 
        //    [CosmosDB(databaseName:"ToDoListCosmoDb", containerName:"ToDoItemsContainer",
        //    Connection = "CosmoDbConnectionString")]  IAsyncCollector<dynamic> todoItemsCollector,
        //    ILogger log)
        //{
        //    //Burada stringe �evirelecek modele ToString methodu ekledim
        //    log.LogInformation($"C# ServiceBus queue trigger function processed message: {todoItem}");

        //    await todoItemsCollector.AddAsync(todoItem);
        //}

        //Ayn� i�lem farkl� kullan�m out dynamic kullan�yorsak async olamaz
        [FunctionName("Function2")]
        public void Run2([ServiceBusTrigger("todoitemqueue", Connection = "ServiceBusConnectionString")] ToDoItem todoItem,
            [CosmosDB(databaseName:"ToDoListCosmoDb", containerName:"ToDoItemsContainer",
            Connection = "CosmoDbConnectionString")]  out dynamic todoItemOut,
            ILogger log)
        {
            //Burada stringe �evirelecek modele ToString methodu ekledim
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {todoItem}");

            todoItemOut = todoItem;
        }
    }
}
