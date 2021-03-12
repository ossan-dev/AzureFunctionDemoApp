using AzureFunctionDemo.Entities;
using AzureFunctionDemo.Entities.Nav;

namespace AzureFunctionDemo.Mappers
{
    public interface ISupplyPointMapper<T> where T : SupplyPoint
    {
        InvCommunicaion ToInvCommunication(SupplyPoint supplyPoint);
        NavSupplyPoint ToSupplyPointStatus(SupplyPoint supplyPoint);
    }
}