using System.Text;

namespace DesignPattern.Strategy.Dynamic
{
    public class MarkdownStrategy : IListStrategy
    {
        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($" * {item}");
        }

        public void End(StringBuilder sb)
        {
           
        }

        public void Start(StringBuilder sb)
        {
           
        }
    }
}
