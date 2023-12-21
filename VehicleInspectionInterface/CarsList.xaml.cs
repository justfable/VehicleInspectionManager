using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using VehicleInspectionManager;

namespace VehicleInspectionInterface
{
    public partial class CarsList : UserControl
    {
        public event EventHandler BackRequested;
        public Techosmotr _techosmotr;
        public CarsList()
        {
            // Инициализация компонентов интерфейса пользователя
            InitializeComponent();
            _techosmotr = new Techosmotr("MyDb.db");
            RefreshCarsList();
        }
        public void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // При нажатии кнопки "Назад" вызываем событие, чтобы уведомить родительское окно
            BackRequested?.Invoke(this, new EventArgs());
        }

        public void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика поиска автомобиля по номеру
            var foundCar = _techosmotr.FindCarByNumber(NumberSearchTextBox.Text);

            if (foundCar != null)
            {
                // Если автомобиль найден, создается новый список с одним найденным автомобилем
                var filteredCars = new List<Car> { foundCar };
                // Поулченный список устанавливается в качестве источника данных для отображаения информации об автомобилях
                CarsListView.ItemsSource = filteredCars;
            }
            else
            {
                MessageBox.Show("Автомобиль с таким номером не найден.");
            }

        }

        public void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarsListView.SelectedItem is Car selectedCar)
            {
                EditCar EditCarControl = new EditCar(); // Создаем новый экземпляр окна
                this.Content = EditCarControl;
                EditCarControl.InitializeFields(selectedCar);
            }
            else
            {
                MessageBox.Show("Выберите автомобиль для редактирования.");
            }
        }



        private void DeleteSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Car selectedCar in CarsListView.SelectedItems)
            {
                _techosmotr.RemoveCar(selectedCar.Number);
            }
            RefreshCarsList();
        }

        private void RefreshCarsList()
        {
            // Обновление списка всех автомобилей
            CarsListView.ItemsSource = _techosmotr.GetAllCars();
        }
    }
}
