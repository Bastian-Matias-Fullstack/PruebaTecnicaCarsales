Carsales – Frontend (Angular 17 + Standalone Components)

Este frontend forma parte de la prueba técnica para la posición de Ingeniero de Software .NET + Angular, y consume un backend propio desarrollado en .NET 8 que actúa como puente hacia la API pública de Rick & Morty.

La aplicación permite:

Listar episodios

Buscar episodios por nombre o código

Paginar resultados

Ver detalles básicos del episodio

Mostrar personajes asociados

El proyecto se desarrolló siguiendo buenas prácticas modernas de Angular, arquitectura basada en componentes y un diseño UI premium estilo glassmorphism lavanda.


Tecnologías Utilizadas
Área	Tecnologías
Framework	Angular 17 (Standalone Components)
Lenguaje	TypeScript
Estilos	SCSS (Glassmorphism + Dark Lavender UI)
Comunicación	HttpClient
Arquitectura	Componentes + Servicios
Diseño	Responsive, grid moderno, animaciones, efectos glass



Consumo de API

El frontend NO consume directamente la API pública.
En su lugar, se comunica con un backend .NET 8 que:

Actúa como BFF (Backend For Frontend)

Maneja errores

Aplica reglas

Capa de protección para el cliente

Endpoints consumidos:

GET /episodes?page=N
GET /episodes/search?query=XYZ


Arquitectura del Frontend
✔ Componentes Standalone

No se utiliza ningún módulo (pattern moderno de Angular).

✔ Servicios inyectados vía DI

EpisodesService es responsable de:

Llamar al backend

Manejar HttpClient

Retornar estructura tipada

Manejo básico de errores

✔ Tipado fuerte (TypeScript)

El modelo Episode está definido en core/models/episode.ts.

✔ Separación clara de responsabilidades

episodes-list.html → estructura

episodes-list.scss → diseño fino

styles.scss → diseño global y tema

episodes-list.ts → lógica de paginación, carga y búsqueda

🔎 Funcionalidades del Frontend
🔥 1. Listado de episodios

Carga inicial de todos los episodios paginados.

🔍 2. Buscador inteligente

Filtra por nombre o código

Muestra conteo

Resetea al limpiar

📄 3. Paginación

Botones:

Anterior

Siguiente

Estado dinámico

Modo búsqueda deshabilita paginación del backend

🎨 4. UI/UX Moderno

Implementado con:

Glassmorphism avanzado

Paleta Dark Lavender

Sombras suaves y gradientes

Botones con hover moderno

Tarjetas animadas (fadeInUp)

Búsqueda con ícono

Badges de episodio

Grid fluido responsive

⚠️ 5. Manejo de errores

Cuando ocurre un error en la API:

Se muestra mensaje al usuario

Se deshabilita loading

No se cae la aplicación

🎨 Diseño y Estilos
🎭 Global (styles.scss)

Fondo moderno con gradientes lavanda y azul

Capas blur estilo VisionOS

Tipografía Inter

Corrección de brillos y contraste

🧊 Componente (episodes-list.scss)

Incluye:

Contenedor glass principal

Buscador con halo dinámico

Paginación con botones translúcidos

Tarjetas vidrio (glass cards)

Efectos en hover

Badges semi-translucidos

Lista de personajes estilizada

Animaciones suaves