# 💊 NhaThuoc – Ứng dụng quản lý nhà thuốc đơn giản

Ứng dụng Android tích hợp Google **ML Kit** để nhận diện khuôn mặt người dùng và phân loại nhóm tính cách dựa trên đặc điểm hình học gương mặt. Dự án lần đầu được phát triển trong Khoá luận tốt nghiệp năm 2025.

## 🔍 Mục tiêu
- Thu thập hình ảnh gương mặt và trích xuất landmark (mắt, mũi, miệng...)
- Suy luận nhóm tính cách dựa trên tri thức nhân tướng học
- Cung cấp giao diện người dùng đơn giản để quản lý và xem kết quả phân tích

## 🚀 Công nghệ sử dụng
- Android (Java + Android Studio)  
- Google ML Kit (Face Contour, Landmark) :contentReference[oaicite:1]{index=1}  
- Room Database (lưu trữ nội bộ)  
- RecyclerView, XML Layout  

## 🧰 Hướng dẫn chạy dự án
1. Clone repository:
   ```bash
   git clone https://github.com/HuynhNgocMy1910/NhaThuoc.git
   cd NhaThuoc/DoAn2
2. Mở bằng Android Studio

3. Build và chạy trên máy thật hoặc emulator Android (SDK ≥ 23)

4. Cho phép app truy cập camera nếu cần
DoAn2/
├─ app/                   # Mã nguồn Android
├─ .gitignore             
├─ README.md             
└─ ...

