using System.Collections.Generic;//must have
namespace ToDoList.Objects
{
  public class Task
  {
    private string _description;//reason it' private so that the properties inside private can't be access or change
    //unless we type public Get... to read what's inside
    //public .. Set.. to change the info inside
    private static List<string> _instances = new List<string> {};
    //List<in here can be Objectsclass like Task, Car, or type>
    public Task (string description)
    {
      _description = description;
    }

    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public static List<string> GetAll()
    {
      return _instances; // static list will be a list of all instances of the Task class not just a specific Task
    }
    public void Save()
    {
      _instances.Add(_description);
      //when we call save() on a specific task, we add its description to _instances
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}
