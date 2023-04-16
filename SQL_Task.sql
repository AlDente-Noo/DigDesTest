--1. Сотрудника с максимальной заработной платой.
sELECT name FROM employee WHERE salary = (SELECT MAX(salary) FROM employee);

--2. Вывести одно число: максимальную длину цепочки руководителей по таблице сотрудников (вычислить глубину дерева).
WITH RECURSIVE cte AS (
   SELECT 1 AS depth, chief_id, id
   FROM employee
   WHERE chief_id IS NULL
   UNION ALL
   SELECT depth + 1, employee.chief_id, employee.id
   FROM employee
   JOIN cte
     ON employee.chief_id = cte.Id
)
SELECT MAX(depth) AS max_chief_depth
FROM cte;

--3. Отдел, с максимальной суммарной зарплатой сотрудников. 
WITH dep_salary AS (
  SELECT department.name, SUM(salary) AS total_salary
  FROM employee
  JOIN department ON department.ID = employee.department_ID
  GROUP BY department.name
)
SELECT name FROM dep_salary WHERE dep_salary.total_salary = (SELECT MAX(total_salary) FROM dep_salary);

--4. Сотрудника, чье имя начинается на «Р» и заканчивается на «н».
SELECT name FROM employee WHERE name LIKE 'Р%н'