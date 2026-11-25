using System;
using System.Collections.Generic;

namespace Buoi03_Stack_Queue
{
    static class B10C5
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(" BÀI 10: ĐƯỜNG TRUYỀN DỮ LIỆU MẠNG NÂNG CAO");
            Console.WriteLine(new string('=', 60));
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                Console.WriteLine("\n=== BỘ ĐỆM ĐƯỜNG TRUYỀN MẠNG ===");
                Console.WriteLine("1. Gửi gói tin mạng mới");
                Console.WriteLine("2. Tiếp nhận và xử lý gói tin");
                Console.WriteLine("3. Hiển thị các gói tin đang chờ truyền");
                Console.WriteLine("0. Quay lại Menu chính");
                int chon = hamhotro.DocSo("Chọn", 1);

                if (chon == 0) break;
                switch (chon)
                {
                    case 1:
                        string packet = hamhotro.DocChuoi("Nhập tên gói tin mạng", "Packet_A");
                        queue.Enqueue(packet);
                        Console.WriteLine($"  - Đã đưa gói tin '{packet}' vào hàng đợi.");
                        break;
                    case 2:
                        if (queue.Count > 0)
                        {
                            Console.WriteLine("  [KẾT QUẢ] ĐANG TRUYỀN: " + queue.Dequeue() + " ... Thành công!");
                        }
                        else Console.WriteLine("  [TRẠNG THÁI] Bộ đệm rỗng, không có gói tin để truyền!");
                        break;
                    case 3:
                        Console.WriteLine("  [TRẠNG THÁI] Các gói tin đang xếp hàng: " +
                            (queue.Count == 0 ? "(Trống)" : string.Join(" | ", queue)));
                        break;
                }
            }
        }
    }
}
