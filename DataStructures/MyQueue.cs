namespace DataStructures;

public class MyQueue<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;
    public int Count { get; private set; }


    public void Add(T item)
    {
        var newNode = new Node<T>(item);

        if (IsEmpty())
        {
            _head = newNode;
            _tail = _head;
        }
        else
        {
            _tail!.Next = newNode;
            _tail = _tail.Next;
        }

        Count++;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException();
        }

        return _head!.Value;
    }

    public T Remove()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException();
        }

        var value = _head!.Value;

        _head = _head.Next;

        Count--;

        if (IsEmpty())
        {
            _tail = null;
        }

        return value;
    }

    public bool IsEmpty()
    {
        return Count == 0;
    }
}