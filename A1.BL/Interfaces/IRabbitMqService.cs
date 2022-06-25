using A1.Models;
using System.Threading.Tasks;

namespace A1.BL.Interfaces
{
    public interface IRabbitMqService
    {
        Task PublishMotorAsync(Motor motor);
    }
}