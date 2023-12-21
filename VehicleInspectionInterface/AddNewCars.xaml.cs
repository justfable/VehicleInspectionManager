using System;
using System.Windows;
using System.Windows.Controls;
using VehicleInspectionManager;

namespace VehicleInspectionInterface
{
    public partial class AddNewCar : UserControl
    {
        public event EventHandler BackRequested;
        public Techosmotr _techosmotr;

        public AddNewCar()
        {
            // Инициализация компонентов интерфейса пользователя
            InitializeComponent();
            _techosmotr = new Techosmotr("MyDb.db"); // Укажите здесь путь к вашей базе данных
        }

        public void BackButtonANC_Click(object sender, RoutedEventArgs e)
        {
            // При нажатии кнопки "Назад" вызываем событие, чтобы уведомить родительское окно
            BackRequested?.Invoke(this, new EventArgs());
        }
        public void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Преобразование года из текста в число
                if (!int.TryParse(YearTextBox.Text, out int year))
                {
                    MessageBox.Show("Введите корректный год выпуска.");
                    return;
                }

                // Создание нового объекта Car
                Car newCar = new Car(
                    mark: MarkTextBox.Text,
                    model: ModelTextBox.Text,
                    year: year,
                    number: NumberTextBox.Text
                )
                {
                    // Установка статуса техосмотра
                    Inspection = chkInspection.IsChecked ?? false
                };

                // Добавление автомобиля в базу данных
                _techosmotr.AddCar(newCar);

                MessageBox.Show("Автомобиль добавлен успешно.");
                MarkTextBox.Text = string.Empty;
                ModelTextBox.Text = string.Empty;
                YearTextBox.Text = string.Empty;
                NumberTextBox.Text = string.Empty;
                chkInspection.IsChecked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении автомобиля: {ex.Message}");
            }
        }
    }
}
