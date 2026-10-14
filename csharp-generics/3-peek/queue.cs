using System;

class Queue<T>
{
    public class Node
    {
        public object value;
        public Node next;

        public Node(object value)
        {
            this.value = value;
        }
    }

    public Node head;
    public Node tail;
    public int count;

    public Type CheckType()
    {
        return typeof(T);
    }

    public void Enqueue(T value)
    {
        Node node = new Node(value);
        if (head == null)
        {
            head = node;
        }
        else
        {
            tail.next = node;
        }
        tail = node;
        count++;
    }

    public int Count()
    {
        return count;
    }

    public T Dequeue()
    {
        if (head == null)
        {
            Console.WriteLine("Queue is empty");
            return default(T);
        }
        Node node = head;
        head = node.next;
        count--;
        if (head == null)
        {
            tail = null;
        }
        return (T)node.value;
    }

    public T Peek()
    {
        if (head == null)
        {
            Console.WriteLine("Queue is empty");
            return default(T);
        }
        return (T)head.value;
    }
}