using RecipeAppWPF3.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace RecipeAppWPF3.Models
{
    public class RecipeManager : INotifyPropertyChanged
    {
        private ObservableCollection<Recipe> _recipes;

        public ObservableCollection<Recipe> Recipes
        {
            get => _recipes;
            set
            {
                _recipes = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }

        public RecipeManager()
        {
            Recipes = new ObservableCollection<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
            SortRecipes();
        }

        public void SortRecipes()
        {
            Recipes = new ObservableCollection<Recipe>(Recipes.OrderBy(r => r.Name));
            OnPropertyChanged(nameof(Recipes));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
