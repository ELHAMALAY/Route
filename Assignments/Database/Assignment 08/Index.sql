-- Q01
CREATE TABLE PatientIndexDemo (
	PatientId   INT,
    PatientName VARCHAR(100),
    DOB         DATE,
    WardId      INT
);
GO

INSERT INTO PatientIndexDemo (PatientId, PatientName, DOB, WardId)
SELECT Id, Name, DOB, WardId
FROM Patients;
GO

CREATE CLUSTERED INDEX IX_PatientIndexDemo_PatientId
ON PatientIndexDemo (PatientId);
GO

-- Q02
CREATE TABLE ConsultantIndexDemo (
    ConsultantId   INT,
    ConsultantName VARCHAR(100),
    Salary         MONEY
);
GO
 
INSERT INTO ConsultantIndexDemo (ConsultantId, ConsultantName, Salary)
SELECT Id, Name, Salary
FROM Consultants;
GO
 
CREATE CLUSTERED INDEX IX_ConsultantIndexDemo_ConsultantId
ON ConsultantIndexDemo (ConsultantId);
GO

-- Q03
CREATE NONCLUSTERED  INDEX IX_Patients_WardId
ON Patients (WardId);
GO

-- Q04
CREATE NONCLUSTERED INDEX IX_Consultants_Salary
ON Consultants (Salary);
GO

-- Q05
CREATE NONCLUSTERED INDEX IX_DrugAdministrations_PatientId_DrugCode
ON DrugAdministrations (PatientId, DrugCode);
GO

-- Q06
CREATE NONCLUSTERED INDEX IX_Patients_WardId_IncludeNameDOB
ON Patients (WardId)
INCLUDE (Name, DOB);
GO

-- Q07
CREATE UNIQUE NONCLUSTERED INDEX UQ_Consultants_Name
ON Consultants (Name);
GO

-- Q08
CREATE TABLE PatientDrugAssignmentDemo (
    PatientId INT,
    DrugCode  INT,
    StartDate DATE
);
GO

CREATE UNIQUE NONCLUSTERED INDEX UQ_PatientDrugAssignmentDemo_PatientId_DrugCode
ON PatientDrugAssignmentDemo (PatientId, DrugCode);
GO

-- Q09
INSERT INTO PatientDrugAssignmentDemo (PatientId, DrugCode, StartDate)
VALUES (1, 101, '2026-01-01');
GO
 
INSERT INTO PatientDrugAssignmentDemo (PatientId, DrugCode, StartDate)
VALUES (1, 101, '2026-02-15');
GO

-- Q10
EXEC sp_helpindex 'Patients';
GO

-- Q11
SELECT 
    t.name  AS TableName,
    i.name  AS IndexName,
    i.type_desc AS IndexType
FROM sys.indexes i
INNER JOIN sys.tables t
ON i.object_id = t.object_id
WHERE i.name IS NOT NULL
ORDER BY t.name, i.name;
GO

-- Q12
DROP INDEX IX_Consultants_Salary ON Consultants;
GO

-- Q13
CREATE NONCLUSTERED INDEX IX_Patients_WardId_DOB
ON Patients (WardId, DOB);
GO

-- Q14
CREATE NONCLUSTERED INDEX IX_DrugAdministrations_PatientId_Date_Reporting
ON DrugAdministrations (PatientId, [DATE])
INCLUDE (DrugCode, Dosage, Quantity);
GO