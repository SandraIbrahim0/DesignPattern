using System.Text;

namespace DesignPattern.Strategy.Dynamic
{
    // motivation here to be able to change the entire strategy by replacing only one component
    // if we always know the strategy that we use no need to be dynamic it can be injected in the DI container or can be coupled with the defination in that case will be static strategy
    public class HtmlStrategy : IListStrategy
    {
        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($"  <li>{item}</li>");
        }

        public void End(StringBuilder sb)
        {
            sb.AppendLine("</ul>");
        }

        public void Start(StringBuilder sb)
        {
            sb.AppendLine("<ul>");
        }
    }
    public enum StrategyFormat
    {
        Markdown = 1,
        Html = 2
    }
}
