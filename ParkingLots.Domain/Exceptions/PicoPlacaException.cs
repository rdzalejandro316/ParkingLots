using System.Runtime.Serialization;
namespace ParkingLots.Domain.Exceptions;

[Serializable]
public sealed class PicoPlacaException : CoreBusinessException
{
    public PicoPlacaException()
    {
    }

    public PicoPlacaException(string msg) : base(msg)
    {
    }

    public PicoPlacaException(string message, Exception inner) : base(message, inner)
    {
    }

    private PicoPlacaException(SerializationInfo info, StreamingContext context): base(info, context)
    {
    }

}
