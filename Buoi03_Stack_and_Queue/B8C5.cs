using System;
using System.Collections.Generic;

namespace Buoi03_Stack_Queue
{
    static class B8C5
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(" BÀI 8: KIỂM TRA CHUỖI NGOẶC () ĐÚNG");
            Console.WriteLine(new string('=', 60));
            string s = hamhotro.DocChuoi("Nhập chuỗi ngoặc tròn", "(())()");
            Stack<char> stack = new Stack<char>();
            bool isValid = true;

            foreach (char c in s)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }
                    stack.Pop();
                }
            }

            if (stack.Count > 0) isValid = false;

            if (isValid)
                Console.WriteLine("  [KẾT QUẢ] Xâu đúng cấu trúc ngoặc tròn!");
            else
                Console.WriteLine("  [KẾT QUẢ] Xâu sai cấu trúc ngoặc tròn!");
        }
    }
}
