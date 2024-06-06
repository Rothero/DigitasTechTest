CREATE TABLE TB_Tasks (
    id int GENERATED ALWAYS AS identity
    ,"name" varchar(100) NOT null
    ,"description" varchar NOT null
    ,taskOwner varchar(100) Not null
    ,dateCreation timestamp NOT null
    ,dateLimit date NOT null
    ,dateConcluded date null
    ,idStatus int NOT null
);

CREATE TABLE TB_Status(
	id int GENERATED ALWAYS AS identity
  	,"description" varchar(100) NOT null
)


CREATE OR REPLACE function InsertTask(
name varchar,
description varchar,
taskOwner varchar,
dateLimit timestamp with time zone,
idStatus int
)
returns int
language plpgsql    
as $$
DECLARE idTask int;
begin
    INSERT into Tb_Tasks (name,description,taskOwner,dateCreation,dateLimit,dateConcluded,idStatus)
    VALUES
    	(name, description, taskOwner,(SELECT NOW()::TIMESTAMP), (SELECT dateLimit :: date), NULL, idStatus)
    returning id into idTask ;
   return idTask;
end;$$;



CREATE OR REPLACE function UpdateTask(
idTask int,
nameUpdated varchar,
descriptionUpdated varchar,
taskOwnerUpdated varchar,
dateLimitUpdated timestamp with time zone,
dateConcludedUpdated timestamp with time zone,
idStatusUpdated int
)
returns int
language plpgsql    
as $$
begin
   update tb_tasks 
    set 
    name = nameUpdated,
    description = descriptionUpdated,
    taskowner  = taskOwnerUpdated,
    datelimit = (select dateLimitUpdated :: date),
    dateconcluded  = (select dateConcludedUpdated :: date),
    idstatus = idStatusUpdated
    where id = idTask;
   
   return idTask;
end;$$;


CREATE OR REPLACE function DeleteTask(
idTask int
)
RETURNS int
language plpgsql    
as $$
DECLARE rowsDeleted int;
begin
	
	with deleted as
	(
   		Delete from tb_tasks 
   		where id = idTask
   		returning *
   	)  	
   	select count(*) from deleted into rowsDeleted;
   	
  RETURN rowsDeleted;
end;$$;



CREATE or replace function ReturnTask(
idTask int
)
returns table 
	(id int
   ,"name" varchar
   ,description varchar
   ,taskOwner varchar
   ,dateCreation timestamp
   ,dateLimit date
   ,dateConcluded date
   ,idStatus int
   ,isTaskOverdue bool)
   language plpgsql 
as $$
begin	
	
   return query 
   select tb_tasks.id
   ,tb_tasks."name"
   ,tb_tasks.description
   ,tb_tasks.taskOwner
   ,tb_tasks.dateCreation
   ,tb_tasks.dateLimit
   ,tb_tasks.dateConcluded
   ,tb_tasks.idStatus
   ,(case when tb_tasks.datelimit < NOW() :: date and tb_tasks.idstatus <> 3  then  true else false end) as isTaskOverdue
   from tb_tasks 
   where tb_tasks.id = idTask;
  
end;$$;

  CREATE or replace function ReturnAllTasks(
)
returns table 
	(id int
   ,"name" varchar
   ,description varchar
   ,taskOwner varchar
   ,dateCreation timestamp
   ,dateLimit date
   ,dateConcluded date
   ,idStatus int
   ,isTaskOverdue bool)
   language plpgsql 
as $$
begin	
	
   return query 
   select tb_tasks.id
   ,tb_tasks."name"
   ,tb_tasks.description
   ,tb_tasks.taskOwner
   ,tb_tasks.dateCreation
   ,tb_tasks.dateLimit
   ,tb_tasks.dateConcluded
   ,tb_tasks.idStatus
   ,(case when tb_tasks.datelimit < NOW() :: date and tb_tasks.idstatus <> 3  then  true else false end) as isTaskOverdue
   from tb_tasks;
  
end;$$;


CREATE OR REPLACE function VerifyDigitasTaskName(
taskName varchar
)
RETURNS int
language plpgsql    
as $$
DECLARE taskRows int;
begin

   select count(*) from tb_tasks where Upper(tb_tasks."name") = Upper(taskName) into taskRows;
   	
  RETURN taskRows;
end;$$;


