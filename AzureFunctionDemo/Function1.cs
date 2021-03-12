using System;
using System.Text.Json;
using AzureFunctionDemo.Entities;
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
        private readonly ISupplyPointMapper<SupplyPoint> _supplyPointMapper;

        //private readonly IPodMapper _podMapper;
        //private readonly IPdrMapper _pdrMapper;

        public Function1(/*IPodMapper podMapper, IPdrMapper pdrMapper*/ISupplyPointMapper<SupplyPoint> supplyPointMapper)
        {
            _supplyPointMapper = supplyPointMapper;
            /*_podMapper = podMapper;
_pdrMapper = pdrMapper;*/
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

            //var invCommPod = _podMapper.ToInvCommunication(pod);
            //var invCommPdr = _pdrMapper.ToInvCommunication(pdr);

            var invCommPod = _supplyPointMapper.ToInvCommunication(pod);

            Console.WriteLine(JsonSerializer.Serialize(invCommPod));
            //Console.WriteLine(JsonSerializer.Serialize(invCommPdr));
        }
    }
}
