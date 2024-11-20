using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using sisir.pages.employeeData;
namespace sisir.pages.positionForm;

public partial class PositionForm : ContentPage
{
    private LocalDbService _dbService;

    public PositionForm()
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
        var position = new Position
        {
            Title = EntryPositionName.Text,
            Salary = decimal.TryParse(EntrySalary.Text, out var salary) ? salary : 0
        };

        if (string.IsNullOrWhiteSpace(position.Title) || position.Salary <= 0)
        {
            await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля корректно.", "ОК");
            return;
        }

        await _dbService.AddPosition(position);
        await DisplayAlert("Успех", "Должность успешно добавлена!", "ОК");
        await Shell.Current.GoToAsync(".."); // Возврат на предыдущую страницу
    }
}