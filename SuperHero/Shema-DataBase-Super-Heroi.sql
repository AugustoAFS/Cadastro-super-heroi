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

INSERT INTO Herois (Nome, NomeHeroi, DataNascimento, Altura, Peso, Created_At, Flg_Inativo) VALUES 
('Bruce Wayne', 'Batman', '1939-05-27', 1.88, 95.0, GETDATE(), 0),
('Clark Kent', 'Superman', '1938-06-18', 1.91, 107.0, GETDATE(), 0),
('Diana Prince', 'Mulher Maravilha', '1941-10-21', 1.83, 75.0, GETDATE(), 0),
('Tony Stark', 'Homem de Ferro', '1970-05-29', 1.85, 82.0, GETDATE(), 0),
('Steve Rogers', 'Capitão América', '1918-07-04', 1.88, 108.0, GETDATE(), 0),
('Peter Parker', 'Homem-Aranha', '2001-08-10', 1.78, 76.0, GETDATE(), 0),
('Thor Odinson', 'Thor', '0965-01-01', 1.98, 290.0, GETDATE(), 0),
('Bruce Banner', 'Hulk', '1969-12-18', 2.50, 635.0, GETDATE(), 0),
('Natasha Romanoff', 'Viúva Negra', '1984-11-22', 1.70, 59.0, GETDATE(), 0),
('Barry Allen', 'Flash', '1989-03-19', 1.83, 88.0, GETDATE(), 0);


INSERT INTO HeroisSuperpoderes (HeroiId, SuperpoderId, Created_At, Flg_Inativo)
SELECT h.Id, s.Id, GETDATE(), 0 FROM Herois h JOIN Superpoderes s ON 1=1
WHERE h.NomeHeroi = 'Superman' 
AND s.Superpoder IN ('Voo', 'Super Força', 'Visão de Raio-X', 'Velocidade Sobre-humana');

INSERT INTO HeroisSuperpoderes (HeroiId, SuperpoderId, Created_At, Flg_Inativo)
SELECT h.Id, s.Id, GETDATE(), 0 FROM Herois h JOIN Superpoderes s ON 1=1
WHERE h.NomeHeroi = 'Mulher Maravilha' 
AND s.Superpoder IN ('Voo', 'Super Força');

INSERT INTO HeroisSuperpoderes (HeroiId, SuperpoderId, Created_At, Flg_Inativo)
SELECT h.Id, s.Id, GETDATE(), 0 FROM Herois h JOIN Superpoderes s ON 1=1
WHERE h.NomeHeroi = 'Homem de Ferro' 
AND s.Superpoder IN ('Voo', 'Super Força');

INSERT INTO HeroisSuperpoderes (HeroiId, SuperpoderId, Created_At, Flg_Inativo)
SELECT h.Id, s.Id, GETDATE(), 0 FROM Herois h JOIN Superpoderes s ON 1=1
WHERE h.NomeHeroi = 'Capitão América' 
AND s.Superpoder IN ('Super Força', 'Regeneração');

INSERT INTO HeroisSuperpoderes (HeroiId, SuperpoderId, Created_At, Flg_Inativo)
SELECT h.Id, s.Id, GETDATE(), 0 FROM Herois h JOIN Superpoderes s ON 1=1
WHERE h.NomeHeroi = 'Homem-Aranha' 
AND s.Superpoder IN ('Super Força', 'Velocidade Sobre-humana', 'Regeneração');

INSERT INTO HeroisSuperpoderes (HeroiId, SuperpoderId, Created_At, Flg_Inativo)
SELECT h.Id, s.Id, GETDATE(), 0 FROM Herois h JOIN Superpoderes s ON 1=1
WHERE h.NomeHeroi = 'Thor' 
AND s.Superpoder IN ('Super Força', 'Voo', 'Controle Elemental');

INSERT INTO HeroisSuperpoderes (HeroiId, SuperpoderId, Created_At, Flg_Inativo)
SELECT h.Id, s.Id, GETDATE(), 0 FROM Herois h JOIN Superpoderes s ON 1=1
WHERE h.NomeHeroi = 'Hulk' 
AND s.Superpoder IN ('Super Força', 'Regeneração');

INSERT INTO HeroisSuperpoderes (HeroiId, SuperpoderId, Created_At, Flg_Inativo)
SELECT h.Id, s.Id, GETDATE(), 0 FROM Herois h JOIN Superpoderes s ON 1=1
WHERE h.NomeHeroi = 'Flash' 
AND s.Superpoder IN ('Velocidade Sobre-humana', 'Regeneração');