using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using sisir.pages.employeeData;

namespace sisir.pages.projectForm
{
    public partial class ProjectForm : ContentPage
    {
        private LocalDbService _dbService;

        public ProjectForm()
        {
            InitializeComponent();
            _dbService = new LocalDbService();
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private async void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            // var qualification = new Qualification
            // {
            //     LevelName = EntryQualificationName.Text,
            //     Coefficient = decimal.TryParse(EntrySalaryCoefficient.Text, out var coefficient) ? coefficient : 0
            // };

            // if (string.IsNullOrWhiteSpace(qualification.LevelName) || qualification.Coefficient <= 0)
            // {
            //     await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля корректно.", "ОК");
            //     return;
            // }

            // await _dbService.AddQualification(qualification);
            // await DisplayAlert("Успех", "Квалификация успешно добавлена!", "ОК");
            // await Shell.Current.GoToAsync(".."); // Возврат на предыдущую страницу
        }
    }
}
