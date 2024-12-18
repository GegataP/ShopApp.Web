namespace ShopApp.Common
{
    public static class EnityValidationConstants
    {
        public class User
        {
            public const int UserFirstNameMaxLength = 350;
            public const int UserLastNameMaxLength = 350;
            
        }

        public  class Product
        {
            public const int ProductNameMaxLength = 150;

            public const int ProductDescriptionMaxLength = 1500;

            public const int ProductImgUrlMaxLength = 550;

        }

        public  class Category
        {
            public const int CategoryNameMaxLength = 100;

        }
    }
}
