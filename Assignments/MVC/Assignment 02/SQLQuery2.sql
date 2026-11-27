SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Plans';

INSERT INTO Plans (Name, Description, DurationDays, Price, IsActive)
VALUES
('Basic', 'Basic gym access for one month', 30, 300, 1),
('Standard', 'Full gym access for three months', 90, 750, 1),
('Premium', 'Full gym access for one year', 365, 2500, 1),
('Family', 'Gym access for six months', 180, 1400, 1);

DELETE FROM Plans
WHERE Name IN ('Basic', 'Standard', 'Premium', 'Family');

INSERT INTO Plans (Name, Description, DurationDays, Price, IsActive)
VALUES
('Basic', 'Basic gym access for one month', 30, 300, 1),
('Standard', 'Full gym access for three months', 90, 750, 1),
('Premium', 'Full gym access for one year', 365, 2500, 1),
('Family', 'Gym access for six months', 180, 1400, 1);