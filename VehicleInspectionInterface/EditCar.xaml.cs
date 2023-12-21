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
using System.Windows.Shapes;
using VehicleInspectionManager;

namespace VehicleInspectionInterface
{
    public partial class EditCar : UserControl
    {
        public Techosmotr _techosmotr = new Techosmotr("MyDb.db");
        public Car CurrentCar { get; set; }

        public EditCar()
        {
            // Инициализация компонентов интерфейса пользователя
            InitializeComponent();
        }
        //Метод используется для заполнения пользовательского интерфейса данными конкретного автомобиля
        public void InitializeFields(Car car)
        {
            // Присваивает внутренней переменной CurrentCar значение объекта car, который передается в метод.
            CurrentCar = car;
            MarkTextBox.Text = car.Mark;
            ModelTextBox.Text = car.Model;
            YearTextBox.Text = car.Year.ToString();
            NumberTextBox.Text = car.Number;
            InspectionCheckBox.IsChecked = car.Inspection;
        }

        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка введенных данных
                if (!int.TryParse(YearTextBox.Text, out int year))
                {
                    MessageBox.Show("Введите корректный год выпуска.");
                    return;
                }

                // Обновление свойств текущего автомобиля
                CurrentCar.Mark = MarkTextBox.Text;
                CurrentCar.Model = ModelTextBox.Text;
                CurrentCar.Year = year;
                CurrentCar.Number = NumberTextBox.Text;
                CurrentCar.Inspection = InspectionCheckBox.IsChecked ?? false;

                // Сохранение изменений в базу данных
                _techosmotr.UpdateCar(CurrentCar);

                // Вывод сообщения пользователю
                MessageBox.Show("Изменения сохранены успешно.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении изменений: {ex.Message}");
            }
        }

    }
}
