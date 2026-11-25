# Buoi03_Stack_Queue

- Họ tên: Đỗ Mạnh Dũng
- MSV: 10125087
- Lớp: 124251

## Bài đã làm

### chương5

| Bài | Nội dung |
|---|---|
| 1 | Kiểm tra tính đúng đắn của biểu thức toán học |
| 2 | Mô phỏng lịch sử trình duyệt web (Cơ bản) |
| 3 | Mô phỏng quá trình thực thi chương trình (Call Stack) |
| 4 | Mô phỏng hệ thống in ấn (Cơ bản) |
| 5 | Mô phỏng đường truyền dữ liệu (Cơ bản) |
| 6 | Mô phỏng quản lý hàng đợi dịch vụ/ngân hàng (Cơ bản) |
| 7 | Mô phỏng lịch sử trình duyệt web nâng cao (Visit, Back, Forward) |
| 8 | Kiểm tra chuỗi ngoặc () đúng |
| 9 | Mô phỏng hệ thống in ấn (FIFO) quản lý chờ và in |
| 10 | Mô phỏng đường truyền dữ liệu trong mạng gửi và xử lý |
| 11 | Mô phỏng hàng đợi quản lý Dịch vụ Khách hàng ngân hàng |
| 12 | Tính giá trị của biểu thức toán học hậu tố (Postfix) |
| 13 | Kiểm tra tính hợp lệ của biểu thức trung tố toán học |
| 14 | Tính giá trị biểu thức trung tố toán học (Ba Lan) |

## Lệnh chạy

### chương5

```powershell
dotnet build .\Buoi03_Stack_and_Queue.csproj
.\bin\Debug\Buoi03_Stack_and_Queue.exe
```

Chương trình mở menu chính. Nhập số bài từ 1 đến 14 để chạy bài tương ứng.

Để chạy nhanh một bài mà không mở menu, truyền số bài làm đối số:

```powershell
.\bin\Debug\Buoi03_Stack_and_Queue.exe 1
.\bin\Debug\Buoi03_Stack_and_Queue.exe 2
.\bin\Debug\Buoi03_Stack_and_Queue.exe 3
.\bin\Debug\Buoi03_Stack_and_Queue.exe 4
.\bin\Debug\Buoi03_Stack_and_Queue.exe 5
.\bin\Debug\Buoi03_Stack_and_Queue.exe 6
.\bin\Debug\Buoi03_Stack_and_Queue.exe 7
.\bin\Debug\Buoi03_Stack_and_Queue.exe 8
.\bin\Debug\Buoi03_Stack_and_Queue.exe 9
.\bin\Debug\Buoi03_Stack_and_Queue.exe 10
.\bin\Debug\Buoi03_Stack_and_Queue.exe 11
.\bin\Debug\Buoi03_Stack_and_Queue.exe 12
.\bin\Debug\Buoi03_Stack_and_Queue.exe 13
.\bin\Debug\Buoi03_Stack_and_Queue.exe 14
```

## Kết quả chạy

### chương5

### bài1

```csharp
using System;
using System.Collections.Generic;

namespace Buoi03_Stack_Queue
{
    static class B1C5
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(" BÀI 1: KIỂM TRA TÍNH ĐÚNG ĐẮN CỦA BIỂU THỨC");
            Console.WriteLine(new string('=', 60));
            string expression = hamhotro.DocChuoi("Nhập biểu thức kiểm tra", "{[()]}");
            Stack<char> stack = new Stack<char>();
            bool isValid = true;

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }
                    char open = stack.Pop();
                    if ((c == ')' && open != '(') ||
                        (c == ']' && open != '[') ||
                        (c == '}' && open != '{'))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (stack.Count > 0) isValid = false;

            if (isValid)
                Console.WriteLine("  [KẾT QUẢ] Biểu thức đúng cấu trúc ngoặc!");
            else
                Console.WriteLine("  [KẾT QUẢ] Biểu thức sai cấu trúc ngoặc!");
        }
    }
}
```

#### kết quả

```text
Chọn nhanh bài: 1

============================================================
 BÀI 1: KIỂM TRA TÍNH ĐÚNG ĐẮN CỦA BIỂU THỨC
============================================================
Nhập biểu thức kiểm tra (Enter = "{[()]}"): {[()]}
  [KẾT QUẢ] Biểu thức đúng cấu trúc ngoặc!
```

### bài2

```csharp
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
```

#### kết quả

```text
Chọn nhanh bài: 2

============================================================
 BÀI 2: MÔ PHỎNG LỊCH SỬ DUYỆT WEB (CƠ BẢN)
============================================================
  [TRẠNG THÁI] Trang hiện tại: Trang_Chu
  - Truy cập 'Google.com'
  [TRẠNG THÁI] Trang hiện tại: Google.com
  - Truy cập 'Github.com'
  [TRẠNG THÁI] Trang hiện tại: Github.com
  - Nhấn nút 'BACK'
  [TRẠNG THÁI] Trang hiện tại: Google.com
  - Nhấn nút 'FORWARD'
  [TRẠNG THÁI] Trang hiện tại: Github.com
```

### bài3

```csharp
using System;
using System.Collections.Generic;

namespace Buoi03_Stack_Queue
{
    static class B3C5
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(" BÀI 3: MÔ PHỎNG QUÁ TRÌNH THỰC THI (CALL STACK)");
            Console.WriteLine(new string('=', 60));
            Stack<string> callStack = new Stack<string>();

            Console.WriteLine("  - Bắt đầu thực thi Main()");
            callStack.Push("Main()");

            Console.WriteLine("  - Main() gọi HamA()");
            callStack.Push("HamA()");

            Console.WriteLine("  - HamA() gọi HamB()");
            callStack.Push("HamB()");

            Console.WriteLine("  [TRẠNG THÁI] Danh sách các hàm đang chờ trong Call Stack:");
            foreach (var func in callStack)
            {
                Console.WriteLine("  - | " + func + " |");
            }
            Console.WriteLine("  - +----------+");

            Console.WriteLine("  - HàmB() thực thi xong, quay về hàm gọi...");
            callStack.Pop();

            Console.WriteLine("  - HàmA() thực thi xong, quay về hàm gọi...");
            callStack.Pop();

            Console.WriteLine("  [TRẠNG THÁI] Call Stack còn lại:");
            foreach (var func in callStack)
            {
                Console.WriteLine("  - | " + func + " |");
            }
            Console.WriteLine("  - +----------+");
        }
    }
}
```

#### kết quả

```text
Chọn nhanh bài: 3

============================================================
 BÀI 3: MÔ PHỎNG QUÁ TRÌNH THỰC THI (CALL STACK)
============================================================
  - Bắt đầu thực thi Main()
  - Main() gọi HamA()
  - HamA() gọi HamB()
  [TRẠNG THÁI] Danh sách các hàm đang chờ trong Call Stack:
  - | HamB() |
  - | HamA() |
  - | Main() |
  - +----------+
  - HàmB() thực thi xong, quay về hàm gọi...
  - HàmA() thực thi xong, quay về hàm gọi...
  [TRẠNG THÁI] Call Stack còn lại:
  - | Main() |
  - +----------+
```

### bài4

```csharp
using System;
using System.Collections.Generic;

namespace Buoi03_Stack_Queue
{
    static class B4C5
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(" BÀI 4: MÔ PHỎNG HỆ THỐNG IN ẤN (CƠ BẢN)");
            Console.WriteLine(new string('=', 60));
            Queue<string> printQueue = new Queue<string>();

            Console.WriteLine("  - Thêm tài liệu vào hàng đợi: BaoCao.pdf");
            printQueue.Enqueue("BaoCao.pdf");

            Console.WriteLine("  - Thêm tài liệu vào hàng đợi: HinhAnh.png");
            printQueue.Enqueue("HinhAnh.png");

            Console.WriteLine("  - Thêm tài liệu vào hàng đợi: BaiTap.docx");
            printQueue.Enqueue("BaiTap.docx");

            Console.WriteLine("  [TRẠNG THÁI] Bắt đầu in theo nguyên lý FIFO (First In First Out):");
            while (printQueue.Count > 0)
            {
                string doc = printQueue.Dequeue();
                Console.WriteLine("  [KẾT QUẢ] Đang in: " + doc + " ... Hoàn thành!");
            }
        }
    }
}
```

#### kết quả

```text
Chọn nhanh bài: 4

============================================================
 BÀI 4: MÔ PHỎNG HỆ THỐNG IN ẤN (CƠ BẢN)
============================================================
  - Thêm tài liệu vào hàng đợi: BaoCao.pdf
  - Thêm tài liệu vào hàng đợi: HinhAnh.png
  - Thêm tài liệu vào hàng đợi: BaiTap.docx
  [TRẠNG THÁI] Bắt đầu in theo nguyên lý FIFO (First In First Out):
  [KẾT QUẢ] Đang in: BaoCao.pdf ... Hoàn thành!
  [KẾT QUẢ] Đang in: HinhAnh.png ... Hoàn thành!
  [KẾT QUẢ] Đang in: BaiTap.docx ... Hoàn thành!
```

### bài5

```csharp
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
```

#### kết quả

```text
Chọn nhanh bài: 5

============================================================
 BÀI 5: MÔ PHỎNG ĐƯỜNG TRUYỀN DỮ LIỆU (CƠ BẢN)
============================================================
  - Gửi gói tin: Packet_1
  - Gửi gói tin: Packet_2
  - Gửi gói tin: Packet_3
  [TRẠNG THÁI] Bộ đệm mạng xử lý và truyền gói tin đến đích:
  [KẾT QUẢ] Đang truyền gói tin: Packet_1 ... Thành công!
  [KẾT QUẢ] Đang truyền gói tin: Packet_2 ... Thành công!
  [KẾT QUẢ] Đang truyền gói tin: Packet_3 ... Thành công!
```

### bài6

```csharp
using System;
using System.Collections.Generic;

namespace Buoi03_Stack_Queue
{
    static class B6C5
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(" BÀI 6: QUẢN LÝ HÀNG ĐỢI DỊCH VỤ / NGÂN HÀNG (CƠ BẢN)");
            Console.WriteLine(new string('=', 60));
            Queue<string> customers = new Queue<string>();

            Console.WriteLine("  - Khách hàng Nguyễn Văn A vào hàng đợi.");
            customers.Enqueue("Nguyễn Văn A");

            Console.WriteLine("  - Khách hàng Trần Thị B vào hàng đợi.");
            customers.Enqueue("Trần Thị B");

            Console.WriteLine("  - Khách hàng Lê Văn C vào hàng đợi.");
            customers.Enqueue("Lê Văn C");

            Console.WriteLine("  [TRẠNG THÁI] Bắt đầu gọi phục vụ theo lượt xếp hàng:");
            while (customers.Count > 0)
            {
                string client = customers.Dequeue();
                Console.WriteLine("  [KẾT QUẢ] Mời khách hàng: " + client + " vào quầy phục vụ... Xong!");
            }
        }
    }
}
```

#### kết quả

```text
Chọn nhanh bài: 6

============================================================
 BÀI 6: QUẢN LÝ HÀNG ĐỢI DỊCH VỤ / NGÂN HÀNG (CƠ BẢN)
============================================================
  - Khách hàng Nguyễn Văn A vào hàng đợi.
  - Khách hàng Trần Thị B vào hàng đợi.
  - Khách hàng Lê Văn C vào hàng đợi.
  [TRẠNG THÁI] Bắt đầu gọi phục vụ theo lượt xếp hàng:
  [KẾT QUẢ] Mời khách hàng: Nguyễn Văn A vào quầy phục vụ... Xong!
  [KẾT QUẢ] Mời khách hàng: Trần Thị B vào quầy phục vụ... Xong!
  [KẾT QUẢ] Mời khách hàng: Lê Văn C vào quầy phục vụ... Xong!
```

### bài7

```csharp
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
```

#### kết quả

```text
Chọn nhanh bài: 7

============================================================
 BÀI 7: LỊCH SỬ TRÌNH DUYỆT WEB NÂNG CAO
============================================================

=== MÔ PHỎNG TRÌNH DUYỆT ===
1. Truy cập trang mới (Visit)
2. Quay lại (Back)
3. Tiến lên (Forward)
4. Hiển thị trang hiện tại
0. Quay lại Menu chính
Chọn chức năng (Enter = 4): 1
Nhập địa chỉ URL trang mới (Enter = "youtube.com"): example.com
  - Đang truy cập: example.com

=== MÔ PHỎNG TRÌNH DUYỆT ===
1. Truy cập trang mới (Visit)
2. Quay lại (Back)
3. Tiến lên (Forward)
4. Hiển thị trang hiện tại
0. Quay lại Menu chính
Chọn chức năng (Enter = 4): 4
  [TRẠNG THÁI] Trang hiện tại: example.com

=== MÔ PHỎNG TRÌNH DUYỆT ===
1. Truy cập trang mới (Visit)
2. Quay lại (Back)
3. Tiến lên (Forward)
4. Hiển thị trang hiện tại
0. Quay lại Menu chính
Chọn chức năng (Enter = 4): 2
  [KẾT QUẢ] Quay lại thành công: homepage.com

=== MÔ PHỎNG TRÌNH DUYỆT ===
1. Truy cập trang mới (Visit)
2. Quay lại (Back)
3. Tiến lên (Forward)
4. Hiển thị trang hiện tại
0. Quay lại Menu chính
Chọn chức năng (Enter = 4): 3
  [KẾT QUẢ] Tiến lên thành công: example.com

=== MÔ PHỎNG TRÌNH DUYỆT ===
1. Truy cập trang mới (Visit)
2. Quay lại (Back)
3. Tiến lên (Forward)
4. Hiển thị trang hiện tại
0. Quay lại Menu chính
Chọn chức năng (Enter = 4): 0
```

### bài8

```csharp
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
```

#### kết quả

```text
Chọn nhanh bài: 8

============================================================
 BÀI 8: KIỂM TRA CHUỖI NGOẶC () ĐÚNG
============================================================
Nhập chuỗi ngoặc tròn (Enter = "(())()"): (())()
  [KẾT QUẢ] Xâu đúng cấu trúc ngoặc tròn!
```

### bài9

```csharp
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
```

#### kết quả

```text
Chọn nhanh bài: 9

============================================================
 BÀI 9: HỆ THỐNG IN ẤN (FIFO NÂNG CAO)
============================================================

=== MENU IN ẤN ===
1. Thêm yêu cầu in mới
2. Thực hiện in tài liệu
3. Hiển thị danh sách đang chờ in
0. Quay lại Menu chính
Chọn (Enter = 1): 1
Nhập tên tài liệu in (Enter = "Tailieu.pdf"): sample.pdf
  - Đã thêm 'sample.pdf' vào danh sách chờ.

=== MENU IN ẤN ===
1. Thêm yêu cầu in mới
2. Thực hiện in tài liệu
3. Hiển thị danh sách đang chờ in
0. Quay lại Menu chính
Chọn (Enter = 1): 3
  [TRẠNG THÁI] Tài liệu chờ in: sample.pdf

=== MENU IN ẤN ===
1. Thêm yêu cầu in mới
2. Thực hiện in tài liệu
3. Hiển thị danh sách đang chờ in
0. Quay lại Menu chính
Chọn (Enter = 1): 2
  [KẾT QUẢ] ĐANG IN: sample.pdf ... Hoàn thành 100%!

=== MENU IN ẤN ===
1. Thêm yêu cầu in mới
2. Thực hiện in tài liệu
3. Hiển thị danh sách đang chờ in
0. Quay lại Menu chính
Chọn (Enter = 1): 2
  [TRẠNG THÁI] Không có yêu cầu in nào trong hàng đợi!

=== MENU IN ẤN ===
1. Thêm yêu cầu in mới
2. Thực hiện in tài liệu
3. Hiển thị danh sách đang chờ in
0. Quay lại Menu chính
Chọn (Enter = 1): 0
```

### bài10

```csharp
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
```

#### kết quả

```text
Chọn nhanh bài: 10

============================================================
 BÀI 10: ĐƯỜNG TRUYỀN DỮ LIỆU MẠNG NÂNG CAO
============================================================

=== BỘ ĐỆM ĐƯỜNG TRUYỀN MẠNG ===
1. Gửi gói tin mạng mới
2. Tiếp nhận và xử lý gói tin
3. Hiển thị các gói tin đang chờ truyền
0. Quay lại Menu chính
Chọn (Enter = 1): 1
Nhập tên gói tin mạng (Enter = "Packet_A"): packet-test
  - Đã đưa gói tin 'packet-test' vào hàng đợi.

=== BỘ ĐỆM ĐƯỜNG TRUYỀN MẠNG ===
1. Gửi gói tin mạng mới
2. Tiếp nhận và xử lý gói tin
3. Hiển thị các gói tin đang chờ truyền
0. Quay lại Menu chính
Chọn (Enter = 1): 3
  [TRẠNG THÁI] Các gói tin đang xếp hàng: packet-test

=== BỘ ĐỆM ĐƯỜNG TRUYỀN MẠNG ===
1. Gửi gói tin mạng mới
2. Tiếp nhận và xử lý gói tin
3. Hiển thị các gói tin đang chờ truyền
0. Quay lại Menu chính
Chọn (Enter = 1): 2
  [KẾT QUẢ] ĐANG TRUYỀN: packet-test ... Thành công!

=== BỘ ĐỆM ĐƯỜNG TRUYỀN MẠNG ===
1. Gửi gói tin mạng mới
2. Tiếp nhận và xử lý gói tin
3. Hiển thị các gói tin đang chờ truyền
0. Quay lại Menu chính
Chọn (Enter = 1): 2
  [TRẠNG THÁI] Bộ đệm rỗng, không có gói tin để truyền!

=== BỘ ĐỆM ĐƯỜNG TRUYỀN MẠNG ===
1. Gửi gói tin mạng mới
2. Tiếp nhận và xử lý gói tin
3. Hiển thị các gói tin đang chờ truyền
0. Quay lại Menu chính
Chọn (Enter = 1): 0
```

### bài11

```csharp
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
```

#### kết quả

```text
Chọn nhanh bài: 11

============================================================
 BÀI 11: QUẢN LÝ DỊCH VỤ KHÁCH HÀNG NGÂN HÀNG
============================================================

=== QUẦY GIAO DỊCH NGÂN HÀNG ===
1. Khách hàng mới lấy số (Xếp hàng)
2. Mời số tiếp theo vào quầy (Phục vụ)
3. Hiển thị các khách hàng đang chờ
0. Quay lại Menu chính
Chọn (Enter = 1): 1
Nhập tên khách hàng (Enter = "Vũ Văn Long"): Khach Test
  - Khách hàng 'Khach Test' đã nhận số thứ tự thành công.

=== QUẦY GIAO DỊCH NGÂN HÀNG ===
1. Khách hàng mới lấy số (Xếp hàng)
2. Mời số tiếp theo vào quầy (Phục vụ)
3. Hiển thị các khách hàng đang chờ
0. Quay lại Menu chính
Chọn (Enter = 1): 3
  [TRẠNG THÁI] Danh sách khách hàng xếp hàng: Khach Test

=== QUẦY GIAO DỊCH NGÂN HÀNG ===
1. Khách hàng mới lấy số (Xếp hàng)
2. Mời số tiếp theo vào quầy (Phục vụ)
3. Hiển thị các khách hàng đang chờ
0. Quay lại Menu chính
Chọn (Enter = 1): 2
  [KẾT QUẢ] ĐANG PHỤC VỤ khách hàng: Khach Test ... Giao dịch hoàn tất!

=== QUẦY GIAO DỊCH NGÂN HÀNG ===
1. Khách hàng mới lấy số (Xếp hàng)
2. Mời số tiếp theo vào quầy (Phục vụ)
3. Hiển thị các khách hàng đang chờ
0. Quay lại Menu chính
Chọn (Enter = 1): 2
  [TRẠNG THÁI] Hiện không có khách hàng nào đang đợi!

=== QUẦY GIAO DỊCH NGÂN HÀNG ===
1. Khách hàng mới lấy số (Xếp hàng)
2. Mời số tiếp theo vào quầy (Phục vụ)
3. Hiển thị các khách hàng đang chờ
0. Quay lại Menu chính
Chọn (Enter = 1): 0
```

### bài12

```csharp
using System;
using System.Collections.Generic;

namespace Buoi03_Stack_Queue
{
    static class B12C5
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(" BÀI 12: TÍNH GIÁ TRỊ BIỂU THỨC HẬU TỐ");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("  - Các toán tử và toán hạng phải cách nhau bằng khoảng trắng. Ví dụ: 3 4 2 * +");
            string postfix = hamhotro.DocChuoi("Nhập biểu thức hậu tố", "3 4 2 * +");

            try
            {
                string[] tokens = postfix.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Stack<double> stack = new Stack<double>();

                foreach (string token in tokens)
                {
                    double val;
                    if (double.TryParse(token, out val))
                    {
                        stack.Push(val);
                    }
                    else
                    {
                        double b = stack.Pop();
                        double a = stack.Pop();
                        switch (token)
                        {
                            case "+": stack.Push(a + b); break;
                            case "-": stack.Push(a - b); break;
                            case "*": stack.Push(a * b); break;
                            case "/": stack.Push(a / b); break;
                            default: throw new InvalidOperationException("Toán tử không hợp lệ!");
                        }
                    }
                }
                Console.WriteLine("  [KẾT QUẢ] Giá trị biểu thức hậu tố: " + stack.Pop());
            }
            catch (Exception)
            {
                Console.WriteLine("  [TRẠNG THÁI] Biểu thức hậu tố sai cấu trúc hoặc thiếu khoảng trắng!");
            }
        }
    }
}
```

#### kết quả

```text
Chọn nhanh bài: 12

============================================================
 BÀI 12: TÍNH GIÁ TRỊ BIỂU THỨC HẬU TỐ
============================================================
  - Các toán tử và toán hạng phải cách nhau bằng khoảng trắng. Ví dụ: 3 4 2 * +
Nhập biểu thức hậu tố (Enter = "3 4 2 * +"): 3 4 2 * +
  [KẾT QUẢ] Giá trị biểu thức hậu tố: 11
```

### bài13

```csharp
using System;
using System.Collections.Generic;

namespace Buoi03_Stack_Queue
{
    static class B13C5
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(" BÀI 13: KIỂM TRA TÍNH HỢP LỆ TRUNG TỐ");
            Console.WriteLine(new string('=', 60));
            string infix = hamhotro.DocChuoi("Nhập biểu thức trung tố", "[(3+4)*2]");
            Stack<char> stack = new Stack<char>();
            bool isValid = true;

            foreach (char c in infix)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }
                    char open = stack.Pop();
                    if ((c == ')' && open != '(') ||
                        (c == ']' && open != '[') ||
                        (c == '}' && open != '{'))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (stack.Count > 0) isValid = false;

            if (isValid)
                Console.WriteLine("  [KẾT QUẢ] Biểu thức trung tố HỢP LỆ!");
            else
                Console.WriteLine("  [KẾT QUẢ] Biểu thức trung tố KHÔNG HỢP LỆ!");
        }
    }
}
```

#### kết quả

```text
Chọn nhanh bài: 13

============================================================
 BÀI 13: KIỂM TRA TÍNH HỢP LỆ TRUNG TỐ
============================================================
Nhập biểu thức trung tố (Enter = "[(3+4)*2]"): [(3+4)*2]
  [KẾT QUẢ] Biểu thức trung tố HỢP LỆ!
```

### bài14

```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace Buoi03_Stack_Queue
{
    static class B14C5
    {
        static bool IsOperand(string s)
        {
            double num;
            return double.TryParse(s, out num);
        }

        static int Pri(string op)
        {
            if (op == "+" || op == "-") return 1;
            if (op == "*" || op == "/") return 2;
            return 0;
        }

        static string HauTo(string infixExpression)
        {
            Stack<string> St = new Stack<string>();
            StringBuilder E1 = new StringBuilder();
            string[] tokens = infixExpression.Split(' ');

            foreach (string s in tokens)
            {
                if (string.IsNullOrWhiteSpace(s)) continue;

                if (s == "(")
                {
                    St.Push(s);
                }
                else if (s == ")")
                {
                    while (St.Count > 0 && St.Peek() != "(")
                    {
                        E1.Append(St.Pop()).Append(" ");
                    }
                    if (St.Count > 0) St.Pop(); 
                }
                else if (IsOperand(s))
                {
                    E1.Append(s).Append(" ");
                }
                else 
                {
                    while (St.Count > 0 && Pri(St.Peek()) >= Pri(s))
                    {
                        E1.Append(St.Pop()).Append(" ");
                    }
                    St.Push(s);
                }
            }

            while (St.Count > 0)
            {
                E1.Append(St.Pop()).Append(" ");
            }

            return E1.ToString().Trim();
        }

        
        static double TinhHauTo(string postfix)
        {
            string[] tokens = postfix.Split(' ');
            Stack<double> stack = new Stack<double>();

            foreach (string token in tokens)
            {
                if (string.IsNullOrWhiteSpace(token)) continue;

                double val;
                if (double.TryParse(token, out val))
                {
                    stack.Push(val);
                }
                else
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    switch (token)
                    {
                        case "+": stack.Push(a + b); break;
                        case "-": stack.Push(a - b); break;
                        case "*": stack.Push(a * b); break;
                        case "/": stack.Push(a / b); break;
                    }
                }
            }
            return stack.Pop();
        }

        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(" BÀI 14: TÍNH GIÁ TRỊ BIỂU THỨC TRUNG TỐ");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("  - Các toán tử và toán hạng cách nhau bằng khoảng trắng. Ví dụ: 3 + 4 * 2");
            string infix = hamhotro.DocChuoi("Nhập biểu thức trung tố", "3 + 4 * 2");

            try
            {
                string postfix = HauTo(infix);
                Console.WriteLine("  - Biểu thức hậu tố (Postfix): " + postfix);

                double ketQua = TinhHauTo(postfix);
                Console.WriteLine("  [KẾT QUẢ] Giá trị biểu thức: " + ketQua);
            }
            catch (Exception)
            {
                Console.WriteLine("  [TRẠNG THÁI] Biểu thức không hợp lệ! Vui lòng kiểm tra lại khoảng trắng giữa các phần tử.");
            }
        }
    }
}
```

#### kết quả

```text
Chọn nhanh bài: 14

============================================================
 BÀI 14: TÍNH GIÁ TRỊ BIỂU THỨC TRUNG TỐ
============================================================
  - Các toán tử và toán hạng cách nhau bằng khoảng trắng. Ví dụ: 3 + 4 * 2
Nhập biểu thức trung tố (Enter = "3 + 4 * 2"): 3 + 4 * 2
  - Biểu thức hậu tố (Postfix): 3 4 2 * +
  [KẾT QUẢ] Giá trị biểu thức: 11
```
