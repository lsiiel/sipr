using sisir.pages.employeeForm;
using sisir.pages.employeeData;
using sisir.pages.teamForm;
using sisir.pages.employeeTable;
using sisir.pages.positionForm;
using sisir.pages.qualificationForm;
using sisir.pages.skillForm;
using sisir.pages.projectForm;
namespace sisir.pages.startPage;

public partial class MainPage : ContentPage
{
	
	public MainPage()
	{
		InitializeComponent();
	}

	private async void onStartButtonClicked(object sender, EventArgs e) {
		await Shell.Current.Navigation.PushAsync(new EmployeeForm());
	}

	private async void onViewEmployeeButtonClicked(object sender, EventArgs e) {
		await Shell.Current.Navigation.PushAsync(new EmployeeTable());
	}

	private async void onAddPositionButtonClicked(object sender, EventArgs e) {
		await Shell.Current.Navigation.PushAsync(new PositionForm());
	}

	private async void onAddQualificationButtonClicked(object sender, EventArgs e) {
		await Shell.Current.Navigation.PushAsync(new QualificationForm());
	}

	private async void onAddSkillButtonClicked(object sender, EventArgs e) {
		await Shell.Current.Navigation.PushAsync(new SkillForm());
	}

	private async void onAddTeamButtonClicked(object sender, EventArgs e) {
		await Shell.Current.Navigation.PushAsync(new TeamForm());
	}

	private async void onAddProjectButtonClicked(object sender, EventArgs e) {
		await Shell.Current.Navigation.PushAsync(new ProjectForm());
	}
}
