
# 🎬 MovieApp – Prueba Técnica

Aplicación de escritorio que permite buscar películas usando la API pública de OMDb y guardar favoritas en una cuenta personal. Desarrollada como prueba técnica aplicando diseño de interfaces con WPF.
Si desea ver un video en el que se muestre y explique el uso del sistema, acceda al siguiente enlace: 
[📄 Ver video de uso del sistema](https://drive.google.com/file/d/1yf5K7xp1ZkqptzmCJQkcapuLpAKCtrP9/view?usp=drive_link)

---

## 🔧 Prerrequisitos

Antes de ejecutar el proyecto, asegúrate de tener instalado lo siguiente (IMPORTANTE: Si no desea instalar MySQL en local, más abajo se proporciona una conexión desplegada en la nube):

- [.NET SDK 8.0 o superior](https://dotnet.microsoft.com/en-us/download) – Para este proyecto se utilizó la versión 9.0
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) – Motor de base de datos utilizado para persistencia.
- [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) – Herramienta visual recomendada para gestionar la base de datos.

> **Nota:** Asegúrate de tener corriendo el servidor MySQL y haber creado una base de datos vacía llamada `movieapp`, o modifica el nombre en la cadena de conexión según se desee. El usuario normalmente es `root`, el port 3306 y el hostname el localhost 

---

## ✅ Tecnologías usadas

- **WPF** – Frontend con patrón MVVM
- **ASP.NET Core Web API** – Backend RESTful
- **Entity Framework Core + MySQL** – Persistencia de datos
- **OMDb API** – Fuente de información de películas
- **JWT (JSON Web Tokens)** – Autenticación de usuarios
- **Swagger** – Documentación interactiva de la API
- **Clean Architecture** – Separación de responsabilidades por capas

---

## ▶️ Pasos para ejecutar la solución

### 🔹 Backend (API) y Frontend (WPF)
Si necesita mayor claridad en el proceso, puede ver el siguiente manual que explica mejor el proceso de configuración en variables como claves secretas, conexiones a bases de datos, etc.
[📄 Ver manual de instalación y ejecución](https://docs.google.com/document/d/15smCGgU2BJ0vR8sGiF-CNirbB7jZBfO4u_YZzkfntqE/edit?usp=sharing)

1. Clona el repositorio y accede a la raíz del proyecto:

   ```bash
   git clone https://github.com/JeffHC0911/MovieApp.git
   cd MovieApp
   ```

2. Configura los valores sensibles con **Secret Manager**:  
   El primero es la clave JWT  
   El segundo es la cadena de conexión a MySQL  
   El tercero es la clave de la API de OMDb

   ```bash
   dotnet user-secrets set "Jwt:Key" "clave-super-secreta" --project Backend/MovieApp.API
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "server=localhost;database=movieapp;user=root;password=tu_clave" --project Backend/MovieApp.API
   dotnet user-secrets set "Omdb:ApiKey" "tu_api_key_de_omdb" --project Backend/MovieApp.API
   ```

   👉 **Alternativa con base de datos remota (sin instalar MySQL local):**

   ```bash
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "server=bjvyf6vglwuoyr4cv5da-mysql.services.clever-cloud.com;port=3306;user=uxcp7rhgx81wq1af;password=C8P9X02RIh8caDTtrkgw;database=bjvyf6vglwuoyr4cv5da;" --project Backend/MovieApp.API
   ```

3. Aplica las migraciones para crear las tablas en la base de datos local (si usas MySQL local):

   ```bash
   dotnet ef database update --project Backend/MovieApp.API
   ```

   > Este paso no es necesario si usas la base de datos remota ya configurada.

4. Ejecuta la solución desde Visual Studio:  
   - Haz clic derecho sobre la solución y selecciona **Configurar proyectos de inicio**.
   - Selecciona **Varios proyectos de inicio** y marca como `Inicio` los proyectos:
     - `MovieApp.API`
     - `MovieApp.WPF`

   Luego presiona `Ctrl + F5` para ejecutar.

---

## 🧠 Decisiones tomadas

- Se usó el patrón **MVVM** en el frontend WPF para mantener una clara separación entre lógica y presentación.
- Se implementó **Clean Architecture** en el backend para facilitar el mantenimiento y escalabilidad.
- Se integró la API pública de **OMDb** para evitar carga manual de datos y enriquecer la experiencia del usuario.
- Para la autenticación, se utilizó **JWT** asegurando que los accesos estén controlados por token.
- Se creó un validador personalizado (**BearerTokenHandler**) debido a que la versión 9 del middleware `Authentication.JwtBearer` tenía problemas al validar correctamente los tokens. Esta solución usa `JwtSecurityTokenHandler` para procesar los tokens manualmente.

---

## 🚀 Posibles mejoras futuras

- Validaciones visuales en formularios
- Mejoras en la interfaz gráfica
- Filtros avanzados por género, año, etc.
- Confirmación de registro vía correo electrónico
- Paginación de resultados de búsqueda
- Acentuar palabras ya que en el momento los archivos con extensión xaml no me lo permitieron

---

## Manuales y guías disponibles
[📄 Ver manual de instalación y ejecución](https://docs.google.com/document/d/15smCGgU2BJ0vR8sGiF-CNirbB7jZBfO4u_YZzkfntqE/edit?usp=sharing)
[📄 Ver video de uso del sistema](https://drive.google.com/file/d/1yf5K7xp1ZkqptzmCJQkcapuLpAKCtrP9/view?usp=drive_link)
*En el video, el registro de usuario no tenía la comprobación de la contraseña (repetir contraseña). Esta validación se agregó posteriormente.

## Usuario general (Para la BD desplegada)
Si utiliza la BD de datos desplegada, puede probar un usuario general que ya está registrado con los siguientes datos:
admin@gmail.com
Admin?


🛠️ Proyecto desarrollado como parte de una prueba técnica para **Tecnimática**.
