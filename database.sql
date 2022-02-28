USE master
GO
DROP DATABASE IF EXISTS WebsiteBanHang
GO
CREATE DATABASE WebsiteBanHang
GO
USE WebsiteBanHang
GO
CREATE TABLE KhachHang(
	id INT PRIMARY KEY IDENTITY,
	taiKhoan VARCHAR(100),
	matKhau VARCHAR(1000),
	hoTen NVARCHAR(100),
	email VARCHAR(255),
	soDienThoai VARCHAR(15),
	ngaySinh DATE,
	gioiTinh NVARCHAR(15),
	diaChi NVARCHAR(255)
)
CREATE TABLE NhanVien(
	id INT PRIMARY KEY IDENTITY,
	taiKhoan VARCHAR(100),
	matKhau VARCHAR(1000),
	hoTen NVARCHAR(100),
	CCCD VARCHAR(15),
	email VARCHAR(255),
	soDienThoai VARCHAR(15),
	ngaySinh DATE,
	gioiTinh NVARCHAR(15),
	diaChi NVARCHAR(255),
	chucVu TINYINT ---1.Admin---2.Nhân viên
)
INSERT INTO NhanVien VALUES('admin',123,N'Trần Tuấn Dũng',1234567891012,'dungtran@gmail.com',0989166427,'11-2-2001','male',N'Hà Nội',1)
CREATE TABLE NhomDanhMuc(
	id INT PRIMARY KEY IDENTITY,
	tenNhomDanhMuc NVARCHAR(50),
	img VARCHAR(255)
)
CREATE TABLE DanhMuc(
	id INT PRIMARY KEY IDENTITY,
	idNhomDanhMuc INT FOREIGN KEY REFERENCES NhomDanhMuc(id) ON DELETE SET NULL,
	tenDanhMuc NVARCHAR(50)
)
CREATE TABLE SanPham(
	id INT PRIMARY KEY IDENTITY,
	tenSanPham NVARCHAR(255),
	idDanhMuc INT FOREIGN KEY REFERENCES DanhMuc(id) ON DELETE SET NULL,
	img VARCHAR(255),
	mota NVARCHAR(4000),
	kichThuoc NVARCHAR(255),
	mauSac NVARCHAR(255),
	chatLieu NVARCHAR(255),
	xuatXu NVARCHAR(255),
	donGia INT,
	giamGia TINYINT, --theo %
	soLuongTon INT
)
CREATE TABLE SanPhamImage(
	id INT PRIMARY KEY IDENTITY,
	idSanPham INT FOREIGN KEY REFERENCES SanPham(id) ON DELETE CASCADE,
	img VARCHAR(255)
)
SELECT *FROM SanPhamImage
CREATE TABLE NhaCungCap(
	id INT PRIMARY KEY IDENTITY,
	tenNhaCungCap NVARCHAR(255),
	email VARCHAR(255),
	soDienThoai VARCHAR(15),
	diaChi NVARCHAR(255),
)
CREATE TABLE PhieuNhap(
	id INT PRIMARY KEY IDENTITY,
	idNhanVien INT FOREIGN KEY REFERENCES NhanVien(id) ON DELETE SET NULL,
	idNhaCungCap INT FOREIGN KEY REFERENCES NhaCungCap(id) ON DELETE SET NULL,
	ngayNhap DATETIME
)
CREATE TABLE ChiTietPhieuNhap(
	id INT PRIMARY KEY IDENTITY,
	idPhieuNhap INT FOREIGN KEY REFERENCES PhieuNhap(id) ON DELETE CASCADE,
	idSanPham INT FOREIGN KEY REFERENCES SanPham(id) ON DELETE SET NULL,
	soLuongNhap INT,
	donGiaNhap INT
)
CREATE TABLE PhieuXuat(
	id INT PRIMARY KEY IDENTITY,
	idNhanVien INT FOREIGN KEY REFERENCES NhanVien(id) ON DELETE SET NULL,
	ngayXuat DATETIME
)
CREATE TABLE ChiTietPhieuXuat(
	id INT PRIMARY KEY IDENTITY,
	idPhieuXuat INT FOREIGN KEY REFERENCES PhieuXuat(id) ON DELETE CASCADE,
	idSanPham INT FOREIGN KEY REFERENCES SanPham(id) ON DELETE SET NULL,
	soLuongXuat INT
)
CREATE TABLE SanPhamYeuThich(
	id INT PRIMARY KEY IDENTITY,
	idKhachHang INT FOREIGN KEY REFERENCES KhachHang(id) ON DELETE CASCADE,
	idSanPham INT FOREIGN KEY REFERENCES SanPham(id) ON DELETE CASCADE
)
--khách hàng thêm, sửa, xóa giỏ hàng, sau khi hoàn tất bấm đặt hàng để tạo đơn hàng
CREATE TABLE GioHang(
	id INT PRIMARY KEY IDENTITY,
	idKhachHang INT FOREIGN KEY REFERENCES KhachHang(id) ON DELETE CASCADE,
	idSanPham INT FOREIGN KEY REFERENCES SanPham(id) ON DELETE CASCADE,
	soLuong INT
)
CREATE TABLE DonHang(
	id INT PRIMARY KEY IDENTITY,
	idKhachHang INT FOREIGN KEY REFERENCES KhachHang(id),
	ngayDatHang DATETIME,
	diaChiGiaoHang NVARCHAR(255),
	ngayGiaoHang DATETIME,
	ghiChu NVARCHAR(4000),
	hinhThucThanhToan NVARCHAR(100),
	thanhTien INT,
	trangThaiThanhToan BIT, ---0.chưa thanh toán---1.đã thanh toán
	trangThaiDonHang TINYINT ---1.chờ xác nhận---2.Chờ lấy hàng---3.Đang giao---4.Đã giao---5.Đã hủy---6.Trả hàng/Hoàn tiền
)
CREATE TABLE NhanVienTiepNhanDonHang(
	id INT PRIMARY KEY IDENTITY,
	idDonHang INT FOREIGN KEY REFERENCES DonHang(id) ON DELETE CASCADE,
	idNhanVien INT FOREIGN KEY REFERENCES NhanVien(id) ON DELETE SET NULL,
	ngayNhanDon DATETIME,
	trangThaiDonHang_Cu TINYINT,
	trangThaiDonHang_Moi TINYINT
	---khi nhân viên tiếp nhận đơn thay đổi trạng thái đơn hàng, sẽ lưu lại lịch sử
)
CREATE TABLE ChiTietDonHang(
	id INT PRIMARY KEY IDENTITY,
	idDonHang INT FOREIGN KEY REFERENCES DonHang(id) ON DELETE CASCADE,
	idSanPham INT FOREIGN KEY REFERENCES SanPham(id) ON DELETE SET NULL,
	soLuong INT,
	donGia INT, --tại thời điểm đặt hàng
	giamGia TINYINT, --theo % tại thời điểm đặt hàng
)
SELECT * FROM SanPham