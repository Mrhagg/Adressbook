using Adressbook.Enums;

namespace Adressbook.Models.Responses;

public interface IServiceResult
{
    ServiceResultStatus Status { get; set; }
    object Result { get; set; }


}


public class ServiceResult : IServiceResult
{
    public ServiceResultStatus Status { get; set; }
    public object Result { get; set; } = null!;
}
