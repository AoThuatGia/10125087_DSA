using System;
using System.Collections.Generic;

namespace Buoi03_Stack_Queue
{
    static class B11C5
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(" BÀI 11: QUẢN LÝ DỊCH VỤ KHÁCH HÀNG NGÂN HÀNG");
            Console.WriteLine(new string('=', 60));
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                Console.WriteLine("\n=== QUẦY GIAO DỊCH NGÂN HÀNG ===");
                Console.WriteLine("1. Khách hàng mới lấy số (Xếp hàng)");
                Console.WriteLine("2. Mời số tiếp theo vào quầy (Phục vụ)");
                Console.WriteLine("3. Hiển thị các khách hàng đang chờ");
                Console.WriteLine("0. Quay lại Menu chính");
                int chon = hamhotro.DocSo("Chọn", 1);

                if (chon == 0) break;
                switch (chon)
                {
                    case 1:
                        string name = hamhotro.DocChuoi("Nhập tên khách hàng", "Vũ Văn Long");
                        queue.Enqueue(name);
                        Console.WriteLine($"  - Khách hàng '{name}' đã nhận số thứ tự thành công.");
                        break;
                    case 2:
                        if (queue.Count > 0)
                        {
                            Console.WriteLine("  [KẾT QUẢ] ĐANG PHỤC VỤ khách hàng: " + queue.Dequeue() + " ... Giao dịch hoàn tất!");
                        }
                        else Console.WriteLine("  [TRẠNG THÁI] Hiện không có khách hàng nào đang đợi!");
                        break;
                    case 3:
                        Console.WriteLine("  [TRẠNG THÁI] Danh sách khách hàng xếp hàng: " +
                            (queue.Count == 0 ? "(Trống)" : string.Join(" | ", queue)));
                        break;
                }
            }
        }
    }
}
