using System;
//using System.Collections.Generic;
using Unit4.CollectionsLib;

namespace ConsoleApplication1
{
    class UsefulMethods
    {
        /* הערות:
        * מחלקת עזר זו כוללת פעולות עזר על רשימה, מחסנית, תור ועץ בינארי
        * לכל פעולה כתובות מעליה (כהערות) טענת הכניסה, טענת היציאה וסיבוכיות זמן הריצה של הפעולה
        * הערה עם סימן קריאה משמעה פעולה חיצונית שקיימת במחלקת עזר זו - יש לכתוב את הפעולה החיצונית!
        * רוב הפעולות מקבלות טיפוס נתונים מסוג מספר שלם, אך יכולות לעבוד עם כל טיפוס אחר
        * © כל הזכויות שמורות לערן - Saurik
        * לבקשות, הערות והצעות: http://www.fxp.co.il/showthread.php?t=14343465
        * בהצלחה בבחינות! 
        */


        ///
        /// רשימה
        /// 
        //טענת כניסה: הפעולה מקבלת רשימה של מספרים שלמים ומספר שלם
        // טענת יציאה: הפעולה מחזירה "אמת" אם המספר נמצא ברשימה, אחרת מחזירה "שקר"
        // סיבוכיות זמן ריצה: O(n)
        public static bool IsExistList(List<int> l, int n)
        {
            Node<int> pos = l.GetFirst();
            while (pos != null)
            {
                if (pos.GetInfo() == n)
                    return true;
                pos = pos.GetNext();
            }
            return false;
        }
        // טענת כניסה: הפעולה מקבלת רשימה של מספרים שלמים
        // טענת כניסה: הפעולה מחזירה את סכום כל איברי הרשימה
        // סיבוכיות זמן ריצה: O(n)
        public static int SumList(List<int> l)
        {
            int sum = 0;
            Node<int> pos = l.GetFirst();
            while (pos != null)
            {
                sum += pos.GetInfo();
                pos = pos.GetNext();
            }
            return sum;
        }
        // טענת כניסה: הפעולה מקבלת רשימה של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה את אורך הרשימה - מספר החוליות בה
        // סיבוכיות זמן ריצה: O(n)
        public static int LengthList(List<int> l)
        {
            int length = 0;
            Node<int> pos = l.GetFirst();
            while (pos != null)
            {
                length++;
                pos = pos.GetNext();
            }
            return length;
        }
        // טענת כניסה: הפעולה מקבלת רשימה של מספרים שלמים ומספר שלם
        // טענת יציאה: הפעולה מחזירה את מספר הפעמים שהמספר מופיע ברשימה
        // סיבוכיות זמן ריצה: O(n)
        public static int HowManyList(List<int> l, int n)
        {
            int count = 0;
            Node<int> pos = l.GetFirst();
            while (pos != null)
            {
                if (pos.GetInfo() == n)
                    count++;
                pos = pos.GetNext();
            }
            return count;
        }
        // טענת כניסה: הפעולה מקבלת רשימה של מספרים שלמים ומספר שלם
        // טענת יציאה: הפעולה מוחקת את כל מופעי המספר שהתקבל מהרשימה
        // סיבוכיות זמן ריצה: O(n)
        public static void DebugList(List<int> l, int n)
        {
            Node<int> pos = l.GetFirst();
            while (pos != null)
                if (pos.GetInfo() == n)
                    pos = l.Remove(pos);
                else pos = pos.GetNext();
        }
        // טענת כניסה: הפעולה מקבלת רשימה ממוינת של מספרים שלמים ומספר שלם
        // טענת יציאה: הפעולה מכניסה באופן ממוין את המספר לרשימה
        // סיבוכיות זמן ריצה: O(n)
        public static void InsertSorted(List<int> l, int n)
        {
            Node<int> pos = l.GetFirst();
            Node<int> before = null;
            while (pos != null && n > pos.GetInfo())
            {
                before = pos;
                pos = pos.GetNext();
            }
            l.Insert(before, n);
        }
        // טענת כניסה: הפעולה מקבלת רשימה של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה "אמת" אם הרשימה ממוינת בסדר עולה, אחרת מחזירה "שקר"
        // סיבוכיות זמן ריצה: O(n)
        public static bool IsSorted(List<int> l)
        {
            Node<int> pos = l.GetFirst();
            while (pos.GetNext() != null)
            {
                if (pos.GetInfo() > pos.GetNext().GetInfo())
                    return false;
                pos = pos.GetNext();
            }
            return true;
        }
        // טענת כניסה: הפעולה מקבלת רשימה לא ממוינת של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה רשימה המכילה את כל ערכי הרשימה שהתקבלה בסדר ממוין עולה
        // סיבוכיות זמן ריצה: O(n²)
        public static List<int> Sort(List<int> l)
        {
            List<int> newL = new List<int>();
            Node<int> pos = l.GetFirst();
            while (pos != null)
            {
                InsertSorted(newL, pos.GetInfo()); //! //O(n)
                pos = pos.GetNext();
            }
            return newL;
        }
        ///
        /// מחסנית
        ///
        // טענת כניסה: הפעולה מקבלת מחסנית של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה מחסנית חדשה, שאיבריה זהים בערכם ובסדרם לאיברי המחסנית שהתקבלה
        // סיבוכיות זמן ריצה: O(n)
        public static Stack<int> CloneStack(Stack<int> s)
        {
            Stack<int> newS = new Stack<int>();
            Stack<int> tmp = new Stack<int>();
            while (!s.IsEmpty())
                tmp.Push(s.Pop());
            while (!tmp.IsEmpty())
            {
                newS.Push(tmp.Top());
                s.Push(tmp.Pop());
            }
            return newS;
        }
        // טענת כניסה: הפעולה מקבלת מחסנית של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה מחסנית חדשה, שאיבריה מסודרים בסדר הפוך ביחס לאיברי המחסנית שהתקבלה
        // סיבוכיות זמן ריצה: O(n)
        public static Stack<int> FlipStack(Stack<int> s)
        {
            Stack<int> newS = new Stack<int>();
            Stack<int> tmp = CloneStack(s); //!
            while (!tmp.IsEmpty())
                newS.Push(tmp.Pop());
            return newS;
        }
        // טענת כניסה: הפעולה מקבלת מחסנית של מספרים שלמים ומספר שלם
        // טענת יציאה: המחסנית מחזירה "אמת" אם המספר נמצא במחסנית, אחרת מחזירה "שקר"
        // סיבוכיות זמן ריצה: O(n)
        public static bool IsExistStack(Stack<int> s, int n)
        {
            Stack<int> sCopy = CloneStack(s); //!
            while (!sCopy.IsEmpty())
                if (sCopy.Pop() == n)
                    return true;
            return false;
        }
        // טענת כניסה: הפעולה מקבלת מחסנית של מספרים שלמים ומספר שלם
        // טענת יציאה: הפעולה מחזירה "אמת" אם המספר נמצא במחסנית, אחרת מחזירה "שקר"
        // הערה: הפעולה רקורסיבית, ועדיין שומרת על סדר המחסנית שהתקבלה
        // סיבוכיות זמן ריצה: O(n)
        public static bool IsExistStackRec(Stack<int> s, int n)
        {
            if (s.IsEmpty())
                return false;
            int x = s.Pop();
            bool exists = (x == n || IsExistStackRec(s, n));
            s.Push(x); //לאחר הקריאה הרקורסיבית, האיבר שנשלף נדחף בחזרה אל תוך המחסנית
            return exists;
        }
        // טענת כניסה: הפעולה מקבלת מחסנית של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה את סכום איברי המחסנית
        // סיבוכיות זמן ריצה: O(n)
        public static int SumStack(Stack<int> s)
        {
            int sum = 0;
            Stack<int> sCopy = CloneStack(s); //!
            while (!sCopy.IsEmpty())
                sum += sCopy.Pop();
            return sum;
        }
        // טענת כניסה: הפעולה מקבלת מחסנית של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה את אורך המחסנית - מספר האיברים בה
        // סיבוכיות זמן ריצה: O(n)
        public static int LengthStack(Stack<int> s)
        {
            int length = 0;
            Stack<int> sCopy = CloneStack(s); //!
            while (!sCopy.IsEmpty())
            {
                length++;
                sCopy.Pop();
            }
            return length;
        }
        // טענת כניסה: הפעולה מקבלת מחסנית של מספרים שלמים ומספר שלם
        // טענת יציאה: הפעולה מחזירה את מספר הפעמים שהמספר מופיע במחסנית
        // סיבוכיות זמן ריצה: O(n)
        public static int HowManyStack(Stack<int> s, int n)
        {
            int count = 0;
            Stack<int> tmp = CloneStack(s); //!
            while (!tmp.IsEmpty())
                if (tmp.Pop() == n)
                    count++;
            return count;
        }
        // טענת כניסה: הפעולה מקבלת מחסנית של מספרים שלמים ומספר שלם
        // טענת יציאה: הפעולה מוחקת את כל מופעי המספר שהתקבל מתוך המחסנית
        // סיבוכיות זמן ריצה: O(n)
        public static void DebugStack(Stack<int> s, int n)
        {
            Stack<int> tmp = FlipStack(s); //!
            while (!s.IsEmpty())
                s.Pop();
            while (!tmp.IsEmpty())
            {
                int x = tmp.Pop();
                if (x != n)
                    s.Push(x);
            }
        }
        ///
        /// תור
        /// 
        // טענת כניסה: הפעולה מקבלת תור של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה תור חדש, שאיבריו זהים בערכם ובסדרם לאיברי התור שהתקבל 
        // סיבוכיות זמן ריצה: O(n)
        public static Queue<int> CloneQueue(Queue<int> q)
        {
            Queue<int> newQ = new Queue<int>();
            Queue<int> tmp = new Queue<int>();
            while (!q.IsEmpty())
            {
                newQ.Insert(q.Head());
                tmp.Insert(q.Remove());
            }
            while (!tmp.IsEmpty())
                q.Insert(tmp.Remove());
            return newQ;
        }
        // טענת כניסה: הפעולה מקבלת מחסנית של מספרים שלמים ומספר שלם
        // טענת יציאה: הפעולה מחזירה "אמת" אם המספר קיים בתור, אחרת מחזירה "שקר"
        // סיבוכיות זמן ריצה: O(n)
        public static bool IsExistQueue(Queue<int> q, int n)
        {
            Queue<int> qCopy = CloneQueue(q); //!
            while (!qCopy.IsEmpty())
                if (qCopy.Remove() == n)
                    return true;
            return false;
        }
        // טענת כניסה: הפעולה מקבלת תור של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה את סכום איברי התור
        // סיבוכיות זמן ריצה: O(n)
        public static int SumQueue(Queue<int> q)
        {
            int sum = 0;
            Queue<int> qCopy = CloneQueue(q); //!
            while (!qCopy.IsEmpty())
                sum += qCopy.Remove();
            return sum;
        }
        // טענת כניסה: הפעולה מקבלת תור של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה את אורך התור - מספר האיברים בו
        // סיבוכיות זמן ריצה: O(n)
        public static int LengthQueue(Queue<int> q)
        {
            int length = 0;
            Queue<int> qCopy = CloneQueue(q); //!
            while (!qCopy.IsEmpty())
            {
                length++;
                qCopy.Remove();
            }
            return length;
        }
        // טענת כניסה: הפעולה מקבלת תור של מספרים שלמים ומספר שלם
        // טענת יציאה: הפעולה מחזירה את מספר הפעמים שהמספר מופיע בתור
        // סיבוכיות זמן ריצה: O(n)
        public static int HowManyQueue(Queue<int> q, int n)
        {
            int count = 0;
            Queue<int> tmp = CloneQueue(q); //!
            while (!tmp.IsEmpty())
                if (tmp.Remove() == n)
                    count++;
            return count;
        }
        // טענת כניסה: הפעולה מקבלת תור של מספרים שלמים ומספר שלם
        // טענת יציאה: הפעולה מוחקת את כל מופעי המספר שהתקבל מתוך התור
        // סיבוכיות זמן ריצה: O(n)
        public static void DebugQueue(Queue<int> q, int n)
        {
            Queue<int> tmp = CloneQueue(q); //!
            while (!q.IsEmpty())
                q.Remove();
            while (!tmp.IsEmpty())
            {
                int x = tmp.Remove();
                if (x != n)
                    q.Insert(x);
            }
        }
        ///
        /// עץ בינארי
        /// 
        // טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה עץ חדש, זהה בדיוק בצמתיו ובמיקומים שלהם לעץ שהתקבל
        // סיבוכיות זמן ריצה: O(n)
        public static BinTreeNode<int> CloneTree(BinTreeNode<int> bt)
        {
            if (bt == null)
                return null;
            BinTreeNode<int> left = CloneTree(bt.GetLeft());
            BinTreeNode<int> right = CloneTree(bt.GetRight());
            return new BinTreeNode<int>(left, bt.GetInfo(), right); //להחליף ימין ושמאל לקבלת עץ מראה
        }
        // טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים ומספר שלם
        // טענת יציאה: הפעולה מחזירה "אמת" אם המספר שהתקבל נמצא בעץ, אחרת מחזירה "שקר"
        // סיבוכיות זמן ריצה: O(n)
        public static bool IsExistTree(BinTreeNode<int> bt, int n)
        {
            if (bt == null)
                return false;
            return (bt.GetInfo() == n || IsExistTree(bt.GetLeft(), n) || IsExistTree(bt.GetRight(), n));
        }
        // טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה את סכום ערכי כל הצמתים בעץ
        // סיבוכיות זמן ריצה: O(n)
        public static int SumTree(BinTreeNode<int> bt)
        {
            if (bt == null)
                return 0;
            return bt.GetInfo() + SumTree(bt.GetLeft()) + SumTree(bt.GetRight());
        }
        // טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה "אמת" אם העץ הוא עלה, אחרת מחזירה "שקר"
        // סיבוכיות זמן ריצה: O(1)
        public static bool IsLeaf(BinTreeNode<int> bt)
        {
            return (bt.GetLeft() == null && bt.GetRight() == null);
        }
        // טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים
        // טענת יציאה: הפעולה מדפיסה את ערכי הצמתים בעץ לפי סדר תחילי - שורש, שמאל, ימין
        // סיבוכיות זמן ריצה: O(n)
        public static void PrintPreOrder(BinTreeNode<int> bt)
        {
            if (bt != null)
            {
                Console.WriteLine(bt.GetInfo());
                PrintPreOrder(bt.GetLeft());
                PrintPreOrder(bt.GetRight());
            }
        }
        // טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים
        // טענת יציאה: הפעולה מדפיסה את ערכי הצמתים בעץ לפי סדר תוכי - שמאל, שורש, ימין
        // סיבוכיות זמן ריצה: O(n)
        public static void PrintInOrder(BinTreeNode<int> bt)
        {
            if (bt != null)
            {
                PrintInOrder(bt.GetLeft());
                Console.WriteLine(bt.GetInfo());
                PrintInOrder(bt.GetRight());
            }
        }
        // טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים
        // טענת יציאה: הפעולה מדפיסה את ערכי הצמתים בעץ לפי סדר סופי - שמאל, ימין, שורש
        // סיבוכיות זמן ריצה: O(n)
        public static void PrintPostOrder(BinTreeNode<int> bt)
        {
            if (bt != null)
            {
                PrintPostOrder(bt.GetLeft());
                PrintPostOrder(bt.GetRight());
                Console.WriteLine(bt.GetInfo());
            }
        }
        // טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים
        // טענת יציאה: הפעולה מדפיסה את ערכי הצמתים בעץ לפי הרמה שלהם - כל צמתי העץ ברמה כלשהי יודפסו אחד אחרי השני
        // סיבוכיות זמן ריצה: O(n)
        public static void PrintByLevels(BinTreeNode<int> bt)
        {
            Queue<BinTreeNode<int>> q = new Queue<BinTreeNode<int>>();
            q.Insert(bt);
            while (!q.IsEmpty())
            {
                BinTreeNode<int> current = q.Remove();
                Console.WriteLine(current.GetInfo());
                if (current.GetLeft() != null)
                    q.Insert(current.GetLeft());
                if (current.GetRight() != null)
                    q.Insert(current.GetRight());
            }
        }
        // טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה את מספר הצמתים בעץ
        // סיבוכיות זמן ריצה: O(n)
        public static int CountNodes(BinTreeNode<int> bt)
        {
            if (bt == null)
                return 0;
            return 1 + CountNodes(bt.GetLeft()) + CountNodes(bt.GetRight());
        }
        // טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה את מספר העלים בעץ
        // סיבוכיות זמן ריצה: O(n)
        public static int CountLeaves(BinTreeNode<int> bt)
        {
            if (bt == null)
                return 0;
            if (IsLeaf(bt)) //!
                return 1;
            return CountLeaves(bt.GetLeft()) + CountLeaves(bt.GetRight());
        }
        // טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה את גובה העץ
        // סיבוכיות זמן ריצה: O(n)
        public static int Height(BinTreeNode<int> bt)
        {
            if (bt == null)
                return -1;
            return 1 + Math.Max(Height(bt.GetLeft()), Height(bt.GetRight()));
        }
        // טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה את הערך הגבוה ביותר בעץ
        // סיבוכיות זמן ריצה: O(n)
        public static int MaxValue(BinTreeNode<int> bt)
        {
            if (IsLeaf(bt)) //!
                return bt.GetInfo();
            int maxLeft = MaxValue(bt.GetLeft());
            int maxRight = MaxValue(bt.GetRight());
            return Math.Max(bt.GetInfo(), Math.Max(maxLeft, maxRight));
        }
        // טענת כניסה: הפעולה מקבלת עץ בינארי "בן" ואת הצומת העליון ביותר בעץ כלשהו בו נמצא "בן" - "שורש"
        // טענת יציאה: הפעולה מחזירה את האב של העץ "בן". אם אביו לא נמצא בעץ "שורש" - יוחזר ערך ריק
        // סיבוכיות זמן ריצה: O(n)
        public static BinTreeNode<int> GetFather(BinTreeNode<int> source, BinTreeNode<int> son)
        {
            if (source == null)
                return null;
            if (source.GetLeft() == son || source.GetRight() == son)
                return source;
            BinTreeNode<int> left = GetFather(source.GetLeft(), son);
            if (left != null)
                return left;
            return GetFather(source.GetRight(), son);
        }
        // טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים ומספר שלם
        // טענת יציאה: הפעולה מחזירה את מספר הצמתים בהם מופיע הערך שהתקבל
        // סיבוכיות זמן ריצה: O(n)
        public static int HowManyTree(BinTreeNode<int> bt, int n)
        {
            if (bt == null)
                return 0;
            if (bt.GetInfo() == n)
                return 1 + HowManyTree(bt.GetLeft(), n) + HowManyTree(bt.GetRight(), n);
            return HowManyTree(bt.GetLeft(), n) + HowManyTree(bt.GetRight(), n);
        }
        // טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים ומספר שלם המייצג רמה בעץ
        // טענת יציאה: הפעולה מחזירה את מספר הצמתים ברמה שהתקבלה
        // סיבוכיות זמן ריצה: O(n)
        public static int NodesInLevel(BinTreeNode<int> bt, int level)
        {
            if (bt == null)
                return 0;
            if (level == 0)
                return 1;
            return NodesInLevel(bt.GetLeft(), level - 1) + NodesInLevel(bt.GetRight(), level - 1);
        }
        // טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים
        // טענת יציאה: הפעולה מחזירה "אמת" אם העץ הוא עץ חיפוש בינארי, אחרת מחזירה "שקר"
        // סיבוכיות זמן ריצה: O(n)
        public static bool IsBST(BinTreeNode<int> bt)
        {
            if (bt == null)
                return true;
            if (bt.GetLeft() != null && bt.GetLeft().GetInfo() >= bt.GetInfo())
                return false;
            if (bt.GetRight() != null && bt.GetRight().GetInfo() < bt.GetInfo())
                return false;
            return IsBST(bt.GetLeft()) && IsBST(bt.GetRight());
        }
        // טענת כניסה: הפעולה מקבלת עץ בינארי של מספרים שלמים ומספר שלם
        // טענת יציאה: הפעולה מוסיפה את המספר שהתקבל לעץ החיפוש הבינארי
        // סיבוכיות זמן ריצה: O(log(n))
        public static void AddToBST(BinTreeNode<int> bt, int n)
        {
            if (bt.GetLeft() == null && n < bt.GetInfo())
                bt.SetLeft(new BinTreeNode<int>(n));
            else if (bt.GetRight() == null && n >= bt.GetInfo())
                bt.SetRight(new BinTreeNode<int>(n));
            else if (n < bt.GetInfo())
                AddToBST(bt.GetLeft(), n);
            else AddToBST(bt.GetRight(), n);
        }
    }
}