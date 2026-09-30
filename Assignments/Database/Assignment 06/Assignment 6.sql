USE Hospital
GO

-- Q1
SELECT
	w.Name,
	COUNT(p.Id) AS PatientCount
FROM Patients p
LEFT JOIN Wards w
ON p.WardId = w.Id
GROUP BY w.Name;

-- Q2
SELECT 
	AVG(Salary) AS AvgConsultantSalary
FROM Consultants

-- Q3
SELECT 
    MIN(Salary) AS MinSalary,
    MAX(Salary) AS MaxSalary,
    AVG(Salary) AS AvgSalary,
    SUM(Salary) AS TotalSalary
FROM Consultants;

-- Q4
SELECT
	w.Name,
	COUNT(p.Id) AS PatientCount
FROM Patients p
LEFT JOIN Wards w
ON p.WardId = w.Id
GROUP BY w.Name
ORDER BY PatientCount DESC;

-- Q5
SELECT 
	p.Name,
	p.Id,
	SUM(DA.Quantity) AS TotalQuantity
FROM Patients p
LEFT JOIN DrugAdministrations DA
ON p.Id = DA.PatientId
GROUP BY p.Name , p.Id;


-- Q6
SELECT 
	p.Name,
	p.Id,
	COUNT(*) AS TotalQuantity
FROM Patients p
LEFT JOIN DrugAdministrations DA
ON p.Id = DA.PatientId
GROUP BY p.Name , p.Id;

-- Q7
SELECT
	w.Id,
	w.Name,
	COUNT(p.Id)
FROM Wards W
LEFT JOIN Patients P
ON w.Id = p.WardId
GROUP BY w.Id, w.Name;


-- Q8
SELECT
	w.Id AS WardId,
	w.Name AS WardName,
	AVG(Salary) AS AvgNurseSalary
FROM Wards w
LEFT JOIN Nurses n
ON n.ServesInWardId = w.Id
GROUP BY w.Id, w.Name;

-- Q9
SELECT
	w.Id AS WardId,
	w.Name AS WardName,
	COUNT(*) AS test
FROM Wards w
FULL JOIN Patients p
ON p.WardId = w.Id
GROUP BY w.Id, w.Name
HAVING COUNT(*) > 3;

-- Q10
SELECT 
    p.Id,
    p.Name,
    COUNT(DA.PatientId) AS AdministrationCount
FROM Patients p
INNER JOIN DrugAdministrations DA 
ON p.Id = DA.PatientId
GROUP BY p.Id, p.Name
HAVING COUNT(DA.PatientId) > 5;

-- Q11
SELECT *
FROM Consultants
Where Salary > (SELECT AVG(Salary) FROM Consultants)

-- Q12
SELECT *
FROM Nurses
Where Salary > (SELECT AVG(Salary) FROM Nurses)

-- Q13
SELECT *
FROM Patients
WHERE WardId IN (
    SELECT 
		TOP (1) WITH TIES WardId
    FROM Patients
    GROUP BY WardId
    ORDER BY COUNT(*) DESC
);

-- Q14
SELECT *
FROM Consultants
WHERE Salary IN
(
	SELECT 
		TOP (1) WITH TIES Salary
	FROM Consultants
	GROUP BY Salary
	ORDER BY Salary DESC
);

-- Q15
SELECT *
FROM Patients P
WHERE EXISTS 
(
	SELECT 
		1
	FROM DrugAdministrations DA
	WHERE DA.PatientId = P.Id
);

-- Q16
SELECT *
FROM Patients P
WHERE NOT EXISTS 
(
	SELECT 
		1
	FROM DrugAdministrations DA
	WHERE DA.PatientId = P.Id
);

-- Q17
SELECT 
	p.Name,
	p.Id,
	COUNT(da.PatientId) AS AdministrationCount
FROM Patients p
LEFT JOIN DrugAdministrations DA
ON p.Id = DA.PatientId
GROUP BY p.Name , p.Id;

-- Q18
SELECT 
	p.Name,
	p.Id,
	SUM(DA.Quantity) AS TotalQuantity
FROM Patients p
LEFT JOIN DrugAdministrations DA
ON p.Id = DA.PatientId
GROUP BY p.Name , p.Id;

-- Q19
SELECT
	C.Id,
    C.Name,
    C.Salary,
	T.AvgSalary
FROM Consultants C
CROSS JOIN 
(
	SELECT
		AVG(Salary) AS AvgSalary
	FROM Consultants 
) AS T
WHERE C.Salary > T.AvgSalary;

-- Q20

-- Q21
DROP TABLE IF EXISTS PatientBackup;
SELECT * INTO PatientBackup
FROM Patients

-- Q22
DROP TABLE IF EXISTS PatientBasicInfo;
SELECT id, Name, DOB INTO PatientBasicInfo
FROM Patients

-- Q23
DROP TABLE IF EXISTS ConsultantSalaryReport;
SELECT Id, Name, Salary INTO ConsultantSalaryReport 
FROM Consultants;

-- Q24
DROP TABLE IF EXISTS PatientWardReport;
SELECT 
	p.Id AS PatientId,
	p.Name AS PatientName,
	P.DOB,
	w.Id AS WardId,
	w.Name AS WardName
	INTO PatientWardReport
FROM Patients P
LEFT JOIN Wards W
ON p.WardId = w.Id

-- Q25
DROP TABLE IF EXISTS dbo.PatientConsultantReport;
SELECT
	P.Id AS PatientId,
	P.Name AS PatientName,
	C.Id AS ConsultantId,
	C.Name AS ConsultantName
	INTO dbo.PatientConsultantReport
FROM Patients P
INNER JOIN PatientConsultantAssignments PCA
ON p.Id = PCA.PatientId
INNER JOIN Consultants C
ON PCA.ConsultantId = C.Id

-- Q26
DROP TABLE IF EXISTS HighSalaryConsultants
SELECT * INTO HighSalaryConsultants
FROM Consultants
WHERE Salary > 50000

-- Q27
DROP TABLE IF EXISTS YoungPatients;
SELECT * INTO YoungPatients
FROM Patients
WHERE DOB > '2000-01-01';

-- Q28
DROP TABLE IF EXISTS HighSalaryNurseReport;
SELECT 
	n.Number AS NurseNumber,
	n.Name AS NurseName,
	n.Salary,
    w.Id AS WardId,
	w.Name AS WardName
INTO HighSalaryNurseReport
FROM Nurses N
INNER JOIN Wards W 
ON w.Id = n.ServesInWardId
WHERE n.Salary > 30000;

-- Q29
DROP TABLE IF EXISTS WardPatientSummary;
SELECT 
	w.Id AS WardId,
	w.Name AS WardName,
	COUNT(p.Id) AS PatientCount
	INTO WardPatientSummary
FROM Wards W
LEFT JOIN Patients P
ON w.Id = p.WardId
GROUP BY w.Id, w.Name

-- Q30
DROP TABLE IF EXISTS PatientMedicationSummary;
SELECT 
	p.Id AS PatientId,
		p.Name AS PatientName,
       SUM(da.Quantity) AS TotalQuantity
	   INTO PatientMedicationSummary
FROM Patients p
LEFT JOIN DrugAdministrations da
ON da.PatientId = p.Id
GROUP BY p.Id, p.Name;

-- Q31
GO
CREATE OR ALTER FUNCTION dbo.CalculatePatientAge (@DOB DATE)
RETURNS INT
AS
BEGIN
	RETURN DATEDIFF(YEAR, @DOB, GETDATE())
		- CASE WHEN DATEADD(YEAR, DATEDIFF(YEAR, @DOB, GETDATE()), @DOB) > CAST(GETDATE() AS DATE)
			THEN 1 ELSE 0 END;
END;
GO

SELECT 
	NAME,
	DOB,
	dbo.CalculatePatientAge(DOB) AS Age
FROM Patients;

-- Q32
GO
CREATE OR ALTER FUNCTION dbo.CalculateAnnualSalary (@MonthlySalary DECIMAL(18,2))
RETURNS DECIMAL(18,2)
AS
BEGIN
	RETURN @MonthlySalary * 12;
END;
GO

-- Q33
GO
CREATE OR ALTER FUNCTION dbo.CalculateMedicationCost (@Quantity INT, @UnitPrice DECIMAL(18,2))
RETURNS DECIMAL(18,2)
AS
BEGIN
    RETURN @Quantity * @UnitPrice;
END;
GO

-- Q34
GO
CREATE OR ALTER FUNCTION dbo.GetPatientsByWard (@WardId INT)
RETURNS TABLE
AS
RETURN
(
SELECT
	Id, Name, DOB, WardId
	FROM dbo.Patients
	WHERE WardId = @WardId
);
GO

-- Q35
GO
CREATE OR ALTER FUNCTION dbo.GetConsultantsByMinimumSalary (@MinSalary DECIMAL(18,2))
RETURNS TABLE
AS
RETURN
(
    SELECT Id, Name, Salary
    FROM dbo.Consultants
    WHERE Salary >= @MinSalary
);
GO

-- Q36
GO
CREATE OR ALTER FUNCTION dbo.GetPatientsWithWard (@WardId INT)
RETURNS TABLE
AS
RETURN
(
    SELECT p.Id, p.Name, p.DOB, p.WardId, w.Name AS WardName
    FROM dbo.Patients AS p
    JOIN dbo.Wards AS w ON w.Id = p.WardId
    WHERE p.WardId = @WardId
);
GO

-- Q37
GO
CREATE OR ALTER FUNCTION dbo.GetPatientsWithAge (@MinAge INT)
RETURNS @Result TABLE
(
	Id		INT,
	Name	NVARCHAR(200),
	DOB		DATE,
	WardId	INT,
	Age		INT
)
AS
BEGIN
	INSERT INTO @Result (Id, Name, DOB, WardId, Age)
	SELECT
		Id,
		Name,
		DOB,
		WardId,
		dbo.CalculatePatientAge(DOB)
	FROM Patients
	WHERE dbo.CalculatePatientAge(DOB) >= @MinAge;

	RETURN;
END;
GO

-- Q38
GO
CREATE OR ALTER FUNCTION dbo.GetPatientMedicationSummary (@PatiendId INT)
RETURNS @Result TABLE
(
	PatientId				INT,
	Name					NVARCHAR(200),
	TotalQuantity			INT,
	AdministrationCount		INT
)
AS
BEGIN
	INSERT INTO @Result (PatientId, Name, TotalQuantity, AdministrationCount)
	SELECT
		@PatiendId,
		p.Name,
		SUM(da.Quantity),
		COUNT(*)
	FROM Patients p
	INNER JOIN DrugAdministrations DA
	ON p.Id = da.PatientId
	WHERE p.Id = @PatiendId
	GROUP BY p.Name;

	RETURN;
END;
GO

-- Q39
GO
CREATE OR ALTER FUNCTION dbo.GetConsultantsWithSalaryClass(@MinSalary DECIMAL(18,2))
RETURNS @Result TABLE
(
	Id				INT,
	Name			NVARCHAR(200),
	Salary			INT,
	SalaryClass		VARCHAR(10)
)
AS
BEGIN
	INSERT INTO @Result (Id, Name, Salary, SalaryClass)
		SELECT
			ID,
			Name,
			Salary,
			 CASE
				WHEN Salary >= 20000 THEN 'High'
				WHEN Salary >= 10000 THEN 'Medium'
				ELSE  'LOW'
				END
		FROM Consultants
		WHERE salary >= @MinSalary

		RETURN;
END;
GO

-- Q40
SELECT 
	p.Id						 AS PatientId,
	p.Name,
    COUNT(da.PatientId)          AS AdministrationCount,
    SUM(da.Quantity)			 AS TotalQuantity,
	AVG(da.Quantity)             AS AvgQuantity
FROM Patients p
LEFT JOIN DrugAdministrations DA 
ON da.PatientId = p.Id
GROUP BY p.Id, p.Name;

-- Q41
WITH WardCounts AS
(
	SELECT 
		w.Id			AS WardId,
		w.Name			AS WardName,
		COUNT(p.Id)		AS PatientCount
	FROM Wards w
	LEFT JOIN Patients p
	ON p.WardId = w.Id
	GROUP BY w.Id, w.Name
)
SELECT *
FROM WardCounts
WHERE PatientCount > (SELECT AVG(PatientCount) FROM WardCounts);

-- Q42
DROP TABLE IF EXISTS HighActivityPatients;
SELECT
	P.Id,
	P.Name,
	COUNT(*) AS AdministrationCount
	INTO HighActivityPatients
FROM Patients P
INNER JOIN DrugAdministrations DA
ON P.Id = DA.NurseId
GROUP BY P.Id, P.Name
HAVING COUNT(*) > 5;

-- Q43
DROP TABLE IF EXISTS dbo.ConsultantAnnualSalaryReport;
SELECT
	Name,
	Salary	AS MonthlySalary,
	dbo.CalculateAnnualSalary(Salary)	AS AnnualSalary
	INTO dbo.ConsultantAnnualSalaryReport
FROM Consultants

-- Q44
SELECT *
FROM dbo.GetConsultantsByMinimumSalary(50000)
WHERE NAME LIKE 'A%';

-- Q45
SELECT *
FROM dbo.GetPatientsWithAge(30)
ORDER BY Age DESC;

-- Q46
SELECT 
	p.Id							AS PatientId,
	p.Name							AS PatientName,
	w.Name							AS WardName,
	dbo.CalculatePatientAge(DOB)	AS Age, 
	COUNT(da.PatientId)				AS MedicationCount,
	SUM(da.Quantity)				AS TotalQuantity
FROM Patients p
LEFT JOIN Wards w
ON p.WardId = w.Id
LEFT JOIN DrugAdministrations DA
ON p.Id = da.PatientId
GROUP BY p.Id, p.Name, w.Name, p.DOB;

