﻿using BilginHelper.Entities.Abstract;
using System;

namespace Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
