SELECT definition
FROM sys.sql_modules
WHERE object_id = OBJECT_ID('trg_Patients_WardChange');
GO

-- Q01
BEGIN TRANSACTION
	UPDATE Patients
	SET WardId = 2
	WHERE Id = 1;
COMMIT TRANSACTION
GO

-- Q02
BEGIN TRANSACTION;
    UPDATE Consultants
    SET Salary = Salary + 5000
    WHERE Id = 1;
ROLLBACK TRANSACTION;
GO

-- Q03
BEGIN TRANSACTION
	UPDATE Patients
	SET WardId = 3
	WHERE Id = 1;

	UPDATE Nurses 
	SET ServesInWardId = 3
	WHERE Number = 1;
COMMIT TRANSACTION;
GO

-- Q04
BEGIN TRANSACTION
	UPDATE Patients
	SET WardId = 2
	WHERE Id = 1;

	SAVE TRANSACTION PatientUpdate;

	UPDATE Patients
    SET Name = 'Temporary Patient Name'
    WHERE Id = 1;

	ROLLBACK TRANSACTION PatientUpdate;
COMMIT TRANSACTION;
GO

-- Q05
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE Consultants
		SET Salary = Salary + 3000
		WHERE Id = 1;
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;

	SELECT 
		ERROR_NUMBER()  AS ErrorNumber,
		ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
GO

-- Q06
CREATE VIEW vw_ConsultantPatientStatistics
AS
SELECT
    c.Id                        AS ConsultantId,
    c.Name                       AS ConsultantName,
    c.Salary,
    COUNT(pca.PatientId)         AS NumberOfPatients
FROM Consultants c
LEFT JOIN PatientConsultantAssignments pca
    ON pca.ConsultantId = c.Id
GROUP BY c.Id, c.Name, c.Salary;
GO

-- Q07
SELECT *
FROM vw_ConsultantPatientStatistics
WHERE NumberOfPatients > 5;
GO

-- Q08
DROP VIEW IF EXISTS dbo.vw_IndexedConsultantPatientCount;
GO

CREATE VIEW dbo.vw_IndexedConsultantPatientCount
WITH SCHEMABINDING
AS
SELECT
    pca.ConsultantId,
    COUNT_BIG(*) AS NumberOfPatients
FROM dbo.PatientConsultantAssignments pca
GROUP BY pca.ConsultantId;
GO

CREATE UNIQUE CLUSTERED INDEX IX_vw_IndexedConsultantPatientCount
ON dbo.vw_IndexedConsultantPatientCount (ConsultantId);
GO


-- Q09
SELECT *
FROM dbo.vw_IndexedConsultantPatientCount
WHERE NumberOfPatients > 5;
GO

-- Q10
SELECT
    name        AS ViewName,
    create_date AS CreationDate,
    modify_date AS ModificationDate
FROM sys.views;
GO

-- Q11
SELECT definition
FROM SYS.sql_modules
WHERE OBJECT_id = OBJECT_ID('vw_PatientInformation');
GO

-- Q12
CREATE OR ALTER VIEW vw_PatientInformation
AS
SELECT
    Id   AS PatientId,
    Name AS PatientName,
    DOB
FROM Patients;
GO

-- Q13
DROP VIEW vw_ConsultantSalary;
GO

-- Q14
CREATE VIEW vw_PatientHospitalReport
AS
SELECT
    p.Id    AS PatientId,
    p.Name  AS PatientName,
    p.DOB,
    w.Name  AS WardName,
    c.Name  AS ConsultantName
FROM Patients p
LEFT JOIN Wards w
    ON w.Id = p.WardId
LEFT JOIN PatientConsultantAssignments pca
    ON pca.PatientId = p.Id
LEFT JOIN Consultants c
    ON c.Id = pca.ConsultantId;
GO

-- Q15
SELECT *
FROM vw_PatientHospitalReport
WHERE ConsultantName IS NOT NULL;
GO

-- Q16
SELECT
    PatientName,
    WardName,
    ConsultantName
FROM vw_PatientHospitalReport
WHERE WardName = 'Cardiology';  
GO

-- Q17
SELECT TOP (1) *
FROM vw_ConsultantPatientStatistics
ORDER BY NumberOfPatients DESC;
GO

-- Q18
CREATE VIEW vw_PatientAgeInformation
AS
SELECT
    Id   AS PatientId,
    Name AS PatientName,
    DOB,
    DATEDIFF(YEAR, DOB, GETDATE())
        - CASE WHEN (MONTH(DOB) > MONTH(GETDATE()))
                 OR (MONTH(DOB) = MONTH(GETDATE()) AND DAY(DOB) > DAY(GETDATE()))
               THEN 1 ELSE 0 END AS Age
FROM Patients;
GO

SELECT *
FROM vw_PatientAgeInformation
WHERE Age > 60;
GO

-- Q19
SELECT *
FROM vw_ConsultantPatientStatistics
ORDER BY NumberOfPatients DESC;
GO

-- Q20
CREATE VIEW vw_PatientWardInformation
AS
SELECT
    p.Id   AS PatientId,
    p.Name AS PatientName,
    w.Id   AS WardId,
    w.Name AS WardName
FROM Patients p
LEFT JOIN Wards w
    ON w.Id = p.WardId;
GO

SELECT
    WardName,
    COUNT(*) AS NumberOfPatients
FROM vw_PatientWardInformation
GROUP BY WardName;
GO

-- Q21
SELECT
    s.name      AS SchemaName,
    v.name      AS ViewName,
    i.name      AS IndexName,
    i.type_desc AS IndexType
FROM sys.views v
JOIN sys.schemas s
    ON s.schema_id = v.schema_id
JOIN sys.indexes i
    ON i.object_id = v.object_id
WHERE i.type > 0;  -- excludes heaps (type = 0); indexed views always have a clustered index
GO