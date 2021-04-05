
--BANCO DE DADOS -> CrudMvcComAdo

---------------------------------------------
--DELETAR----------------------------------
---------------------------------------------
--CREATE PROCEDURE ExcluirTime
--(

--@TimeId INT

--)

--AS

--BEGIN
--    DELETE FROM Times WHERE TimeId = @TimeId
--END



---------------------------------------------
--ATUALIZAR----------------------------------
---------------------------------------------

--CREATE PROCEDURE AtualizarTime
--(

--@TimeId INT,
--@Time NVARCHAR(100),
--@EstadoId INT,
--@Cores VARCHAR(50)

--)

--AS

--BEGIN
--    UPDATE Times SET 
--	      Time = @Time, 
--		  EstadoId = @EstadoId, 
--		  Cores = @Cores  
--		  FROM 
--		     Times 
--	      WHERE TimeId = @TimeId
--END




---------------------------------------------
--INCLUIR------------------------------------
---------------------------------------------
--CREATE PROCEDURE IncluirTime
--(

--@Time NVARCHAR(100),
--@EstadoId INT,
--@Cores VARCHAR(50)

--)

--AS

--BEGIN
--    INSERT INTO Times VALUES( 
--	      @Time, 
--		  @EstadoId, 
--		  @Cores)  
--END

---------------------------------------------
--Select Times com join em Estado------------
---------------------------------------------

--CREATE PROCEDURE ObterTimes

--AS

--BEGIN
--    SELECT t.TimeId,t.Time, e.EstadoSigla, e.EstadoNome, t.Cores FROM Times t
--	  JOIN Estado e
--	    ON 
--	  e.EstadoId = t.EstadoId
--END

---------------------------------------------
--Select Estado------------------------------
---------------------------------------------

--CREATE PROCEDURE ObterEstados

--AS

--BEGIN
--    SELECT  EstadoId, EstadoSigla, EstadoNome FROM Estado
--END