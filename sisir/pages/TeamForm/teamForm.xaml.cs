using sisir.pages.employeeData;
namespace sisir.pages.teamForm;

public partial class TeamForm : ContentPage
{
    private LocalDbService _dbService;

    public TeamForm()
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
        var team = new Team
        {
            TeamName = EntryTeamName.Text,
        };

        if (string.IsNullOrWhiteSpace(team.TeamName))
        {
            await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля корректно.", "ОК");
            return;
        }

        await _dbService.CreateTeam(team);
        await DisplayAlert("Успех", "Команда успешно добавлена!", "ОК");
        await Shell.Current.GoToAsync("//MainPage");
    }
}