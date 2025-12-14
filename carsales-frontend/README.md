# Carsales Frontend

Este proyecto corresponde al **frontend de la prueba técnica Carsales**.  
Está desarrollado en **Angular 20** y consume un **BFF en .NET**, encargado de centralizar el acceso a la API externa y desacoplar la lógica del cliente de servicios de terceros.

El foco principal del frontend es mantener una **estructura clara**, un **manejo de estado simple** y una **experiencia consistente frente a errores o fallas del backend**, priorizando mantenibilidad y legibilidad del código.

---

## Tecnologías utilizadas

- Angular 20
- Standalone Components (sin NgModules)
- Angular Signals para manejo de estado
- HttpClient
- SCSS
- Node.js / npm

---

## Estructura del proyecto

La aplicación está organizada siguiendo una arquitectura basada en **features**, separando responsabilidades de forma explícita y evitando acoplamientos innecesarios.

No se utilizan módulos tradicionales. Todos los componentes son **standalone**, alineados con las recomendaciones actuales del framework y facilitando una configuración más simple y explícita.

---

## Manejo de estado

El estado de la vista se gestiona utilizando **Angular Signals**, priorizando un manejo de estado simple y predecible en la capa de UI.

Se manejan mediante signals los siguientes estados:

- Listado de episodios
- Estado de carga
- Mensajes de error
- Paginación
- Estado de búsqueda

Este enfoque reduce complejidad innecesaria en los componentes y facilita el mantenimiento del código.

---

## Comunicación con el backend

El frontend consume un **BFF desarrollado en .NET** mediante `HttpClient`.

La URL base del backend no está hardcodeada y se define a través de los archivos de entorno:

```ts
environment.apiBaseUrl
```

Esto permite cambiar el endpoint según el entorno (desarrollo o producción) sin modificar el código de la aplicación.

---

## Manejo de errores

La aplicación contempla escenarios comunes de error, por ejemplo:

- Backend no disponible
- Error en la búsqueda
- Respuestas sin resultados

En estos casos:

- La aplicación no se rompe
- Se muestra un mensaje claro al usuario
- El estado visual se mantiene consistente

El objetivo es evitar fallos silenciosos o comportamientos inesperados en la UI.

---

## Cómo ejecutar el proyecto

Desde la carpeta `carsales-frontend` ejecutar:

```bash
npm install
npm start
```

La aplicación quedará disponible en:

```
http://localhost:4200
```

Para un correcto funcionamiento, el backend debe estar levantado o la URL debe estar configurada correctamente en los archivos de entorno.

---

## Formato de código

El proyecto utiliza **Prettier** para mantener un formato consistente en archivos TypeScript, HTML y SCSS.

Los avisos reportados por `npm audit` corresponden a dependencias oficiales de Angular y **no afectan el alcance funcional de esta prueba**, por lo que no se aplicaron fixes forzados para evitar romper compatibilidad.

---

## Alcance

Este frontend forma parte de una **prueba técnica** y está enfocado en demostrar:

- Organización y estructura del proyecto
- Uso de features modernas de Angular
- Buen manejo de estado y errores
- Claridad, legibilidad y mantenibilidad del código
