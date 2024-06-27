using RecipeAppWPF3.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace RecipeAppWPF3.Models
{
    public class Recipe : INotifyPropertyChanged
    {
        private string _name;
        private ObservableCollection<Ingredient> _ingredients;
        private ObservableCollection<string> _steps;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ObservableCollection<Ingredient> Ingredients
        {
            get => _ingredients;
            set
            {
                _ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }

        public ObservableCollection<string> Steps
        {
            get => _steps;
            set
            {
                _steps = value;
                OnPropertyChanged(nameof(Steps));
            }
        }

        public Recipe()
        {
            Ingredients = new ObservableCollection<Ingredient>();
            Steps = new ObservableCollection<string>();
        }

        public int CalculateTotalCalories()
        {
            return Ingredients.Sum(i => i.Calories);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
