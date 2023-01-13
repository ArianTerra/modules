--TASK 1
drop proc if exists sp_CreateTable

create proc sp_CreateTable
as
    create table SalesOrders.dbo.tb_Results(
        SalesOrderID int not null,
        CustomerID int,
        WarehouseCode nvarchar(20),
        SalesDate datetime,
        TotalAmt decimal(25, 6),
        PaidAmt decimal(25, 6)
    )
go

exec sp_CreateTable

--TASK 2
drop proc if exists sp_AlterTableAddKeys

create proc sp_AlterTableAddKeys
as
    alter table SalesOrders.dbo.tb_Results
        add constraint PK_Result primary key (SalesOrderID);
    alter table SalesOrders.dbo.tb_Results
        add constraint FK_Result_Customer foreign key (CustomerID) references Customer(CustomerID);
go

exec sp_AlterTableAddKeys

--TASK 3
drop proc if exists sp_SelectInsert

create proc sp_SelectInsert
as
    insert into SalesOrders.dbo.tb_Results(SalesOrderID, CustomerID, WarehouseCode, SalesDate, TotalAmt, PaidAmt)
    select s.SalesOrderID, s.CustomerID, w.WarehouseCode, s.SalesDate, s.TotalAmt, s.PaidAmt
    from SalesOrder s
    inner join Warehouse W on W.WarehouseID = s.WarehouseID
    inner join Customer C on C.CustomerID = s.CustomerID
    where C.State = 'IL' or C.State = 'NY' or C.State = 'MO'
go

exec sp_SelectInsert

--TASK 4
drop proc if exists sp_UpdateDelete

create proc sp_UpdateDelete
as
    begin
        delete from SalesOrders.dbo.tb_Results
        where TotalAmt = PaidAmt

        update tb_Results
        set PaidAmt = 100
        where TotalAmt - PaidAmt > 100
    end
go

exec sp_UpdateDelete

--TASK 5
drop proc if exists sp_GetInfoByCustomer

create proc sp_GetInfoByCustomer
as
    select top 7 S.CustomerID, C.Name, count(*) as Count, sum(S.TotalAmt) as TotalAmt, sum(S.TotalAmt) - sum(S.PaidAmt) as TotalUnpaid
    from SalesOrder S
    inner join Customer C on C.CustomerID = S.CustomerID
    group by S.CustomerID, C.Name
    order by Count desc, S.CustomerID
go

exec sp_GetInfoByCustomer

--TASK 6
drop proc if exists sp_GetInfoByUnpaidCustomer

create proc sp_GetInfoByUnpaidCustomer
as
    select S.CustomerID, C.Name, count(*) as Count, sum(S.TotalAmt) as TotalAmt, sum(S.TotalAmt) - sum(S.PaidAmt) as TotalUnpaid
    from SalesOrder S
    inner join Customer C on C.CustomerID = S.CustomerID
    group by S.CustomerID, C.Name
    having sum(S.TotalAmt) - sum(S.PaidAmt) > 0
go

exec sp_GetInfoByUnpaidCustomer

--TASK 7
drop proc if exists sp_GetAverageSalesOrderAmt

create proc sp_GetAverageSalesOrderAmt
    @avg decimal(25, 6) out
as
    select @avg = avg(TotalAmt) from SalesOrder
go

declare @c decimal(25, 6)
exec sp_GetAverageSalesOrderAmt @c out
select @c

--TASK 8
drop proc if exists sp_DropTable

create proc sp_DropTable
as
    drop table if exists tb_Results
go

exec sp_DropTable