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
        //CosmosDbye aktaralým
        //Var olan bir id ile gönderme iþlemi yapýnca otomatik güncelliyor
        //[FunctionName("Function1")]
        //public async Task Run([ServiceBusTrigger("todoitemqueue", Connection = "ServiceBusConnectionString")] ToDoItem todoItem, 
        //    [CosmosDB(databaseName:"ToDoListCosmoDb", containerName:"ToDoItemsContainer",
        //    Connection = "CosmoDbConnectionString")]  IAsyncCollector<dynamic> todoItemsCollector,
        //    ILogger log)
        //{
        //    //Burada stringe çevirelecek modele ToString methodu ekledim
        //    log.LogInformation($"C# ServiceBus queue trigger function processed message: {todoItem}");

        //    await todoItemsCollector.AddAsync(todoItem);
        //}

        //Ayný iþlem farklý kullaným out dynamic kullanýyorsak async olamaz
        [FunctionName("Function2")]
        public void Run2([ServiceBusTrigger("todoitemqueue", Connection = "ServiceBusConnectionString")] ToDoItem todoItem,
            [CosmosDB(databaseName:"ToDoListCosmoDb", containerName:"ToDoItemsContainer",
            Connection = "CosmoDbConnectionString")]  out dynamic todoItemOut,
            ILogger log)
        {
            //Burada stringe çevirelecek modele ToString methodu ekledim
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {todoItem}");

            todoItemOut = todoItem;
        }
    }
}
