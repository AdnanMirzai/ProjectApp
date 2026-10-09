namespace ProjectApp.Core.Interfaces; // presentation - BO gräns

public interface IProjectService
{
    List<Project> GetAllByUserName(string userName);  
    
    Project GetById(int id, string userName);
    
    void Add(string userName, string Title);  
}