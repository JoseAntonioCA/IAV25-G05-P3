# Ghost - Base
Proyecto de videojuego creado en **Unity 2022.3.40f1** utilizando la plantilla **URP 3D** y sobreescribiendo después con el proyecto completo **John Lemon**, uno de los ejemplos de Unity Technologies. Este proyecto está diseñador para servir como punto de partida en algunas prácticas.

También está listo para utilizar Visual Scripting e incluye la extensión de pago Behavior Designer 1.7.12 + Tutorials + Samples, que está ignorada para que no se pueda subir al repositorio, pues sólo aquellos alumnos con permiso de la UCM podrán descargar el ZIP desde [esta carpeta de Google Drive](https://drive.google.com/drive/folders/1K7ILY8UWtANnjcNmSEQYRh8Io0m23DLw) y volcarlo MANUALMENTE como carpetas Behavior Designer, Behavior Designer Tutorials y Behavior Designer Samples dentro de Assets.

El proyecto consiste en un entorno virtual 3D que representa una casa encantada, con dos tipos de fantasmas y un personaje (con cara de limón) controlable por el jugador que es John Lemon, quien tendrá que llegar al final esquivando con sigilo a los fantasmas de la casa.

## Licencia
Federico Peinado, autor de la documentación, código y recursos de este trabajo, concedo permiso permanente a los alumnos de la Facultad de Informática de la Universidad Complutense de Madrid para utilizar este material, con sus comentarios y evaluaciones, con fines educativos o de investigación; ya sea para obtener datos agregados de forma anónima como para utilizarlo total o parcialmente reconociendo expresamente mi autoría.

## Notas


## Referencias
Los recursos de terceros utilizados son de uso público.
* Plantilla URP 3D, incluida en Unity 2022.3.40f1
* Unity Learn | 3D Beginner: John Lemon - Complete Project 1.8 (19 de agosto de 2024), que tiene estas dependencias:
  * com.unity.ai.navigation@1.1.4
  * com.unity.cinemachine@2.9.7
  * com.unity.inputsystem@1.5.1 (el nuevo, lo que implica reiniciar todo el editor)
  * com.unity.postprocessing@3.2.2
  * com.unity.render-pipelines.universal@14.0.7
* Behavior Designer 1.7.12, incluyendo Tutorials y Samples descargados desde la web de Opsive


## Documentación
En esta ocasión, la práctica pide que implementemos comportamientos basados en la toma de decisiones, principalmente.
En algunos enemigos se usará el sistema de máquina de estados para definir su comportamiento, y el jugador usará un sistema de comportamiento basado en árboles.

## Fantasmas
En este juego están las gárgolas, que son estáticas y no cambian su posición. Pero luego están los fantasmas, que sí se mueven y persiguen al jugador.
Basándonoes en el modelo de máquina de estados, tenemos 3 estados principales:

- Patrullar: Se dedica a deambular por una ruta, comprobando si encuentra al jugador.
- Investigar: Comprueba si hay algo sospechoso en una estatua.
- Perseguir: Trata de atrapar al jugador una vez lo ha visto.

Adjuntamos una imagen esquematizada sobre su comportamiento, donde se explica brevemente la transición entre estados: 
![alt text](image.png)

## John Lemon

Como el árbol de comportamiento de John Lemon era algo complicado, decidimos separarlo por partes. Además del árbol principal habrá otro para la toma de decisiones cuando hay fantasmas cerca, y otro para eliminar las estátuas que se encuentre por el camino.

### Comportaminto base

![alt text](image-3.png)

Este gráfico enseña una manera simplificada de la toma de decisiones a la hora de moverse.

Antes de nada, comprueba que no hay fantasmas que le pongan en peligro. Si ese fuera el caso, llamaría al sub-árbol para evadir fantasmas. 

Si no los hubiera, intentaría ir hacia la salida, mientras el camino esté despejado. En caso de que algún tótem le bloquease el camino, llamaría al sub-árbol de romper estatuas.

### Destruir las estátuas

![alt text](image-1.png)

Este gráfico enseña una manera simplificada de la toma de decisiones para empujar el tótem.

Primero de todo, se asegura que puede llegar en línea recta desde el totem hasta la estátua. Si no puede, recalcula un punto más cercano en la ruta e intenta ir a dicho punto lanzando el arbol de nuevo de manera recursiva. 

Una vez sabe a que punto puede ir, mirará si se puede colocar detrás del tótem para empujarlo, y lo intentará desatascar de ser así. 

Al colocarse detrás del totem solo le quedará empujarlo hasta la estátua (o hasta el checkpoint si estamos en una llamada recursiva). Si en algún momento deja de estar detrás de la estátua simplemente se recolocará detrás de nuevo y la seguirá empujando.

### Evadir fantasmas

![alt text](image-2.png)

Este gráfico enseña una manera simplificada de la toma de decisiones para huir de los fantasmas.

Primero se pregunta si hay algún sitio en el que esconderse. Si lo hay, intentará esconderse ahí. De no ser ese el caso, huirá.