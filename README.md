
# Guía para Ejecutar el Proyecto en .NET Core 8 con MySQL

Este documento proporciona las instrucciones necesarias para configurar y ejecutar un proyecto .NET Core 8 utilizando **MySQL** como base de datos con **migraciones**.

---

## 📋 Requisitos Previos

- **.NET SDK 8.0**: Asegúrate de tener la versión adecuada instalada. Puedes verificarla ejecutando:

  ```bash
  dotnet --version
  ```

- **MySQL**: Puedes instalarlo utilizando **XAMPP** o **WAMP**.
- **Git**: Necesario para clonar el repositorio del proyecto.

---

## ⚙️ Configuración de la Base de Datos

1. **Iniciar XAMPP o WAMP**:
   - Asegúrate de iniciar los servicios de **MySQL**.

2. **Crear una Base de Datos**:

   Abre la terminal de MySQL y ejecuta:

   ```sql
   CREATE DATABASE examen_net;
   ```

3. **Configurar la Cadena de Conexión**:

   En el archivo `appsettings.json`, asegúrate de tener la siguiente configuración:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=examen_net;Uid=root;Pwd=;"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "AllowedHosts": "*"
   }
   ```

---

## 🚀 Configuración del Proyecto

1. **Clonar el Repositorio**:

   ```bash
   git clone https://github.com/usuario/nombre-del-proyecto.git
   ```

2. **Navegar al Directorio del Proyecto**:

   ```bash
   cd nombre-del-proyecto
   ```

3. **Restaurar Dependencias**:

   Ejecuta el siguiente comando:

   ```bash
   dotnet restore
   ```

---

## ▶️ Ejecución de Migraciones

1. **Aplicar Migraciones a la Base de Datos**:

   Ejecuta el siguiente comando para aplicar las migraciones:

   ```bash
   dotnet ef database update
   ```

2. **Verificar la Tabla Creada**:

   Revisa en MySQL si la tabla `Users` fue creada correctamente:

   ```sql
   SHOW TABLES;
   ```

   La salida debe mostrar la tabla `Users`.

3. **Código de la Migración `InitialUsers`**:

   ```csharp
   using Microsoft.EntityFrameworkCore.Migrations;

   #nullable disable

   namespace examen_backend_alexis.Migrations
   {
       public partial class InitialUsers : Migration
       {
           protected override void Up(MigrationBuilder migrationBuilder)
           {
               migrationBuilder.CreateTable(
                   name: "Users",
                   columns: table => new
                   {
                       Id = table.Column<int>(type: "int", nullable: false)
                           .Annotation("MySQL:ValueGenerationStrategy", MySql.EntityFrameworkCore.Metadata.MySQLValueGenerationStrategy.IdentityColumn),
                       Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                       Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                       Edad = table.Column<int>(type: "int", nullable: false)
                   },
                   constraints: table =>
                   {
                       table.PrimaryKey("PK_Users", x => x.Id);
                   });
           }

           protected override void Down(MigrationBuilder migrationBuilder)
           {
               migrationBuilder.DropTable(name: "Users");
           }
       }
   }
   ```

---

## 🛠️ Comandos Útiles

- **Crear una Nueva Migración**:

  ```bash
  dotnet ef migrations add NuevaMigracion
  ```

- **Revertir una Migración**:

  ```bash
  dotnet ef database update <NombreMigraciónAnterior>
  ```

- **Limpiar Archivos de Compilación**:

  ```bash
  dotnet clean
  ```

---

## 🐞 Resolución de Problemas

- **Verificar la Configuración del Proyecto**:

  Si hay problemas al conectar a la base de datos, revisa la cadena de conexión en `appsettings.json`.

- **Actualizar el SDK de .NET**:

  ```bash
  dotnet upgrade
  ```

- **Verificar Servicios MySQL**:

  Asegúrate de que **MySQL** esté corriendo correctamente en XAMPP o WAMP.

---

## 📚 Recursos Adicionales

- [Documentación de .NET](https://learn.microsoft.com/en-us/dotnet/)
- [Paquetes NuGet](https://www.nuget.org/)
- [MySQL](https://www.mysql.com/)

---

## 📞 Contacto

Si tienes preguntas o necesitas soporte, contacta a:

- **Correo Electrónico**: [soporte@ejemplo.com](mailto:soporte@ejemplo.com)
- **GitHub Issues**: [Issues del Proyecto](https://github.com/usuario/nombre-del-proyecto/issues)

---

## 🎉 ¡Gracias por colaborar!
