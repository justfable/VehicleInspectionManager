using System;
using System.Collections.Generic;
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

namespace VehicleInspectionInterface
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        public void AddCar_Click(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр UserControl для добавления нового автомобиля.
            AddNewCar addCarControl = new AddNewCar();
            // Подписываемся на событие BackRequested
            addCarControl.BackRequested += AddNewCarsControl_BackRequested;
            this.Content = addCarControl;
        }

        public void AddNewCarsControl_BackRequested(object sender, EventArgs e)
        {
            // Возвращаемся к начальному содержимому MainWindow
            Content = MainGrid;
        }


        public void CarList_Click(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр UserControl для отображения списка автомобилей.
            CarsList carsListControl = new CarsList();
            // Подписываемся на событие BackRequested
            carsListControl.BackRequested += CarsListControl_BackRequested;
            this.Content = carsListControl;
        }

        public void CarsListControl_BackRequested(object sender, EventArgs e)
        {
            // Возвращаемся к начальному содержимому MainWindow
            Content = MainGrid;
        }

    }
}
