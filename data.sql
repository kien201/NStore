USE [WebsiteBanHang]
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([id], [taiKhoan], [matKhau], [hoTen], [email], [soDienThoai], [ngaySinh], [gioiTinh], [diaChi]) VALUES (1, N'kien123', N'202cb962ac59075b964b07152d234b70', N'Trần Kiên', N'kien123@gmail.com', N'03397529422', CAST(N'2001-11-24' AS Date), N'Nam', N'Tây Mỗ, Nam Từ Liêm, Hà Nội')
INSERT [dbo].[KhachHang] ([id], [taiKhoan], [matKhau], [hoTen], [email], [soDienThoai], [ngaySinh], [gioiTinh], [diaChi]) VALUES (3, N'11', N'202cb962ac59075b964b07152d234b70', N'kien123', N'vip2k18@gmail.com', N'1141094202', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[NhomDanhMuc] ON 

INSERT [dbo].[NhomDanhMuc] ([id], [tenNhomDanhMuc], [img]) VALUES (1, N'Phòng khách', N'ghe-sofa-chu-l-phong-khach.jpg')
INSERT [dbo].[NhomDanhMuc] ([id], [tenNhomDanhMuc], [img]) VALUES (2, N'Phòng ngủ', N'phong-ngu-dep.jpg')
INSERT [dbo].[NhomDanhMuc] ([id], [tenNhomDanhMuc], [img]) VALUES (3, N'Phòng làm việc', N'avar-ban-giam-doc.jpg')
INSERT [dbo].[NhomDanhMuc] ([id], [tenNhomDanhMuc], [img]) VALUES (4, N'Phòng ăn & Bếp', N'he-tu-bep-thong-minh-thiet-ke-khoa-hoc.jpg')
SET IDENTITY_INSERT [dbo].[NhomDanhMuc] OFF
GO
SET IDENTITY_INSERT [dbo].[DanhMuc] ON 

INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (1, 1, N'Bàn cà phê')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (2, 1, N'Tủ kệ Tivi')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (3, 1, N'Ghế thư giãn')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (4, 1, N'Sản phẩm gắn tường')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (5, 1, N'Đèn sàn')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (6, 1, N'Hoa & Lọ hoa')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (7, 1, N'Gối trang trí')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (8, 1, N'Ghế đôn')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (9, 2, N'Nệm')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (10, 2, N'Chăn ga gối')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (11, 2, N'Tủ quần áo')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (12, 2, N'Tủ đầu giường')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (13, 2, N'Bàn trang điểm')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (14, 2, N'Gương')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (15, 2, N'Khung tranh')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (16, 2, N'Tinh dầu & túi thơm')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (17, 4, N'Bàn ăn')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (18, 4, N'Ghế ăn')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (19, 4, N'Bàn ngoài trời')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (20, 4, N'Đồ dùng bàn ăn')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (21, 4, N'Dụng cụ làm bếp')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (22, 4, N'Bảo quản thực phẩm')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (23, 4, N'Tiện ích sẵp xếp nhà bếp')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (24, 4, N'Đồ dùng vải cho bếp')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (25, 3, N'Bàn làm việc')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (26, 3, N'Ghế văn phòng')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (27, 3, N'Kệ sách')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (28, 3, N'Đèn')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (29, 3, N'Đồ dùng văn phòng')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (30, 3, N'Thùng rác')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (31, 3, N'Sản phẩm gắn tường')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc]) VALUES (32, 3, N'Tinh dầu & túi thơm')
SET IDENTITY_INSERT [dbo].[DanhMuc] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([id], [taiKhoan], [matKhau], [hoTen], [CCCD], [email], [soDienThoai], [ngaySinh], [gioiTinh], [diaChi], [chucVu]) VALUES (1, N'kien123', N'202cb962ac59075b964b07152d234b70', N'Trần Kiên', N'033201002759', N'kientr201@gmail.com', N'0372938109', CAST(N'2001-11-24' AS Date), N'Nam', N'Tây Mỗ, Nam Từ Liêm, Hà Nội', 1)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
