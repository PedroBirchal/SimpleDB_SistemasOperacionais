public abstract class Listing<T> where T : class{
    #region Atributes
    public Node<T> root;
    public int size;
    public int index;
    public T[] elements;
    #endregion


    #region Abstract Methods
    public abstract void ReplacePolicy();
    #endregion

    #region Virtual Methods

    public virtual Node<T> this[int i]{
        get => GetAt(i);
        set => SetAt(i, value, out _);
    }

    public virtual Node<T> Add(T value){
        index ++;
        if(index > size){
            Console.WriteLine("Maximum capacity exceeded, replacement policy is going to be executed to allow insertion of new value.");
            ReplacePolicy();
        }
        for(Node<T> i = root; i.next != null; root = root.next){
            if(i.next == null){
                i.next = new Node<T>(value);
                return i.next;
            }
        }
        return null;
    }
    public virtual T Remove(int index){
        Node<T> n = root;
        for(int i = 0; i < index; i++, n = n.next){}
        T removed = n.next.value;
        n.next = n.next.next;
        index--;
        return removed;
    }
    protected virtual Node<T> GetAt(int index){
        Node<T> n = root;
        for(int i = 0; i < index; i++, n = n.next){}
        return n.next;
    }

    protected virtual void SetAt(int index, Node<T> value, out int i){
        Node<T> n = root.next;
        for(i = 0; i < index; i++, n = n.next){}
        n.value = value.value;
    }

    public virtual bool Search(T value, out int i){
        i = 0;
        for(Node<T> n = root; n.next != null; n = n.next, i++){
            if(n.next.value == value){
                return true;
            }
        }
        return false;
    }

    public virtual T Print(int index){
        Node<T> n = root;
        for(int i = 0; i < index; i++, n = n.next){}
        return n.next.value;
    }

    public virtual T[] ToArray(){
        T[] elem = new T[size];
        for((Node<T> n, int i) = (root, 0); n.next != null; n = n.next){
            elem[i] = n.next.value;
        }
        return elem;
    }

    #endregion

}

public class Node<T>{
    #region Atributes
    public T value{

        get { return _value;}
        set{
            if(!_value.Equals(value)) _value = value;
        }
    }
    private T _value;
    public Node<T> next;
    #endregion

    #region Constructor
    public Node(T value, Node<T> next = null){
        this.value = value;
        this.next = next;
    }
    #endregion
}