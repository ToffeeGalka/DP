﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebData.Entities
{
    public class DoctorEntity
    {
        public int Id { get; set; }
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? SecName { get; set; }
        public int IdPost { get; set; }
        public PostEntity Post { get; set; }
    }
}
