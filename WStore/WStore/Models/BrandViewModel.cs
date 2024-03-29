﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WStore.Models
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
