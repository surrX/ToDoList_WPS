using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace ToDO
{
    public class TaskItem
    {
        // текст задачи
        public string Title { get; set; } = " ";

        // выполнена?
        public bool IsDone { get; set; }  = false;

    }
    public class TodoManager
    {
        
        public List<TaskItem> Task { get; set; }  = new List<TaskItem>();



        //Добавление задач
        public void AddTask(TaskItem t)
        {
            Task.Add(t);
        }

        //Удаление
        public void DeleteTask(TaskItem t)
        {
            Task.Remove(t);
        }

        public void jsonWrite()
        {
            string jsonText = JsonConvert.SerializeObject(Task);
            File.WriteAllText("tasks.json", jsonText);
        }

        // ПРАВИЛЬНОЕ МЕСТО ДЛЯ ФУНКЦИИ ЧТЕНИЯ:
        public void jsonRead()
        {
            if (File.Exists("tasks.json"))
            {
                string jsonText = File.ReadAllText("tasks.json");
                var loadedTasks = JsonConvert.DeserializeObject<List<TaskItem>>(jsonText);

                if (loadedTasks != null)
                {
                    Task = loadedTasks; // Теперь C# видит список Task!
                }
            }
        }


    }
}
