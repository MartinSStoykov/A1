using System.Collections.Generic;
using System.Threading.Tasks;
using A1.Models;

namespace A1.DL
{
    public interface IMotorRepository
    {
        Task Add(Motor motor);

        Task<IEnumerable<Motor>> GetAll();

        Task<IEnumerable<Motor>> GetAllByYear(int Year);
    }
}