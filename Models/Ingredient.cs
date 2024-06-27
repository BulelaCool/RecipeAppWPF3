using System.ComponentModel;

namespace RecipeAppWPF3.Models
{
    public class Ingredient : INotifyPropertyChanged
    {
        private string _name;
        private double _quantity;
        private string _unit;
        private int _calories;
        private string _foodGroup;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public double Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public string Unit
        {
            get => _unit;
            set
            {
                _unit = value;
                OnPropertyChanged(nameof(Unit));
            }
        }

        public int Calories
        {
            get => _calories;
            set
            {
                _calories = value;
                OnPropertyChanged(nameof(Calories));
            }
        }

        public string FoodGroup
        {
            get => _foodGroup;
            set
            {
                _foodGroup = value;
                OnPropertyChanged(nameof(FoodGroup));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
