# Sistema Académico — Instituto Superior Cura Gabriel Brochero

Proyecto de Prácticas Profesionalizantes. Lo desarrollan 4 equipos sobre esta misma base.

El sistema tiene dos perfiles: **Secretario** y **Estudiante**.

---

## Las 5 reglas que no se rompen

1. **Nunca** pushear directo a `development`, `testing` ni `production`.
2. **Nunca** subir `node_modules/`, `dist/`, `bin/` ni `obj/`. Se generan solos.
3. **Nunca** usar `git push --force`. Le rompe el repositorio a todos.
4. Antes de abrir un Pull Request, `npm run build` tiene que pasar sin errores. Si tocaste el backend, también `dotnet build`.
5. Los conflictos los resolvés **en tu rama**, en tu máquina. No con el botón de GitHub.

---

## Arrancar el frontend en 3 pasos

```bash
git clone https://github.com/gonzaleztomi1978-design/Sistema-Academico.git
cd Sistema-Academico
npm install
npm run dev
```

Se abre en **http://localhost:5173**. Necesitás **Node.js 20 o superior**.

Todavía no hay login. Para cambiar entre Secretario y Estudiante usá el **simulador de roles** que aparece en pantalla.

---

## Base de datos y backend

### Qué necesitás instalar

- **SQL Server Express** y **SQL Server Management Studio**.
- **.NET 10 SDK**: https://dotnet.microsoft.com/download/dotnet/10.0

### 1. Crear la base en tu computadora

Cada uno tiene su propia copia de la base. Se crea con el script del repositorio:

1. Abrí Management Studio y conectate a `localhost\SQLEXPRESS` con **Windows Authentication**.
2. Abrí el archivo `database/AcademicSystem.sql` y apretá **F5**.

Se crea la base `AcademicSystem` con sus 22 tablas. Si el script cambia, lo volvés a correr: no borra nada ni duplica datos.

### 2. Levantar el backend

```bash
cd backend
dotnet run --project AcademicSystem.Api
```

Queda en **http://localhost:5000**. Para comprobar que se conectó a la base, abrí en el navegador:

**http://localhost:5000/api/health**

Tiene que mostrar `"status":"ok"` y `"roles":4`.

### Cómo se conecta a la base

La conexión está en `backend/AcademicSystem.Api/appsettings.json`:

```json
"ConnectionStrings": {
  "AcademicSystem": "Server=localhost\\SQLEXPRESS;Database=AcademicSystem;Trusted_Connection=True;TrustServerCertificate=True"
}
```

En ese archivo la barra va doble: `localhost\\SQLEXPRESS`.

**Si tu SQL Server tiene otro nombre**, no cambies ese archivo. Guardá tu conexión solo en tu computadora con este comando, cambiando la parte de `Server`:

```bash
cd backend
dotnet user-secrets set "ConnectionStrings:AcademicSystem" "Server=localhost;Database=AcademicSystem;Trusted_Connection=True;TrustServerCertificate=True" --project AcademicSystem.Api
```

El nombre de tu servidor es el que ponés en **Server name** cuando te conectás desde Management Studio.

### 3. Conectar el frontend con el backend

Creá un archivo `.env.local` en la raíz del proyecto, al lado de `package.json`, con esta línea:

```
VITE_API_BASE_URL=http://localhost:5000
```

Después reiniciá `npm run dev`. Ese archivo no se sube al repositorio.

Hoy las pantallas usan datos simulados. Cuando un equipo pase su pantalla a datos reales, llama a la API con `request('/api/...')` de `src/api/httpClient.js`.

### Cómo está armado el backend

```
backend/
├── AcademicSystem.Api/                 → endpoints (Controllers) y configuración
├── AcademicSystem.Business/Services/   → la lógica de cada funcionalidad
├── AcademicSystem.Data/Context/        → la conexión a la base (AcademicSystemContext)
└── AcademicSystem.Entities/
    ├── DTOs/                           → lo que la API recibe y devuelve
    └── Models/                         → una clase por cada tabla de la base
```

Cada funcionalidad recorre las cuatro capas en el mismo orden: el controller llama a un servicio, el servicio usa el contexto, y el contexto trabaja con los models. La API devuelve DTOs, nunca los models directamente. El ejemplo para copiar es el de `/api/health`: `HealthController`, `HealthService` y `HealthResponseDto`.

Las clases de `Entities/Models` y el contexto se generan automáticamente desde la base, con los mismos nombres de tablas y columnas. **No los edites a mano.** Si la base cambia, se acuerda en la Mesa Técnica, se actualiza el script y el E1 los vuelve a generar con este comando:

```bash
cd backend
dotnet tool restore
dotnet ef dbcontext scaffold "Name=ConnectionStrings:AcademicSystem" Microsoft.EntityFrameworkCore.SqlServer --project AcademicSystem.Data --startup-project AcademicSystem.Api --context AcademicSystemContext --context-dir Context --context-namespace AcademicSystem.Data.Context --output-dir ../AcademicSystem.Entities/Models --namespace AcademicSystem.Entities.Models --no-onconfiguring --force
```

---

## Comandos que vas a usar

| Comando | Para qué |
|---|---|
| `npm run dev` | Levantar el frontend mientras trabajás. |
| `npm run build` | Compilar el frontend. **Tiene que pasar antes de abrir un Pull Request.** |
| `npm run lint` | Ver problemas de estilo del código. |
| `npm test` | Correr los tests. |
| `dotnet run --project AcademicSystem.Api` | Levantar el backend, parado en `backend/`. |
| `dotnet build` | Compilar el backend, parado en `backend/`. |

---

## Dónde va tu código

```
src/
├── core/        → layout, menú y ruteo. Lo mantiene el E1.
├── api/         → acceso a datos. Hoy son datos simulados. Lo mantiene el E1.
├── hooks/       → funciones reutilizables (useCrud). Lo mantiene el E1.
├── modules/
│   ├── secretario/pages/   → pantallas del Secretario (E2 y E3)
│   └── estudiante/pages/   → pantallas del Estudiante (E4)
└── styles/      → estilos compartidos
```

| Equipo | Qué hace | Su rama | Dónde trabaja |
|---|---|---|---|
| **E1** — Acceso e Integración | Login, usuarios, roles, permisos, integrar todo | `e1` | `src/core/`, `src/api/`, `src/hooks/` |
| **E2** — Secretaría | Inscripción a 1.º año, docentes, estudiantes por comisión | `e2` | `src/modules/secretario/pages/Docentes/` e `.../Inscripciones/` |
| **E3** — Gestión Académica | Planes de estudio, materias, correlatividades | `e3` | `src/modules/secretario/pages/PlanesEstudio/` |
| **E4** — Inscripciones | Consulta de materias e inscripción a 2.º y 3.º | `e4` | `src/modules/estudiante/pages/Inscripciones/` |

En el backend, cada equipo agrega sus endpoints en `backend/AcademicSystem.Api/Controllers/`, su lógica en `backend/AcademicSystem.Business/Services/` y sus DTOs en `backend/AcademicSystem.Entities/DTOs/`. Cada servicio nuevo se registra con una línea en `Program.cs`, como `HealthService`.

Cada equipo crea su código **en su propia carpeta**. Los archivos compartidos se tocan solo para agregar lo propio, nunca para cambiar lo de otro.

---

## Las ramas

```
    e1 ─┐
    e2 ─┤
    e3 ─┼─ PR ─> development ─ PR ─> testing ─ PR ─> production
    e4 ─┘
```

| Rama | Qué es | ¿Podés pushear? |
|---|---|---|
| `e1` `e2` `e3` `e4` | La rama de tu equipo. Acá trabajás todos los días. | **Sí**, directo. |
| `development` | Donde se junta el trabajo de los 4 equipos. | No. Solo por Pull Request. |
| `testing` | Versión candidata: se prueba entera antes de darla por buena. | No. Solo por Pull Request. |
| `production` | Versión estable. Es lo que se muestra y se entrega. | No. Solo por Pull Request. |

El E1 es el que mergea hacia `development`, `testing` y `production`.

---

## Tu día a día con Git

```bash
# 1. Pararte en tu rama y traer lo último de tus compañeros
git checkout e2
git pull origin e2

# 2. Traer lo que ya integraron los otros equipos
git fetch origin
git merge origin/development

# 3. Trabajar, y cuando terminás algo:
git status
git add .
git commit -m "E2: inscripción de estudiantes a primer año"
git push origin e2
```

Después abrís el Pull Request en GitHub con **base `development`** y **compare `e2`**.

Dos cosas importantes:

- El paso 2 **no es opcional**. Sin el `git fetch` estarías mergeando una copia vieja.
- Los mensajes de commit empiezan con tu equipo: `E2: descripción corta en presente`.

Guía completa, con los conflictos típicos y cómo salir de cada problema: [documentos/flujo-git.md](documentos/flujo-git.md).

---

## Documentación

**De la cátedra**

- [Sistema Académico](documentos/Sistema%20Acad%C3%A9mico.md) — qué tiene que hacer el sistema.
- [Equipos Proyectos 2do](documentos/Equipos%20Proyectos%202do.md) — integrantes y responsabilidades de cada equipo.
- [continuacion.md](documentos/continuacion.md) — arquitectura del proyecto y convenciones de código.
- [diagrama UML](documentos/diagrama_uml_Sistema_Acad%C3%A9mico.md) — diagrama del sistema.

**De Git (las arma el E1)**

- [flujo-git.md](documentos/flujo-git.md) — trabajo diario de los equipos.
- [integracion-y-releases.md](documentos/integracion-y-releases.md) — cómo integra y promueve el E1.
- [configuracion-github.md](documentos/configuracion-github.md) — configuración del repositorio en GitHub.
