# Prueba Técnica Carsales — BFF + Frontend

Este repositorio contiene la solución completa a la prueba técnica Carsales, compuesta por:

- Un **Backend BFF en .NET**
- Un **Frontend en Angular 20**

El objetivo de la solución es exponer una **capa intermedia (BFF)** que centraliza el acceso a una API externa y entregar un frontend desacoplado, con manejo claro de estado, errores y estructura.

---

## Arquitectura general

La solución está organizada como un **monorepo**, separando claramente backend y frontend:

```
PruebaTecnicaCarsales/
├── Carsales.BFF/          # Backend BFF (.NET)
├── Carsales.BFF.Tests/    # Tests del backend
├── carsales-frontend/     # Frontend Angular
└── README.md              # Documentación general
```

Cada proyecto mantiene su propia responsabilidad y documentación específica.

---

## Backend — Carsales.BFF

El backend actúa como un **Backend For Frontend (BFF)**, encargado de:

- Consumir la API externa (Rick & Morty)
- Aplicar lógica de negocio básica
- Manejar errores de forma consistente
- Exponer endpoints simples y claros para el frontend

### Tecnologías

- .NET 8
- ASP.NET Core Web API
- Arquitectura en capas
- HttpClient
- DTOs y mappers
- Tests unitarios

### Endpoints principales

- `GET /api/episodes?page={number}`
- `GET /api/episodes/search?name={value}`

El backend maneja correctamente:

- Paginación
- Validación de parámetros
- Errores de la API externa (502)
- Errores de negocio (400)
- Errores inesperados (500)

---

## Frontend — carsales-frontend

El frontend está desarrollado en **Angular 20** y consume exclusivamente el BFF.

### Características principales

- Standalone Components (sin NgModules)
- Uso de **Angular Signals** para manejo de estado
- Arquitectura basada en features
- Manejo explícito de errores y estados de carga
- Uso de environments para configuración

El frontend **no consume directamente** la API externa, solo el backend BFF.

---

## Manejo de errores end-to-end

La solución contempla escenarios de error en toda la cadena:

- API externa caída → Backend retorna `502`
- Backend no disponible → Frontend muestra mensaje al usuario
- Inputs inválidos → Backend retorna `400`
- Errores inesperados → Manejo global con respuesta consistente

En ningún caso la aplicación se rompe ni queda en un estado inconsistente.

---

## Ejecución del proyecto

### Backend

Desde la carpeta `Carsales.BFF`:

```bash
dotnet restore
dotnet run
```

El backend queda disponible en la URL configurada (por defecto `https://localhost:xxxx`).

Swagger está habilitado para pruebas manuales.

---

### Frontend

Desde la carpeta `carsales-frontend`:

```bash
npm install
npm start
```

La aplicación estará disponible en:

```
http://localhost:4200
```

La URL del backend se configura mediante los archivos de environment del frontend.

---

## Tests

El backend incluye un proyecto de tests (`Carsales.BFF.Tests`) que valida:

- Comportamiento de los servicios
- Manejo de errores
- Casos de borde

Los artefactos de build (`bin/`, `obj/`) fueron removidos del repositorio y correctamente ignorados.

---

## Formato y calidad de código

- El frontend utiliza **Prettier** para mantener un formato consistente
- El backend mantiene un estilo limpio y consistente
- No se forzaron fixes automáticos de `npm audit` para evitar romper compatibilidad con Angular

---

## Decisiones técnicas relevantes

- Uso de BFF para desacoplar frontend de la API externa
- Uso de Signals para simplificar el manejo de estado en Angular
- Separación clara de responsabilidades
- Manejo explícito de errores
- Repositorio limpio sin artefactos de build

---

## Alcance

Esta solución forma parte de una **prueba técnica** y está enfocada en demostrar:

- Criterio arquitectónico
- Organización del código
- Uso de tecnologías actuales
- Capacidad de mantener y escalar la solución
