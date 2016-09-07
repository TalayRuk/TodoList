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
      Get["/view_all_tasks"]=_=> {
        List<srting> allTasks = Task.GetAll();
        //instead of Task newTask = new Task(Request.Query["new-task"]); replaced in with List<string>
        return View["view_all_tasks.cshtml", newTask];

      Post["/task_added"] = _ => {
        Task newTask = new Task (Request.Form["new-task"]);
        newTask.Save();
        return View["task_added.cshtml", newTask];
        //added a new route with Post instead of Get. We still instantiate a new Task Obj named newTask
        //w/Post request, the description is not coming fr the pages'query parameters,
        //it's coming from the form. So we use Request.Form["new-task"] instead of Request.Query
        //Then we call save() method on newTask
        //The request will return the View task_added.cshtml. THis is just going to be a page that display
        // the Task we just added, newTask, so all we need to do is pass in newTask.
        //in order for form to follow this route upon being submitted, we need to change the form in add_new_task.cshtml
        //by changing form action to task_added and add method ="post" now we need to create views/task_added.cshtml
        //this is where we will add @Model.GetDescription() and link to view-all-tasks
      };

    }
  }
}
