using AzureFunctionDemo.Entities;
using AzureFunctionDemo.Entities.Nav;

namespace AzureFunctionDemo.Mappers
{
    public interface IPdrMapper
    {
        InvCommunicaion ToInvCommunication(Pdr supplyPoint);
    }
}