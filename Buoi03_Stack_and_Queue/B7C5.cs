using System;
using System.Collections.Generic;

namespace Buoi03_Stack_Queue
{
    static class B7C5
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(" BÀI 7: LỊCH SỬ TRÌNH DUYỆT WEB NÂNG CAO");
            Console.WriteLine(new string('=', 60));
            Stack<string> backStack = new Stack<string>();
            Stack<string> forwardStack = new Stack<string>();
            string currentPage = "homepage.com";

            while (true)
            {
                Console.WriteLine("\n=== MÔ PHỎNG TRÌNH DUYỆT ===");
                Console.WriteLine("1. Truy cập trang mới (Visit)");
                Console.WriteLine("2. Quay lại (Back)");
                Console.WriteLine("3. Tiến lên (Forward)");
                Console.WriteLine("4. Hiển thị trang hiện tại");
                Console.WriteLine("0. Quay lại Menu chính");
                int chon = hamhotro.DocSo("Chọn chức năng", 4);

                if (chon == 0) break;
                switch (chon)
                {
                    case 1:
                        string url = hamhotro.DocChuoi("Nhập địa chỉ URL trang mới", "youtube.com");
                        backStack.Push(currentPage);
                        currentPage = url;
                        forwardStack.Clear();
                        Console.WriteLine("  - Đang truy cập: " + currentPage);
                        break;
                    case 2:
                        if (backStack.Count > 0)
                        {
                            forwardStack.Push(currentPage);
                            currentPage = backStack.Pop();
                            Console.WriteLine("  [KẾT QUẢ] Quay lại thành công: " + currentPage);
                        }
                        else Console.WriteLine("  [TRẠNG THÁI] Không thể BACK (Lịch sử rỗng).");
                        break;
                    case 3:
                        if (forwardStack.Count > 0)
                        {
                            backStack.Push(currentPage);
                            currentPage = forwardStack.Pop();
                            Console.WriteLine("  [KẾT QUẢ] Tiến lên thành công: " + currentPage);
                        }
                        else Console.WriteLine("  [TRẠNG THÁI] Không thể FORWARD.");
                        break;
                    case 4:
                        Console.WriteLine("  [TRẠNG THÁI] Trang hiện tại: " + currentPage);
                        break;
                    default:
                        Console.WriteLine("  [TRẠNG THÁI] Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }
    }
}
