using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace RecipeAppWPF3
{
    public class Step
    {
        public string Description { get; set; }
    }

    public class Recipe : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public ObservableCollection<Step> Steps { get; set; }

        // Other properties

        public Recipe()
        {
            Ingredients = new ObservableCollection<Ingredient>();
            Steps = new ObservableCollection<Step>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }

    public class RecipeViewModel : INotifyPropertyChanged
    {
        private string newStepDescription;

        public ObservableCollection<Recipe> Recipes { get; set; }
        public string NewStepDescription
        {
            get => newStepDescription;
            set
            {
                newStepDescription = value;
                OnPropertyChanged(nameof(NewStepDescription));
            }
        }

        private Recipe selectedRecipe;
        public Recipe SelectedRecipe
        {
            get => selectedRecipe;
            set
            {
                selectedRecipe = value;
                OnPropertyChanged(nameof(SelectedRecipe));
            }
        }

        public ICommand AddStepCommand { get; }

        public RecipeViewModel()
        {
            Recipes = new ObservableCollection<Recipe>();
            AddStepCommand = new RelayCommand(AddStep);
        }

        private void AddStep()
        {
            if (SelectedRecipe != null && !string.IsNullOrEmpty(NewStepDescription))
            {
                var newStep = new Step { Description = NewStepDescription };
                SelectedRecipe.Steps.Add(newStep);
                NewStepDescription = string.Empty;
            }
            else
            {
                // Handle error: either SelectedRecipe is null or NewStepDescription is empty
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => canExecute == null || canExecute();

        public void Execute(object parameter) => execute();

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }
    }
}
