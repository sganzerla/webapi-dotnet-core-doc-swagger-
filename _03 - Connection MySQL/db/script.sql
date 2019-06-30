use swagger;
create table `persons` (
 `Id` int (10) unsigned null default null,
 `FirstName` varchar(50) null default null,
 `LastName` varchar(50) null default null,
 `Address` varchar(50) null default null,
 `Gender` varchar(50) null default null
)
engine=InnoDB;

use swagger;
alter table `persons` change Id Id int(10) auto_increment primary key;