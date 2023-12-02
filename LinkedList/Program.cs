namespace DS_LinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[,] data =
            {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
            };

            
            LinkedList.PrintTwoDimList(LinkedList.TwoDimlist(data));
        }
    }
}