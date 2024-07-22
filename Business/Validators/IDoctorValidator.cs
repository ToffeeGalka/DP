using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebData;

namespace Business.Validators
{
    public interface IDoctorValidator
    {
        public Task Validate(Doctor doctor, AppDbContext dbContext);
    }
}
