static class Utils
{
    public static void printNode<T>(Node<T> current)
    {
        if (current == null)
        {
            Console.WriteLine();
            return;
        }
        Console.Write(current.GetValue() + " --> ");
        printNode(current.GetNext());
    }

    public static Node<T> buildNode<T>(T[] arr)
    {
        Node<T> dummy = new Node<T>(arr[0]);
        Node<T> current = dummy;
        foreach (T cell in arr)
        {
            current.SetNext(new Node<T>(cell));
            current = current.GetNext();
        }
        return dummy.GetNext();
    }

    public static Queue<T> buildQueue<T>(T[] arr)
    {
        Queue<T> newQueue = new Queue<T>();
        foreach (T val in arr)
            newQueue.Insert(val);
        return newQueue;
    }
}