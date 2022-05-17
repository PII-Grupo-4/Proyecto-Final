# Universidad Católica del Uruguay
<img src="https://ucu.edu.uy/sites/all/themes/univer/logo.png">

## Facultad de Ingeniería y Tecnologías
### Programación II

## Proyecto 2022 - Primer Semestre - Batalla Naval - [Batalla naval (juego)](https://es.wikipedia.org/wiki/Batalla_naval_(juego)).

La pregunta orientadora de este proyecto es:

> :thinking: ¿Cómo podemos nosotros, estudiantes de Programación II de la Universidad Católica del Uruguay, crear un juego de estrategia y suerte para jugar de forma online?

El trabajo consiste en desarrollar un [chatbot](https://es.wikipedia.org/wiki/Bot_conversacional) que permitirá conectar juadores.

## Introducción

Un chatbot (o bot conversacional) es «un programa que simula mantener una conversación con una persona al proveer respuestas automáticas a entradas hechas por el usuario.»<sup>1</sup>

Existen gran variedad de chatbots actualmente y varios _sabores_. Hay chatbots que simplemente responden a comandos pre-establecidos, y otros que integran algoritmos de [inteligencia artificial](https://es.wikipedia.org/wiki/Inteligencia_artificial) para procesar los mensajes de los usuarios e [interpretar lo que se está diciendo](https://es.wikipedia.org/wiki/Procesamiento_de_lenguajes_naturales).

Los chatbots son especialmente útiles para asistir a las personas en tareas o consultas sin necesidad de la interacción humana del otro lado. Algunos ejemplos de esto son:

- ayudar a resolver un problema cuando pido comida y no llega
- hacer trámites con bancos, por ejemplo, notificación por Whatsapp que salgo de viaje
- [asistencia al público actualmente durante la pandemia del COVID-19](https://www.gub.uy/ministerio-salud-publica/coronavirus)
- hacer de asistente, por ejemplo, para agendar reuniones entre personas
- oficiar de agente de viajes, para encontrar vuelos, estadías, etc.
- buscar multimedia (GIFs, videos, música, etc.)
- y mucho más.

Algunas de las aplicaciones más conocidas que abren sus puertas al desarrollo de chatbots (tienen [APIs](https://es.wikipedia.org/wiki/Interfaz_de_programaci%C3%B3n_de_aplicaciones)) son: Telegram, Messenger, Whatsapp, Slack, Discord, entre otras.

## La propuesta
Aquí veremos una explicación general e informal de las funciones del software (nuestro programa), escrita desde la perspectiva del usuario final. 

- Como jugador debo poder iniciar una partida. 
- Como jugador debo posicionar mis naves antes de comenzar con el primer movimiento.
- Como jugador debo poder acceder a dos tableros, uno para visualizar mis propias naves y otro para que contenga los disaparos realizados.
- Como jugador debo poder indicar una posición de ataque.
- Como administrador del juego, debo poder registrar usuarios.
- Como administrador del juego, debo poder conectar dos jugadores que se encuentren esperando para jugar.
- Como administrador debo poder actualizar el tablero de registro de ataques, cuando un jugador ataca a otro.
- Como administrador debo poder actualizar el tablero de un jugador cuando recibe un ataque.
- Como administrador del juego, debo poder almacenar todas las partidas en juego, junto con sus datos (tableros, jugadores, etc.)
- Como administrador del juego, se debe permitir tantas rondas como sean necesarias para cada una de las partidas.
- Como administrador del juego, luego de cada ataque debo indicar el resultado del mismo a ambos participantes (si el ataque coincide con la posición de un barco: "Tocado" en caso de haber más partes aún sin atancar, "Hundido" sino quedan partes de la nave por atacar, o bien si no ha tocado ninguna parte de una nave indicará "Agua".
- Como adnministrador debo indicar que se finalizó la partida cuando todas las naves de un jugador queden hundidas.

### Negociando con el cliente
Cómo empresa desarrolladora de video juegos, analizan que el juego es muy simple y quieren destacarse ante la competencia, por esto deciden agregar algunas funcionalidades/requerimientos a la letra del proyecto. Para esto, cada uno de los participantes del equipo deberá idear una nueva funcionalidad, que deberá presentar ante el cliente (o sea los profesores de la asignatura) y negociar el diseño y dearrollo de las mismas para sumar al proyecto. 


### Persistencia de la información
Cómo ya te habrás dado cuenta, nuestro chatbot necesitará guardar la información de empresas, emprendedores, materiales, etc. Para esto te brindaremos una interface que te permitirá realizar persistencia de datos (guardar y recuperar) y luego una implemnentación utilizando archivos. Tengan presente, que a los profes les gusta guardar información en bases de datos, así que si cambiamos la implementación de la interface, el chatbot debería seguir funcionando sin cambios.

## Roadmap y Entregables
| Instancia | Fecha | Entregables |
| --- | --- | --- |
| Kick-off | 21 de Abril |
| Primer Entrega | 26 de Mayo | [Entrega de tarjetas CRC/Diagrama de Clases.](https://github.com/ucudal/Proyecto_PII_2022_1/blob/main/Entregas/Entrega1.md)<sup>1</sup>
| Segunda Entrega | 21 de Junio | [Entrega](https://github.com/ucudal/Proyecto_PII_2022_1/blob/main/Entregas/Entrega2.md) de [User Stories](https://es.wikipedia.org/wiki/Historias_de_usuario) implementadas. Las historias de usuario deberán ser implementadas mediante casos de prueba.
| Entrega Final |5 de Julio<sup>2</sup>|

<sup>1</sup> Cada equipo designará qué integrante del equipo desarrollará cada clase. La distribución debe contemplar número de clases y responsabilidades. Se evaluará que cada integrante trabaje en una rama independiente y que se integren los cambios mediante pull requests.

<sup>2</sup> Las entregas serán hasta las 23:59 del día indicado.