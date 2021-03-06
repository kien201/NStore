--kien123 - 123
USE [WebsiteBanHang]
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([id], [taiKhoan], [matKhau], [hoTen], [email], [soDienThoai], [ngaySinh], [gioiTinh], [diaChi]) VALUES (1, N'kien123', N'202cb962ac59075b964b07152d234b70', N'Trần Kiên', N'kien123@gmail.com', N'03397529422', CAST(N'2001-11-24' AS Date), N'Nam', N'Tây Mỗ, Nam Từ Liêm, Hà Nội')
INSERT [dbo].[KhachHang] ([id], [taiKhoan], [matKhau], [hoTen], [email], [soDienThoai], [ngaySinh], [gioiTinh], [diaChi]) VALUES (4, N'sonng22', N'202cb962ac59075b964b07152d234b70', N'Nguyễn Văn Sơn', N'sonng22@gmail.com', N'0977876023', CAST(N'2002-06-04' AS Date), N'Nam', N'Hoàng Quốc Việt, Bắc Từ Liêm, Hà Nội')
INSERT [dbo].[KhachHang] ([id], [taiKhoan], [matKhau], [hoTen], [email], [soDienThoai], [ngaySinh], [gioiTinh], [diaChi]) VALUES (5, N'uyntr21', N'202cb962ac59075b964b07152d234b70', N'Trần Thị Phương Uyên', N'uyn21@gmail.com', N'0982776045', CAST(N'2001-11-04' AS Date), N'Nữ', N'Tứ Liên, Tây Hồ, Hà Nội')
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

INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (1, 1, N'Bàn cà phê', N'ban-ca-phe-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (2, 1, N'Tủ kệ Tivi', N'ke-tivi-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (3, 1, N'Ghế thư giãn', N'ghe-thu-gian-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (4, 1, N'Sản phẩm gắn tường', N'ke-trang-tri-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (5, 1, N'Đèn sàn', N'den-san-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (6, 1, N'Hoa & Lọ hoa', N'lo-hoa-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (7, 1, N'Gối trang trí', N'vo-goi-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (8, 1, N'Ghế đôn', N'don-mem-co-hoc-joey-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (9, 2, N'Nệm', N'nem-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (10, 2, N'Chăn ga gối', N'chan-ga-goi-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (11, 2, N'Tủ quần áo', N'tu-quan-ao-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (12, 2, N'Tủ đầu giường', N'tu-dau-giuong-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (13, 2, N'Bàn trang điểm', N'ban-trang-diem-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (14, 2, N'Gương', N'guong-trang-diem-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (15, 2, N'Khung tranh', N'tranh-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (17, 4, N'Bàn ăn', N'ban-an-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (18, 4, N'Ghế ăn', N'bo-ban-ghe-an-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (19, 4, N'Bàn ngoài trời', N'bo-ban-an-ngoai-troi-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (20, 4, N'Đồ dùng bàn ăn', N'do-dung-ban-an-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (21, 4, N'Dụng cụ làm bếp', N'dung-cu-lam-bep-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (22, 4, N'Bảo quản thực phẩm', N'bo-hop-dung-thuc-pham-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (23, 4, N'Tiện ích sẵp xếp nhà bếp', N'bo-suu-tap-sap-xep-nha-bep-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (24, 4, N'Đồ dùng vải cho bếp', N'do-dung-vai-cho-bep-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (25, 3, N'Bàn làm việc', N'ban-van-phong-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (26, 3, N'Ghế văn phòng', N'ghe-van-phong-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (27, 3, N'Kệ sách', N'ke-sach-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (28, 3, N'Đèn', N'den-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (29, 3, N'Đồ dùng văn phòng', N'do-dung-van-phong-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (30, 3, N'Thùng rác', N'thung-rac-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (31, 3, N'Sản phẩm gắn tường', N'san-pham-gan-tuong-menu.jpg')
INSERT [dbo].[DanhMuc] ([id], [idNhomDanhMuc], [tenDanhMuc], [img]) VALUES (33, 3, N'Tinh dầu & túi thơm', N'hoa-kho-luu-huong-menu.jpg')
SET IDENTITY_INSERT [dbo].[DanhMuc] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (1, N'Bàn cà phê Connemara', 1, N'Ban-ca-phe-CONNEMARA-1.jpg', NULL, N'L100xW60xH42', N'Nâu đậm', N'Walnut-veneer', N'Việt Nam', 4990000, 5, 8)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (2, N'Chăn Bella', 10, N'bella_comforter_baya_2000556.jpg', N'Chăn được làm từ 100% polyester dạng lông cừu, lông mềm mại, độ bền cao, bền màu, nhẹ, giữ nhiệt và giữa ấm tốt, không phai màu, không bị rụng lông trong quá trình sử dụng
Bề mặt chăn mềm mại, mịn màng , tạo cảm giác dễ chịu, thoải mái, giúp mang lại giấc ngủ ngon và ấm áp cho bạn, an toàn với làn da trẻ em, nhạy cảm đem lại trải nghiệm tuyệt vời.
Chăn có trọng lượng nhẹ, tạo cảm giác rất thoải mái khi chạm vào da bởi chất liệu lông cừu mềm mịn như nhung, thích hợp sử dụng với cả những người dùng hoặc trẻ nhỏ có làn da mỏng, nhạy cảm.
Chăn với các sợi lông siêu nhỏ kết hợp cùng đặc điểm của len lông đó là nhẹ và có tính cách nhiệt rất tốt, nên khi đắp ngay lập tức sẽ mang lại cảm giác ấm áp và luôn tạo sự thoải mái dễ chịu cho người dùng. Ngoài ra, với kỹ thuật dệt may tiên tiến còn giúp cho chăn không chỉ ấm mà còn tạo sự thông thoáng, không bị ẩm hay bí khí. Chất liệu chất lượng cao, không phai màu khi giặt, không bị rụng lông trong suốt quá trình sử dụng.
Họa tiết màu sắc tươi sáng tạo cảm giác ấm cũng cho phòng ngủ.
Sản phẩm có thể sử dụng với nhiều công dụng khác nhau như làm chăn văn phòng, chăn đắp khi ngủ, chăn thư giãn sofa, chăn cho em bé, chăn dùng trên ô tô, khi đi du lịch khi gấp lại có thể dùng decor, dù sử dụng với mục đích nào thì cũng khiến bạn cảm thấy dễ chịu, vừa thoáng khí và vô cùng ấm áp.', N'L200xW150 - Tenderness step', N'Nhiều màu', N'Vải tổng hợp', N'Thái Lan', 599000, 0, 19)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (3, N'Bàn cà phê Anne', 1, N'anne_coffee_table_baya_7100020_4.jpg', NULL, N'D105xW52xH35', N'Màu kem nhạt', N'Aluminum-Petan-Glass', N'Việt Nam', 2490000, 30, 0)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (4, N'Bàn cà phê Carine', 1, N'carine_coffee_table_baya_5276.jpg', N'Thanh lịch, quý phái, và đầy tiện ích! Bạn còn có thể đòi hỏi gì nữa ở chiếc bàn cà phê CARINE tuyệt vời này chứ!
Được làm từ chất liệu gỗ sồi veneer cao cấp và khung sắt sơn tĩnh điện, chiếc bàn cà phê CARINE quả thật là một điểm nhấn bắt mắt mà không ai có thể bỏ lỡ.
Và đừng bao giờ tự giới hạn bản thân mình hết! Phòng khách hay phòng ngủ, chiếc bàn cà phê này đều phù hợp hết cả! Sản phẩm là một thiết kế độc quyền của NStore.', N'H50xDia80', N'Light-Wood-Black', N'MDF-Oak-Veneer-Metal', N'Việt Nam', 4990000, 0, 0)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (5, N'Sọt rác Soji', 30, N'soji_waste_bin_baya_2000247.jpg', N'Thùng rác (15 lít) có vỏ thùng được làm bằng inox được bao phủ bởi lớp nano bền bỉ và sang trọng. Khay đựng bên trong có thể tháo rời tiện lợi, giúp việc lấy rác ra khỏi thùng dễ dàng sản phẩm ứng dụng công nghệ nắp kháng khuẩn E 99% đảm bảo nắp thùng rác luôn sạch khuẩn.
Ngăn đựng sáp chống côn trùng bên dưới nắp thùng đảm bảo thùng rác và không gian sống luôn sạch sẽ, hợp vệ sinh. Nút cài túi rác làm tối ưu hóa thao tác thay rác và đảm bảo tính thẩm mỹ cho sản phẩm và mái ấm của bạn.', N'D29xW27xH43', N'Màu đen', N'Thép/ nhựa', N'Việt Nam', 750000, 0, 0)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (6, N'Sọt rác Factor', 30, N'factor_waste_bin_baya_1089011_1.jpg', N'Thùng rác FACTOR là một thiết kế đơn giản và ấn tượng cho tổ ấm của bạn. Với chất liệu nhựa bền chắc, cơ chế đóng nắp chậm & êm ái cùng độ bám cao của thùng rác lên sàn nhà, sản phẩm cho bạn cảm giác thoải mái khi sử dụng. Trang bị thùng rác FACTOR trong bất kỳ căn phòng nào bạn muốn để hoàn thiện vẻ đẹp hiện đại cho ngôi nhà.', N'L33xW23xH43', N'Màu xám', N'Nhựa', N'Việt Nam', 349000, 0, 0)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (7, N'Sọt rác Factor', 30, N'factor-waste-bin-plastic-grey-uma-1088960.jpg', N'Thùng rác FACTOR là một thiết kế đơn giản và ấn tượng cho tổ ấm của bạn. Sản phẩm được làm từ chất liệu nhựa cao cấp và bền bỉ theo thời gian sử dụng. Ngoài công dụng chứa rác, đây còn là vật dụng tiện ích cho bạn cất gọn quần áo, đồ chơi… Trang bị thùng rác FACTOR trong bất kỳ căn phòng nào bạn muốn để hoàn thiện vẻ đẹp hiện đại cho ngôi nhà.', N'L32xW20xH37', N'Màu xám', N'Nhựa', N'Việt Nam', 99000, 0, 0)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (8, N'Tinh dầu CLEOPATRA', 33, N'cleopatra_aroma_oil_baya_2000138.jpg', N'Tinh dầu hương thảo được chiết xuất từ 100% chất liệu tự nhiên giúp không gian trở nên mát mẻ, thanh lọc không khí, xua tan nhanh các mùi ô nhiễm.
Hướng dẫn sử dụng: Cho một ít nước vào đèn xông tinh dầu và 3 giọt tinh dầu cho phòng 15m2. Đặt một ngọn nến thắp sáng dưới cốc và tận hưởng hương thơm!', N'10ml - Rosemary', NULL, N'100%-Natural-Oil', N'Việt Nam', 199000, 0, 0)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (9, N'Quả cầu thơm trang trí Tamarind', 33, N'TAMARIND_Potpourri_box_UMA_1090758.jpg', N'Hộp thơm TAMARIND gồm những quả cầu xinh xắn được kết bằng tay từ cây cỏ khô và chất liệu sợi thiên nhiên cho mùi hương dễ chịu của cocktail rượu & trái cây. Thêm chút ấm áp ngọt ngào cho không gian sống với những quả cầu thơm lừng bài trí tự nhiên trong thố hoặc ly thủy tinh, bạn sẽ có những phút giây thư giãn tuyệt vời!', N'D11xW18xH19 - Punch', N'Nhiều màu', N'Hoa và cây khô', N'Ấn Độ', 249000, 50, 14)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (10, N'Lọ hoa Mandy', 6, N'mandy_vase_baya_2001044.jpg', N'Lọ hoa được sản xuất thủ công ở làng gốm Bát Tràng.
Chất liệu sứ men trắng bóng.
Họa tiết hoa được vẽ bằng tay nhiều màu sắc bắt mắt, sang trọng, độc đáo phù hợp trang trí nhà cửa ngày Tết, cắm hoa mai, cúc, hoa ly, họa my.. và làm quà tặng.
Dễ dàng trưng bày mix and match với nội thất trong không gian gia đình, văn phòng.', N'H30xDia9', N'Nhiều màu', N'Sành', N'Việt Nam', 519000, 0, 0)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (11, N'Ghế đôn KONDO', 8, N'kondo_stool_with_storage_baya_2000539.jpg', NULL, N'L70xW38xH42 - Foldable', N'Màu be', N'Polyester-MDF', N'Việt Nam', 799000, 0, 10)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (12, N'Đèn sàn Urban', 5, N'urban_floor_lamp_metal_black_1083705_1.jpg', N'Nổi bật với thiết kế đơn giản nhưng vô cùng bắt mắt, đèn sàn URBAN là điểm nhấn hoàn hảo cho không gian căn nhà. Thân đèn làm từ kim loại phủ sơn vừa đẹp mắt vừa tăng độ bền cho sản phẩm. Bạn có thể tùy ý đặt đèn sàn ở góc sofa phòng khách, đầu giường phòng ngủ đều hoàn toàn phù hợp. Lưu ý, sản phẩm không bao gồm bóng đèn.', N'L55xW25xH170', N'Màu đen', N'Kim loại', N'Trung Quốc', 1190000, 0, 0)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (13, N'Bàn ăn Verona', 17, N'verona_dining_table_baya_2000485.jpg', NULL, N'L75xW75xH75 - Black legs', N'Màu trắng', N'MDF-metal', N'Việt Nam', 1990000, 0, 0)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (14, N'Bàn ăn Verona', 17, N'verona_dining_table_baya_2000470.jpg', N'Bàn ăn VERONA nổi bật với màu trắng tinh khôi được làm từ gỗ công nghiệp bền chắc. Rất phù hợp với những gia đình ít người và không gian phòng bếp hạn chế. Mặt bàn được xử lý kỹ càng, mang vẻ đẹp tinh xảo. Chân bàn làm từ kim loại, cho độ cứng cáp và chắc chắn cao. Bạn có thể kết hợp bàn cùng các sản phẩm khác trong cùng bộ sưu tập VERONA để hoàn thiện nội thất phòng ăn của gia đình bạn.', N'L75xW75xH75 - Black legs', N'Xám/ trắng', N'MDF-Faux-granite', N'Việt Nam', 1990000, 0, 0)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (15, N'Set 4 ghế Verona', 18, N'verona_dining_set_baya_6000279.jpg', NULL, NULL, N'Màu đen', N'MDF-metal', N'Việt Nam', 3390000, 0, 0)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (16, N'Bộ hộp 2 bát và 2 đôi đũa', 20, N'sun_flower_box_set_of_2_bowls_and_2_pair_of_chopsticks_baya_7300174_1.jpg', NULL, NULL, N'Nhiều màu', N'Gốm', N'Trung Quốc', 179000, 0, 19)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (17, N'Bộ dao kéo Recipe', 21, N'5174_1.jpg', NULL, NULL, NULL, N'Thép không gỉ', N'Trung Quốc', 1582000, 0, 8)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (18, N'Kệ tivi Iconico', 2, N'2001005-1.jpg', N'Kệ TV ICONICO được thiết kế theo phong cách tối giản, tân cổ điển nhưng vẫn mang đậm chất sang trọng, thượng lưu, toát lên sự khác biệt. Với 2 màu cơ bản dành cho khách hàng lựa chọn là màu trắng mờ và màu gỗ sồi tự nhiên, sản phẩm được hứa hẹn sẽ đem lại sự tiện nghi và đem đến không gian đẳng cấp cho gia chủ.
Kệ TV với tay nắm màu đen thanh mảnh như một điểm nhấn hiện đại trên bề mặt viền khung. Bên cạnh đó, với thiết bị chống lật tủ sẽ mang lại độ an toàn cao cho người dùng và trẻ nhỏ.
Kệ có kích thước là 160 x 44.5 x 53.5 cm ( Dài x Rộng x Cao) bao gồm 4 ngăn với trọng lượng tương ứng là 37kg phù hợp với không gian sống của các hộ gia đình.
Chất liệu chính của sản phẩm bao gồm: gỗ, ván gỗ, nhựa và kim loại. Các ván gỗ công nghiệp được sản xuất từ nguồn gỗ chất lượng đạt tiêu chuẩn của FSC và Quản lý và Khai thác Gỗ bền vững, đồng thời đạt tiêu chuẩn an toàn với sức khỏe người dùng Châu Âu.
Sản phẩm được thiết kế và sản xuất tại Ý.', N'D44.5xW160xH53.5 - traditional', N'Màu trắng', N'MFC', N'Ý', 4490000, 0, 9)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (19, N'Kệ trưng bày Ionico', 27, N'2000993.jpg', N'Sản phẩm được thiết kế theo phong cách hiện đại, có kích thước 75 x 35 x 75 cm, được chia thành 4 ngăn, với sức chứa tối đa là 30 kg. Sản phẩm có sự đa dạng trong màu sắc, có tới 5 màu: xám đậm, xanh oliu, vân gỗ sồi, san hô, trắng để khách hàng thoải mái lựa chọn.
Không những vậy, Kệ ICONICO còn có khả năng kết hợp với các sản phẩm ICONICO khác  và 4 nút bịt chân bàn (có thể tự điều chỉnh), có thể điều chỉnh để phù hợp với yêu cầu của khách hàng.
Về tổng thể, có thể thấy sản phẩm được thiết kế vô cùng thông minh, linh hoạt và đa năng. Không chỉ đảm bảo về mặt công năng, giúp gia chủ tối ưu không gian sống, mà còn thỏa mãn tính thẩm mỹ, mang lại vẻ đẹp sang trọng cho ngôi nhà.
Sản phẩm được sản xuất từ nguồn gỗ đạt tiêu chuẩn của FSC về Quản lý và khai thác gỗ bền vững, đồng thời đạt chứng nhận an toàn cho sức khỏe người dùng theo tiêu chuẩn Châu Âu.
Nhờ vào chất liệu đạt tiêu chuẩn, sản phẩm cũng giúp chủ nhân thuận lợi hơn trong việc vệ sinh, tiết kiệm được nhiều thời gian cho công việc dọn dẹp.', N'D35xW75xH75', N'Màu trắng', N'MFC', N'Ý', 2490000, 0, 4)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (20, N'Nệm Sapa', 9, N'sapa_mattress_foam_baya_2000320_5.jpg', N'Nệm gấp SAPA với kích thước nhỏ gọn là một lựa chọn thích hợp cho bé hoặc một người lớn có thể nằm vô cùng thoải mái.
Nệm được sản xuất trên dây chuyền công nghệ hiện đại, sử dụng nguồn nguyên liệu cao cấp an toàn cho sức khỏe.
Vỏ nệm được làm từ vải gấm xốp 240g có trần mút tạo múi, đem lại cảm giác êm ái cho giấc ngủ của bạn.', N'L190xW138xH12', N'Màu trắng', N'Mút', N'Việt Nam', 2990000, 0, 5)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (21, N'Nệm Nest', 9, N'nest_mattress_baya_2000223_1.jpg', N'Nệm Nest như một “chiếc tổ”, nơi chúng ta khởi đầu, là nơi đầm ấm, không hào nhoáng nhưng cũng là nơi đủ đầy nhất, là nơi ta an tâm ngủ ngon nhất.', N'L180xW200xH15', N'Màu xám', N'Mút', N'Việt Nam', 9690000, 0, 6)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (22, N'Tủ quần áo Ionico', 11, N'6000262.jpg', N'Tủ quần áo gắn liền với mọi sinh hoạt hằng ngày của khách hàng vì vậy việc chọn tủ quần áo là việc vô cùng quan trọng, không chỉ là một chiếc tủ quần áo đẹp mà còn phải phù hợp với không gian của sống của gia đình. ICONICO là tủ quần áo có được sự kết hợp hài hòa giữa thẩm mỹ hiện đại và công năng linh hoạt bao gồm: 2 cánh tủ, thanh treo đồ và ngăn chia có thể linh hoạt tùy chỉnh theo nhu cầu sử dụng và quý khách hàng cũng có thể mua kèm bộ 2 ngăn tủ rời đáp ứng cho mục đích sử dụng riêng. Đặc biệt có thiết bị chống lật tủ, mang lại độ an toàn cao cho người dùng và trẻ nhỏ.
Tủ có kích thước là 80 x 55.5 x 190.5 cm (Dài x Rộng x Cao) với trọng lượng tương ứng 53 kg phù hợp với nhiều không gian sống trong gia đình. Sản phẩm được thiết kế và sản xuất tại Ý.
Về vật liệu và màu sắc: các ván gỗ được sản xuất từ nguồn gỗ đạt tiêu chuẩn của FSC về Quản lý và Khai thác Gỗ bền vững, đồng thời đạt chuẩn an toàn với sức khỏe người dùng Châu Âu.
Chất liệu chính bao gồm: ván dăm, nhựa và kim loại được thiết kế với 2 màu lựa chọn: màu trắng mờ và màu vân gỗ sồi để cho quý khách hàng có thể dễ dàng lựa chọn.', N'D55.5xW80xH190.5 ', N'Oak', N'Mút', N'Ý', 6490000, 0, 7)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (23, N'Bộ bàn góc và ghế thư giãn Anne', 3, N'anne-leisure-chair-baya-52942.jpg', NULL, N'L54xW55xH30', N'Đen/ xám', N'Steel-Aluminum-Fabric', N'Việt Nam', 6000000, 0, 2)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (24, N'Gối tựa Fur', 7, N'fur_cushion_cover_baya_2000200.jpg', NULL, N'L45xW45', N'Màu nâu', N'Vải tổng hợp', N'Việt Nam', 199000, 0, 8)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (25, N'Gương đứng Miramar', 14, N'miramar_standing_mirror_baya_2000396.jpg', NULL, N'H150xW55', N'Màu vàng', N'Nhôm', N'Trung Quốc', 2490000, 0, 5)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (26, N'Gương treo tường Miramar', 14, N'miramar_wall_mirror_baya_2000392.jpg', NULL, N'Dia50 - Round', N'Màu vàng', N'Nhôm', N'Trung Quốc', 999000, 0, 16)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (27, N'Chăn mỏng Sofia', 10, N'sofia_comforter_baya_2000585_2.jpg', N'Chăn được làm từ100% polyester dạng lông mềm mại, nỉ có độ bền cao, bền màu, nhẹ, giữ nhiệt và giữa ấm tốt, không phai màu, không bị rụng lông trong quá trình sử dụng
Bề mặt chăn mềm mại, mịn màng như nhung , trọng lượng nhẹ, tạo cảm giác dễ chịu, thoải mái, giúp mang lại giấc ngủ ngon và ấm áp cho bạn, an toàn với làn da trẻ em, nhạy cảm đem lại trải nghiệm tuyệt vời.
Chăn với các sợi lông siêu nhỏ kết hợp cùng đặc điểm của len lông đó là nhẹ và có tính cách nhiệt rất tốt, nên khi đắp ngay lập tức sẽ mang lại cảm giác ấm áp và luôn tạo sự thoải mái dễ chịu cho người dùng. Ngoài ra, với kỹ thuật dệt may tiên tiến còn giúp cho chăn không chỉ ấm mà còn tạo sự thông thoáng, không bị ẩm hay bí khí. Chất liệu chất lượng cao, không phai màu khi giặt, không bị rụng lông trong suốt quá trình sử dụng.
Họa tiết màu sắc tươi sáng tạo cảm giác ấm cúng.
Sản phẩm có thể sử dụng với nhiều công dụng khác nhau như làm chăn văn phòng, chăn đắp khi ngủ, chăn thư giãn sofa, chăn đắp trên ô tô, khi đi du lịch… với mục đích nào thì cũng khiến bạn cảm thấy dễ chịu, vừa thoáng khí và vô cùng ấm áp.', N'L152xW127', N'Màu xám', N'Vải tổng hợp', N'Thái Lan', 499000, 0, 10)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (28, N'Bộ bàn học Sund', 25, N'sund_desk_baya_6000239.jpg', N'• Bộ bàn học SUND được thiết kế với một bên đầu bàn gắn liền với giá sách 3 tầng SUND, đầu bàn còn lại kết nối với giá sách 2 tầng có chức năng như chân bàn. Việc kết hợp bàn học với 2 giá sách giúp bạn tối đa hóa không gian lưu trữ, tùy ý sắp xếp sách vở, tài liệu và các vật dụng trang trí.
• Đặc biệt phần giá sách 2 tầng có thể được tùy chỉnh linh hoạt, xoay ra phía ngoài hoặc vào trong theo mong muốn của người sử dụng.
• Một điểm cực kỳ mới nữa là với bàn học SUND này khách hàng có nhiều lựa chọn hơn trước vì Baya có bán rời phần mặt bàn và giá sách 2 tầng. Nếu bạn đã có sẵn một giá sách SUND 3 tầng, chỉ cần mua thêm phần rời này là có thể có một bàn học đa năng ở nhà rồi. Hoặc bạn cũng có thể lựa chọn hai màu khác nhau cho giá sách SUND 3 tầng và phần còn lại (mặt bàn + giá sách 2 tầng) để phối màu thành một bàn học kiêm giá sách dễ thương theo cách bạn muốn.', N'D56.3xW140xH73.6', N'Màu xám', N'MFC', N'Việt Nam', 1390000, 0, 6)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (29, N'Bàn làm việc Suecia', 25, N'suecia_desk_baya_5248.jpg', NULL, N'L100xD50xH75', N'Light-Wood-Black', N'MFC', N'Việt Nam', 3490000, 0, 11)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (31, N'Chăn Bella', 10, N'bella_comforter_baya_2000552.jpg', N'Chăn được làm từ100% polyester dạng lông cừu, lông mềm mại, độ bền cao, bền màu, nhẹ, giữ nhiệt và giữa ấm tốt, không phai màu, không bị rụng lông trong quá trình sử dụng

Bề mặt chăn mềm mại, mịn màng , tạo cảm giác dễ chịu, thoải mái, giúp mang lại giấc ngủ ngon và ấm áp cho bạn, an toàn với làn da trẻ em, nhạy cảm đem lại trải nghiệm tuyệt vời.

Chăn có trọng lượng nhẹ, tạo cảm giác rất thoải mái khi chạm vào da bởi chất liệu lông cừu mềm mịn như nhung, thích hợp sử dụng với cả những người dùng hoặc trẻ nhỏ có làn da mỏng, nhạy cảm.

Chăn với các sợi lông siêu nhỏ kết hợp cùng đặc điểm của len lông đó là nhẹ và có tính cách nhiệt rất tốt, nên khi đắp ngay lập tức sẽ mang lại cảm giác ấm áp và luôn tạo sự thoải mái dễ chịu cho người dùng. Ngoài ra, với kỹ thuật dệt may tiên tiến còn giúp cho chăn không chỉ ấm mà còn tạo sự thông thoáng, không bị ẩm hay bí khí. Chất liệu chất lượng cao, không phai màu khi giặt, không bị rụng lông trong suốt quá trình sử dụng.

Họa tiết màu sắc tươi sáng tạo cảm giác ấm cũng cho phòng ngủ.

Sản phẩm có thể sử dụng với nhiều công dụng khác nhau như làm chăn văn phòng, chăn đắp khi ngủ, chăn thư giãn sofa, chăn cho em bé, chăn dùng trên ô tô, khi đi du lịch khi gấp lại có thể dùng decor, dù sử dụng với mục đích nào thì cũng khiến bạn cảm thấy dễ chịu, vừa thoáng khí và vô cùng ấm áp.', N'L152xW76', N'Màu xám', N'Vải tổng hợp', N'Thái Lan', 399000, 0, 8)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (32, N'Ghế văn phòng Ramon', 26, N'RAMON_Office_chair_Mesh_Metal_Black_UMA_1060805_Corner.jpg', N'Ghế văn phòng RAMON với khung kim loại chắc chắn và đệm ngồi êm ái giúp bạn thoải mái ngồi làm việc trong thời gian dài. Sản phẩm có bánh xe dễ di chuyển và độ cao có thể điều chỉnh được. Lưng tựa bằng vải lưới có dây kéo để bạn tháo rời và giặt sạch.', N'D61xW60xH91', N'Màu đen', N'Kim loại', N'Trung Quốc', 1990000, 0, 39)
INSERT [dbo].[SanPham] ([id], [tenSanPham], [idDanhMuc], [img], [mota], [kichThuoc], [mauSac], [chatLieu], [xuatXu], [donGia], [giamGia], [soLuongTon]) VALUES (34, N'Bàn cao Hill', 25, N'notting_hill_high_table_baya_5304_3.jpg', N'Bàn cao đa chức năng màu gỗ tối có thể dùng làm bàn ăn hai người hoặc bàn làm việc đều tiện lợi. Sản phẩm thiết kế đẹp mắt rất phù hợp cho không gian phòng ăn nhỏ, đa chức năng sinh hoạt, đi kèm góc chứa đồ tiện lợi bên hông, có thể để sách vở, tạp chí hoặc dụng cụ bàn ăn khi cần.', N'L120xW60xH92', N'Màu gỗ đậm', N'Gỗ cao su / MFC', N'Việt Nam', 3490000, 15, 4)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPhamYeuThich] ON 

INSERT [dbo].[SanPhamYeuThich] ([id], [idKhachHang], [idSanPham]) VALUES (1, 1, 1)
INSERT [dbo].[SanPhamYeuThich] ([id], [idKhachHang], [idSanPham]) VALUES (2, 1, 2)
INSERT [dbo].[SanPhamYeuThich] ([id], [idKhachHang], [idSanPham]) VALUES (3, 1, 25)
INSERT [dbo].[SanPhamYeuThich] ([id], [idKhachHang], [idSanPham]) VALUES (5, 1, 27)
SET IDENTITY_INSERT [dbo].[SanPhamYeuThich] OFF
GO
SET IDENTITY_INSERT [dbo].[GioHang] ON 

INSERT [dbo].[GioHang] ([id], [idKhachHang], [idSanPham], [soLuong]) VALUES (37, 4, 34, 1)
SET IDENTITY_INSERT [dbo].[GioHang] OFF
GO
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([id], [idKhachHang], [ngayDatHang], [diaChiGiaoHang], [ngayGiaoHang], [ghiChu], [hinhThucThanhToan], [thanhTien], [trangThaiThanhToan], [trangThaiDonHang]) VALUES (5, 1, CAST(N'2022-04-01T12:16:59.000' AS DateTime), N'Tây Mỗ, Nam Từ Liêm, Hà Nội', CAST(N'2022-04-25T15:22:12.000' AS DateTime), N'test lần 3 :((', N'Trả tiền mặt khi nhận hàng', 10679000, 1, 4)
INSERT [dbo].[DonHang] ([id], [idKhachHang], [ngayDatHang], [diaChiGiaoHang], [ngayGiaoHang], [ghiChu], [hinhThucThanhToan], [thanhTien], [trangThaiThanhToan], [trangThaiDonHang]) VALUES (6, 1, CAST(N'2022-04-01T12:20:21.593' AS DateTime), N'Tây Mỗ, Nam Từ Liêm, Hà Nội', NULL, N'test chuyển khoản ngân hàng, địa chỉ mặc định', N'Chuyển khoản ngân hàng', 23702500, 0, 5)
INSERT [dbo].[DonHang] ([id], [idKhachHang], [ngayDatHang], [diaChiGiaoHang], [ngayGiaoHang], [ghiChu], [hinhThucThanhToan], [thanhTien], [trangThaiThanhToan], [trangThaiDonHang]) VALUES (7, 1, CAST(N'2022-04-01T12:23:03.000' AS DateTime), N'Hà Nội', CAST(N'2022-04-25T15:28:32.000' AS DateTime), N'test giao hàng đến địa chỉ khác, trả tiền mặt khi nhận hàng', N'Trả tiền mặt khi nhận hàng', 599000, 1, 6)
INSERT [dbo].[DonHang] ([id], [idKhachHang], [ngayDatHang], [diaChiGiaoHang], [ngayGiaoHang], [ghiChu], [hinhThucThanhToan], [thanhTien], [trangThaiThanhToan], [trangThaiDonHang]) VALUES (8, 1, CAST(N'2022-04-02T21:11:37.000' AS DateTime), N'Tây Mỗ, Nam Từ Liêm, Hà Nội', CAST(N'2022-04-25T15:32:04.000' AS DateTime), N'Ship vào khoảng 4 đến 6 giờ chiều', N'Trả tiền mặt khi nhận hàng', 17440000, 1, 4)
INSERT [dbo].[DonHang] ([id], [idKhachHang], [ngayDatHang], [diaChiGiaoHang], [ngayGiaoHang], [ghiChu], [hinhThucThanhToan], [thanhTien], [trangThaiThanhToan], [trangThaiDonHang]) VALUES (9, 1, CAST(N'2022-04-02T01:57:38.000' AS DateTime), N'Tây Mỗ, Nam Từ Liêm, Hà Nội', CAST(N'2022-04-03T16:40:44.000' AS DateTime), N'test đặt hàng với số lượng sản phẩm', N'Trả tiền mặt khi nhận hàng', 9481000, 1, 4)
INSERT [dbo].[DonHang] ([id], [idKhachHang], [ngayDatHang], [diaChiGiaoHang], [ngayGiaoHang], [ghiChu], [hinhThucThanhToan], [thanhTien], [trangThaiThanhToan], [trangThaiDonHang]) VALUES (11, 4, CAST(N'2022-06-25T16:30:29.000' AS DateTime), N'Hoàng Quốc Việt, Bắc Từ Liêm, Hà Nội', CAST(N'2022-06-25T18:47:15.000' AS DateTime), NULL, N'Trả tiền mặt khi nhận hàng', 4956500, 1, 4)
INSERT [dbo].[DonHang] ([id], [idKhachHang], [ngayDatHang], [diaChiGiaoHang], [ngayGiaoHang], [ghiChu], [hinhThucThanhToan], [thanhTien], [trangThaiThanhToan], [trangThaiDonHang]) VALUES (12, 1, CAST(N'2022-06-25T18:44:39.000' AS DateTime), N'Tây Mỗ, Nam Từ Liêm, Hà Nội', CAST(N'2022-06-26T11:16:29.000' AS DateTime), NULL, N'Trả tiền mặt khi nhận hàng', 6737500, 1, 4)
INSERT [dbo].[DonHang] ([id], [idKhachHang], [ngayDatHang], [diaChiGiaoHang], [ngayGiaoHang], [ghiChu], [hinhThucThanhToan], [thanhTien], [trangThaiThanhToan], [trangThaiDonHang]) VALUES (13, 4, CAST(N'2022-06-26T11:14:04.493' AS DateTime), N'Hoàng Quốc Việt, Bắc Từ Liêm, Hà Nội', NULL, N'', N'Trả tiền mặt khi nhận hàng', 4179000, 0, 2)
INSERT [dbo].[DonHang] ([id], [idKhachHang], [ngayDatHang], [diaChiGiaoHang], [ngayGiaoHang], [ghiChu], [hinhThucThanhToan], [thanhTien], [trangThaiThanhToan], [trangThaiDonHang]) VALUES (14, 4, CAST(N'2022-06-26T11:14:55.000' AS DateTime), N'Hoàng Quốc Việt, Bắc Từ Liêm, Hà Nội', CAST(N'2022-06-26T11:16:41.000' AS DateTime), NULL, N'Trả tiền mặt khi nhận hàng', 723500, 1, 4)
INSERT [dbo].[DonHang] ([id], [idKhachHang], [ngayDatHang], [diaChiGiaoHang], [ngayGiaoHang], [ghiChu], [hinhThucThanhToan], [thanhTien], [trangThaiThanhToan], [trangThaiDonHang]) VALUES (15, 1, CAST(N'2022-06-26T11:15:41.000' AS DateTime), N'Tây Mỗ, Nam Từ Liêm, Hà Nội', CAST(N'2022-06-26T11:16:18.000' AS DateTime), NULL, N'Trả tiền mặt khi nhận hàng', 11720500, 1, 4)
INSERT [dbo].[DonHang] ([id], [idKhachHang], [ngayDatHang], [diaChiGiaoHang], [ngayGiaoHang], [ghiChu], [hinhThucThanhToan], [thanhTien], [trangThaiThanhToan], [trangThaiDonHang]) VALUES (16, 1, CAST(N'2022-06-26T13:14:24.483' AS DateTime), N'Tây Mỗ, Nam Từ Liêm, Hà Nội', NULL, N'', N'Trả tiền mặt khi nhận hàng', 14690500, 0, 2)
SET IDENTITY_INSERT [dbo].[DonHang] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([id], [taiKhoan], [matKhau], [hoTen], [CCCD], [email], [soDienThoai], [ngaySinh], [gioiTinh], [diaChi], [chucVu]) VALUES (1, N'kien123', N'202cb962ac59075b964b07152d234b70', N'Trần Kiên', N'033201002759', N'kientr201@gmail.com', N'0372938109', CAST(N'2001-11-24' AS Date), N'Nam', N'Tây Mỗ, Nam Từ Liêm, Hà Nội', 1)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([id], [tenNhaCungCap], [email], [soDienThoai], [diaChi]) VALUES (1, N'Nhà cung cấp HOME DECOR - NHÀ SÀNH', NULL, N'0934954121', N'108 Cộng hòa, phường 4, Quận Tân Bình, Thành phố Hồ Chí Minh, Việt Nam')
INSERT [dbo].[NhaCungCap] ([id], [tenNhaCungCap], [email], [soDienThoai], [diaChi]) VALUES (2, N'Nội thất MAKE MY HOME', NULL, N'02862676466', N'97-99 Cộng Hoà, P4, Q Tân Bình, Tp Hồ chí Minh.')
INSERT [dbo].[NhaCungCap] ([id], [tenNhaCungCap], [email], [soDienThoai], [diaChi]) VALUES (3, N'Nội thất HOÀNG PHÁT', NULL, N'0917312319', N'55 Bạch Đằng, Phường 15, Quận Bình Thạnh, Thành phố Hồ Chí Minh')
INSERT [dbo].[NhaCungCap] ([id], [tenNhaCungCap], [email], [soDienThoai], [diaChi]) VALUES (4, N'Nội thất MYRA', NULL, N'0903840585', N'16N9 KDC Mega Ruby Khang Điền, đường Võ Chí Công, Quận 9, TP. Hồ Chí Minh')
INSERT [dbo].[NhaCungCap] ([id], [tenNhaCungCap], [email], [soDienThoai], [diaChi]) VALUES (5, N'Nội thất GỖ XANH', NULL, N'0975123239', N'Số 403 Xô Viết Nghệ Tĩnh, Phường 24, Quận Bình Thạnh, Thành phố Hồ Chí Minh, Việt Nam')
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuNhap] ON 

INSERT [dbo].[PhieuNhap] ([id], [idNhanVien], [idNhaCungCap], [ngayNhap]) VALUES (2, 1, 1, CAST(N'2022-04-01T00:13:32.273' AS DateTime))
INSERT [dbo].[PhieuNhap] ([id], [idNhanVien], [idNhaCungCap], [ngayNhap]) VALUES (3, 1, 3, CAST(N'2022-06-25T15:10:27.850' AS DateTime))
INSERT [dbo].[PhieuNhap] ([id], [idNhanVien], [idNhaCungCap], [ngayNhap]) VALUES (4, 1, 3, CAST(N'2022-06-25T15:12:45.330' AS DateTime))
INSERT [dbo].[PhieuNhap] ([id], [idNhanVien], [idNhaCungCap], [ngayNhap]) VALUES (5, 1, 5, CAST(N'2022-06-25T16:22:34.170' AS DateTime))
INSERT [dbo].[PhieuNhap] ([id], [idNhanVien], [idNhaCungCap], [ngayNhap]) VALUES (6, 1, 4, CAST(N'2022-06-25T16:25:39.567' AS DateTime))
SET IDENTITY_INSERT [dbo].[PhieuNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuXuat] ON 

INSERT [dbo].[PhieuXuat] ([id], [idNhanVien], [ngayXuat], [idDonHang]) VALUES (4, 1, CAST(N'2022-04-03T16:17:24.670' AS DateTime), 9)
INSERT [dbo].[PhieuXuat] ([id], [idNhanVien], [ngayXuat], [idDonHang]) VALUES (11, 1, CAST(N'2022-06-25T15:24:31.167' AS DateTime), 8)
INSERT [dbo].[PhieuXuat] ([id], [idNhanVien], [ngayXuat], [idDonHang]) VALUES (12, 1, CAST(N'2022-06-25T18:47:08.087' AS DateTime), 11)
INSERT [dbo].[PhieuXuat] ([id], [idNhanVien], [ngayXuat], [idDonHang]) VALUES (13, 1, CAST(N'2022-06-25T18:47:50.183' AS DateTime), 12)
INSERT [dbo].[PhieuXuat] ([id], [idNhanVien], [ngayXuat], [idDonHang]) VALUES (14, 1, CAST(N'2022-06-26T11:16:08.167' AS DateTime), 13)
INSERT [dbo].[PhieuXuat] ([id], [idNhanVien], [ngayXuat], [idDonHang]) VALUES (15, 1, CAST(N'2022-06-26T11:16:10.153' AS DateTime), 14)
INSERT [dbo].[PhieuXuat] ([id], [idNhanVien], [ngayXuat], [idDonHang]) VALUES (16, 1, CAST(N'2022-06-26T11:16:12.187' AS DateTime), 15)
INSERT [dbo].[PhieuXuat] ([id], [idNhanVien], [ngayXuat], [idDonHang]) VALUES (17, 1, CAST(N'2022-06-26T13:16:17.657' AS DateTime), 16)
SET IDENTITY_INSERT [dbo].[PhieuXuat] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPhamImage] ON 

INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (6, 1, N'Ban-ca-phe-CONNEMARA-1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (8, 1, N'Ban-ca-phe-CONNEMARA-2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (9, 1, N'Ban-ca-phe-CONNEMARA-3.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (10, 1, N'Ban-ca-phe-CONNEMARA-4.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (25, 2, N'bella_comforter_baya_2000556.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (26, 2, N'bella_comforter_baya_2000556_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (27, 2, N'bella_comforter_baya_2000556_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (28, 3, N'anne_coffee_table_baya_7100020_4.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (29, 3, N'anne_coffee_table_baya_7100020_1_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (30, 3, N'anne_coffee_table_baya_7100020_2_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (31, 3, N'anne_coffee_table_baya_7100020_3_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (32, 4, N'carine_coffee_table_baya_5276.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (33, 4, N'carine_coffee_table_baya_5276_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (34, 4, N'bst-carine-baya-1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (35, 4, N'sofa-giuong-co-hoc-shibuya-1076905_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (36, 5, N'soji_waste_bin_baya_2000247.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (37, 5, N'soji_waste_bin_baya_2000247_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (38, 5, N'soji_waste_bin_baya_2000247_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (39, 5, N'soji_waste_bin_baya_2000247_3.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (40, 6, N'factor_waste_bin_baya_1089011_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (41, 6, N'factor_waste_bin_baya_1089011_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (42, 7, N'factor-waste-bin-plastic-grey-uma-1088960.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (43, 7, N'factor_waste_bin_baya_1088960_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (44, 8, N'cleopatra_aroma_oil_baya_2000138.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (45, 8, N'cleopatra_aroma_oil_baya_2000138_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (46, 9, N'TAMARIND_Potpourri_box_UMA_1090758.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (47, 9, N'TAMARIND_Potpouri_UMA_Inspiration_13.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (48, 10, N'mandy_vase_baya_2001044.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (49, 11, N'kondo_stool_with_storage_baya_2000539.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (50, 11, N'kondo_stool_with_storage_baya_2000539_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (51, 11, N'kondo_stool_with_storage_baya_2000539_3.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (52, 11, N'kondo_stool_with_storage_baya_2000539_4.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (53, 12, N'urban_floor_lamp_metal_black_1083705_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (54, 12, N'URBAN_Floor_Lamp_Metal_Black_UMA_1083705_front.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (55, 12, N'URBAN_Floor_Lamp_Metal_Black_UMA_1083705_material.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (56, 12, N'den-san-urban-1083705.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (57, 13, N'verona_dining_table_baya_2000485.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (58, 13, N'verona_dining_table_baya_2000485_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (59, 13, N'verona_dining_table_baya_2000485_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (60, 14, N'verona_dining_table_baya_2000470.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (61, 14, N'verona_dining_table_baya_2000470_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (62, 14, N'verona_dining_table_baya_2000470_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (63, 14, N'verona_dining_table_baya_2000470_inspiration.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (64, 15, N'verona_dining_set_baya_6000279.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (65, 16, N'sun_flower_box_set_of_2_bowls_and_2_pair_of_chopsticks_baya_7300174_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (66, 16, N'sun_flower_box_set_of_2_bowls_and_2_pair_of_chopsticks_baya_7300174_3.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (67, 16, N'sun_flower_box_set_of_2_bowls_and_2_pair_of_chopsticks_baya_7300174_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (68, 16, N'sun_flower_box_set_of_2_bowls_and_2_pair_of_chopsticks_baya_7300174.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (69, 17, N'5174_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (70, 18, N'2001005.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (71, 18, N'2001005-1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (72, 18, N'2001005-2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (73, 18, N'2001005-3.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (74, 18, N'2001005-4.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (75, 18, N'2001005-5.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (76, 19, N'2000993.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (77, 19, N'2000993-1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (78, 19, N'2000993-2.png')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (79, 19, N'2000993-3.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (80, 19, N'2000993-4.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (81, 20, N'sapa_mattress_foam_baya_2000320_5.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (82, 20, N'sapa_mattress_foam_baya_2000320_1_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (83, 20, N'sapa_mattress_foam_baya_2000320_2_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (84, 20, N'sapa_mattress_foam_baya_2000320_3_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (85, 21, N'nest_mattress_baya_2000223_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (86, 21, N'nest_mattress_baya_2000223_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (87, 21, N'nest_mattress_baya_2000223_3.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (88, 22, N'6000262.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (89, 22, N'6000262-1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (90, 22, N'6000262-2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (91, 22, N'6000262-5.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (92, 23, N'anne-leisure-chair-baya-52942.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (93, 23, N'anne_leisure_chair_baya_5294_5.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (94, 23, N'anne_leisure_chair_baya_5294_1_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (95, 23, N'anne_leisure_chair_baya_5294_2_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (96, 23, N'anne_side_table_baya_5293_3.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (97, 24, N'fur_cushion_cover_baya_2000200.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (98, 25, N'miramar_standing_mirror_baya_2000396.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (99, 25, N'miramar_standing_mirror_baya_2000396_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (100, 25, N'miramar_standing_mirror_baya_2000396_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (101, 26, N'miramar_wall_mirror_baya_2000392.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (102, 26, N'miramar_wall_mirror_baya_2000392_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (103, 26, N'miramar_wall_mirror_baya_2000392_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (104, 27, N'sofia_comforter_baya_2000585_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (105, 27, N'sofia_comforter_baya_2000585.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (106, 27, N'sofia_comforter_baya_2000585_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (107, 27, N'sofia_comforter_baya_2000570_2000585_inspiration_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (108, 28, N'sund_desk_baya_6000239.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (109, 28, N'sund_desk_baya_6000239_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (110, 28, N'sund_desk_baya_6000239_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (111, 28, N'sund_desk_baya_6000239_3.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (112, 29, N'suecia_desk_baya_5248.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (113, 29, N'suecia_desk_baya_5248_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (114, 29, N'suecia_desk_baya_5248_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (115, 29, N'suecia_desk_baya_5248_3.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (123, 31, N'bella_comforter_baya_2000552.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (124, 31, N'bella_comforter_baya_2000552_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (125, 32, N'RAMON_Office_chair_Mesh_Metal_Black_UMA_1060805_Corner.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (126, 32, N'RAMON_Office_chair_Mesh_Metal_Black_UMA_1060805_back_corner.jpg')
GO
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (127, 32, N'RAMON_Office_chair_Mesh_Metal_Black_UMA_1060805_front.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (128, 32, N'RAMON_Office_chair_Mesh_Metal_Black_UMA_1060805_material_down.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (129, 32, N'RAMON_Office_chair_Mesh_Metal_Black_UMA_1060805_side.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (130, 32, N'RAMON_Office_chair_Mesh_Metal_Black_UMA_1060805_material_upper.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (136, 34, N'notting_hill_high_table_baya_5304_3.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (137, 34, N'notting_hill_high_table_baya_5304.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (138, 34, N'notting_hill_high_table_baya_5304_1.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (139, 34, N'notting_hill_high_table_baya_5304_2.jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (140, 34, N'notting_hill_high_table_baya_5304_2 (1).jpg')
INSERT [dbo].[SanPhamImage] ([id], [idSanPham], [img]) VALUES (141, 34, N'notting_hill_high_table_baya_5304_4.jpg')
SET IDENTITY_INSERT [dbo].[SanPhamImage] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhap] ON 

INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (3, 2, 1, 10, 400000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (4, 2, 25, 4, 80000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (5, 3, 2, 20, 210000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (6, 4, 32, 50, 1030000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (7, 4, 18, 10, 2500000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (8, 4, 29, 15, 1800000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (9, 5, 34, 5, 2000000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (10, 5, 31, 8, 204000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (11, 5, 28, 6, 700000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (12, 5, 27, 12, 180000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (13, 5, 26, 17, 400000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (14, 5, 24, 9, 40000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (15, 5, 23, 2, 4000000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (16, 6, 22, 7, 3000000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (17, 6, 21, 6, 5000000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (18, 6, 20, 5, 800000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (19, 6, 19, 4, 900000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (20, 6, 17, 8, 400000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (21, 6, 16, 19, 80000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (22, 6, 11, 10, 400000)
INSERT [dbo].[ChiTietPhieuNhap] ([id], [idPhieuNhap], [idSanPham], [soLuongNhap], [donGiaNhap]) VALUES (23, 6, 9, 15, 80000)
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietPhieuXuat] ON 

INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (5, 4, 1, 2, 4740500)
INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (15, 11, 32, 3, 1990000)
INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (16, 11, 18, 1, 4490000)
INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (17, 11, 29, 2, 3490000)
INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (18, 12, 34, 1, 2966500)
INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (19, 12, 32, 1, 1990000)
INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (20, 13, 1, 1, 4740500)
INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (21, 13, 26, 1, 999000)
INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (22, 13, 27, 2, 499000)
INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (23, 14, 32, 2, 1990000)
INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (24, 14, 24, 1, 199000)
INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (25, 15, 9, 1, 124500)
INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (26, 15, 2, 1, 599000)
INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (27, 16, 29, 2, 3490000)
INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (28, 16, 1, 1, 4740500)
INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (29, 17, 32, 5, 1990000)
INSERT [dbo].[ChiTietPhieuXuat] ([id], [idPhieuXuat], [idSanPham], [soLuongXuat], [donGiaXuat]) VALUES (30, 17, 1, 1, 4740500)
SET IDENTITY_INSERT [dbo].[ChiTietPhieuXuat] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietDonHang] ON 

INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (1, 5, 1, 2, 4990000, 5)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (2, 5, 2, 2, 599000, 0)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (3, 6, 1, 5, 4990000, 5)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (4, 7, 2, 1, 599000, 0)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (5, 8, 32, 3, 1990000, 0)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (6, 8, 18, 1, 4490000, 0)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (7, 8, 29, 2, 3490000, 0)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (8, 9, 1, 2, 4990000, 5)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (14, 11, 34, 1, 3490000, 15)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (15, 11, 32, 1, 1990000, 0)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (16, 12, 1, 1, 4990000, 5)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (17, 12, 26, 1, 999000, 0)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (18, 12, 27, 2, 499000, 0)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (19, 13, 32, 2, 1990000, 0)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (20, 13, 24, 1, 199000, 0)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (21, 14, 9, 1, 249000, 50)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (22, 14, 2, 1, 599000, 0)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (23, 15, 29, 2, 3490000, 0)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (24, 15, 1, 1, 4990000, 5)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (25, 16, 32, 5, 1990000, 0)
INSERT [dbo].[ChiTietDonHang] ([id], [idDonHang], [idSanPham], [soLuong], [donGia], [giamGia]) VALUES (26, 16, 1, 1, 4990000, 5)
SET IDENTITY_INSERT [dbo].[ChiTietDonHang] OFF
GO
