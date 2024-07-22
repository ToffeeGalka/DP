using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebData;
using Microsoft.EntityFrameworkCore;

namespace Business.Validators
{
    public interface IDispRegValidator
    {
        public Task Validate(DispReg dispReg, AppDbContext dbContext);
    }
}
