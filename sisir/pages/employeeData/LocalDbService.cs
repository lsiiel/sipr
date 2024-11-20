using SQLite;
using System.Diagnostics;

namespace sisir.pages.employeeData
{
    public class LocalDbService
    {
        private const string DB_NAME = "sisirDB.db";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            string dbPath = "/Users/lsiiel/Documents/study/sisirDB";
            _connection = new SQLiteAsyncConnection(dbPath);
            InitializeDatabase();
        }

        private async void InitializeDatabase()
        {
            try
            {
                await _connection.CreateTableAsync<EmployeeData>();
                await _connection.CreateTableAsync<Position>();
                await _connection.CreateTableAsync<Qualification>();
                await _connection.CreateTableAsync<Project>();
                await _connection.CreateTableAsync<EmployeeProject>();
                await _connection.CreateTableAsync<Skill>();
                await _connection.CreateTableAsync<Team>();
                await _connection.CreateTableAsync<ProjectSkill>();
                Debug.WriteLine("Database initialized successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Database initialization error: {ex.Message}");
            }
        }

        //сотрудники
        public async Task CreateEmployee(EmployeeData employeeData)
        {
            await _connection.InsertAsync(employeeData);
        }

        public async Task<List<EmployeeData>> GetEmployees()
        {
            return await _connection.Table<EmployeeData>().ToListAsync();
        }

        public async Task<EmployeeData> GetEmployeeById(int id)
        {
            return await _connection.Table<EmployeeData>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateEmployee(EmployeeData employeeData)
        {
            await _connection.UpdateAsync(employeeData);
        }

        public async Task DeleteEmployee(EmployeeData employeeData)
        {
            await _connection.DeleteAsync(employeeData);
        }

        // Должность
        public async Task AddPosition(Position position)
        {
            await _connection.InsertAsync(position);
        }

        public async Task<List<Position>> GetPositions()
        {
            return await _connection.Table<Position>().ToListAsync();
        }

        // Квалификация
        public async Task AddQualification(Qualification qualification)
        {
            await _connection.InsertAsync(qualification);
        }

        public async Task<List<Qualification>> GetQualifications()
        {
            return await _connection.Table<Qualification>().ToListAsync();
        }

        // Проекты
        public async Task AddProject(Project project)
        {
            await _connection.InsertAsync(project);
        }

        public async Task<List<Project>> GetProjects()
        {
            return await _connection.Table<Project>().ToListAsync();
        }

        // Работники - проекты
        public async Task AssignEmployeeToProject(int employeeId, int projectId)
        {
            await _connection.InsertAsync(new EmployeeProject { EmployeeId = employeeId, ProjectId = projectId });
        }

        public async Task<List<EmployeeProject>> GetEmployeeProjects(int employeeId)
        {
            return await _connection.Table<EmployeeProject>().Where(ep => ep.EmployeeId == employeeId).ToListAsync();
        }

        // Проекты - навыки
        public async Task AssignProjectToSkill(int skillId, int projectId)
        {
            await _connection.InsertAsync(new ProjectSkill { ProjectId = projectId, SkillId = skillId });
        }

        public async Task<List<ProjectSkill>> GetProjectSkills(int projectId)
        {
            return await _connection.Table<ProjectSkill>().Where(ep => ep.ProjectId == projectId).ToListAsync();
        }
        // Команды
        public async Task CreateTeam(Team team)
        {
            await _connection.InsertAsync(team);
        }

        public async Task<List<Team>> GetTeams()
        {
            return await _connection.Table<Team>().ToListAsync();
        }
        // Навыки
        public async Task CreateSkill(Skill skill)
        {
            await _connection.InsertAsync(skill);
        }

        public async Task<List<Skill>> GetSkills()
        {
            return await _connection.Table<Skill>().ToListAsync();
        }

    }
}
