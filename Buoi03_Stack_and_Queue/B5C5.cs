using System;
using System.Collections.Generic;

namespace Buoi03_Stack_Queue
{
    static class B5C5
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(" BÀI 5: MÔ PHỎNG ĐƯỜNG TRUYỀN DỮ LIỆU (CƠ BẢN)");
            Console.WriteLine(new string('=', 60));
            Queue<string> networkQueue = new Queue<string>();

            Console.WriteLine("  - Gửi gói tin: Packet_1");
            networkQueue.Enqueue("Packet_1");

            Console.WriteLine("  - Gửi gói tin: Packet_2");
            networkQueue.Enqueue("Packet_2");

            Console.WriteLine("  - Gửi gói tin: Packet_3");
            networkQueue.Enqueue("Packet_3");

            Console.WriteLine("  [TRẠNG THÁI] Bộ đệm mạng xử lý và truyền gói tin đến đích:");
            while (networkQueue.Count > 0)
            {
                string packet = networkQueue.Dequeue();
                Console.WriteLine("  [KẾT QUẢ] Đang truyền gói tin: " + packet + " ... Thành công!");
            }
        }
    }
}
