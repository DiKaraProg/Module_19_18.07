using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Module_19
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IView
    {
        Presenter presenter;
        public int Id { get; }
        
        public string Type { get => TypeChoise.Text; }
        public string Name { get => NameTxt.Text ; set => NameTxt.Text = value; }
        public int Age
        {
           
        get
            {
                try
                {
                    return Convert.ToInt32(AgeTxt.Text);
                }
                catch (Exception)
                {
                    Model.Popup("The input weight must be an integer or floating point");

                    return -1;
                }
            }
            set
            {
                try
                {
                    Age = Convert.ToInt32(AgeTxt.Text);
                }
                catch (Exception)
                {

                    Model.Popup("The input weight must be an integer or floating point");
                }
            }
        }
        


		
        public double Weight
        {
            get
            {
                try
                {
                   return Convert.ToDouble(WeihgtTxt.Text);
                }
                catch (Exception)
                {
                    Model.Popup("The input weight must be an integer or floating point");
                    return -1;

                }
            }
            set
            {
                try
                {
                    Weight = Convert.ToDouble(WeihgtTxt.Text);
                }
                catch (Exception)
                {
                    Model.Popup("The input weight must be an integer or floating point");
                }
            }
        }

        public int SaveIndexChoise { get=>SaveChoise.SelectedIndex; set => SaveChoise.SelectedIndex = value; }

        //public Animal animal;
        public IAnimal animal;

        public MainWindow()
        {
            
            InitializeComponent();
            presenter = new Presenter(this);
            
            this.Closing += (s, e) => presenter.SaveAnimalBase();

            this.Loaded += (s, e) => AnimalGrid.DataContext = presenter.LoadAnimals();

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
                presenter.AddAnimal();
                NameTxt.Text = String.Empty;
                AgeTxt.Text = String.Empty;
                WeihgtTxt.Text = String.Empty;
                //AnimalGrid.DataContext = null;
                AnimalGrid.DataContext = presenter.GetAllAnimal();      
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            
            presenter.RemoveAnimal();
            AnimalGrid.DataContext = null;
            AnimalGrid.DataContext = presenter.GetAllAnimal();
        }

        private void AnimalGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            animal = (IAnimal)AnimalGrid.SelectedItem;
        }

        private void AnimalGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (animal ==null) return;
            
            presenter.Edit(animal);
            AnimalGrid.DataContext = null;
            AnimalGrid.DataContext = presenter.GetAllAnimal();

        }

        private void SaveTo_Click(object sender, RoutedEventArgs e)
        {
            presenter.SaveTO(SaveIndexChoise);
        }
    }
}
