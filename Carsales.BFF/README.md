# Carsales – Prueba Técnica Fullstack (.NET + Angular)

Este repositorio contiene la solución a la prueba técnica de Carsales, implementada mediante un **Backend for Frontend (BFF)** en .NET y un **frontend en Angular**. El objetivo principal es desacoplar el frontend de la API externa (Rick & Morty), manejar errores de forma controlada y presentar una solución clara, mantenible y coherente.

---

## Arquitectura General

La solución se divide en dos partes bien definidas:

* **Backend (BFF)**

  * API desarrollada en .NET.
  * Consume la API pública de Rick & Morty.
  * Expone endpoints propios adaptados al frontend.
  * Centraliza validaciones, manejo de errores y paginación.

* **Frontend**

  * Aplicación Angular basada en componentes standalone.
  * Arquitectura orientada a *features*.
  * Consume exclusivamente el BFF, sin dependencia directa de la API externa.

Esta aproximación permite mayor control, trazabilidad y flexibilidad ante cambios futuros.

---

## Stack Tecnológico

### Backend

* .NET 8
* ASP.NET Core Web API
* HttpClient
* Swagger / OpenAPI

### Frontend

* Angular 20
* Standalone Components
* Angular Signals (manejo de estado local)
* RxJS
* SCSS

---

## Estructura del Proyecto (Frontend)

```
carsales-frontend/
└── src/app
    ├── core
    │   ├── models
    │   └── services
    ├── features
    │   └── episodes
    │       ├── pages
    │       │   └── episodes-list
    │       └── services
    └── shared
```

La aplicación está organizada por *features*, donde cada funcionalidad agrupa sus páginas, servicios y modelos asociados. Las **pages** representan rutas y orquestan la UI, mientras que los servicios encapsulan la lógica de acceso a datos.

---

## Cómo Ejecutar el Proyecto

### Backend

1. Abrir la solución en Visual Studio.
2. Ejecutar el proyecto `Carsales.BFF`.
3. Acceder a Swagger en:

   ```
   https://localhost:7149/swagger
   ```

### Frontend

1. Ir a la carpeta del frontend:

   ```bash
   cd carsales-frontend
   ```
2. Instalar dependencias:

   ```bash
   npm install
   ```
3. Ejecutar la aplicación:

   ```bash
   npm start
   ```
4. Abrir en el navegador:

   ```
   http://localhost:4200/episodes
   ```

---

## Configuración de Environments

El frontend utiliza archivos de *environment* para evitar URLs hardcodeadas:

* `environment.ts`: entorno de desarrollo local, apuntando al BFF en `https://localhost:7149/api`.
* `environment.prod.ts`: entorno productivo (placeholder), pensado para un backend desplegado.

Esto permite separar claramente configuración y lógica de negocio.

---

## Endpoints del Backend

* **GET /api/Episodios?page={page}**
  Obtiene la lista paginada de episodios.

* **GET /api/Episodios/búsqueda?nombre={texto}**
  Busca episodios por nombre.

---

## Manejo de Errores

* Si la API externa falla, el BFF responde con **HTTP 502 (Bad Gateway)**.
* El frontend muestra mensajes de error amigables sin romper la UI.
* La aplicación puede recuperarse automáticamente cuando el backend vuelve a estar disponible, sin necesidad de recargar la página.

Este flujo fue validado de forma end-to-end (Swagger → Frontend).

---

## Decisiones Técnicas

* Se utilizó un patrón **BFF** para desacoplar el frontend de la API externa.
* Se implementó una arquitectura por *features* en Angular para mejorar escalabilidad y mantenibilidad.
* Se usaron **Angular Signals** para el manejo de estado local (loading, error, paginación), alineándose con prácticas modernas del framework.
* Se priorizó simplicidad y claridad por sobre sobre-ingeniería.

---

## Validaciones Realizadas

* Pruebas manuales de paginación y búsqueda desde Swagger.
* Pruebas de consumo del BFF desde el frontend.
* Simulación de caída de la API externa y validación de respuestas 502.
* Verificación de recuperación automática del frontend tras restablecer el backend.

---

## Notas Finales

El foco de esta solución está en la **claridad arquitectónica**, el **manejo correcto de errores** y la **consistencia entre backend y frontend**, manteniendo un alcance acorde a una prueba técnica de nivel mid-senior.
