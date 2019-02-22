# Apply for .NET Ninja

Layers
------------------------------------
La aplicacion fue aplicada algunas mejoras como ejemplo agregando Nueva capas que seria:

- Businnes:Será donde estará centralizada toda la logica de la aplicacion utilizando el Patron FACADE,que centraliza funcionalidades desacoplada por metodos.
- Common : Será responsable de disponibilizar todas funcionalidades em comun entre toda las capas ejemplo (Excepciones ,Extension...)
- DataAccess: Responsable de impactar y tener acceso a los Datos(DB)
- Model:Donde disponibilizara todo el modelo de la aplicaciones por clases y sus funcionalidades.
- Test: Responsable por las pruebas unitarias de la aplicacion de Ninja para mantener la calidad de código buscando un coverage mayor a 80%.
- Web: Capa de Presentacion Front End donde si integra con el core.


Inyección de dependencia
------------------------------------
- Agregado el patron de inyeccion de depencia con ioc para quitar la responsabiulidad de la clases principal de crear intancias y sus dependencias, para evitar la depencia directa.

