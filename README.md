# OpticaZamora — gestión de una óptica

Sistema web de gestión para una **óptica**: pacientes, doctores, expedientes clínicos, catálogo de productos y ventas con detalle y estado de pago. Es mi **repositorio más antiguo (noviembre de 2019)** y el primero en el que aplico pruebas automatizadas y análisis estático de código.

## Qué hace

- **Pacientes y doctores**: alta, edición y consulta, con tipo de documento y género.
- **Expedientes** clínicos con la graduación de cada ojo (esfera, cilindro y eje), medidas de la montura y recomendación.
- **Catálogo**: productos y categorías.
- **Ventas**: venta con detalle por producto y estado de pago.
- **Acceso** con inicio de sesión (gestión de sesión propia) y páginas protegidas con `[Authorize]`.

## Stack

| Capa | Tecnología |
|---|---|
| Web | ASP.NET MVC 5 sobre .NET Framework 4.7.1 |
| Datos | Entity Framework 6 (Code First con migraciones) + SQL Server |
| Inyección de dependencias | Unity.Mvc |
| UI | Bootstrap 3 · jQuery |

## Estructura

```
OpticaZamora/                      aplicación web
  Controllers/                     Casefile, Category, Doctor, Login, Optica, Patient, Product, Venta
  Models/                          Paciente, Doctor, Expediente, Producto, Categoria, Sale, DetalleVenta...
  Services/                        lógica de negocio por dominio
  Validation/                      validaciones de campos por entidad
  Managers/ Interface/ DB/         sesión, contratos y contexto de datos
PruebasUnitariasOpticaZamora/      pruebas unitarias de servicios, controladores y validaciones
PruebasSeleniunOpticaZamora/       pruebas de interfaz con Selenium WebDriver
ScriptsOpticaZamora.txt            script SQL de las tablas
sonar.bat                          análisis estático con SonarQube
```

## Calidad: lo que más me interesa de este proyecto

- **Pruebas unitarias** (73 casos) sobre servicios, controladores y validaciones, aislando las dependencias con la inyección de Unity.
- **Pruebas de interfaz con Selenium** (56 casos) que recorren los flujos de login, doctores, pacientes, categorías, productos y ventas.
- **Análisis estático con SonarQube** mediante `sonar.bat` (`SonarScanner.MSBuild` sobre la solución).

## Cómo ejecutarlo

Requisitos: Windows, Visual Studio con .NET Framework 4.7.1 y SQL Server.

1. Crea la base de datos con `ScriptsOpticaZamora.txt` o con las migraciones de Entity Framework.
2. Ajusta la cadena de conexión `OpticaContext` en `OpticaZamora/Web.config`.
3. Ejecuta la solución `OpticaZamora.sln`.
4. Pruebas unitarias: Test Explorer de Visual Studio. Las de Selenium necesitan la aplicación en ejecución y un driver de navegador.

## Nota

Proyecto de aprendizaje de 2019: la solución usa .NET Framework 4.7.1, por lo que solo compila en Windows.
