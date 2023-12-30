using Adressbook.Enums;

namespace Adressbook.Interfaces
{
    /// <summary>
    /// An interface representing the result of a service operation, containing a result object and a status.
    /// </summary>
    public interface IServiceResult
    {
        /// <summary>
        /// Get's or set's the result of the object thats been operated.
        /// </summary>
        object Result { get; set; }

        /// <summary>
        /// Gets or sets the status of the service operation.
        /// </summary>
        ServiceResultStatus Status { get; set; }
    }
}