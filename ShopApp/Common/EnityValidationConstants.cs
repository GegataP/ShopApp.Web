namespace ShopApp.Common
{
    public static class EnityValidationConstants
    {
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
