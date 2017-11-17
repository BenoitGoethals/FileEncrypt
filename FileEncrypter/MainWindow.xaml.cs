using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FileEncrypter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker BackgroundWorker=new BackgroundWorker();
        public MainWindow()
        {
            InitializeComponent();
            BackgroundWorker.DoWork += BackgroundWorker_DoWork;
            BackgroundWorker.RunWorkerAsync();


            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = FileHelper.InDirectory + @"/in";
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite 
                                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            //  watcher.Filter = "*.txt";

            // Add event handlers.
            watcher.Changed += Watcher_Changed;
            watcher.Created += Watcher_Changed; 
            watcher.Deleted += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;

            // Begin watching.
            watcher.EnableRaisingEvents = true;




        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            ProcesFolder();
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            ProcesFolder();
        }

       
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {


          UpdateList();


        }

        private void ButtonGo_Click(object sender, RoutedEventArgs e)
        {
            ProcesFolder();
        }

        private void ProcesFolder()
        {
            CyptroManager cyptroManager = new CyptroManager("5dfdf");
            TaskFactory factory = new TaskFactory();
            foreach (var file in FileHelper.GetAllFile(FileHelper.InDirectory, Location.In))
            {
                Action function = () =>
                {
                    cyptroManager.AsynCyrptoFile(file);
                    Thread.Sleep(100);
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                        UpdateList();
                    }
                };

                factory.StartNew(function);
                function.Invoke();
            }
        }

        private void UpdateList()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                FileHelper.MakeStructure();
                var allFile = FileHelper.GetAllFile(FileHelper.InDirectory, Location.In);
                ListViewFiles.ItemsSource = allFile;


            }), DispatcherPriority.ContextIdle);
        }
    }
}
