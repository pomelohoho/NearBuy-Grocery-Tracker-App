using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace backend
{
    public static class InventoryController
    {
        [FunctionName("AddToInventory")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "inventory/add")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Processing request to add an item to the inventory.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            string name = data?.name;
            int quantity = data?.quantity;

            if (string.IsNullOrEmpty(name) || quantity <= 0)
            {
                return new BadRequestObjectResult("Please provide valid item name and quantity.");
            }

            // Here, you would add logic to store the inventory item in the database.

            return new OkObjectResult($"Item '{name}' added to inventory with quantity {quantity}.");
        }

        [FunctionName("GetInventory")]
        public static async Task<IActionResult> GetInventory(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "inventory/get")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Processing request to retrieve inventory.");

            // Logic to retrieve inventory from the database would go here.

            // Example response (mock data):
            var inventory = new[] { new { name = "Pomelos", quantity = 10 }, new { name = "Rodolfos", quantity = 10 } };

            return new OkObjectResult(inventory);
        }

    
    }
}
