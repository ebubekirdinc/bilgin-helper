using Bilgin.Test.DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bilgin.Test.Business
{
    public class CategoryManager
    {
        public Category Add(Category item)
        {
            CategoryDal categoryDal = new CategoryDal();
            return categoryDal.Add(item);
        }
    }
}
