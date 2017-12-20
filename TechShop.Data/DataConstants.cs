namespace TechShop.Data
{
    public static class DataConstants
    {
        //Product data model constants:
        public const int ProductNameMinLength = 3;
        public const int ProductNameMaxLength = 50;

        public const int ProductDescriptionMinLength = 10;
        public const int ProductDescriptionMaxLength = 250;

        //User data model constants:
        public const int NameMinLength = 3;
        public const int NameMaxLength = 30;

        public const int AddressMinLength = 10;
        public const int AddressMaxLength = 150;

        //Category data model constants:
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 30;

        public const int PictureUrlMinLength = 5;
        public const int PictureUrlMaxLength = 1000;

        //Comment data model constants:
        public const int ContentMinLength = 4;
        public const int ContentMaxLength = 100;

        //Order data model constants:
        public const int OrderAddressMinLength = 10;
        public const int OrderAddressMaxLength = 150;

    }
}
