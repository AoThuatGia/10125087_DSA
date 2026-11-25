using System;
using System.Collections.Generic;

namespace Buoi03_Stack_Queue
{
    static class B9C5
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(" BÀI 9: HỆ THỐNG IN ẤN (FIFO NÂNG CAO)");
            Console.WriteLine(new string('=', 60));
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                Console.WriteLine("\n=== MENU IN ẤN ===");
                Console.WriteLine("1. Thêm yêu cầu in mới");
                Console.WriteLine("2. Thực hiện in tài liệu");
                Console.WriteLine("3. Hiển thị danh sách đang chờ in");
                Console.WriteLine("0. Quay lại Menu chính");
                int chon = hamhotro.DocSo("Chọn", 1);

                if (chon == 0) break;
                switch (chon)
                {
                    case 1:
                        string file = hamhotro.DocChuoi("Nhập tên tài liệu in", "Tailieu.pdf");
                        queue.Enqueue(file);
                        Console.WriteLine($"  - Đã thêm '{file}' vào danh sách chờ.");
                        break;
                    case 2:
                        if (queue.Count > 0)
                        {
                            Console.WriteLine("  [KẾT QUẢ] ĐANG IN: " + queue.Dequeue() + " ... Hoàn thành 100%!");
                        }
                        else Console.WriteLine("  [TRẠNG THÁI] Không có yêu cầu in nào trong hàng đợi!");
                        break;
                    case 3:
                        Console.WriteLine("  [TRẠNG THÁI] Tài liệu chờ in: " +
                            (queue.Count == 0 ? "(Rỗng)" : string.Join(" | ", queue)));
                        break;
                }
            }
        }
    }
}
