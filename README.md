## finales_servidor

## Requisitos iniciales

## Ejecución con Docker
docker build --no-cache -t aspnetapp .
docker run -it --rm -p 5000:80 --name aspnetcore_sample aspnetapp

## Requisitos iniciales
## Gestion Tipos de evento, Ej: carrera de caballos
Campos:
Deporte
Competicion
Fecha de inicio y fecha de fin
Descripcion
Mantenimiento de tipos de evento: dar de alta, modificar, borrar, listar, ver detalle.

## Gestion tipos de apuesta, Ej: Resultado al acabar, puntos en un cuarto, puntos totales del equipo, etc
Campos:
Descripcion
Riesgo
Multiplicador
Deporte
Notas extra
Mantenimiento de tipos de apuesta: dar de alta, modificar, borrar, listar, ver detalle.


## Requisitos extra:
## Gestion de eventos
Campos:
Codigo
Nombre
Activo
Tipo de evento
Tipos de apuesta
Mantenimiento de eventos: dar de alta, modificar, borrar, listar, ver detalle.
Los tipos de apuesta solo puede ser los relacionados con el deporte del tipo de evento
No se puede modificar/borrar el evento si esta activo.
No se puede borrar o modificar el deporte de un tipo de evento o tipo de apuesta.
