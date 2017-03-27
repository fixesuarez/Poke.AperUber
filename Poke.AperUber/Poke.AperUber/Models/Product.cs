using MvvmHelpers;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Poke.AperUber.Models
{
    [Table( "Products" )]
    public class Product : ObservableObject
    {
        string _name;
        string _foodCategoryName;
        double _price;
        string _image;

        #region Properties
        [PrimaryKey]
        public string Name
        {
            get { return _name; }
            set { SetProperty( ref _name, value ); }
        }

        [ForeignKey( typeof( FoodCategory ) )]
        public string FoodCategoryName
        {
            get { return _foodCategoryName; }
            set { SetProperty( ref _foodCategoryName, value ); }
        }

        public double Price
        {
            get { return _price; }
            set { SetProperty( ref _price, value ); }
        }

        public string Image
        {
            get { return _image; }
            set { SetProperty( ref _image, value ); }
        }
        #endregion
    }
}
