# Sales Date Prediction
## Descripción
Sales Date Prediction es una aplicación diseñada para gestionar órdenes de clientes y predecir la fecha de la próxima orden basada en el historial de compras.

## Tecnologías utilizadas
- **Backend**: .NET Framework (Web API)
- **Frontend**: Angular 17+
- **Base de Datos**: SQL Server

## Requisitos previos
Antes de ejecutar el proyecto, asegúrate de tener instalados:
- **SQL Server** con la base de datos `StoreSample` importada (usar el script `DBSetup.sql`)
- **.NET Framework**
- **Node.js** y **Angular CLI** (para el frontend)
- **Git** (para el control de versiones)

## Instalación y ejecución

### Backend (.NET Framework)
1. Navega a la carpeta del backend:
   ```sh
   cd SalesDatePrediction.Api
   ```
2. Restaura los paquetes NuGet:
   ```sh
   nuget restore
   ```
3. Configura la cadena de conexión en `Web.config`.
4. Ejecuta el proyecto desde Visual Studio o con:
   ```sh
   dotnet run
   ```
La API debería estar disponible en https://localhost:44301.

### Frontend (Angular 17+)
1. Navega a la carpeta del frontend:
   ```sh
   cd SalesDatePrediction.Web
   ```
2. Instala las dependencias:
   ```sh
   npm install
   ```
3. Ejecuta la aplicación:
   ```sh
   ng serve --open
   ```

Esto abrirá la aplicación en el navegador en `http://localhost:4200/`.

## Endpoints principales (API)
- **GET** `/api/orders/{clientId}` - Obtiene las órdenes de un cliente
- **POST** `/api/orders` - Crea una nueva orden
- **GET** `/api/predictions` - Obtiene la fecha estimada de la próxima orden por cliente

## Notas sobre la prueba técnica
- Se aplicaron principios **SOLID** en el diseño de la API.
- Se implementó paginación y ordenamiento en la tabla de órdenes.

## Autor
Cristian Andres Jimenez Arciniegas