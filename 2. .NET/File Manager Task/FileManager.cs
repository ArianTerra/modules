namespace File_Manager_Task
{
    public class FileManager
    {
        public FileManager(IHistorySaver historySaver)
        {
            _historySaver = historySaver;
        }

        private IHistorySaver _historySaver;
        
        private string _path = "\\";
        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                _historySaver.Save(value);
            }
        }
        
        public static string ReadFile(string path, int size)
        {
            StreamReader reader = new StreamReader(path);
            char[] buffer = new char[size];

            try
            {
                for (int i = 0; i < size; i++)
                {
                    if (reader.EndOfStream)
                    {
                        break;
                    }

                    buffer[i] = (char)reader.Read();
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }
            
            return new String(buffer);
        }
        
        public IEnumerable<string> GetDirectoryContent()
        {
            return GetDirectoryContent("Name");
        }
        
        public IEnumerable<string> GetDirectoryContent(string sortCategory)
        {
            var propertyInfo = typeof(FileSystemInfo).GetProperty(sortCategory);
            if (propertyInfo == null)
            {
                throw new ArgumentException("Sort category not found");
            }

            if (propertyInfo.GetType().GetInterface(nameof(IComparable)) != null ||
                propertyInfo.GetType().GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() 
                    == typeof(IComparable<>))) // check if sorting type implements IComparable
            {
                throw new ArgumentException("Sort category is not comparable");
            }
            
            
            var info = new List<string>();

            Comparison<FileSystemInfo> asc = (t1, t2) => 
                ((IComparable) propertyInfo.GetValue(t1, null)).CompareTo(propertyInfo.GetValue(t2, null));
            
            var dirInfo = GetDirectoriesInfo().ToList();
            dirInfo.Sort(asc);
            info.AddRange(dirInfo.Select(info => info.FullName));

            var filesInfo = GetFilesInfo().ToList();
            filesInfo.Sort(asc);
            info.AddRange(filesInfo.Select(info => info.FullName));
            
            return info;
        }
        
        public IEnumerable<FileSystemInfo> GetFilesInfo()
        {
            var info = new List<FileSystemInfo>();

            if (Path != "\\")
            {
                var filesPath = Directory.EnumerateFiles(Path);
            
                info.AddRange(filesPath.Select(path => new FileInfo(path)));
            }
            
            return info;
        }

        public IEnumerable<FileSystemInfo> GetDirectoriesInfo()
        {
            var info = new List<FileSystemInfo>();
            
            if (Path == "\\")
            {
                var drives = Directory.GetLogicalDrives();
                info.AddRange(drives.Select(drive => new DirectoryInfo(drive)));
            }
            else
            {
                var dir = Directory.EnumerateDirectories(Path);
                info.AddRange(dir.Select(directory => new DirectoryInfo(directory)));
            }

            return info;
        }
    }
}