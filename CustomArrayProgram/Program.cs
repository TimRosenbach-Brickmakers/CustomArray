// See https://aka.ms/new-console-template for more information

namespace CustomArrayProgramm;
internal class Program
{
    public static void Main(string[] args)
    {
    }
}

public class MyArrayList<T>
{
    private Node? _entryNode;


    public MyArrayList()
    {
    }

    public MyArrayList(Node entryNode)
    {
        _entryNode = entryNode;
    }

    public void Add(T value)
    {
        if (_entryNode == null)
        {
            _entryNode = new Node(value);
        }
        else
        {
            Add(value, _entryNode);
        }
    }

    private void Add(T value, Node node)
    {
        if (node.NextNode == null)
        {
            node.NextNode = new Node(value);
        }
        else
        {
            Add(value, node.NextNode);
        }
    }

    public T Get(int index)
    {
        return Get(index, _entryNode);
    }

    private T Get(int index, Node? node)
    {
        if (node == null)
        {
            throw new IndexOutOfRangeException();
        }

        return index == 0 ? node.Value : Get(index - 1, node.NextNode);
    }

    public class Node(T value)
    {
        public T Value = value;
        public Node? NextNode;
    }

    public void Remove(T value)
    {
        if (_entryNode == null)
        {
            throw new ArgumentException();
        }

        if (EqualityComparer<T>.Default.Equals(_entryNode.Value, value))
        {
            _entryNode = null;
        }

        else
        {
            Remove(value, _entryNode);
        }
    }

    private void Remove(T value, Node node)
    {
        if (node.NextNode == null)
        {
            throw new ArgumentException();
        }

        if (EqualityComparer<T>.Default.Equals(node.NextNode.Value, value))
        {
            node.NextNode = node.NextNode.NextNode;
        }
        else
        {
            Remove(value, node.NextNode);
        }
    }

    public int FindIndex(int value)
    {
        throw new NotImplementedException();
    }
}