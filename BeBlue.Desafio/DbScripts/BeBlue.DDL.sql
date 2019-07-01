/*
* Desafio Be-Blue
* Criação das tabelas
*/

If object_id('fkAlbumGenero', 'F') Is Not Null
	Alter Table Albuns Drop Constraint fkAlbumGenero;
Go
If object_id('fkCashBackGenero', 'F') Is Not Null
	Alter Table CashBack Drop Constraint fkCashBackGenero;
Go
If object_id('fkVendaCliente', 'F') Is Not Null
	Alter Table Vendas Drop Constraint fkVendaCliente;
Go
If object_id('fkAlbumGenero', 'F') Is Not Null
	Alter Table Albuns Drop Constraint fkAlbumGenero;
Go
If object_id('fkItemVenda', 'F') Is Not Null
	Alter Table ItensVenda Drop Constraint fkItemVenda;
Go
If object_id('fkAlbumVenda', 'F') Is Not Null
	Alter Table ItensVenda Drop Constraint fkAlbumVenda;
Go

If object_id(N'Generos', N'U') is Not Null
	Drop Table Generos;
Go
Create Table	Generos
(
		id			int		Constraint pkGenero Primary Key Identity (1, 1) Not Null
	,	descricao	varChar(70)	Not Null
);
Go
Create Unique Index idxGenero On Generos ( id );
Go
If object_id(N'Albuns', N'U') is Not Null
	Drop Table Albuns;
Go
Create Table	Albuns
(
		id			int				Constraint pkAlbum Primary Key Identity (1, 1) Not Null
	,	titulo		varChar(250)	Not Null
	,	idGenero	int				Constraint fkAlbumGenero Foreign Key References Generos(id) Not Null
	,	preco	decimal(18, 2)	Not Null
);
Go
Create Unique Index idxAlbum On Albuns ( id, idGenero );
Go
If object_id(N'CashBack', N'U') is Not Null
	Drop Table CashBack;
Go
Create Table	CashBack
(
		id			int		Constraint pkCashBack Primary Key Identity (1, 1) Not Null
	,	idGenero	int		Constraint fkCashBackGenero Foreign Key References Generos (id) Not Null
	,	diaSemana	int		Not Null
	,	porcentagem	decimal(18, 2) Not Null
);
Go
Create Unique Index idxCashBack On CashBack ( id, idGenero, diaSemana );
Go
If object_id(N'Clientes', N'U') is Not Null
	Drop Table Clientes;
Go
Create Table	Clientes
(
		id		int				Constraint pkCliente Primary Key Identity (1, 1) Not Null
	,	nome	varChar(70)		Not Null
	,	email	nVarChar(250)	Not Null
);
Go
Create Unique Index idxCliente On Clientes ( id );
Go
If object_id(N'Vendas', N'U') is Not Null
	Drop Table Vendas;
Go
Create Table	Vendas
(
		id			int			Constraint pkVenda Primary Key Identity (1, 1) Not Null
	,	idCliente	int			Constraint fkVendaCliente Foreign Key References Clientes ( id ) Not Null
	,	dtVenda		smallDateTime Not Null	Default getDate()
);
Go
Create Unique Index idxVenda On Vendas ( id );
Go
If object_id(N'ItensVenda', N'U') is Not Null
	Drop Table ItensVenda;
Go
Create Table	ItensVenda
(
		id			int			Constraint pkItem Primary Key Identity (1, 1) Not Null
	,	idVenda		int			Constraint fkItemVenda Foreign Key References Vendas ( id ) Not Null
	,	idAlbum		int			Constraint fkAlbumVenda Foreign Key References Albuns ( id ) Not Null
	,	totalItem	decimal(18, 2) Not Null
	,	cashBack	decimal(18, 2) Not Null
);
Go
Create Unique Index idxItemVenda On ItensVenda ( id, idVenda, idAlbum );
Go