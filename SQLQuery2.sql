

create function [dbo].[MaxSalary]
(
)
returns money
As
Begin
return(select Max(EmpSalary) from Employee)
End
GO
/****** Object:  Table [dbo].[Department]    Script Date: 19-07-2022 10:09:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DeptId] [int] IDENTITY(1,1) NOT NULL,
	[DeptName] [varchar](50) NOT NULL,
	[DeptLocation] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 19-07-2022 10:09:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmpId] [int] IDENTITY(1,1) NOT NULL,
	[DeptId] [int] NOT NULL,
	[EmpName] [varchar](50) NOT NULL,
	[EmpSalary] [money] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOGS]    Script Date: 19-07-2022 10:09:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOGS](
	[ACTIVITY] [varchar](20) NULL,
	[ACTIVITY_DATE] [datetime] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON 
GO
INSERT [dbo].[Department] ([DeptId], [DeptName], [DeptLocation]) VALUES (1, N'Designing', N'Hyderabad')
GO
INSERT [dbo].[Department] ([DeptId], [DeptName], [DeptLocation]) VALUES (2, N'Programming', N'Chennai')
GO
INSERT [dbo].[Department] ([DeptId], [DeptName], [DeptLocation]) VALUES (3, N'Testing', N'Mumbai')
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([EmpId], [DeptId], [EmpName], [EmpSalary]) VALUES (1, 1, N'Sathesh Kumar', 75000.0000)
GO
INSERT [dbo].[Employee] ([EmpId], [DeptId], [EmpName], [EmpSalary]) VALUES (2, 1, N'Rama', 35000.0000)
GO
INSERT [dbo].[Employee] ([EmpId], [DeptId], [EmpName], [EmpSalary]) VALUES (3, 2, N'Krishna', 65000.0000)
GO
INSERT [dbo].[Employee] ([EmpId], [DeptId], [EmpName], [EmpSalary]) VALUES (4, 2, N'Mohan', 55000.0000)
GO
INSERT [dbo].[Employee] ([EmpId], [DeptId], [EmpName], [EmpSalary]) VALUES (5, 3, N'Anil', 55000.0000)
GO
INSERT [dbo].[Employee] ([EmpId], [DeptId], [EmpName], [EmpSalary]) VALUES (6, 3, N'Suresh', 45800.0000)
GO
INSERT [dbo].[Employee] ([EmpId], [DeptId], [EmpName], [EmpSalary]) VALUES (7, 1, N'aaaa', 65000.0000)
GO
INSERT [dbo].[Employee] ([EmpId], [DeptId], [EmpName], [EmpSalary]) VALUES (8, 1, N'bbbb', 25500.0000)
GO
INSERT [dbo].[Employee] ([EmpId], [DeptId], [EmpName], [EmpSalary]) VALUES (9, 1, N'Krish', 25000.0000)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
INSERT [dbo].[LOGS] ([ACTIVITY], [ACTIVITY_DATE]) VALUES (N'DML TRIGGER FIRED', CAST(N'2022-07-14T12:51:32.927' AS DateTime))
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DeptId])
REFERENCES [dbo].[Department] ([DeptId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
/****** Object:  StoredProcedure [dbo].[AddEmployee]    Script Date: 19-07-2022 10:09:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AddEmployee]
(
@empName varchar(100),
@empSalary money
)
As 
Begin

	insert into Employee values(@empName, @empSalary);

End
GO
/****** Object:  StoredProcedure [dbo].[DeptDetails]    Script Date: 19-07-2022 10:09:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[DeptDetails]
(
@deptId int,
@deptName varchar(50) output,
@deptLocation varchar(50) output
)
As
Begin

select @deptName=DeptName, @deptLocation=DeptLocation from Department where DeptId=@deptId

End
GO
/****** Object:  StoredProcedure [dbo].[GetAllEmployees]    Script Date: 19-07-2022 10:09:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[GetAllEmployees]
 
As 
Begin
select * from Employee
End


/*
exec GetAllEmployees
*/
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeesByDept]    Script Date: 19-07-2022 10:09:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 create proc [dbo].[GetEmployeesByDept]
 (
 @DeptId int=null
 )
 As 
 Begin

select e.EmpId,e.EmpName,e.EmpSalary, e.DeptId, d.DeptName,d.DeptLocation from Employee e
JOIN Department d on e.DeptId=d.DeptId
where (e.DeptId=@DeptId or @DeptId is null)
end
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeesByDeptId]    Script Date: 19-07-2022 10:09:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* 
exec GetEmployeesByDeptId 2
*/

CREATE proc [dbo].[GetEmployeesByDeptId]
(
@deptId int=null
)
as
begin

declare @MaxValue int;
set @MaxValue=(select MAX(EmpSalary) as MaxSalary from Employee);

select  @MaxValue as MaxValue


select * into #t from Employee
select * into #t1 from Department

select t.EmpId, t.EmpName, t.EmpSalary, t.DeptId, t1.DeptName, t1.DeptLocation from #t t
JOIN #t1 t1 on t.DeptId=t1.DeptId
where (t.DeptId=@deptId or @deptId is null)

drop table #t
drop table #t1

end


