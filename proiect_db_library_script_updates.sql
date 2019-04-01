
update books set title = 'Constelatia fenomenelor vitale' where bookid = 1;

update books set title = 'Toata lumina pe care nu o putem vedea' where bookid = 2;

update books set title = 'Singuratatea numerelor prime' where bookid = 3;

update authors set FirstName = 'Anthony', LastName = 'Marra', BirthDate = CONVERT(DATETIME, '1-JAN-1984')  where authorid = 1;

update authors set FirstName = 'Anthony', LastName = 'Doerr', BirthDate = CONVERT(DATETIME, '27-OCT-1973')  where authorid = 2;

update authors set FirstName = 'Paolo', LastName = 'Giordano', BirthDate = CONVERT(DATETIME, '19-DEC-1982')  where authorid = 3;

alter table members add [Password] varchar(100);

update members set [Password] = 'start123';
