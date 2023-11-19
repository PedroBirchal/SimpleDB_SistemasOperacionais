
public class FifoListing<T> : Listing<T> where T : class{

    public FifoListing(int size, T rootValue){
        this.size = size;
        root = new Node<T>(rootValue);
        index = 0;
    }

    public override void ReplacePolicy()
    {
        Console.WriteLine("Replacing object by FIFO replacement policy");
        Console.WriteLine($"Object {Remove(0)} was removed from cache");
    }
}