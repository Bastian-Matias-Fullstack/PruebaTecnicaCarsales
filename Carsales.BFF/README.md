# 🚀 Prueba Técnica – Carsales  
Backend (.NET 8) + Frontend (Angular 17)

Este proyecto corresponde a la prueba técnica para la posición de **Ingeniero de Software .NET + Angular**, donde se solicita implementar:

- Un **Backend For Frontend (BFF)** en .NET 8  
- Un **Frontend moderno** en Angular 17  
- Consumo indirecto de la API pública de Rick & Morty  
- Funcionalidades de listado, búsqueda y paginación  

---

# 📦 Estructura del Repositorio

```
/
├── backend/        -> API .NET 8 (BFF)
│     └── README.md
│
├── frontend/       -> Angular 17 (Standalone)
│     └── README.md
│
├── docs/           -> Documentación adicional (opcional)
│
└── README.md       -> Este archivo
```

---

# 🧩 Descripción General

El proyecto consiste en consumir datos de episodios desde la API pública de *Rick and Morty*, pero **NO desde el frontend**, sino mediante un **Backend intermedio (BFF)** que:

- Normaliza respuestas  
- Maneja errores de la API externa  
- Expone endpoints propios  
- Evita exponer la API real al frontend  

El frontend consume este backend y presenta los datos:

- Listado paginado  
- Búsqueda por nombre o código  
- Botón para limpiar búsqueda  
- Manejo de errores  
- UI moderna con Glass + Dark Lavender UI  

---

# ⚙️ Tecnologías Utilizadas

### 🟣 Backend – .NET 8
- ASP.NET Core 8 Web API  
- Clean Architecture  
- HttpClientFactory  
- Inyección de dependencias  
- Manejo unificado de errores  
- Pruebas unitarias  
- Swagger (opcional)

### 🔵 Frontend – Angular 17
- Standalone Components  
- HttpClient  
- Servicios tipados  
- SCSS modular  
- Animaciones suaves  
- Glass Dark Lavender UI  

---

# 📘 Cómo Ejecutar el Proyecto Completo

## 1️⃣ Clonar el repositorio

```
git clone <URL_REPO>
cd carsales-project
```

---

# 🟣 2️⃣ Levantar Backend (.NET 8)

```
cd backend
dotnet restore
dotnet watch run
```

El backend arrancará en:

```
http://localhost:5000
```

### Endpoints expuestos:

| Endpoint | Descripción |
|---------|-------------|
| `GET /episodes?page=N` | Lista episodios paginados |
| `GET /episodes/search?query=XYZ` | Busca episodios |

---

# 🔵 3️⃣ Levantar Frontend (Angular 17)

```
cd frontend
npm install
ng serve -o
```

La aplicación abrirá en:

```
http://localhost:4200
```

---

# 🔍 Funcionalidades del Frontend

✔ Listado completo de episodios  
✔ Búsqueda por nombre o código (Pilot, S01E05…)  
✔ Paginación dinámica  
✔ Botón “Limpiar búsqueda”  
✔ Manejo de errores  
✔ Diseño Dark Lavender Glass  
✔ Responsive Desktop/Mobile  

---

# 🧪 Pruebas sugeridas

### ✔ Buscar “Pilot”  
### ✔ Buscar “S01E01”  
### ✔ Buscar algo inexistente (“aaaaaa”)  
Debe mostrar *“No se encontraron episodios”*.

### ✔ Probar paginación  
- Flecha siguiente  
- Flecha anterior  
- Desactivación correcta  

### ✔ Desconectar backend  
Debe mostrar error sin romper la UI.

---

# 🏗 Arquitectura (Resumen)

## Backend
```
Aplicacion/
Dominio/
Infraestructura/
API/
Tests/
```

✔ Dominio sin dependencias  
✔ Aplicación define contratos  
✔ Infraestructura implementa integración externa  
✔ API expone endpoints BFF  
✔ Tests cubren flujo principal  

## Frontend
```
core/models/
features/episodes/
   pages/episodes-list/
   services/episodes.service.ts
styles.scss
```

✔ Angular Standalone  
✔ Servicios limpios  
✔ Componentes separados  
✔ SCSS modular y moderno  

---

# 📄 Documentación Adicional

- `/backend/README.md` — Explicación técnica del BFF  
- `/frontend/README.md` — Explicación de vistas, servicios y diseño  
- `/docs/` — Opcional para capturas, diagramas o checklist  

---

# ✔ Checklist Final (Antes de entregar)

- [x] Backend funciona correctamente  
- [x] Frontend consume el backend  
- [x] Búsqueda y paginación completas  
- [x] Manejo de errores correcto  
- [x] Diseño final aplicado  
- [x] Repositorio limpio (`node_modules`, `bin`, `obj` ignorados)  
- [x] Documentación clara  
- [x] README general presente  

---

# 🙌 Notas para el Evaluador

Este proyecto fue construido priorizando:

- Buenas prácticas de Angular y .NET  
- Arquitectura clara y mantenible  
- Código limpio y ordenado  
- Manejo adecuado de errores  
- UI moderna agradable para el usuario  
- Separación estricta entre frontend ↔ backend  

Listo para revisión.

---

# 🏁 FIN DEL README
