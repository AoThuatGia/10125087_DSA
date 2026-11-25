using System;
using System.Collections.Generic;

namespace Buoi03_Stack_Queue
{
    static class B2C5
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(" BÀI 2: MÔ PHỎNG LỊCH SỬ DUYỆT WEB (CƠ BẢN)");
            Console.WriteLine(new string('=', 60));
            Stack<string> backStack = new Stack<string>();
            Stack<string> forwardStack = new Stack<string>();
            string currentPage = "Trang_Chu";

            Console.WriteLine("  [TRẠNG THÁI] Trang hiện tại: " + currentPage);

            Console.WriteLine("  - Truy cập 'Google.com'");
            backStack.Push(currentPage);
            currentPage = "Google.com";
            forwardStack.Clear();
            Console.WriteLine("  [TRẠNG THÁI] Trang hiện tại: " + currentPage);

            Console.WriteLine("  - Truy cập 'Github.com'");
            backStack.Push(currentPage);
            currentPage = "Github.com";
            forwardStack.Clear();
            Console.WriteLine("  [TRẠNG THÁI] Trang hiện tại: " + currentPage);

            Console.WriteLine("  - Nhấn nút 'BACK'");
            if (backStack.Count > 0)
            {
                forwardStack.Push(currentPage);
                currentPage = backStack.Pop();
            }
            Console.WriteLine("  [TRẠNG THÁI] Trang hiện tại: " + currentPage);

            Console.WriteLine("  - Nhấn nút 'FORWARD'");
            if (forwardStack.Count > 0)
            {
                backStack.Push(currentPage);
                currentPage = forwardStack.Pop();
            }
            Console.WriteLine("  [TRẠNG THÁI] Trang hiện tại: " + currentPage);
        }
    }
}
