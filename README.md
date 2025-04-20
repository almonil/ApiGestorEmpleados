# Frontend para API Gestor de Empleados

Este es el proyecto frontend en Angular para gestionar productos en el sistema de gestión de empleados. La aplicación permite realizar las siguientes acciones:

- Visualizar productos.
- Crear, editar y eliminar productos.
- Subir y eliminar imágenes asociadas a los productos.

## Tecnologías utilizadas

- **Angular**: Framework para la construcción de aplicaciones web dinámicas.
- **RxJS**: Biblioteca para la programación reactiva en JavaScript.
- **Angular Forms**: Para el manejo de formularios reactivos y validaciones.
- **Angular Routing**: Para el manejo de la navegación entre las diferentes vistas.
- **Bootstrap**: Para el diseño y estilos rápidos.

## Estructura del proyecto

El proyecto está organizado en varias carpetas que representan las diferentes funcionalidades y servicios de la aplicación:

- **src/app**: Contiene los componentes, servicios y módulos de la aplicación.
  - **componentes/productos**: Componente para gestionar los productos.
  - **core/services**: Servicios para interactuar con la API backend.
  - **shared/models**: Modelos para las estructuras de datos.
  
- **src/app/home**: Componente principal de inicio, redirige a los productos.

## Configuración inicial

### 1. Clonación del repositorio

Primero, debes clonar el repositorio para comenzar a trabajar:


git clone https://github.com/almonil/ApiGestorEmpleados.git


### 2. Instalación de dependencias

Dentro del directorio del proyecto, instala las dependencias necesarias:



### 3. Ejecutar la aplicación

Una vez que las dependencias están instaladas, puedes iniciar la aplicación con el siguiente comando:

ng serve


La aplicación estará disponible en [http://localhost:4200](http://localhost:4200).

## Ramas del repositorio

Este repositorio contiene tres ramas principales:

### 1. **master**

- Rama principal del proyecto.
- Contiene la versión estable y de producción.
- Se realiza el merge de las funcionalidades completadas y listas para producción.

### 2. **front**

- Rama dedicada al desarrollo del **frontend** (Angular).
- Todos los cambios relacionados con la interfaz de usuario, servicios de frontend y componentes se realizan en esta rama.
- Los desarrolladores que trabajen en la parte del frontend deben hacer checkout a esta rama.

### 3. **back**

- Rama dedicada al desarrollo del **backend** (API).
- Contiene la lógica de servidor, acceso a la base de datos y controladores API.
- Los desarrolladores que trabajen en la parte del backend deben hacer checkout a esta rama.

## Flujo de trabajo básico

1. **Seleccionar la rama adecuada** antes de realizar cambios. Si estás trabajando en el frontend, haz checkout a la rama `front`. Si estás trabajando en el backend, haz checkout a la rama `back`.

2. **Crear una nueva rama** para nuevas funcionalidades:

git checkout -b nombre-de-la-rama

### 3. Ejecutar la aplicación

Una vez que las dependencias están instaladas, puedes iniciar la aplicación con el siguiente comando:
ng serve


## Rutas

La aplicación utiliza el enrutador de Angular para manejar la navegación entre las vistas.

- **Ruta principal** (`/`): Componente **HomeComponent**.
- **Ruta de productos** (`/productos`): Componente **ProductosComponent** para gestionar productos.

## Operaciones principales

### 1. Ver productos

En la ruta `/productos`, puedes ver una lista de productos cargados desde la API. Esta vista incluye opciones para:

- Crear un nuevo producto.
- Editar un producto existente.
- Eliminar un producto.

### 2. Subir y eliminar imágenes de productos

Cada producto tiene la opción de cargar imágenes asociadas y eliminarlas. Estas imágenes se gestionan a través del componente **ImagenesProductoComponent**.

### 3. Manejo de formularios

Los formularios de creación y edición de productos están gestionados por Angular Forms. Los formularios incluyen validaciones de entrada como requerir un nombre y un precio mayor que 0.

## Contribuciones

Si deseas contribuir a este proyecto, por favor sigue el flujo de trabajo descrito arriba para crear ramas y realizar Pull Requests. Asegúrate de que tus cambios estén bien documentados y sean probados.

## Licencia

Este proyecto está bajo la licencia MIT. Para más detalles, consulta el archivo LICENSE.

---

Este `README.md` cubre la información básica del proyecto, cómo configurarlo, cómo interactuar con el repositorio y algunas buenas prácticas a seguir. Si necesitas más detalles o información, no dudes en pedirlo.
