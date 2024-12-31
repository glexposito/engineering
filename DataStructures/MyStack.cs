namespace DataStructures;
 
public class MyStack<T>
{
    private Node<T>? _head;
 
    public int Count { get; private set; }
    
    public void Push(T item)
    {
        var newNode = new Node<T>(item)
        {
            Next = _head
        };
 
        _head = newNode;
        Count++;
    }
 
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException();
        }
        
        return _head!.Value; // Using the existing non-null instruct
    }
 
    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException();
        }
 
        var value = _head!.Value; 
        _head = _head.Next;
        Count--;
        return value;
    }
 
    public bool IsEmpty()
    {
        return Count == 0;
    }
}