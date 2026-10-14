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
}