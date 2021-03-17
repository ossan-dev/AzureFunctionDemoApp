using System;
using System.Text.Json;
using AzureFunctionDemo.Entities;
using AzureFunctionDemo.Entities.Nav;
using AzureFunctionDemo.Factory;
using AzureFunctionDemo.Mappers;
using AzureFunctionDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunctionDemo
{
    public class Function1
    {
        private readonly SupplyPointFactory _supplyPointFactory;

        public Function1(SupplyPointFactory supplyPointFactory)
        {
            _supplyPointFactory = supplyPointFactory;
        }

        [FunctionName("Function1")]
        public void Run([TimerTrigger("*/15 * * * * *")]TimerInfo myTimer)
        {
            Pod pod = new Pod();
            pod.Id = new Guid("678137fc-6ccc-49f8-ae51-dea9e921ee5e");
            pod.InsertDate = new DateTime(2020, 2, 25);
            pod.PodNo = "IT123";

            Pdr pdr = new Pdr();
            pdr.Id = new Guid("e95319e4-3782-43f6-ae0c-28495cbe53a3");
            pdr.InsertDate = new DateTime(2020, 2, 25);
            pdr.PdrNo = "00123";

            var invCommPod = _supplyPointFactory.GetSupplyPointMapper(pod).ToInvCommunication(pod);
            var invCommPdr = _supplyPointFactory.GetSupplyPointMapper(pdr).ToInvCommunication(pdr);
            var podNav = _supplyPointFactory.GetSupplyPointMapper(pod).ToSupplyPointStatus(pod);
            var pdrNav = _supplyPointFactory.GetSupplyPointMapper(pdr).ToSupplyPointStatus(pdr);

            Console.WriteLine(JsonSerializer.Serialize(invCommPod));
            Console.WriteLine(JsonSerializer.Serialize(podNav));
            Console.WriteLine(JsonSerializer.Serialize(invCommPdr));
            Console.WriteLine(JsonSerializer.Serialize(pdrNav));
        }
    }
}
