using Microsoft.Extensions.Logging;
using sisir.pages.employeeForm;
using sisir.pages.employeeData;
using sisir.pages.employeeTable;
using sisir.pages.startPage;
using sisir.pages.positionForm;
using sisir.pages.qualificationForm;
using sisir.pages.teamForm;
using sisir.pages.skillForm;

namespace sisir;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<LocalDbService>();
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<EmployeeForm>();
		builder.Services.AddTransient<EmployeeTable>();
		builder.Services.AddTransient<PositionForm>();
		builder.Services.AddTransient<QualificationForm>();
		builder.Services.AddTransient<SkillForm>();
		builder.Services.AddTransient<TeamForm>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
