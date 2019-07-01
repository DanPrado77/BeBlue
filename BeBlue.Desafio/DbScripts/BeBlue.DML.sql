/*
* Desafio Be-Blue
* Pré-Cargas
*/
Insert Into Generos
Values		( 'Rock' )
	,		( 'Classic' )
	,		( 'MPB' )
	,		( 'POP' );
Go
Insert Into Albuns
Values		( 'Album 1', 1, 60 )
		,	( 'Album 2', 1, 65 )
		,	( 'Album 3', 3, 30 )
		,	( 'Album 4', 2, 40);
Go
Insert Into	CashBack
Values		( 1, 0, 40 ) -- Domingo (Rock)
	,		( 2, 0, 35 ) -- Domingo (Classic)
	,		( 3, 0, 30 ) -- Domingo (MPB)
	,		( 4, 0, 25 ) -- Domingo (Pop)

	,		( 1, 1, 10 ) -- Segunda (Rock)
	,		( 2, 1, 3 ) -- Segunda (Classic)
	,		( 3, 1, 5 ) -- Segunda (MPB)
	,		( 4, 1, 7 ) -- Segunda (Pop)

	,		( 1, 2, 15 ) -- Terça (Rock)
	,		( 2, 2, 5 ) -- Terça (Classic)
	,		( 3, 2, 10 ) -- Terça (MPB)
	,		( 4, 2, 6 ) -- Terça (Pop)

	,		( 1, 3, 15 ) -- Quarta (Rock)
	,		( 2, 3, 8 ) -- Quarta (Classic)
	,		( 3, 3, 15 ) -- Quarta (MPB)
	,		( 4, 3, 2 ) -- Quarta (Pop)

	,		( 1, 4, 15 ) -- Quinta (Rock)
	,		( 2, 4, 13 ) -- Quinta (Classic)
	,		( 3, 4, 20 ) -- Quinta (MPB)
	,		( 4, 4, 10 ) -- Quinta (Pop)

	,		( 1, 5, 20 ) -- Sexta (Rock)
	,		( 2, 5, 18 ) -- sexta (Classic)
	,		( 3, 5, 25 ) -- Sexta (MPB)
	,		( 4, 5, 15 ) -- Sexta (Pop)

	,		( 1, 6, 40 ) -- Sábado (Rock)
	,		( 2, 6, 25 ) -- Sábado (Classic)
	,		( 3, 6, 30 ) -- Sábado (MPB)
	,		( 4, 6, 20 ) -- Sábado (Pop)
Go
Insert Into	Clientes
Values		( 'João da Silva', 'joao@email.com' )
		,	( 'Maria da Silva', 'maria@email.com ');
Go
Insert Into	Vendas
Values		( 1, getDate());
Go
Insert Into	ItensVenda
Values		( 1, 1, 100, 75 );