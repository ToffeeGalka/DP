using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators
{
    public interface IPostValidator
    {
        public void Validate(Post post);
    }
}
