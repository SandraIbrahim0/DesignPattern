using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Strategy.Dynamic
{
    public class TextProcessing
    {
        private IListStrategy strategy;
        private StringBuilder sb = new StringBuilder();
        //static one 
        public void SetProcessingStrategy(IListStrategy strategy)
        {
            this.strategy = strategy;
        }

        // dynamic one 
        public void SetProcessingStrategy(int strategyChoice)
        {
            switch (strategyChoice)
            {
                case (int)StrategyFormat.Html:
                    strategy = new HtmlStrategy();
                    break;
                case (int)StrategyFormat.Markdown:
                    strategy = new MarkdownStrategy();
                    break;
            }
        }
        public void AppendList(IEnumerable<string> items)
        {
            strategy.Start(sb);
            foreach (var item in items)
                strategy.AddListItem(sb, item);
            strategy.End(sb);
        }

        public StringBuilder Clear()
        {
            return sb.Clear();
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}
