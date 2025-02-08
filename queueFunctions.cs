        public static Queue<int> sortQueue(Queue<int> queue) 
        {
            Queue<int> sortedQueue = new Queue<int>();
            while (!queue.IsEmpty())
            {
                int min = findMin(queue); 
                Queue<int> tempQueue = new Queue<int>();
                while (!queue.IsEmpty())
                {
                    int current = queue.Head();
                    queue.Remove();
                    if (current == min)
                    {
                        sortedQueue.Insert(current);            }
                    else
                    {
                        tempQueue.Insert(current);             }
                }
                queue = tempQueue; 
            }
            return sortedQueue;
        }

        public static Queue<int> copyqueue(Queue<int> queue) 
        {
            Queue<int> temp = new Queue<int>();
            Queue<int> temp2 = new Queue<int>();
            while (!queue.IsEmpty())
            {
                temp.Insert(queue.Head());
                temp2.Insert(queue.Head());
                queue.Remove();
            }
            while (!temp2.IsEmpty())
            {
                queue.Insert(temp2.Head());
                temp2.Remove();
            }
            return temp;
        }

        public static int findMin(Queue<int> queue)
        {
            Queue<int> tempQueue = copyqueue(queue); 
            int min = int.MaxValue;
            while (!tempQueue.IsEmpty())
            {
                int current = tempQueue.Head();
                tempQueue.Remove();
                if (current < min)
                {
                    min = current;
                }
            }
            return min;
        }

        public static int queuelength(Queue<int> q)
        { //queue length
            int count = 0;
            Queue<int> queuecopy = copyqueue(q); 
            while (!queuecopy.IsEmpty())
            {
                count++;
                queuecopy.Remove();
            }
            return count;
        }

        public static int countinstance(Queue<int> q, int instance)
        { 
            int count = 0;
            Queue<int> copyq = copyqueue(q);
            while (!copyq.IsEmpty())
            {
                if (copyq.Head() == instance) { count++; }
                copyq.Remove();
            }
            return count;
        }

        public static Queue<int> delnumber(Queue<int> q, int number)
        { //delete any instance of number in queue
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                if (q.Head() != number)
                {
                    temp.Insert(q.Head());  
                }
                q.Remove(); 
            }
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Head());  
                temp.Remove();
            }
            return q;
        }