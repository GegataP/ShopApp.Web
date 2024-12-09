using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Common
{
    public class EnityValidationConstants
    {
        public  class User
        {
            public const int UserNameMaxLength = 100;

            public const int UserPasswordHash = 100;

            public const int UserRoleLength = 100;
        }

        public  class Product
        {
            public const int ProductNameMaxLength = 150;

            public const int ProductDescriptionMaxLength = 1500;

            public const int ProductImgUrlMaxLength = 250;

        }

        public  class Category
        {
            public const int CategoryNameMaxLength = 100;

        }
    }
}
