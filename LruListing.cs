public class LruListing<T> : Listing<T> where T : class{

    public LruListing(int size, T rootValue){
        this.size = size;
        root = new Node<T>(rootValue);
        tail = new Node<T>(rootValue, root);
        root.next = tail;
        index = 0;
    }

    protected override Node<T> GetAt(int index){
        Node<T> n = root;
        for(int i = 0; i < index; i++, n = n.next){}
        return Add(Remove(index));
    }

    protected override void SetAt(int index, Node<T> value, out int i){
        base.SetAt(index, value, out i);
        Add(Remove(i));
    }

    public override void ReplacePolicy()
    {
        Console.WriteLine("Replacing object by LRU replacement policy");
        Console.WriteLine($"Object {Remove(0)} was removed from cache");
    }

    public override bool Search(T value, out int i){
        i = 0;
        for(Node<T> n = root; n != null; n = n.next, i++){
            if(n.value == value){
                Remove(i);
                Add(value);
                return true;
            }
        }
        return false;
    }

}