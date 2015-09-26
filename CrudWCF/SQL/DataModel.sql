create table Invoice
(
	idInvoice int identity(1,1) primary key,
	Number int not null,
	Concept varchar(200) not null,
	Description varchar(1000) not null,
	total decimal not null,
	dateI datetime not null,
	dateF datetime not null
)

go

create table InvoiceLine
(

	idLine int identity(1,1) primary key,
	rIdInvoice int not null,
	sDesc varchar(200) not null,
	total decimal not null
)

go

ALTER TABLE InvoiceLine ADD CONSTRAINT fkInvoice 
FOREIGN KEY (rIdInvoice) REFERENCES Invoice(idInvoice)

go

--select getdate()
insert into Invoice(Number,Concept,Description,total,dateI, dateF)
values(1,'235.61.278','Payment Kantoor Utrecht',1345,GETDATE(),'2015-11-13 14:29:54.063')

go

insert into InvoiceLine(rIdInvoice,sDesc,total)
values(2,'Line 1',1345)


