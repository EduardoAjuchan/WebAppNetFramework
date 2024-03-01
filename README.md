# Proyecto de Gestión de Empleados

Este proyecto es una aplicación web desarrollada en .NET Framework 4.6.2 para la gestión de empleados. Utiliza una arquitectura de N Capas para una mejor organización y mantenimiento del código. A continuación, se proporciona una guía para comprender y utilizar la aplicación.

---

### Arquitectura de N Capas

La arquitectura de N Capas organiza el código en múltiples capas, cada una con una responsabilidad específica. En este proyecto, las capas son las siguientes:

1. **EmpleadoDataLayer**: Esta capa se encarga de las operaciones de acceso a la base de datos, como listar, crear, actualizar y eliminar registros. También gestiona la conexión a la base de datos mediante una clase que contiene la cadena de conexión SQL.

2. **EmpleadoEntityLayer**: Aquí se realiza el mapeo de las tablas de la base de datos a objetos de entidad en el código. Es donde se definen las clases de entidad con sus respectivos atributos y métodos.

3. **EmpleadosBusinessLayer**: La capa de lógica de negocio realiza llamadas a los métodos proporcionados por la capa de datos para ejecutar las funciones necesarias para el funcionamiento del proyecto.

4. **Empleado WebForm**: Esta capa contiene la interfaz de usuario de la aplicación. Aquí se define la parte frontal con JavaScript, HTML y CSS (Bootstrap). También se asignan las funciones a los elementos gráficos para que el usuario pueda interactuar con ellos.

---

### Tecnologías Utilizadas

- .NET Framework 4.6.2
- Microsoft SQL Server 2019
- JavaScript
- CSS (Bootstrap)
- HTML 5

---

### Funcionalidades Principales

1. **Inicio**: En la pantalla de inicio se muestran todos los empleados ingresados en la base de datos, junto con las opciones para crear un nuevo empleado, generar un reporte, editar o eliminar un empleado.

![Pantalla de Inicio](https://i.imgur.com/0tHDLYM.png)

2. **Crear Nuevo Empleado**: En este formulario se solicitan los datos del empleado, como nombre completo, departamento, sueldo, fecha de contrato y fecha de nacimiento. Por defecto, el estatus se establece como activo.

![Crear Nuevo Empleado](https://i.imgur.com/yTLuET1.png)

3. **Editar Empleado**: El formulario de edición es similar al de creación, pero los campos se llenan automáticamente con la información del empleado seleccionado. El usuario puede modificar los datos según sea necesario.

![Editar Empleado](https://i.imgur.com/pnB2I9J.png)

4. **Eliminar Empleado**: Al seleccionar un empleado y hacer clic en el botón eliminar, se mostrará una alerta solicitando confirmación. Una vez confirmada, el empleado será eliminado de la base de datos.

![Eliminar Empleado](https://i.imgur.com/jW2WNtt.png)

5. **Generar Reporte**: Al hacer clic en el botón "Reportes", se abrirá un modal donde se solicitarán dos fechas para definir un rango. Esta opción permite buscar empleados contratados en ese intervalo de tiempo.

![Crear un Reporte](https://i.imgur.com/UwJfTl1.png)

6. **Reporte de Empleados**: El reporte generado se mostrará en la misma tabla donde se muestran todos los empleados, pero esta vez solo se mostrarán los empleados que estén dentro del rango de fechas seleccionado por el usuario.

![Reporte de Empleados](https://i.imgur.com/bVihDAv.png)

---

### Contacto

Para más información o asistencia, no dude en ponerse en contacto:

- Correo Electrónico: eduardoajuchan@gmail.com
- LinkedIn: [Perfil de LinkedIn](https://www.linkedin.com/in/ajuchanedo/)

---
