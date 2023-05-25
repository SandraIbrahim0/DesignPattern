

namespace DesignPattern.SOLID
{
    public class SingleResponsibility
    {
    }
    public class Journal
    {
        private readonly List<string> _journals = new List<string>();
        private static int _count = 0;
        public int AddEntry(string text)
        {
            _journals.Add($"{_count++} :{text}");
            return _count;
        }
        public void RemoveEntity(int count)
        {
            _journals.RemoveAt(count);
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, _journals);
        }

    }
    public class Presisitence
    {
        public void SaveFile(Journal j, string filePath, bool overWrite = false)
        {
            if (overWrite || !File.Exists(filePath)) { File.WriteAllText(filePath, j.ToString()); }
        }
    }
}
