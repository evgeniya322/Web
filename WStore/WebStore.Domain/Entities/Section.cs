﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    [Table("Sections")]
    public class Section : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }


        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual Section ParentSections { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
