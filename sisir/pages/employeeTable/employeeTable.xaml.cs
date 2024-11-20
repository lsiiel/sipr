using sisir.pages.employeeData;

namespace sisir.pages.employeeTable
{
    public partial class EmployeeTable : ContentPage
    {
    //     private readonly LocalDbService _dbService;

    //     public EmployeeTable(LocalDbService dbService)
    //     {
    //         _dbService = dbService;
    //         InitializeComponent();
    //         LoadEmployees();
    //     }

    //     private async void LoadEmployees()
    //     {
    //         EmployeesGrid.RowDefinitions.Clear();
    //         EmployeesGrid.Children.Clear();

    //         var employees = await _dbService.GetEmployee();
    //         AddEmployeeRows(employees);
    //     }

    //     private void AddEmployeeRows(IEnumerable<EmployeeData> employees)
    //     {
    //         int rowIndex = 1;

    //         foreach (var employee in employees)
    //         {
    //             EmployeesGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

    //             AddLabelToGrid(employee.FirstName, rowIndex, 0);
    //             AddLabelToGrid(employee.LastName, rowIndex, 1);
    //             AddLabelToGrid(employee.Email, rowIndex, 2);
    //             AddLabelToGrid(employee.PhoneNumber, rowIndex, 3);
    //             AddLabelToGrid(employee.JobTitle, rowIndex, 4);

    //             AddEditAndDeleteButtonsToGrid(employee, rowIndex, 5);

    //             rowIndex++;
    //         }
    //     }

    //     private void AddEditAndDeleteButtonsToGrid(EmployeeData employee, int row, int column)
    //     {
    //         var actionsStack = new StackLayout
    //         {
    //             Orientation = StackOrientation.Horizontal,
    //             HorizontalOptions = LayoutOptions.Center,
    //             VerticalOptions = LayoutOptions.Center,
    //             Spacing = 10
    //         };

    //         var editButton = new Button
	// 		{
	// 			Text = "UPD",
	// 			HorizontalOptions = LayoutOptions.Center,
	// 			VerticalOptions = LayoutOptions.Center,
	// 			BackgroundColor = (Color)Application.Current.Resources["Yellow"]
	// 		};
	// 		editButton.Clicked += async (sender, e) => await OnEditButtonClicked(employee);
	// 		actionsStack.Children.Add(editButton);

	// 		var deleteButton = new Button
	// 		{
	// 			Text = "DEL",
	// 			HorizontalOptions = LayoutOptions.Center,
	// 			VerticalOptions = LayoutOptions.Center,
	// 			BackgroundColor = (Color)Application.Current.Resources["Red"]
	// 		};
	// 		deleteButton.Clicked += async (sender, e) => await OnDeleteButtonClicked(employee);
	// 		actionsStack.Children.Add(deleteButton);


    //         EmployeesGrid.Children.Add(actionsStack);
    //         Grid.SetRow(actionsStack, row);
    //         Grid.SetColumn(actionsStack, column);
    //     }

    //     private async Task OnEditButtonClicked(EmployeeData employee)
    //     {
         
    //     }

    //     private async Task OnDeleteButtonClicked(EmployeeData employee)
    //     {
    //         bool confirm = await Application.Current.MainPage.DisplayAlert("Подтверждение", "Вы уверены, что хотите удалить эту запись?", "Да", "Нет");
    //         if (confirm)
    //         {
    //             await _dbService.DeleteEmployee(employee);
    //             LoadEmployees();
    //         }
    //     }

    //     private void AddLabelToGrid(string text, int row, int column)
    //     {
    //         var frame = new Frame
    //         {
    //             BorderColor = Colors.Black,
    //             Padding = 5,
    //             Margin = 0,
    //             CornerRadius = 0,
    //             Content = new Label
    //             {
    //                 Text = text,
    //                 HorizontalOptions = LayoutOptions.Center,
    //                 VerticalOptions = LayoutOptions.Center,
    //                 FontSize = 18
    //             }
    //         };

    //         EmployeesGrid.Children.Add(frame);
    //         Grid.SetRow(frame, row);
    //         Grid.SetColumn(frame, column);
    //     }

	// 	private async void OnBackButtonClicked(object sender, EventArgs e)
	// 	{
	// 		await Shell.Current.GoToAsync("//MainPage");
	// 	}
    }
}
