# AGENTS.md

Monorepo: an Angular 22 SPA at the repo root plus a nested ASP.NET Core (.NET 10) Web API.

- Angular app: `package.json`/`angular.json`, source in `src/`.
- Backend: `API/API REST PO/API REST PO/` (project `API_REST_PO`), solution file `API/API REST PO/API REST PO.slnx` (new `.slnx` format).

## Commands

Frontend (from repo root):
- `npm start` or `ng serve` -> http://localhost:4200
- `ng build` -> outputs to `dist/`
- `ng test` -> Vitest (`@angular/build:unit-test`)
- `ng e2e` -> no e2e framework configured

Backend (run from `API/API REST PO/API REST PO`):
- `dotnet run` -> uses the `http` profile (http://localhost:5197)
- `dotnet run --launch-profile https` -> https://localhost:7148 (this is what the Angular service targets — see gotchas)
- `dotnet ef migrations add <Name>` / `dotnet ef database update` (SQL Server LocalDB, no server needed)

## Architecture / wiring

- Backend uses EF Core + SQL Server LocalDB. Connection string `ConexionSQL` -> database `PuntoDeVentaDB` (`appsettings.json`). `ApplicationDbContext` exposes `DbSet<Producto> Productos`.
- `ProductosController` route is `api/productos`.
- CORS policy `PermitirAngular` allows only `http://localhost:4200`.
- OpenAPI (`MapOpenApi()`) is mapped only in Development.

## Gotchas

- **Port mismatch between frontend and `.http` file**: `src/app/services/producto.services.ts` calls `https://localhost:7148/api/productos`; `API REST PO.http` uses `http://localhost:5197`. These correspond to the `https` and `http` launch profiles. `dotnet run` defaults to `http` (5197) — use `--launch-profile https` for the frontend to connect.
- **All Angular `*.spec.ts` files reference modules that don't exist**: they import from `./inicio`, `./lista-productos`, `./producto` while the actual files are `*.component.ts` / `*.services.ts`. These specs will not compile/pass. Fix the imports if you touch tests.
- **Hardcoded data**: `ProductosController.GetProductos()` returns an inline list; it does NOT query the DB. `ListaProductosComponent` also uses a hardcoded array and does not inject `ProductoService`. `ProductoService`, `ApplicationDbContext`, and the `Inicial` migration exist but are not actually wired end-to-end.
- **Templates use new control flow syntax** (`@if` / `@for` / `@else`); do NOT add `CommonModule` for these (standalone components need only the built-in syntax).
- **CORS middleware order matters**: `app.UseCors("PermitirAngular")` must appear before `app.UseAuthorization()` (comment in `Program.cs`).

## Style

- Single quotes, 2-space indent (`$PROJECT_ROOT/.editorconfig`, `.prettierrc`).
- Prettier: `printWidth` 100, Angular parser for `*.html`.
- Comments in the code are Spanish; UI strings are Spanish (Q for currency).
