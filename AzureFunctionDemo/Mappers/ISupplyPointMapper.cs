using AzureFunctionDemo.Entities;
using AzureFunctionDemo.Entities.Nav;

namespace AzureFunctionDemo.Mappers
{
    public interface ISupplyPointMapper<T> where T : class
    {
        InvCommunicaion ToInvCommunication(SupplyPoint supplyPoint);
    }
}