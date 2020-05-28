# VIDEOJUEGO: SWAP
## JUEGO HECHO EN UNITY.
## VERSIÓN: 2019.3.1f1.

### Integrantes:
##### Jesús Armando Báez Camacho.
##### Francisco Javier Castro Márquez. 
##### Eric Ramón Valenzuela Cruz.
##### José Luis Aguilera Luzania.
##### Manuel Crisólogo Monge Tinoco.

<image src="images/MENU.gif" width="550" height="500">

### Desarrollo del proyecto:
Juego de naves creado en Java, reescribir el código en C# utilizando el Motor de Juegos Unity.

### Reglas del Juego:
Interfaz: Se tiene un menú en el cual se puede seleccionar empezar a jugar o salir del juego.
Cuando se está jugando se pueden visualizar tres vidas, con la imagen de 3 naves.

### Controles:
El juego consiste en una nave la cual puede cambiar de color al oprimir la barra espaciadora, los colores a elegir son rojo y azul, el movimiento de la nave se da con las teclas W,A,S,D y disparar proyectiles con la tecla P.

<image src="images/nave.png" width="149" height="55">

### Enemigos:
El juego actualmente cuenta con 3 tipos de enemigos, círculos, cuadrados y triángulos donde cada uno tiene su patrón de ataque y movimiento.

##### Círculo: Los círculos se mueven de manera vertical, van desde arriba hacia abajo, este enemigo cuando es destruido suelta balas que oscilan.
<image src="images/EnemigoCirculo.png" width="104" height="54">
 
##### Triángulo: El triángulo tiene un movimiento de tipo exponencial, pero van a arriba a abajo, este enemigo dispara en vertical y la bala se mueve de arriba a abajo.
<image src="images/EnemigoTriangulo.png" width="106" height="58">
  
##### Cuadrado: Los cuadrados se mueven de forma horizontal y pueden ir de izquierda a derecha o de derecha a izquierda, este enemigo dispara en vertical y la bala se mueve de arriba a abajo.
<image src="images/EnemigoCuadrado.png" width="106" height="56">

##### Tipos: 
cada enemigo lo podemos dividir en dos tipos, de color azul el cual dispara balas del mismo o de color rojo el cual dispara balas de color rojo.

### Daño que hace el enemigo al jugador:
Se definió anteriormente que la nave puede cambiar de color entre rojo y azul y que podemos tener enemigos tanto azules como rojos, en  base a esto generamos el daño cuando una bala de color contrario toca a la nave.
Por ejemplo si un enemigo azul dispara y esta bala choca cuando nuestra nave cuando es de color rojo entonces recibiremos daño y de descontará una vida de la interfaz.

### Condición después del daño:
La nave se pondrá en modo invulnerable y su alpha se reducirá un poco después de recibir daño esto para prevenir que el jugador puede perder vidas demasiado rápido y le de tiempo de recuperarse.

### Daño que hace el jugador al enemigo:
Los enemigos recibirán daño directo cuando los toque el proyectil de la nave.
Todos los enemigos cuentan con una sola vida por lo que en el momento que los toque la bala estos desaparecerán.

### Condición perdiste:
Cuando el número de vidas en la interfaz llega a cero entonces se desplegará un mensaje de perdiste en la interfaz y se regresará al menú.

### Condición de victoria:
Cuando la nave llega al final del nivel entonces se desplegará un mensaje de victoria en la interfaz y se regresará al menú.

<image src="images/Juego.png" width="591" height="700">

### Implementación de modo multijugador:
En base a lo que se tiene anteriormente se debe de implementar un sistema multijugador en línea para dos jugadores, a su vez utilizando un sistema para crear una cuenta de usuario y una tabla de puntuaciones.

### Registro Cuenta de Usuario:
Se implementará un servidor con una base de datos para poder guardar cada uno de los usuarios registrados de manera online.

### Modo de dos jugadores:
Se podrá visualizar dos naves en pantalla y cada una de ella se podrá controlar por ordenadores diferentes.

### Tabla de puntuación:
Cada jugador en línea, después de terminar una partida podrá registrar por medio de su cuenta, la puntuación que a obtenido y se almacenará en una tabla.

---
