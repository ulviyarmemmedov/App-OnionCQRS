﻿using App.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Brand:BaseEntity
    {
        public Brand()
        {
            
        }
        public Brand(string name)
        {
            Name = name;
        }
        public required string Name { get; set; }
    }
}
