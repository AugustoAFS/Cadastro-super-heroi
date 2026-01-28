Create database Desafio_Trainee_Viceri;

use Desafio_Trainee_Viceri;

create table Herois (
	Id int Identity(1,1) primary key not null,
	Nome varchar(120) not null,
	NomeHeroi varchar(120) not null,
	DataNascimento DateTime null,
	Altura Decimal(18,2) not null,
	Peso Decimal(18,2) not null,
	
    Created_At DateTime NOT NULL,
    Flg_Inativo BIT NOT NULL,
    Deleted_At DateTime NULL
);

create table Superpoderes(
	Id int Identity(1,1) primary key not null,
	Superpoder varchar(50) not null,
	Descricao varchar(250) null,

    Created_At DateTime NOT NULL,
    Flg_Inativo BIT NOT NULL,
    Deleted_At DateTime NULL
);

create table HeroisSuperpoderes(
	Id int Identity(1,1) primary key not null,
	HeroiId int null,
	SuperpoderId int null,

    Created_At DateTime NOT NULL,
    Flg_Inativo BIT NOT NULL,
    Deleted_At DateTime NULL

	CONSTRAINT FK_HeroisSuperpoderes_Herois FOREIGN KEY (HeroiId) REFERENCES Herois(Id),
    CONSTRAINT FK_HeroisSuperpoderes_Superpoderes FOREIGN KEY (SuperpoderId) REFERENCES Superpoderes(Id),
);


INSERT INTO Superpoderes (Superpoder, Descricao, Created_At, Flg_Inativo) VALUES 
('Super Força', 'Capacidade de exercer força física acima dos limites humanos normais.', GETDATE(), 0),
('Voo', 'Habilidade de desafiar a gravidade e se mover pelo ar.', GETDATE(), 0),
('Invisibilidade', 'Capacidade de não ser visto a olho nu.', GETDATE(), 0),
('Telepatia', 'Habilidade de ler e controlar mentes.', GETDATE(), 0),
('Velocidade Sobre-humana', 'Capacidade de se mover a velocidades extremas.', GETDATE(), 0),
('Regeneração', 'Habilidade de curar ferimentos rapidamente.', GETDATE(), 0),
('Teletransporte', 'Capacidade de se mover instantaneamente de um lugar para outro.', GETDATE(), 0),
('Controle Elemental', 'Habilidade de manipular elementos da natureza (fogo, água, terra, ar).', GETDATE(), 0),
('Visão de Raio-X', 'Capacidade de ver através de objetos sólidos.', GETDATE(), 0),
('Elasticidade', 'Habilidade de esticar e deformar o corpo.', GETDATE(), 0);
