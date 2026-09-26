USE Hospital;
GO

SELECT DB_NAME();

-- Q1
SELECT 
	P.Name AS PatientName,
	W.Name AS WardName
FROM 
	Patients P INNER JOIN Wards W
ON p.WardId = w.Id;

-- Q2
SELECT
	p.Name AS PatientName,
	d.DrugCode
FROM 
	Patients P INNER JOIN DrugAdministrations D
ON p.Id = d.PatientId;

-- Q3
SELECT 
	p.Name AS PatientName,
	C.Name AS ConsultantsName
FROM
	Patients P INNER JOIN PatientExaminations PE
	ON P.Id = PE.PatientId
	INNER JOIN Consultants C
	ON PE.ConsultantId = C.Id;

-- Q4
SELECT 
	P.Name AS PatientName,
	W.Name AS WardName
FROM 
	Patients P LEFT JOIN Wards W
ON p.WardId = w.Id;

-- Q5
SELECT 
	P.Name AS PatientName,
	W.Name AS WardName
FROM 
	Patients P RIGHT JOIN Wards W
ON p.WardId = w.Id;

-- Q6
SELECT 
	p.Name AS PatientName,
	C.Name AS ConsultantsName
FROM
	Patients P RIGHT JOIN PatientExaminations PE
	ON P.Id = PE.PatientId
	RIGHT JOIN Consultants C
	ON PE.ConsultantId = C.Id;

-- Q7
SELECT 
	P.Name AS PatientName,
	W.Name AS WardName
FROM 
	Patients P LEFT JOIN Wards W
ON p.WardId = w.Id;

-- Q8
SELECT 
	p.Name AS PatientName,
	C.Name AS ConsultantsName
FROM
	Patients P LEFT JOIN PatientExaminations PE
	ON P.Id = PE.PatientId
	LEFT JOIN Consultants C
	ON PE.ConsultantId = C.Id;

-- Q9
SELECT 
	p.Name AS PatientName,
	W.Name AS WardName
FROM 
	Patients P FULL OUTER JOIN Wards W
ON p.WardId = w.Id;

-- Q10
SELECT 
	p.Name AS PatientName,
	C.Name AS ConsultantsName
FROM
	Patients P FULL OUTER JOIN PatientExaminations PE
	ON P.Id = PE.PatientId
	FULL OUTER JOIN Consultants C
	ON PE.ConsultantId = C.Id;

-- Q11
SELECT 
	n.Name AS NurseName,
	m.Name AS ManagerName
FROM 
	Nurses n LEFT JOIN Nurses m
ON n.ManagerId = m.Number;

-- Q12
SELECT 
	n.Name AS NurseName,
	m.Name AS ManagerName
FROM 
	Nurses n INNER JOIN Nurses m
ON n.ManagerId = m.Number;

-- Q13
SELECT 
	n.Name AS ManagerName,
	m.Name AS NurseName
FROM 
	Nurses m LEFT JOIN Nurses n
ON  m.Number = n.ManagerId;

-- Q14
SELECT
    p.Name AS PatientName,
    c.Name AS ConsultantName
FROM Patients p
CROSS JOIN Consultants c;

-- Q15
SELECT 
	w.Name AS WardName,
    c.Name AS ConsultantName
FROM 
	Wards w CROSS JOIN Consultants c

-- Q16
SELECT 
	p.Name AS PatientName,
	w.Name AS WardName,
    c.Name AS ConsultantName
FROM 
	Patients p
INNER JOIN Wards w
	ON p.WardId = w.Id
INNER JOIN PatientExaminations PE
	ON p.Id = PE.PatientId
INNER JOIN Consultants c
	ON PE.ConsultantId = c.Id;

-- Q17
SELECT
    p.Name AS PatientName,
    n.Name AS NurseName,
	d.DrugCode
FROM Patients p
INNER JOIN DrugAdministrations D
	ON p.Id = d.PatientId
INNER JOIN Nurses n
	ON d.NurseId = n.Number;

-- Q18
SELECT
    p.Name AS PatientName,
    n.Name AS NurseName,
	W.Name AS WardName,
	da.Dosage
FROM Patients p
INNER JOIN DrugAdministrations DA
	ON p.Id = da.PatientId
INNER JOIN Nurses n
	ON da.NurseId = n.Number
INNER JOIN Wards w
	ON p.WardId = w.Id;

-- Q19
SELECT
    p.Name AS PatientName,
    c.Name AS ConsultantName,
	w.Name AS WardName
FROM Patients p
INNER JOIN wards w
	ON p.WardId = w.Id
INNER JOIN PatientExaminations PE
	ON p.Id = PE.PatientId
INNER JOIN Consultants c
	ON PE.ConsultantId = c.Id;

-- Q20
SELECT
    p.Name AS PatientName,
	n.Name AS NurseName,
	DA.DrugCode,
	DA.Dosage,
	DA.Date AS AdministrationDate,
	DA.Time AS AdministrationTime
FROM Patients p
INNER JOIN DrugAdministrations DA
	ON p.Id = DA.PatientId
INNER JOIN Nurses n
	ON DA.NurseId = n.Number;

-- Q21
SELECT 
	Id,
	Name,
	Salary,
	Row_Number() OVER (ORDER BY Salary DESC) AS RowNum
FROM Consultants;

-- Q22
SELECT 
	Id,
	Name,
	Salary,
	Row_Number() OVER (ORDER BY Salary ASC) AS RowNum
FROM Consultants;

-- Q23
SELECT 
	Id,
	Name,
	Salary,
	Row_Number() OVER (ORDER BY Salary, Name) AS RowNum
FROM Consultants;

-- Q24
SELECT 
	Id,
	Name,
	Salary,
	RANK() OVER (ORDER BY Salary DESC) AS RowNum
FROM Consultants;

-- Q25
SELECT 
	Id,
	Name,
	Salary,
	RANK() OVER (ORDER BY Salary ASC) AS RowNum
FROM Consultants;

-- Q26
SELECT
    Name, Salary,
    RANK() OVER (ORDER BY Salary DESC) AS SalaryRank
FROM Consultants
ORDER BY Salary DESC;

-- Q27
SELECT
    Id, Name, Salary,
    DENSE_RANK() OVER (ORDER BY Salary DESC) AS SalaryDenseRank
FROM Consultants;

-- Q28
SELECT 
	Name, Salary,
    DENSE_RANK() OVER (ORDER BY Salary DESC) AS SalaryDenseRank
FROM Consultants
ORDER BY Salary DESC;

-- Q29
SELECT
	name, salary,
	RANK()		 OVER (ORDER BY salary DESC) AS rank,
	DENSE_RANK() OVER (ORDER BY salary DESC) AS dense_rank
FROM Consultants;

-- Q30
SELECT
    Id, Name, Salary,
    NTILE(2) OVER (ORDER BY Salary DESC) AS SalaryGroup
FROM Consultants;

-- Q31
SELECT
    Id, Name, Salary,
    NTILE(3) OVER (ORDER BY Salary DESC) AS SalaryGroup
FROM Consultants;

-- Q32
SELECT
    Id, Name, Salary,
    NTILE(4) OVER (ORDER BY Salary DESC) AS SalaryGroup
FROM Consultants
ORDER BY SalaryGroup;

-- Q33
SELECT
	N.Number,
	N.Name,
	N.Salary,
	N.ServesInWardId,
	RANK() OVER (PARTITION BY N.ServesInWardId ORDER BY N.Salary DESC) AS WardSalaryRank
FROM Nurses N;

-- Q34
SELECT
    N.Number,
	N.Name,
	N.Salary,
	N.ServesInWardId,
    ROW_NUMBER() OVER (PARTITION BY N.ServesInWardId ORDER BY N.Salary DESC) AS WardRowNum
FROM Nurses N;

-- Q35
SELECT
    N.Number,
	N.Name,
	N.Salary,
	N.ServesInWardId,
    DENSE_RANK() OVER (PARTITION BY N.ServesInWardId ORDER BY N.Salary DESC) AS WardDenseRank
FROM Nurses N;

-- Q36
SELECT
    N.Number,
	N.Name,
	N.Salary,
	N.ServesInWardId,
    NTILE(2) OVER (PARTITION BY N.ServesInWardId ORDER BY N.Salary DESC) AS WardSalaryGroup
FROM Nurses N;

-- Q37
SELECT
    N.Name       AS NurseName,
    W.Name       AS WardName,
    RANK() OVER (PARTITION BY N.ServesInWardId ORDER BY N.Salary DESC) AS WardSalaryRank
FROM Nurses N
JOIN Wards W ON N.ServesInWardId = W.Id;