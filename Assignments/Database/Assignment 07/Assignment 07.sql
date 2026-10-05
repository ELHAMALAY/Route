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
