create database QuanCafe
go
use QuanCafe
go
create table taikhoan
(
	tentk nvarchar(100) primary key,
	matk nvarchar(100) not null,
	tenht nvarchar(100) not null,
	kieutk int not null default 1 -- 0 : nhân viên || 1: admin
)
go
create table ban
(
	maban int identity primary key,
	tenban nvarchar(50) not null,
	thuoctinh nvarchar(50) not null
)
go
create table nhanvien
(
	manv int identity primary key,
	tennv nvarchar(100) not null,
	gt nvarchar(10) not null,
	chucvu nvarchar(100) not null,
	ngayvaolam date,
	diachi nvarchar(100) not null,
	sdt int,
	
)
go
create table loaihanghoa
(
	malh int identity primary key,
	tenlh nvarchar(100) not null,
	mota nvarchar(100) not null
)
go
create table hanghoa
(
	mahh int identity primary key,
	tenhang nvarchar(100) not null,
	malh int not null,
	solg int not null,
	giasp float,
	constraint p1 foreign key(malh) references loaihanghoa(malh)
)
go
create table khachhang
(
	makh int identity primary key,
	tenkh nvarchar(100) not null,
	diachi nvarchar(100),
	sdt int not null,
)
go
create table hoadonbh
(
	mahdbh int identity primary key,
	manv int not null,
	makh int not null,
	maban int not null,
	mahh int not null,
	soluong int not null,
	ngayhdbh date,
	tongtien float not null,
	giamgia int,
	constraint p2 foreign key(manv) references nhanvien(manv),
	constraint p3 foreign key(makh) references khachhang(makh),
	constraint p4 foreign key(maban) references ban(maban),
	constraint p5 foreign key(mahh) references hanghoa(mahh)
)

create table hoadon
(
	id int identity primary key,
	datecheckin date not null default getdate(),
	datecheckout date,
	idtable int not null,
	trangthai int not null default 0, -- 1: là đã thanh toán || 0: chưa thanh toán
	constraint p6 foreign key(idtable) references ban(maban)
)
go
create table tthoadon
(
	id int identity primary key,
	idBill int not null,
	idFood int not null,
	Slg int not null default 0,
	constraint p7 foreign key(idbill) references hoadon(id),
	constraint p8 foreign key(idfood) references hanghoa(mahh)
)


alter table hoadon add giagia int
alter table hoadon add totalPrice float

ALTER TABLE hanghoa DROP COLUMN malh
ALTER TABLE hanghoa ADD malh int;
drop table hoadonbh
drop table khachhang
ALTER TABLE hanghoa ADD CONSTRAINT p1 foreign key(malh) references loaihanghoa(malh)
select * from nhanvien
go

go
select * from taikhoan
go
select * from hanghoa
go 


insert ban values 
(N'Bàn 6',N'Đã Sử Dụng')

update ban set thuoctinh = N'Trống'  where maban = '9'

delete ban where maban = '9'

create proc USP_Danhsachban
as select * from ban
go
exec USP_Danhsachban

select * from hanghoa where malh = 3

create proc USP_Danhsach
as select h.tenhang, h.giasp from hanghoa h
go
exec USP_Danhsach

alter proc USP_login
@tentk nvarchar(100), @matk nvarchar(100)
as 
begin
select * from taikhoan where tentk = @tentk and matk = @matk
end

exec USP_login

insert hoadon values
(GETDATE(),null,'2',0),
(GETDATE(),null,'3',0),
(GETDATE(),GETDATE(),'16',1)
go
select * from hoadon
go
insert tthoadon values
(1,1,3),
(1,2,1),
(1,3,2),
(2,5,3),
(2,9,3),
(3,10,3),

(3,1,3),
(3,2,3)
go
select * from tthoadon
go
---------------------------------------------
select SUM(totalPrice) from hoadon
---------------------------------------------
select * from hoadon
---------------------------------------------
select * from tthoadon where idBill = 3
---------------------------------------------
select h.tenhang, t.Slg, h.giasp, h.giasp*t.Slg as TotalPrice 
from tthoadon as t, hoadon as hd, hanghoa as h 
where t.idBill = hd.id and t.idFood = h.mahh and hd.trangthai = 0 and hd.idtable = 3;
---------------------------------------------
select MAX(id) from hoadon
---------------------------------------------
alter proc USP_getListBillByDate
@checkIn date, @checkOut date
as
begin
		select t.tenban as [Tên Bàn] , h.totalPrice as [Tổng Tiền] ,datecheckin as [Ngày Vào] ,datecheckout as [Ngày Ra] , giagia as [Giảm Giá] 
		from hoadon h, ban t
		where datecheckin >= @checkIn and datecheckout <= @checkOut and h.trangthai = 1
		and t.maban = h.idtable
end
go
drop proc USP_getListBillByDate
go

exec USP_getListBillByDate
go
--------------------------------------------
alter proc USP_getTotalPrice
@checkIn date, @checkOut date
as
begin
		select SUM(totalPrice) as [Tổng Doanh Thu]
		from hoadon h, ban t 
		where datecheckin >= @checkIn and datecheckout <= @checkOut and h.trangthai = 1
		and t.maban = h.idtable
end
go
drop proc USP_getTotalPrice
go
exec USP_getTotalPrice @checkin = '2021/03/14', @checkout = '2021/03/18'
go
--------------------------------------------
alter proc USP_InsertBill 
@idtable int as
begin
insert hoadon values
(GETDATE(),null,@idtable,0,0,0)
end
go
exec USP_InsertBill 
@idtable
-----------------------------------------------

create proc USP_InsertBillInfo
@idBill int, @idFood int, @Slg int as
begin
		declare @isExitBillInfo int 
		declare @foodCount int = 1
		
		select @isExitBillInfo = id ,@foodCount = b.Slg  from tthoadon as b where idBill = @idBill and idFood = @idFood 
		if(@isExitBillInfo > 0)
		begin 
		declare @newCount int = @foodCount + @Slg
		
		if(@newCount>0)
			update tthoadon set Slg = @foodCount + @Slg where idFood = @idFood
		else
			delete tthoadon where idBill = @idBill and idFood = @idFood
		end
		else
		begin
		insert tthoadon values
		(@idBill,@idFood,@Slg)
		end
end
go
----------------------------------------------------------------------
create proc USP_DeleteBillInfo
@idBill int, @idFood int, @Slg int as
begin
		declare @isExitBillInfo int 
		declare @foodCount int = 0
		
		select @isExitBillInfo = id ,@foodCount = b.Slg  from tthoadon as b where idBill = @idBill and idFood = @idFood 
		if(@isExitBillInfo > 0)
		begin 
		declare @newCount int = @foodCount - @Slg 
		
		if(@newCount>0)
			update tthoadon set Slg = @foodCount - @Slg  where idFood = @idFood
		else
			delete tthoadon where idBill = @idBill and idFood = @idFood
		end
end
go
-------------------------------------------------------------------------------------
create proc USP_ClearBillInfo
@idBill int, @idFood int, @Slg int as
begin
	declare @isExitBillInfo int 
		declare @foodCount int = 0
		
		select @isExitBillInfo = id ,@foodCount = b.Slg  from tthoadon as b where idBill = @idBill and idFood = @idFood 
		if(@isExitBillInfo > 0)
		begin 
		declare @newCount int = @foodCount - @Slg 
		
		if(@newCount>0)
			update tthoadon set Slg = @foodCount - @Slg  where idFood = @idFood
		else
			delete tthoadon where idBill = @idBill and idFood = @idFood
		end
end
go
-------------------------------------------------------------------------------------
create trigger USP_UpdateBillInfo
on tthoadon for insert, update as
begin 
	declare @idBill int 
	
	select idBill from inserted
	
	declare @idTable int
	
	select @idTable = idtable from hoadon where id = @idBill and trangthai = 0
	
	declare @SlgBillInfo int 
	
	select COUNT(*) from tthoadon where idBill = @idBill
	
	if(@SlgBillInfo > 0)
	update ban set thuoctinh = N'Có Người' where  maban = @idTable
	else
	update ban set thuoctinh = N'Trống' where  maban = @idTable
end
go
-------------------------------------------------------------------------------------
alter trigger USP_UpdateBill
on hoadon for update as
begin
	declare @idBill int 
	select @idBill = id from Inserted
	declare @idTable int
	select @idTable = idtable from hoadon where id = @idBill
	declare @slg int = 0
	select @slg = COUNT(*) from hoadon where idtable = @idTable and trangthai = 0
	if(@slg = 0)
		update ban set thuoctinh = N'Trống' where maban = @idTable

end
go
-------------------------------------------------------------------------------------
create trigger UTG_UpdateBillInfo
on tthoadon for insert, update
as
begin
	declare @idBill int 
	select @idBill = idBill from inserted
	declare @idTable int 
	select @idTable = idTable from hoadon where id = @idBill and trangthai = 0
	declare @Slg int
	select @Slg = COUNT(*) from tthoadon where idBill = @idBill
	
	if(@Slg > 0)
	begin
		update ban set thuoctinh = N'Có Người' where maban = @idTable
	end
	else
		begin
			update ban set thuoctinh = N'Trống' where maban = @idTable
		end
end
go
-------------------------------------------------------------------------------------
alter trigger UTG_UpdateTTHD
on tthoadon for insert,update
as
	declare @idBill int 
	select @idBill = idBill from inserted
	declare @idTable int 
	select @idTable = idTable from hoadon where id = @idBill and trangthai = 0
begin
	if exists (select * from inserted where inserted.id = @idTable)
	begin
		update hanghoa set solg = solg + (select inserted.slg from inserted where idFood = inserted.idFood)
		from hanghoa join inserted on hanghoa.mahh = inserted.idFood
	end
	else
	begin
		update hanghoa set solg = solg - (select inserted.slg from inserted where idFood = inserted.idFood)
		from hanghoa join inserted on hanghoa.mahh = inserted.idFood
	end
end
go
drop trigger UTG_UpdateTTHD
-------------------------------------------------------------------------------------
create proc USP_SwichTable
@idTable1 int, @idTable2 int 
as
begin
	declare @idBillFirst int
	declare @idBillSeconr int
	declare @idFirstTableEmty int = 1
	declare @idSeconrTableEmty int = 1
	
	select @idBillSeconr = id from hoadon where idtable = @idTable2 and trangthai = 0
	select @idBillFirst = id from hoadon where idtable = @idTable1 and trangthai = 0
	
	if(@idBillFirst is null)
	begin
		insert hoadon values (GETDATE(),null,@idTable1,0,0,0)
		
		select @idBillFirst = MAX(id) from hoadon where idtable = @idTable1 and trangthai = 0

	end
	select @idFirstTableEmty = COUNT(*) from tthoadon where idBill = @idBillFirst

	
	if(@idBillSeconr is null)
	begin
		insert hoadon values (GETDATE(),null,@idTable2,0,0,0)

	select @idBillSeconr = MAX(id) from hoadon where idtable = @idTable2 and trangthai = 0

	end
	select @idSeconrTableEmty = COUNT(*) from tthoadon where idBill = @idBillSeconr
	
	select id into IdBillInfoTable from tthoadon where idBill = @idBillSeconr
	
	update tthoadon set idBill = @idBillSeconr where idBill = @idBillFirst
	
	update tthoadon set idBill = @idBillFirst where id in (select * from IdBillInfoTable)
	
	drop table IdBillInfoTable
	
	if(@idFirstTableEmty = 0)
		update ban set thuoctinh = N'Trống' where maban = @idTable2
		
	if(@idSeconrTableEmty = 0)
		update ban set thuoctinh = N'Trống' where maban = @idTable1
	
end
-------------------------------------------------------------------------------------
alter proc USP_GopBan
@idTable1 int, @idTable2 int 
as
begin
	declare @idBillFirst int
	declare @idBillSeconr int
	declare @idFirstTableEmty int = 0
	declare @idSeconrTableEmty int = 0
	
	select @idBillFirst = id from hoadon where idtable = @idTable1 and trangthai = 0
	select @idBillSeconr = id from hoadon where idtable = @idTable2 and trangthai = 0
	

	if(@idBillFirst is null)
	begin
		insert hoadon values (GETDATE(),null,@idTable1,0,0,0)
		select @idBillFirst = MAX(id) from hoadon where idtable = @idTable1 and trangthai = 0
	end
	select @idFirstTableEmty = COUNT(*) from tthoadon where idBill = @idBillFirst
	
	
	if(@idBillSeconr is null)
	begin
		insert hoadon values (GETDATE(),null,@idTable2,0,0,0)
	select @idBillSeconr = MAX(id) from hoadon where idtable = @idTable2 and trangthai = 1
	
	end
	select @idSeconrTableEmty = COUNT(*) from tthoadon where idBill = @idBillSeconr
	
	select id into IdBillInfoTab from tthoadon where idBill = @idBillSeconr
	
	update tthoadon set idBill = @idBillSeconr where idBill = @idBillFirst
	update tthoadon set idBill = @idBillSeconr where id in (select * from IdBillInfoTab)

	drop table IdBillInfoTab
	
	if(@idSeconrTableEmty = 0)
		update ban set thuoctinh = N'Trống' where maban = @idTable2
		
	if(@idFirstTableEmty = 1)
		update ban set thuoctinh = N'Trống' where maban = @idTable1
	
end
go
-------------------------------------------------------------------------------------

