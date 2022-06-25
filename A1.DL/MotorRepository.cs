using A1.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace A1.DL
{
    public class MotorRepository : IMotorRepository
    {
        public MotorRepository()
        {

        }
        public Task Add(Motor motor)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Motor>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Motor>> GetAllByYear(int Year)
        {
            throw new NotImplementedException();
        }
    }
}