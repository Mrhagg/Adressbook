using Adressbook.Enums;

namespace Adressbook.Interfaces
{
    public interface IServiceResult
    {
        object Result { get; set; }
        ServiceResultStatus Status { get; set; }
    }
}