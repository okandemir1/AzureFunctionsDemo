using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using ToDoItems.Models;

namespace ToDoItems.Ingress.Api
{
    public static class Function1
    {
        //Ýlla gelen request'i cast etmeme gerek yok modeli de alabilir
        [FunctionName("CreaterToDo")]
        public static async Task<IActionResult> Run(
            //[HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v2/CreateToDo")] HttpRequest req,
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v2/CreateToDo")] ToDoItem todoItem,
            [ServiceBus(queueOrTopicName:"todoitemqueue", Connection = "ServiceBusConnectionString")] IAsyncCollector<dynamic> serviceBusCollector,
            ILogger log)
        {
            //var bodyJson = await req.ReadAsStringAsync();
            //var todoItem = System.Text.Json.JsonSerializer.Deserialize<ToDoItem>(bodyJson);

            await serviceBusCollector.AddAsync(todoItem);

            return new OkObjectResult("TodoItem Servis Bus'a Eklendi");
        }
    }
}
