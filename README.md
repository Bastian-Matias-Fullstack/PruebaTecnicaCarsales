
# 🚗 Prueba Técnica Carsales
**BFF .NET 8 + Frontend Angular 20 + Tests**

---

## 📌 Contexto

Este repositorio contiene la solución completa a la **prueba técnica Carsales** para la posición de **Ingeniero de Software Fullstack (.NET / Angular)**.

La solución implementa un **Backend For Frontend (BFF)** en .NET 8 que consume una API externa y expone endpoints claros y controlados para un **frontend moderno en Angular 20**, totalmente desacoplado de dicha API.

El foco del proyecto está en demostrar:
- Criterio arquitectónico
- Organización del código
- Buenas prácticas modernas
- Manejo de errores end‑to‑end
- Capacidad de mantener y escalar la solución

---

## 🧱 Arquitectura General

Estructura tipo **monorepo**, separando claramente backend, frontend y pruebas:

```
PruebaTecnicaCarsales/
├── Carsales.BFF/          # Backend BFF (.NET 8)
├── Carsales.BFF.Tests/    # Pruebas unitarias del backend
├── carsales-frontend/     # Frontend Angular 20
└── README.md              # Documentación principal
```

Cada proyecto mantiene responsabilidades claras y aislamiento técnico.

---

## 🔧 Backend — Carsales.BFF (.NET 8)

### Rol del BFF

El backend actúa como **Backend For Frontend**, encargado de:

- Consumir la API externa **Rick & Morty**
- Aplicar lógica de negocio básica
- Validar parámetros de entrada
- Centralizar el manejo de errores
- Exponer endpoints simples y estables para el frontend

El frontend **no consume directamente** la API externa.

---

### Tecnologías

- .NET 8
- ASP.NET Core Web API
- Arquitectura basada en **Clean Architecture**
- HttpClientFactory
- DTOs y Mappers
- Middleware de manejo global de errores
- Tests unitarios con xUnit

---

### Arquitectura Interna

```
Carsales.BFF/
├── Application/       # DTOs, Interfaces, Mappers, Servicios
├── Domain/            # Entidades y reglas de dominio
├── Infrastructure/   # Cliente HTTP externo (Rick & Morty API)
├── Controllers/       # Endpoints REST
├── Middleware/        # Manejo global de errores
└── README.md
```

Separación clara de responsabilidades y dependencias dirigidas hacia el dominio.

---

### Endpoints Principales

| Método | Ruta                                   | Descripción                     |
|------|----------------------------------------|---------------------------------|
| GET  | /api/episodes?page={number}             | Lista paginada de episodios     |
| GET  | /api/episodes/search?query={value}      | Búsqueda por nombre o código    |

---

### Manejo de Errores

El backend retorna respuestas consistentes:

- **400** → Parámetros inválidos
- **502** → Error al consumir la API externa
- **500** → Error inesperado

Ejemplo de respuesta:

```json
{
  "error": "Error inesperado",
  "details": "Excepción interna"
}
```

El middleware centraliza el control de errores y evita estados inconsistentes.

---

### Ejecución del Backend

Requisitos:
- .NET SDK 8

```bash
cd Carsales.BFF
dotnet restore
dotnet run
```

URLs por defecto:
- https://localhost:7207
- http://localhost:5207

Swagger está habilitado para pruebas manuales.

---

## 🎨 Frontend — carsales-frontend (Angular 20)

El frontend consume **exclusivamente** el BFF.

### Tecnologías y Enfoque

- Angular 20
- Standalone Components (sin NgModules)
- Angular Signals para manejo de estado
- Arquitectura basada en **features**
- SCSS modular
- Uso de environments para configuración

---

### Estructura Principal

```
carsales-frontend/
├── core/models/          # Tipado de datos
├── features/episodes/   # Feature principal (lista, búsqueda, paginación)
├── app.routes.ts        # Ruteo standalone
├── styles.scss          # Estilos globales
└── README.md
```

---

### Características UI

- Paginación completa
- Búsqueda por nombre y código (ej: S01E05)
- Estados UI: loading, error, empty results
- Diseño responsive
- Estilo visual **glassmorphism**

---

### Ejecución del Frontend

Requisitos:
- Node.js 18+
- Angular CLI

```bash
cd carsales-frontend
npm install
ng serve -o
```

URL:
- http://localhost:4200

La URL del backend se configura mediante `environment.ts`.

---

## 🧪 Pruebas Unitarias

Ubicadas en `Carsales.BFF.Tests`.

Incluyen pruebas representativas para:

- Servicios de aplicación
- Controladores
- Manejo de errores
- Validación de parámetros

Tecnologías:
- xUnit
- Moq
- FluentAssertions

```bash
cd Carsales.BFF.Tests
dotnet test
```

---

## 🔗 Comunicación con API Externa

API consumida:
```
https://rickandmortyapi.com/api/episode
```

Buenas prácticas aplicadas:
- HttpClientFactory
- Manejo de errores de red
- Timeouts
- Logging para diagnóstico

---

## 🧩 Decisiones Técnicas Clave

- Uso de BFF para desacoplar frontend del API externo
- Clean Architecture para mantenibilidad y escalabilidad
- Angular Standalone + Signals para un frontend moderno
- Manejo explícito de errores end‑to‑end
- Arquitectura basada en features
- Repositorio limpio sin artefactos de build

---

## 📦 Scripts Útiles

### Backend
```bash
dotnet run
dotnet test
```

### Frontend
```bash
npm install
ng serve -o
```

---

## 🚀 Conclusión

Este proyecto demuestra experiencia sólida en:

- Desarrollo fullstack moderno (.NET 8 + Angular 20)
- Arquitecturas limpias y mantenibles
- Pruebas unitarias
- Integración con APIs externas
- Buenas prácticas de frontend y backend

---

## 👤 Autor

**Bastián Matías** — Fullstack Developer (.NET + Angular)

📧 Email: bastian.dev.fullstack@gmail.com  
🔗 LinkedIn: https://www.linkedin.com/in/bastian-espinoza-ubilla-4663a6189/
