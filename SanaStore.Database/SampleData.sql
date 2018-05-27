/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT Categories ([Name]) VALUES
('Action'),
('Adventure'),
('Puzzle'),
('Horror'),
('Mature'),
('RPG')
GO

INSERT Products ([Name], [Price]) VALUES
('Destiny', 40),
('Destiny 2', 45),
('Resident Evil VII', 60),
('Dead Space', 20),
('Doom', 35),
('Minecraft', 10)
GO

INSERT ProductCategories([ProductId],[CategoryId]) VALUES
(1,2),(1,6),
(2,2),(2,6),
(3,1),(3,4),(3,5),
(4,1),(4,3),(4,4),
(5,1),(5,4),
(6,2),(6,3)
GO

