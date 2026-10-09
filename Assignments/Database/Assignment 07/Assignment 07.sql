-- Q01
CREATE PROCEDURE GetAllPatients
AS
    SELECT Id, Name, DOB, WardId FROM Patients;
GO

-- Q02
CREATE OR ALTER PROCEDURE GetAllConsultants
AS
    SELECT Id, Name, Salary FROM Consultants;
GO

-- Q03
CREATE PROCEDURE GetPatientsWithWards
AS
    SELECT p.Id, p.Name, p.DOB, w.Id AS WardId, w.Name AS WardName
    FROM Patients P
    LEFT JOIN Wards W
    ON P.WardId = W.Id
GO

-- Q04
CREATE PROCEDURE GetPatientById 
@PatientId INT
AS
    SELECT *
    FROM Patients
    WHERE Patients.Id = @PatientId
GO

-- Q05
CREATE PROCEDURE GetConsultantsByMinSalary
@MinSalary DECIMAL(10,2)
AS
    SELECT *
    FROM Consultants
    WHERE Consultants.Salary >= @MinSalary
GO

-- Q06
CREATE OR ALTER PROCEDURE GetPatientsByWard
@WardId INT
AS
    SELECT *
    FROM Patients
    WHERE Patients.WardId = @WardId;
GO

-- Q07
CREATE PROCEDURE GetPatientCount
@COUNT INT OUTPUT
AS
BEGIN
    SELECT @COUNT = COUNT(*) 
    FROM Patients
END;
GO

-- Q08
CREATE PROCEDURE GetAverageConsultantSalary 
@AvgSalary DECIMAL(10,2) OUTPUT
AS
BEGIN
    SELECT @AvgSalary = AVG(Salary)
    FROM Consultants
END;
GO

-- Q09
CREATE PROCEDURE GetPatientMedicationQuantity
@PatientId INT,
@TotalQuantity INT OUTPUT
AS
BEGIN
    SELECT @TotalQuantity = ISNULL(SUM(Quantity), 0)
    FROM DrugAdministrations
    WHERE DrugAdministrations.PatientId = @TotalQuantity;
END;
GO

-- Q10
CREATE PROCEDURE IncreaseSalary
@Salary DECIMAL(10,2) OUTPUT,
@Percentage DECIMAL(5,2)
AS
BEGIN
    SET @Salary = @Salary + (@Salary * @Percentage / 100);
END;
GO

-- Q11
CREATE PROCEDURE AddMedicationQuantity
@Quantity INT OUTPUT,
@AdditionalQuantity INT
AS
BEGIN
    SET @Quantity = @Quantity + @AdditionalQuantity;
END;
GO

-- Q12
CREATE PROCEDURE ConvertMonthlyToAnnual
@Salary DECIMAL(10,2) OUTPUT
AS
    SET @Salary = @Salary * 12;
GO

-- Q13
CREATE PROCEDURE InsertPatientSafe
@Name NVARCHAR(100),
@DOB DATE,
@WardId INT
AS
BEGIN TRY
    INSERT INTO Patients (Name, DOB, WardId) VALUES (@Name, @DOB, @WardId)
    SELECT 'Patient inserted successfully.' AS Result;
END TRY
BEGIN CATCH
    SELECT ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
GO

-- Q14
CREATE PROCEDURE UpdateConsultantSalarySafe
@ConsultantId INT,
@NewSalary DECIMAL(10,2)
AS
BEGIN TRY
    UPDATE Consultants 
    SET Salary = @NewSalary
    WHERE Consultants.Id = @ConsultantId
    IF @@ROWCOUNT = 0  
        RAISERROR('Consultant not found.', 16, 1);
END TRY
BEGIN CATCH
    SELECT ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
GO

-- Q15
CREATE PROCEDURE DeletePatientSafe
@PatientId INT
AS
BEGIN TRY
    DELETE FROM Patients WHERE Id = @PatientId
    IF @@ROWCOUNT = 0
        RAISERROR('Patient not found.', 16, 1);
END TRY
BEGIN CATCH 
    SELECT ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
GO

-- Q16
CREATE PROCEDURE AddPatient
@Name NVARCHAR(100),
@DOB DATE,
@WardId INT
AS
    INSERT INTO Patients (Name, DOB, WardId) VALUES (@Name, @DOB, @WardId);
GO

-- Q17
CREATE PROCEDURE AddConsultant
@Name NVARCHAR(100),
@Salary DECIMAL(10,2)
AS
    INSERT INTO Consultants (Name, Salary) VALUES (@Name, @Salary);
GO

-- Q18
CREATE PROCEDURE AddMedicationAdministration
@NurseId INT,
@DrugCode NVARCHAR(20),
@PatientId INT,
@Dosage NVARCHAR(50),
@Date DATE,
@Time TIME,
@Quantity INT
AS
    INSERT INTO DrugAdministrations(NurseId, DrugCode, PatientId, Dosage, [DATE], [TIME], Quantity) 
    VALUES (@NurseId, @DrugCode, @PatientId, @Dosage, @Date, @Time, @Quantity);
GO

-- Q19
CREATE PROCEDURE UpdatePatient
@PatientId INT,
@Name NVARCHAR(100),
@DOB DATE,
@WardId INT
AS
    UPDATE Patients
    SET Name = @Name, DOB = @DOB, WardId = @WardId
    WHERE Id = @PatientId;
GO

-- Q20
CREATE PROCEDURE UpdateConsultantSalary
@ConsultantId INT,
@Salary DECIMAL(10,2)
AS
    UPDATE Consultants 
    SET Salary = @Salary
    WHERE Id = @ConsultantId;
GO

-- Q21
CREATE PROCEDURE IncreaseNurseSalary
@NurseNumber INT,
@Percentage DECIMAL(5,2)
AS
    UPDATE Nurses
    SET Salary = Salary + (Salary * @Percentage / 100)
    WHERE NUMBER = @NurseNumber;
GO

-- Q22
CREATE PROCEDURE DeletePatient 
@PatientId INT
AS
    DELETE FROM Patients WHERE Id = @PatientId;
GO

-- Q23
CREATE PROCEDURE DeleteConsultant 
@ConsultantId INT
AS
    DELETE FROM Consultants WHERE Id = @ConsultantId;
GO

-- Q24
CREATE PROCEDURE DeleteMedicationAdministration
@NurseId INT,
@DrugCode NVARCHAR(20),
@PatientId INT,
@Date DATE,
@Time TIME
AS
    DELETE FROM DrugAdministrations
        WHERE NurseId = @NurseId AND DrugCode = @DrugCode AND PatientId = @PatientId
          AND [DATE] = @Date AND [Time] = @Time;
GO

-- Q25
CREATE TABLE StoredAllPatients (
    Id INT, Name NVARCHAR(100), DOB DATE, WardId INT
);
INSERT INTO StoredAllPatients EXEC GetAllPatients;
GO

-- Q26
CREATE TABLE StoredHighSalaryConsultants (
    Id INT, Name NVARCHAR(100), Salary DECIMAL(10,2)
);
INSERT INTO StoredHighSalaryConsultants EXEC GetConsultantsByMinSalary 50000;
GO

-- Q27
CREATE TABLE StoredWardPatients (
    Id INT, Name NVARCHAR(100), DOB DATE, WardId INT
);
INSERT INTO StoredWardPatients EXEC GetPatientsByWard @WardId = 1;
GO

-- Q28
CREATE TABLE PatientAudit (
    AuditId       INT IDENTITY(1,1) PRIMARY KEY,
    PatientId     INT           NOT NULL,
    OperationType NVARCHAR(20)  NOT NULL,   -- INSERT / UPDATE / DELETE / WARD_CHANGE
    OperationDate DATETIME      NOT NULL DEFAULT GETDATE(),
    OldName       NVARCHAR(100) NULL,
    NewName       NVARCHAR(100) NULL,
    OldDOB        DATE          NULL,
    NewDOB        DATE          NULL,
    OldWardId     INT           NULL,
    NewWardId     INT           NULL
);
GO

-----------------------------------------------------------------------------------------------------

-- Q29
CREATE TRIGGER trg_Patients_AfterInsert
ON Patients 
AFTER INSERT
AS
BEGIN
    INSERT INTO PatientAudit (PatientId, OperationType, NewName, NewDOB, NewWardId)
    SELECT Id, 'INSERT', Name, DOB, WardId FROM inserted
END;
GO

-- Q30
CREATE TABLE ConsultantSalaryAudit (
    AuditId      INT IDENTITY(1,1) PRIMARY KEY,
    ConsultantId INT NOT NULL,
    OldSalary    DECIMAL(10,2) NULL,
    NewSalary    DECIMAL(10,2) NULL,
    ChangedAt    DATETIME NOT NULL DEFAULT GETDATE()
);
GO

CREATE TRIGGER trg_Consultants_SalaryAudit
ON Consultants 
AFTER UPDATE
AS 
BEGIN
    INSERT INTO ConsultantSalaryAudit (ConsultantId, OldSalary, NewSalary)
    SELECT i.Id, d.Salary, i.Salary
    FROM inserted i
    INNER JOIN deleted d
    ON I.Id = D.Id
    WHERE D.Salary <> I.Salary;
END;
GO

-- Q31
CREATE TRIGGER trg_Patients_WardChange
ON Patients 
AFTER UPDATE
AS
BEGIN
    IF NOT UPDATE(WardId) RETURN;
    INSERT INTO PatientAudit (PatientId, OperationType, OldWardId, NewWardId)
    SELECT i.Id, 'WARD_CHANGE', d.WardId, i.WardId
    FROM inserted i 
    INNER JOIN deleted d
    ON i.Id = d.Id
    WHERE D.WardId <> I.WardId;
END;
GO

-- Q32
CREATE TABLE DeletedPatients (
    PatientId INT,
    Name      NVARCHAR(100),
    DOB       DATE,
    WardId    INT,
    DeletedAt DATETIME DEFAULT GETDATE()
);
GO

CREATE TRIGGER trg_Patients_ArchiveDelete
ON Patients
AFTER DELETE
AS
BEGIN
    INSERT INTO DeletedPatients (PatientId, Name, DOB, WardId)
    SELECT Id, Name, DOB, WardId FROM deleted;
END;
GO

-- Q33
CREATE TABLE DeletedConsultants (
    ConsultantId INT,
    Name         NVARCHAR(100),
    Salary       DECIMAL(10,2),
    DeletedAt    DATETIME DEFAULT GETDATE()
);
GO

CREATE TRIGGER trg_Consultants_ArchiveDelete
ON Consultants AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO DeletedConsultants (ConsultantId, Name, Salary)
    SELECT Id, Name, Salary FROM deleted;
END;
GO

-- Q34
CREATE TRIGGER trg_Consultants_ShowSalaryChange
ON Consultants 
AFTER DELETE
AS
BEGIN
    SELECT i.Id, i.Name, d.Salary AS OldSalary, i.Salary AS NewSalary
    FROM inserted i 
    INNER JOIN deleted d
    ON i.Id = d.Id;
END;
GO

-- Q35
CREATE TRIGGER trg_Patients_ShowWardChange
ON Patients 
AFTER UPDATE
AS
BEGIN
    SELECT i.Id AS PatientId, i.Name,
           dw.Name AS OldWard, iw.Name AS NewWard
    FROM inserted i
    INNER JOIN deleted d ON i.Id = d.Id
    LEFT JOIN Wards dw ON d.WardId = dw.Id
    LEFT JOIN Wards iw ON i.WardId = iw.Id;
END;
GO

-- Q36
INSERT INTO Patients (Name, DOB, WardId)
VALUES
    ('Patient A', '1990-01-15', 1),
    ('Patient B', '1985-06-20', 2),
    ('Patient C', '2000-11-02', 1);

SELECT * FROM PatientAudit 
WHERE OperationType = 'INSERT';
GO

-- Q37
CREATE OR ALTER TRIGGER trg_Patients_ValidateInsert1
ON Patients 
INSTEAD  OF INSERT
AS
BEGIN
    IF EXISTS(SELECT 1 FROM inserted WHERE WardId IS NULL)
    BEGIN
        RAISERROR('Date of birth cannot be in the future.', 16, 1);        
        RETURN;
    END
    
    INSERT INTO Patients (Name, DOB, WardId)
    SELECT Name, DOB, WardId FROM inserted;
END;
GO

-- Q38
CREATE OR ALTER TRIGGER trg_Patients
ON Patients 
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE DOB > CAST(GETDATE() AS DATE))
    BEGIN
        RAISERROR('Date of birth cannot be in the future.', 16, 1);
        RETURN;
    END;
    INSERT INTO Patients (Name, DOB, WardId)
    SELECT Name, DOB, WardId FROM inserted;
END;
GO

-- Q39
CREATE OR ALTER TRIGGER trg_Consultants_PreventReduction
ON Consultants 
INSTEAD OF UPDATE
AS
BEGIN 
    IF EXISTS (SELECT 1 FROM inserted i
    INNER JOIN deleted d
    ON i.id = d.id
    WHERE I.Salary < D.Salary)
    BEGIN
        RAISERROR('Consultant salary cannot be reduced.', 16, 1);
        RETURN;
    END;

    UPDATE C
    SET c.Name = i.Name , c.Salary = i.Salary
    FROM Consultants c 
    INNER JOIN inserted i 
    ON c.Id = i.Id;
END;
GO

-- Q40
CREATE OR ALTER TRIGGER trg_Patients_SafeUpdate
ON Patients 
INSTEAD OF UPDATE
AS
BEGIN
    UPDATE p
    SET p.Name = i.Name, p.DOB = i.DOB, p.WardId = i.WardId
    FROM Patients p 
    INNER JOIN inserted i 
    ON p.Id = i.Id;
END;
GO

-- Q41
CREATE OR ALTER TRIGGER trg_Patients_PreventDelete
ON Patients 
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR('Patients cannot be deleted directly.', 16, 1);
END;
GO

-- Q42
DROP TRIGGER IF EXISTS trg_Patients_PreventDelete;
GO
CREATE OR ALTER TRIGGER trg_Patients_ArchiveBeforeDelete
ON Patients 
INSTEAD OF DELETE
AS
BEGIN
    INSERT INTO DeletedPatients (PatientId, Name, DOB, WardId)
    SELECT Id, Name, DOB, WardId FROM deleted;

    DELETE FROM Patients WHERE ID IN (SELECT Id FROM deleted);
END;
GO

-- Q43
CREATE OR ALTER PROCEDURE AddPatientWithAudit
@Name VARCHAR(100),
@DOB DATE,
@WardId INT
AS
    INSERT INTO Patients (Name, DOB, WardId) VALUES (@Name, @DOB, @WardId);
GO

EXEC AddPatientWithAudit @Name = 'Sara Ali', @DOB = '1998-04-10', @WardId = 1;
SELECT * FROM PatientAudit WHERE OperationType = 'INSERT';
GO

-- Q44
CREATE OR ALTER PROCEDURE UpdateConsultantSalaryAudited
@ConsultantId INT,
@NewSalary DECIMAL(10,2)
AS
    UPDATE Consultants
    SET Salary = @NewSalary
    WHERE Id = @ConsultantId;
GO

-- Q45
CREATE OR ALTER PROCEDURE DeletePatientArchived
@PatientId INT
AS
    DELETE FROM Patients
    WHERE Id = @PatientId;
GO