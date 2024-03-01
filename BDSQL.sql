create database PERFILESSAA
use PERFILESSAA
/*Creamos las tablas necesarias*/

create table Departamento(
IdDepartamento int primary key identity,
Nombre varchar(50),
Descripcion varchar (150)
)

go
 create table Empleado(
 IdEmpleado int primary key identity,
 NombreCompleto varchar(50),
 IdDepartamento int references Departamento(IdDepartamento),
 Sueldo decimal(10,2),
 FechaContrato date,
 FechaNacimiento date,
 Edad int
 )
 ALTER TABLE Empleado
ADD Estatus varchar(20) NOT NULL DEFAULT 'Activo'

/*Insertamos datos para pruebas*/
INSERT INTO Departamento (Nombre, Descripcion) VALUES
('Créditos y Cobros', 'Departamento encargado de gestionar las cuentas por cobrar y los créditos de la empresa.'),
('Publicidad e Imagen Corporativa', 'Encargado de desarrollar estrategias de publicidad y mantener la imagen corporativa de la empresa.'),
('Gerencia General', 'Departamento encargado de la dirección y supervisión general de la empresa.'),
('Finanzas', 'Responsable de la gestión financiera y contable de la empresa.'),
('Mercadeo', 'Encargado de desarrollar estrategias de mercadeo para promocionar los productos o servicios de la empresa.'),
('Contabilidad', 'Responsable del registro y control de las operaciones contables de la empresa.'),
('Negocios', 'Encargado de identificar y desarrollar oportunidades de negocios para la empresa.'),
('Administración', 'Responsable de la gestión administrativa y operativa de la empresa.'),
('Informática', 'Departamento encargado del desarrollo y mantenimiento de sistemas de información y tecnología.'),
('Corporativo', 'Encargado de las actividades corporativas y de coordinar las operaciones entre distintas áreas de la empresa.'),
('Riesgos', 'Responsable de identificar y gestionar los riesgos a los que está expuesta la empresa.'),
('Ventas', 'Encargado de la comercialización y venta de productos o servicios de la empresa.');

INSERT INTO Empleado (NombreCompleto, IdDepartamento, Sueldo, FechaContrato, FechaNacimiento, Edad, Estatus) VALUES
('Juan Pérez', 1, 2500.00, '2022-01-15', '1988-05-10', 36, 'Activo'),
('María García', 2, 2800.00, '2021-11-20', '1990-09-22', 31, 'Activo'),
('Luis Martínez', 3, 3200.00, '2022-03-05', '1985-03-15', 37, 'Activo'),
('Ana Rodríguez', 4, 3000.00, '2022-02-10', '1995-07-08', 26, 'Activo'),
('Pedro Sánchez', 5, 2700.00, '2021-12-03', '1983-12-20', 38, 'Activo'),
('Laura López', 6, 2900.00, '2021-10-18', '1992-04-30', 29, 'Activo'),
('Carlos Hernández', 7, 3100.00, '2022-04-22', '1987-11-25', 34, 'Activo'),
('Sofía Díaz', 8, 3300.00, '2022-01-30', '1993-08-12', 28, 'Activo'),
('Jorge Ramírez', 9, 2800.00, '2021-09-08', '1991-06-05', 30, 'Activo'),
('Isabel Torres', 10, 3000.00, '2021-08-14', '1989-02-18', 32, 'Activo');

/*CREAMOS FUNCIONES PARA LA BD*/

/*ESTE NOS HACE UN SELECT PARA DARNOS LA INFO DE LOS DEPARTAMENTOS O AREAS*/
create function fn_departamentos()
returns table
as
return
	select IdDepartamento,Nombre, Descripcion from Departamento

go

/*CON ESTE TRAEMOS LOS DATOS DE LOS EMPLEADOS PARA LISTARLOS Y DAMOS ESTILO 103 A LAS FECHAS*/
create function fn_empleados()
returns table
as
return
(
	select e.IdEmpleado, e.NombreCompleto,
		e.IdDepartamento, d.Nombre as NombreDepartamento,
		e.Sueldo, convert(char(10), e.FechaContrato, 103) as FechaContrato,
		convert(char(10), e.FechaNacimiento, 103) as FechaNacimiento,
		e.Edad, e.Estatus
	from Empleado e
	inner join Departamento d on d.IdDepartamento = e.IdDepartamento
)

go

/*OBTENEMOS LOS DATOS DE UN EMPLEADO MEDIANTE SU ID (PK)*/
create function fn_empleadoos(@idEmpleado int)
returns table
as
return
(
	select e.IdEmpleado, e.NombreCompleto,
		e.IdDepartamento, d.Nombre as NombreDepartamento,
		e.Sueldo, e.FechaContrato as FechaContrato,
		e.FechaNacimiento as FechaNacimiento,
		e.Edad, e.Estatus
	from Empleado e
	inner join Departamento d on d.IdDepartamento = e.IdDepartamento
	where e.IdEmpleado = @idEmpleado
)

/*AQUI CREAMOS UN NUEVO EMPLEADO*/
create procedure sp_CrearEmpleadoos(
    @NombreCompleto varchar(50),
    @IdDepartamento int,
    @Sueldo decimal(10,2),
    @FechaContrato date, -- Cambiado a date
    @FechaNacimiento date,
    @Edad int,
    @Estatus varchar(20) = 'Activo'
)
as
begin
    set dateformat dmy
    insert into Empleado (NombreCompleto, IdDepartamento, Sueldo, FechaContrato, FechaNacimiento, Edad, Estatus)
    values (@NombreCompleto, @IdDepartamento, @Sueldo, @FechaContrato, @FechaNacimiento, @Edad, @Estatus)
end

/*LO UTILIZAMOS PARA EDITAR LA INFORMACIÓN DE UN EMPLEADO*/
create procedure sp_EditarEmpleadooss(
    @IdEmpleado int,
    @NombreCompleto varchar(50),
    @IdDepartamento int,
    @Sueldo decimal(10,2),
    @FechaContrato date,
    @FechaNacimiento date,
    @Edad int,
    @Estatus varchar(20)
)
as
begin
    set dateformat dmy
    update Empleado set
        NombreCompleto = @NombreCompleto,
        IdDepartamento = @IdDepartamento,
        Sueldo = @Sueldo,
        FechaContrato = @FechaContrato,
        FechaNacimiento = @FechaNacimiento,
        Edad = @Edad,
        Estatus = @Estatus
    where IdEmpleado = @IdEmpleado
end
go
/*ELIMINAMOS UN EMPLEADO POR SU ID*/
create procedure sp_EliminarEmpleado(
@IdEmpleado int
)
as
begin
	delete from Empleado where IdEmpleado = @IdEmpleado
end

select * from fn_empleados

SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Empleado' 
AND COLUMN_NAME IN ('FechaContrato', 'FechaNacimiento');

/*IMPORTANTE: CON ESTA FUNCION REALIZAMOS EL REPORTE POR RANGO DE FECHAS, DE ESTA MANERA OBTENEMOS
TODOS LOS DATOS QUE ESTEN EN EL RANGO DE FECHAS DEFINIDAS POR EL USUARIO*/
CREATE FUNCTION fn_empleados_por_fecha_contratacion(
    @FechaInicio date,
    @FechaFin date
)
RETURNS TABLE
AS
RETURN
(
    SELECT e.IdEmpleado, e.NombreCompleto,
        e.IdDepartamento, d.Nombre as NombreDepartamento,
        e.Sueldo, CONVERT(char(10), e.FechaContrato, 103) as FechaContrato,
        CONVERT(char(10), e.FechaNacimiento, 103) as FechaNacimiento,
        e.Edad, e.Estatus
    FROM Empleado e
    INNER JOIN Departamento d ON d.IdDepartamento = e.IdDepartamento
    WHERE e.FechaContrato BETWEEN @FechaInicio AND @FechaFin
)
