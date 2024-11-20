using sisir.pages.employeeData;
namespace sisir.pages.skillForm;

public partial class SkillForm : ContentPage
{
    private LocalDbService _dbService;

    public SkillForm()
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
        var skill = new Skill
        {
            SkillName = EntrySkillName.Text
        };

        if (string.IsNullOrWhiteSpace(skill.SkillName))
        {
            await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля корректно.", "ОК");
            return;
        }

        await _dbService.CreateSkill(skill);
        await DisplayAlert("Успех", "Навык успешно добавлен!", "ОК");
        await Shell.Current.GoToAsync("//MainPage"); // Возврат на предыдущую страницу
    }
}