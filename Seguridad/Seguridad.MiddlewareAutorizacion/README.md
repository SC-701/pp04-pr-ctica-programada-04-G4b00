# AuthMiddleware

Middleware de autenticación ligero y extensible para aplicaciones ASP.NET Core.

## Instalación

```bash
dotnet add package AuthMiddleware
```

O desde la consola del Package Manager:

```powershell
Install-Package AuthMiddleware
```

## Configuración

En `Program.cs`:

```csharp
builder.Services.AddAuthMiddleware(options =>
{
    options.SecretKey = builder.Configuration["Jwt:Secret"];
    options.ExcludedPaths = ["/login", "/register"];
});

// ...

app.UseAuthMiddleware();
```

## Opciones

| Opción | Tipo | Descripción |
|--------|------|-------------|
| `SecretKey` | `string` | Clave secreta para verificar tokens JWT |
| `ExcludedPaths` | `string[]` | Rutas que no requieren autenticación |
| `OnUnauthorized` | `Func<HttpContext, Task>` | Handler personalizado para errores 401 |

## Cómo funciona

1. Intercepta cada request entrante
2. Valida el token `Bearer` en el header `Authorization`
3. Adjunta el payload decodificado al `HttpContext.User`
4. Responde con `401 Unauthorized` si el token es inválido o expirado

## Requisitos

- .NET 8 o superior
- ASP.NET Core

## Licencia

MIT