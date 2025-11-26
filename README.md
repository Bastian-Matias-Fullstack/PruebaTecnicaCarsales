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
🔗 LinkedIn: ([tu linkedin](https://www.linkedin.com/in/bastian-espinoza-ubilla-4663a6189/))
