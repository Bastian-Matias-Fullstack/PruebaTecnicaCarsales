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
=======
📄 README.md — Proyecto Técnico Carsales

(Frontend Angular + Backend .NET 8 BFF + Tests)

🚗 Prueba Técnica – Carsales

Posición: Ingeniero de Software (.NET / Angular)
Tecnologías principales:

Backend: .NET 8 + Arquitectura Limpia + BFF

Frontend: Angular 18 (standalone) + SCSS + Arquitectura por Features

Testing: xUnit + Moq + FluentAssertions

Cliente externo: API Rick & Morty

Este proyecto implementa un BFF en .NET y una interfaz moderna en Angular para consumir, paginar y buscar episodios desde la API externa Rick & Morty.

Incluye manejo de errores, arquitectura limpia, componentes reutilizables, paginación, pruebas unitarias completas y diseño UI estilo glassmorphism profesional.

🧱 Arquitectura General
📁 PruebaTecnicaCarsales/
│
├── 📁 Carsales.BFF             → Backend .NET 8 (BFF)
│   ├── Application/            → DTOs, Interfaces, Mappers, Servicios
│   ├── Domain/                 → Entidades
│   ├── Infraestructure/        → ApiClient externo
│   ├── Controllers/            → Endpoints REST
│   ├── Middleware/             → Manejo global de errores
│   └── README.md
│
├── 📁 Carsales.BFF.Tests       → Pruebas unitarias (xUnit)
│
└── 📁 carsales-frontend        → Frontend Angular 18
    ├── core/models/            → Tipado de datos
    ├── features/episodes/      → Página principal y servicios
    ├── styles.scss             → Estilos globales
    ├── app.routes.ts           → Ruteo standalone
    └── README.md

⚙️ Cómo ejecutar el proyecto
1️⃣ Backend – .NET 8 BFF
Requisitos

.NET SDK 8

Cualquier IDE (VS / VS Code)

Instalar dependencias y ejecutar
cd Carsales.BFF
dotnet restore
dotnet run

El servidor iniciará en:
https://localhost:7207
http://localhost:5207

Endpoints principales
Método	Ruta	Descripción
GET	/api/episodes?page=1	Lista paginada de episodios
GET	/api/episodes/search?query=termino	Búsqueda por nombre o código

Incluye:

Manejo de errores global

Logging a archivos /logs/

Cliente HTTP tipado (HttpClientFactory)

DTOs, Mappers y Arquitectura Limpia

2️⃣ Frontend – Angular 18 Standalone
Requisitos

Node 18+

Angular CLI (npm install -g @angular/cli)

Instalar dependencias
cd carsales-frontend
npm install

Ejecutar
ng serve -o

La aplicación abre en:
http://localhost:4200

🎨 Características del Frontend

Arquitectura por Features (mejor práctica moderna)

SCSS modular + variables + glassmorphism

Paginación completa

Búsqueda por nombre y código (ej: S01E05)

Diseño responsive

Estados UI: loading, error, empty results

Hover effects y sombreados suaves

🧪 Pruebas Unitarias

Ubicadas en Carsales.BFF.Tests.

Incluye pruebas para:

✔ Servicios

Mock de HttpClient

Validación de respuestas

Manejo de errores

✔ Controladores

Respuestas 200 OK

Errores 400 / 502

Validación de parámetros

✔ Estructura

Arrange / Act / Assert

FluentAssertions

Moq

Ejecutar:

cd Carsales.BFF.Tests
dotnet test

🛡 Manejo Global de Errores (Backend)

El middleware centraliza:

Validación de parámetros

Errores de red al API externo

Errores desconocidos

Respuesta consistente JSON

Ejemplo de respuesta:

{
  "error": "Error inesperado",
  "details": "Excepción interna"
}

🔗 Comunicación BFF → API Externa

El BFF consume:

https://rickandmortyapi.com/api/episode


Aplicando:

HttpClientFactory

Timeouts

Retries (si fuera necesario)

Logs

🧩 Decisiones Técnicas Clave

BFF para desacoplar frontend del API externo

Angular Standalone (sin módulos) para mayor rendimiento

Arquitectura limpia en .NET

Tests unitarios reales

Patrón Feature-based en frontend

UI con glassmorphism para una presentación profesional

📦 Scripts útiles
Backend
dotnet run
dotnet test

Frontend
npm install
ng serve -o

🚀 Conclusión

Este proyecto demuestra experiencia sólida en:

Desarrollo fullstack moderno (.NET 8 + Angular 18)

Arquitecturas limpias y escalables

Pruebas unitarias

Integración con APIs externas

Diseño UI profesional

Buenas prácticas en frontend y backend

💬 Autor

Bastián Matías — Fullstack Developer (.NET + Angular)
📧 Contacto: (bastian.dev.fullstack@gmail.com)
🔗 LinkedIn: (https://www.linkedin.com/in/bastian-espinoza-ubilla-4663a6189/)
