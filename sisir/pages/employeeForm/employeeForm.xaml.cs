using Microsoft.Maui.Controls;
using sisir.pages.employeeData;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using sisir.pages.employeeTable;
using sisir.pages.positionForm;
using sisir.pages.qualificationForm;
using sisir.pages.skillForm;
using sisir.pages.teamForm;
using sisir.pages.projectForm;

namespace sisir.pages.employeeForm
{
    public partial class EmployeeForm : ContentPage
    {
        private readonly LocalDbService _dbService;
        public ObservableCollection<JobPosition> AvailablePositions { get; set; }
        public ObservableCollection<QualificationLevel> AvailableQualifications { get; set; }

        public EmployeeForm()
        {
            InitializeComponent();

            _dbService = new LocalDbService();

            AvailablePositions = new ObservableCollection<JobPosition>();
            AvailableQualifications = new ObservableCollection<QualificationLevel>();

            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadDataFromDatabase();
        }

        private async Task LoadDataFromDatabase()
        {
            AvailablePositions.Clear();
            AvailableQualifications.Clear();

            var positions = await _dbService.GetPositions();
            foreach (var position in positions)
            {
                AvailablePositions.Add(new JobPosition { Title = position.Title, IsSelected = false });
            }

            var qualifications = await _dbService.GetQualifications();
            foreach (var qualification in qualifications)
            {
                AvailableQualifications.Add(new QualificationLevel { LevelName = qualification.LevelName, IsSelected = false });
            }
        }

        private void OnJobPositionCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value) // Если выбран элемент
            {
                var selectedPosition = (sender as RadioButton)?.BindingContext as JobPosition;
                foreach (var position in AvailablePositions)
                {
                    if (position != selectedPosition && position.IsSelected)
                    {
                        position.IsSelected = false; // Сбрасываем выбор у других элементов
                    }
                }
            }
        }

        private void OnQualificationCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value) // Если выбран элемент
            {
                var selectedQualification = (sender as RadioButton)?.BindingContext as QualificationLevel;
                foreach (var qualification in AvailableQualifications)
                {
                    if (qualification != selectedQualification && qualification.IsSelected)
                    {
                        qualification.IsSelected = false; // Сбрасываем выбор у других элементов
                    }
                }
            }
        }



        private async void OnAddPositionButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new PositionForm());
        }

        private async void OnAddQualificationButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new QualificationForm());
        }

        private async void OnAddSkillButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new SkillForm());
        }

        private async void OnAddTeamButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new TeamForm());
        }

        private async void OnAddProjectButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new ProjectForm());
        }

        private async void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            // Проверка обязательных полей
            if (string.IsNullOrWhiteSpace(EntryFirstName.Text) ||
                string.IsNullOrWhiteSpace(EntryMiddleName.Text) ||
                string.IsNullOrWhiteSpace(EntryPassportSeries.Text) ||
                string.IsNullOrWhiteSpace(EntryPassportNumber.Text) ||
                string.IsNullOrWhiteSpace(EntryIssuedBy.Text) ||
                string.IsNullOrWhiteSpace(EntryRegistrationAddress.Text) ||
                string.IsNullOrWhiteSpace(EntryResidentialAddress.Text) ||
                string.IsNullOrWhiteSpace(EntryEmail.Text) ||
                string.IsNullOrWhiteSpace(EntryPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(EntryDateOfBirth.Text) ||
                string.IsNullOrWhiteSpace(EntryIssuedDate.Text))
            {
                await DisplayAlert("Ошибка", "Пожалуйста, заполните все обязательные поля.", "ОК");
                return;
            }

            // Проверка формата номера телефона
            string phonePattern = @"^(\+7|8)\d{10}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(EntryPhoneNumber.Text, phonePattern))
            {
                await DisplayAlert("Ошибка", "Некорректный номер телефона. Пример: +79458437662 или 89458437662.", "ОК");
                return;
            }

            // Проверка формата серии паспорта
            string passportSeriesPattern = @"^\d{4}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(EntryPassportSeries.Text, passportSeriesPattern))
            {
                await DisplayAlert("Ошибка", "Серия паспорта должна состоять из 4 цифр.", "ОК");
                return;
            }

            // Проверка формата номера паспорта
            string passportNumberPattern = @"^\d{6}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(EntryPassportNumber.Text, passportNumberPattern))
            {
                await DisplayAlert("Ошибка", "Номер паспорта должен состоять из 6 цифр.", "ОК");
                return;
            }

            // Проверка формата электронной почты
            string emailPattern = @"^[^@\s]+@[^@\s]+\.(ru|com)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(EntryEmail.Text, emailPattern))
            {
                await DisplayAlert("Ошибка", "Некорректный адрес электронной почты. Пример: example@domain.ru или example@domain.com.", "ОК");
                return;
            }

            // Проверка полей на отсутствие цифр (Имя, Фамилия, Отчество)
            string namePattern = @"^[^\d]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(EntryFirstName.Text, namePattern) ||
                !System.Text.RegularExpressions.Regex.IsMatch(EntryMiddleName.Text, namePattern) ||
                !System.Text.RegularExpressions.Regex.IsMatch(EntryLastName.Text, namePattern))
            {
                await DisplayAlert("Ошибка", "Имя, фамилия и отчество не должны содержать цифры.", "ОК");
                return;
            }

            // Проверка формата Telegram-логина
            if (!string.IsNullOrWhiteSpace(EntryTelegram.Text) && !EntryTelegram.Text.StartsWith("@"))
            {
                await DisplayAlert("Ошибка", "Логин Telegram должен начинаться с символа '@'.", "ОК");
                return;
            }

            // Проверка и парсинг даты рождения
            if (!DateTime.TryParseExact(EntryDateOfBirth.Text, "dd.MM.yyyy",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                                        out var dateOfBirth))
            {
                await DisplayAlert("Ошибка", "Некорректная дата рождения. Используйте формат ДД.ММ.ГГГГ.", "ОК");
                return;
            }

            // Проверка и парсинг даты выдачи паспорта
            if (!DateTime.TryParseExact(EntryIssuedDate.Text, "dd.MM.yyyy",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                                        out var issuedDate))
            {
                await DisplayAlert("Ошибка", "Некорректная дата выдачи паспорта. Используйте формат ДД.ММ.ГГГГ.", "ОК");
                return;
            }

            // Проверка выбора должности и квалификации
            var selectedPosition = AvailablePositions.FirstOrDefault(p => p.IsSelected);
            var selectedQualification = AvailableQualifications.FirstOrDefault(q => q.IsSelected);

            if (selectedPosition == null || selectedQualification == null)
            {
                await DisplayAlert("Ошибка", "Выберите одну должность и один уровень квалификации.", "ОК");
                return;
            }

            // Получение идентификаторов должности и квалификации
            var positionId = await GetPositionId(selectedPosition.Title);
            var qualificationId = await GetQualificationId(selectedQualification.LevelName);

            // Создание объекта данных сотрудника
            var employeeData = new EmployeeData
            {
                LastName = EntryMiddleName.Text,
                FirstName = EntryFirstName.Text,
                MiddleName = EntryLastName.Text,
                DateOfBirth = dateOfBirth,
                PositionId = positionId,
                QualificationId = qualificationId,
                Telegram = EntryTelegram.Text,
                Email = EntryEmail.Text,
                PhoneNumber = EntryPhoneNumber.Text,
                PassportSeries = EntryPassportSeries.Text,
                PassportNumber = EntryPassportNumber.Text,
                IssuedBy = EntryIssuedBy.Text,
                IssuedDate = issuedDate,
                RegistrationAddress = EntryRegistrationAddress.Text,
                ResidentialAddress = EntryResidentialAddress.Text
            };

            await _dbService.CreateEmployee(employeeData);

            await DisplayAlert("Сохранение", "Запись успешно добавлена!", "ОК");
            await Navigation.PopAsync();
        }



        private async Task<int> GetPositionId(string positionTitle)
        {
            var positions = await _dbService.GetPositions();
            var position = positions.FirstOrDefault(p => p.Title == positionTitle);
            return position?.Id ?? 0;
        }

        private async Task<int> GetQualificationId(string qualificationLevelName)
        {
            var qualifications = await _dbService.GetQualifications();
            var qualification = qualifications.FirstOrDefault(q => q.LevelName == qualificationLevelName);
            return qualification?.Id ?? 0;
        }

        private void OnDateInfoButtonTapped(object sender, EventArgs e)
        {
            TooltipLabel.IsVisible = !TooltipLabel.IsVisible;
        }

        private void OnEmailInfoButtonTapped(object sender, EventArgs e)
        {
            EmailTooltipLabel.IsVisible = !EmailTooltipLabel.IsVisible;
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }
    }

    public class JobPosition : INotifyPropertyChanged
    {
        private bool _isSelected;
        public string Title { get; set; }
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class QualificationLevel : INotifyPropertyChanged
    {
        private bool _isSelected;
        public string LevelName { get; set; }
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
