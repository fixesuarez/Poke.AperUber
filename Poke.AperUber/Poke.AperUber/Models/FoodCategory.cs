using MvvmHelpers;
using SQLite;

namespace Poke.AperUber.Models
{
    [Table( "FoodCategory" )]
    public class FoodCategory : ObservableObject
    {
        /// <summary>
        /// Primary Key of FoodCategory Table
        /// </summary>
        string _name;
        string _cover;

        #region Properties
        [PrimaryKey]
        public string Name
        {
            get { return _name; }
            set { SetProperty( ref _name, value ); }
        }

        public string Cover
        {
            get { return _cover; }
            set { SetProperty( ref _cover, value ); }
        }
        #endregion
    }

    public enum FoodCategories
    {
        SAUCISSONS,
        RILLETTES,
        PATE
    }
}
