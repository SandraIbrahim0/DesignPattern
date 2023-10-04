namespace DesignPattern.Command
{
    // motivation to decoupled the sender and the reciever from the request which will be handled 
    // to keep track the changes happened in the request to get benefit from the undo operation 
    // helpful in the wizards, progress bars, GUI buttons, menu actions, and other transactional behaviors
    public class Order
    {
        public class Tag
        {
            public string TagName { get; set; }
        }

        public class MenuItem
        {
            public string Item { get; set; }
            public int Quantity { get; set; }
            public int TableNumber { get; set; }
            public List<Tag> Tags { get; set; }

            public void DisplayOrder()
            {
                Console.WriteLine("Table No: " + TableNumber);
                Console.WriteLine("Item: " + Item);
                Console.WriteLine("Quantity: " + Quantity);
                Console.Write("\tTags: ");
                foreach (var item in Tags)
                {
                    Console.Write(item.TagName);
                }
            }
        }
    }
}
