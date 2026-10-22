using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;

namespace ToDO
{

 
    public partial class MainWindow : Window
    {

        TodoManager manager = new TodoManager();

        public MainWindow()
        {
            InitializeComponent();
            manager.jsonRead();
            MyListBox.ItemsSource = manager.Task;
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {


            TaskItem newTask = new TaskItem();
            newTask.Title = QuestHelper.Text;
            manager.AddTask(newTask);
            manager.jsonWrite();
            MyListBox.ItemsSource = manager.Task;
            MyListBox.ItemsSource = null;
            QuestHelper.Clear();    


            // 2. Привязываем его заново — теперь появятся ВСЕ задачи по порядку
            MyListBox.ItemsSource = manager.Task;

        }

        private void RemoveButton(object sender, RoutedEventArgs e)
        {
            var taskForDelete = MyListBox.SelectedItem as TaskItem;
            manager.DeleteTask(taskForDelete);
            MyListBox.ItemsSource = null;
            MyListBox.ItemsSource = manager.Task;
            manager.jsonWrite();


        }



    }
}