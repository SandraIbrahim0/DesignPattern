namespace DesignPattern.Factory
{
    // motivation to make a the consctor in async way 
    public class AsynFactory
    {
        private AsynFactory()
        {

        }
        private async Task<AsynFactory> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }
        public static async Task<AsynFactory> Create()
        {
            var result = new AsynFactory();
            await result.InitAsync();
            return result;

        }
    }
}
