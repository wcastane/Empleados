use [CE_Planning]
go

if object_Id('dbo.Personas') > 0
   drop table [dbo].[Personas]
go

create table [dbo].[Personas](
	[PersonaId] nvarchar(10) not null,
	[Nombre] nvarchar(10) not null,
	[Apellido] nvarchar(20) not null
) on [PRIMARY]
go

if object_Id('dbo.EmpleadosInternos') > 0
   drop table [dbo].[EmpleadosInternos]
go

create table [dbo].[EmpleadosInternos](
	[PersonaId] [nvarchar](10) not null,
	[Nomina] [nvarchar](10) null
) 
go

if object_Id('dbo.EmpleadosInternos') > 0
   drop table [dbo].[EmpleadosExternos]
go

create table [dbo].[EmpleadosExternos](
	[PersonaId] [nvarchar](10) NOT NULL,
	[NombreEmpresa] [nvarchar](10) NULL
) 
go

select * from dbo.Personas
select * from dbo.EmpleadosInternos
select * from dbo.EmpleadosExternos