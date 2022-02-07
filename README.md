# Practica-GCCE-Grupo3
Repositorio que inlcuye los elementos constituyentes al desarrollo de la prática de la asignatura de máster GCCE.
## Base datos
- **Motor**: MySQL
- **Estructura**: la estructura de la base de datos es la acordada por el resto de grupos en la definición de la prática.
- **Diseño**: en la carpeta _sql/_ se encuentran los scripts empleados para crear las tablas de la base de datos.
## Generación de datos
### Requisitos
El programa de genreación de datos aleatorios se ha escrito en el lenguaje c#, empleando la SDK de .NET 6, lo cual lo vuelve un requisito para su ejecución. Puede descargarse de la página oficial de Microsoft [aquí](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
### Paquetes
Se han empleado los siguientes paquetes durante el desarrollo del programa:
- **CsvHelper**: paquete para imprimir datos en csv. Se instala con: _dotnet add package CsvHelper_.
- **Newtonsoft.Json**: paquete para leer datos de un archivo .json. Se instala con: _dotnet add package Newtonsoft.Json_.

### Ejecución y resultado
Para su ejecución, si está correctamente instalado el sdk de .NET, simplemente necesita ejecutar en la carpeta _/src_ el siguiente comando:
> dotnet run

Como resultado se obtendrán ocho archivos .csv en la carpeta _/src/output_, cada una referenciando a una tabla de la base de datos.
### Parámetros de ejecución
Para editar los parámetros de la ejecución se puede editar el archivo _/src/App.config_, y así cambiar el comportamiento de la simulación. Los parámetros a editar son los siguientes:
- **n_alumnos_nuevos**: número de alumnos nuevos por año.
- **n_profesores**: número de profesores a simular en la Universidad.
- **n_cursos**: número de cohortes a crear. Cada cohorte se creará el año posterior a la anterior.
- **n_titulaciones**: número de titulaciones a simular en la Universidad.
- **n_cursos_simular**: número de cursos a simular para cada alumno.

### Reglas aleatorias
**Titulación**

Probabilidad se grado con 240 créditos, o un máster de 72 créditos.
El tipo de estudios afecta a la probabilidad de abandono de la titulación:
- entre 0 y 25 por ciento para letras
- entre 25 y 50 por ciento para ciencias

**Asignatura**

Probabilidad del 75% de ser obligatoria y 25% de ser optativa.
Los grados tienen dos asignaturas especiales de 12 créditos y el máster una.
La dificultad se define con los siguientes porcentajes:
- 25% de ser baja
- 50% de ser media
- 25% de ser alta 

**Acceso**

Nota media varía según el tipo de acceso:
- Acceso por bachillerato implica una nota entre 6 y 10.
- Acceso por FP o Extranjero implica una nota entre 5 y 8.

**Alumno**

El sexo tiene un 47% de probabilidades de ser masculino, otro 47% de ser femenino y un 6% de otro.
El nivel de renta depende de los estudios de los progenitores, los cuales son aleatorios.

**Matricula**

La posibilidad de inscribirse al POAT es del 50% 

### Reglas dependientes
**Matrícula**

Si tiene o no beca, viene determinado por la nota media del acceso o bien de su anterior año, y del nivel de renta del alumno.
La cancelación de matrícula depende del número de asignaturas matriculadas, la relación entre créditos matriuclados y aprobados, y de si el alumno trabaja o no, de la siguiente manera:
- Si trabaja tiene un 10% de posibilidades de cancelar
- Si se ha matriculado en al menos 6 asiganturas y no ha aprobado un 25% de los créditos matriculados, entonces cancela.

**Servicios externos**

La probilidad de trabajo y el sueldo varía según el tipo de estudio:
- 25% de posibilidad de trabajar con una renta baja-media si cursa un grado
- 66% de posibilidad de trabajar con una renta media-alta si cursa un máster

**Calificación académica**

Las notas del primer año dependen de: nota de acceso, POAT, beca y dificultad de la asignatura.
Las notas de los años posteriores dependen de: nota media del año anterior, POAT, beca y dificultad de la asignatura.
Que se presente o no, varía según el tipo de asignatura:
- 90% de presentarse si la asignatura es obligatoria
- 95% de presentarse si la asignatura es optativa

**Alumno**

El estado tiene tres posibles valores que se definen con las siguientes comprobaciones:
- *Todas las aignaturas de la titulación aprobadadas*: el estado es **gradudado**.
- *Matrícula cancelada*:
  - *Han pasado menos de 2 años*: el estado es **pausado** o **abandono**.
  - *Han pasado 2 años o más*: el estado es **abandono**.
- *Cualquier otro caso*: el estado es **activo** o **abandono**.

Cuando se determina si el alumno abandona o no, se calcula la probabilidad de abandono en base a:
- **nota media**
- **número de cursos en la titulación**
- **probabilidad de abandono de la titulación**

**Flujo**

    ┌─────────────────────────────┐
    │                             │
    │  ┌────────────┐        ┌────┴───┐
    ├──┤ Titulacion ├────────► Alumno ◄───────────────────┐
    │  └──────┬─────┘        └────▲───┘                   │
    │         │                   │                       │
    │         │                   │                       │
    │  ┌──────▼─────┐    ┌────────┴─────────┐       ┌─────▼─────┐
    │  │ Asignatura ├───►│ Calif. Academica ◄───────┤ Matricula │
    │  └────────────┘    └────────▲─────────┘       └─────▲─────┘
    │                             │                       │
    │                             │                       │
    │                         ┌───┴────┐        ┌─────────┴──────────┐
    │                         │ Acceso │        │ Servicios Externos │
    │                         └────────┘        └─────────▲──────────┘
    │                                                     │
    └─────────────────────────────────────────────────────┘
