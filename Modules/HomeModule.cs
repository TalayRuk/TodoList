using Nancy;
using ToDoList.Objects;
using System.Collections.Generic;//added when use LIst<string>

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"]=_=> View["add_new_task.cshtml"];
      Get["/view_all_tasks"] = _ => {
        List<string> allTasks = Task.GetAll();
        //2.instead of Task newTask = new Task(Request.Query["new-task"]); replaced in with List<string>
        return View["view_all_tasks.cshtml", allTasks];
        //3.view_all_tasks, Nancy will show view_all_tasks.cshtml, with allTasks (which is the result of Task.GetAll(), or _instances) as the Model.
        //now we need to create ul>f@foreach(string task in Model) at all_tasks.cshtml
        //then add button set to tasks_cleared to clear out the task.
        //4. this button, the form submits a post request to the URL /tasks_cleared. Let’s create that route next.
        //after Post /task_added
      };
      Post["/task_added"] = _ => {
        Task newTask = new Task (Request.Form["new-task"]);
        newTask.Save();
        return View["task_added.cshtml", newTask];
        //1.added a new route with Post instead of Get. We still instantiate a new Task Obj named newTask
        //w/Post request, the description is not coming fr the pages'query parameters,
        //it's coming from the form. So we use Request.Form["new-task"] instead of Request.Query
        //Then we call save() method on newTask
        //The request will return the View task_added.cshtml. THis is just going to be a page that display
        // the Task we just added, newTask, so all we need to do is pass in newTask.
        //in order for form to follow this route upon being submitted, we need to change the form in add_new_task.cshtml
        //by changing form action to task_added and add method ="post" now we need to create views/task_added.cshtml
        //this is where we will add @Model.GetDescription() and link to view-all-tasks
      };
      Post["/tasks_cleared"] = _ => {
        Task.ClearAll();
        return View["tasks_cleared.cshtml"];
        //5.now need to add view/tasks_cleared.cshtml then add method to Objects/Task.cs
        //when the ClearAll() method in task.cs is call on _instances, setting it back to an empty list.
      };
    }
  }
}
