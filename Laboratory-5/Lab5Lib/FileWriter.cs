using System.Reflection.Metadata;

namespace Lab5Lib
{
    public class FileWriter : IWriter
    {
        string fileName = Constant.FileName;
        public string FileName { get { return fileName; } }

        public FileWriter(string? fileName = null)
        {
            this.fileName = fileName ?? Constant.FileName;
        }

        public string? Save(string? message)
        {
            using (StreamWriter sw = new(this.fileName))
            {
                sw.WriteLine(message);
            }
            return this.fileName;
        }
    }
}
