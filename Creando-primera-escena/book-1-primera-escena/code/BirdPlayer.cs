using Godot;
using System;

public partial class BirdPlayer : RigidBody2D
{

#region [DOC] Variables
	private int speed = 5;
	private double gravity = 9.8;
	private double _angularSpeed = Math.PI;
	private Sprite2D _sprite;
	private Label _labelLife;
	private bool _isPrinted = false;

	private int _life = 10;

#endregion


#region [DOC] Properties
	[Export]
    public int Life
    {
        get { return _life; }
        set { _life = value; }
    }
	
#endregion


	#region [DOC] Constructor
	/*
	 	Constructor de la clase BirdPlayer.
	 	Se llama cuando se crea una instancia de la clase.
	 	Se utiliza para inicializar variables y establecer el estado inicial del objeto.
	*/
	#endregion
	public BirdPlayer()
	{
		GD.Print("[BirdPlayer][ Constructor ] first events.");
	}

 	~BirdPlayer()
    {
        // Código que se ejecuta cuando el recolector de basura destruye el objeto
		GD.Print("[BirdPlayer][ Destructor ] last events.");
    }


#region [DOC] _Notification
	/*
		La función _Notification(int what) en Godot es una función especial que se llama automáticamente por el motor cuando ocurren eventos 
		internos específicos del ciclo de vida del nodo.

		No se llama periódicamente como _Process(), sino solo cuando pasa algo relevante, como cuando el nodo entra al árbol, se dibuja, 
		cambia su visibilidad, etc.

		🧩 ¿Qué es _Notification(int what)?
		Es una forma de interceptar notificaciones del sistema. Cada evento del motor envía un código entero (por ejemplo,
		NOTIFICATION_ENTER_TREE o NOTIFICATION_DRAW), que puedes capturar sobreescribiendo este método.

		📆 ¿Cuándo se llama?
		Se llama automáticamente por Godot en situaciones como:

		---------------------------------------------------------------------------------------------
		| Evento                        | Código | Descripción breve                        		|
		|-------------------------------|--------|--------------------------------------------------|
		| Nodo entra al árbol           |   10   | NOTIFICATION_ENTER_TREE. Antes de _Ready()		|
		| Nodo sale del árbol           |   11   | NOTIFICATION_EXIT_TREE. Cleanup/liberar  		|
		| Nodo está listo para procesar |   13   | NOTIFICATION_READY. Similar a _Ready()   		|
		| Se pausa la escena            |   14   | NOTIFICATION_PAUSED. Escena pausada      		|
		| Se reanuda la escena          |   15   | NOTIFICATION_UNPAUSED. Escena despausada 		|
		| Inicia el proceso por frame   |   17   | NOTIFICATION_PROCESS. Cada frame         		|
		| Cambia visibilidad            |   28   | NOTIFICATION_VISIBILITY_CHANGED. Mostrar/ocultar |
		| Comienza un nuevo frame de dibujo | 30 | NOTIFICATION_DRAW. Para dibujar cosas    		|
		| Cambia el tamaño del nodo (UI)|   40   | NOTIFICATION_RESIZED. Útil en Control    		|
		---------------------------------------------------------------------------------------------
		Estos códigos son constantes predefinidas en Godot, y puedes usarlos para identificar qué evento ocurrió.
	*/
	#endregion

	public override void _Notification(int what)
	{
		//GD.Print($"[BirdPlayer][ _Notification ] node notification: {what}");

		base._Notification(what);
		switch (what)
		{
			case (int)NotificationVisibilityChanged:
				//GD.Print("[BirdPlayer][ _Notification ][NotificationVisibilityChanged] node is visible.");
				break;
			case (int)NotificationReady:
				//GD.Print("[BirdPlayer][ _Notification ][NotificationReady] node is ready.");
				break;
			case (int)NotificationProcess:
				//GD.Print("[BirdPlayer][ _Notification ][NotificationProcess] node is processing.");
				break;
			case (int)NotificationPhysicsProcess:
				//GD.Print("[BirdPlayer][ _Notification ][NotificationPhysicsProcess] node is processing physics.");
				break;
			case (int)NotificationDraw:
				//GD.Print("[BirdPlayer][ _Notification ][NotificationDraw] node is drawing.");
				break;
			case (int)NotificationExitTree:
				//GD.Print("[BirdPlayer][ _Notification ][NotificationExitTree] node is exiting the scene tree.");
				break;
		}
	}


#region [DOC] _EnterTree
	/*
	 	Se llama cuando el nodo se añade al árbol de escenas, pero antes de que se llame a _Ready.
	 	Es útil para inicializaciones que no dependen de otros nodos o del estado del juego.
	*/
#endregion
	public override void _EnterTree()
	{
		base._EnterTree();
		// Inicializaciones tempranas o conexión de señales.
		GD.Print("[BirdPlayer][ _EnterTree ] node is entering the scene tree.");
	}

	#region [DOC] _Ready
	/*
		Al instanciar una escena conectada a la primera escena ejecutada, 
		Godot instanciará nodos hacia abajo en el árbol (haciendo llamadas _init()) 
		y construirá el árbol yendo hacia abajo desde la raíz. Esto hace que las llamadas _enter_tree() 
		caigan en cascada por el árbol. Una vez que el árbol está completo, los nodos hoja llaman a _ready. 
		Un nodo llamará a este método una vez que todos los nodos hijos hayan terminado de llamar a los suyos. 
		Esto provoca una cascada inversa que vuelve a la raíz del árbol.

		Al instanciar un script o una escena independiente, los nodos no se añaden al SceneTree en el momento de la creación, 
		por lo que no se activan las llamadas de retorno _enter_tree(). En su lugar, sólo se produce la llamada _init(). 
		Cuando la escena se añade al SceneTree, se producen las llamadas _enter_tree() y _ready().

	 	Called when the node is ready.
	 	Called when the node enters the scene tree for the first time.
	 	Se llama cuando el nodo y todos sus hijos ya han sido añadidos y están listos.
	 	Es el momento indicado para acceder a otros nodos, inicializar variables que dependan del árbol de escenas o preparar la lógica del juego.
	*/
	#endregion
	public override void _Ready()
	{
		base._Ready();
		// Inicializaciones tardías o conexiones de señales.
		GD.Print("[BirdPlayer][ _Ready ] node is ready.");

		_sprite = GetNode<Sprite2D>("Sprite2D");

		var parent = GetParent();
		_labelLife = parent.GetNode<Label>("LabelLife");

		if (_labelLife == null)
		{
			GD.PrintErr("[BirdPlayer][ _Ready ] LabelLife node not found.");
		}
		_labelLife.Text = $"{_sprite.GlobalPosition.X},{_sprite.GlobalPosition.Y}";

		/*
			var timer = new Timer();
			timer.Autostart = true;
			timer.WaitTime = 0.5;
			AddChild(timer);
			timer.Timeout += () => GD.Print("This block runs every 0.5 seconds");
		*/

	}

#region [DOC] _Draw
	/*
		La función _Draw() en Godot, ya sea en GDScript o C#, es parte del ciclo de vida de los nodos que heredan de CanvasItem, 
		como Control, Node2D, etc.

		🎯 ¿Qué hace _Draw()?

		Es el callback para dibujar contenido personalizado (líneas, círculos, texto, etc.) directamente en el nodo. 
		Pero no se llama automáticamente cada frame como _Process(). 
		Solo se ejecuta cuando:
	    El nodo necesita redibujarse (por cambios de tamaño, visibilidad, etc.).
	    Se llama explícitamente a Update() (GDScript) o Update() (C#).

		_Draw() no se llama al iniciar a menos que se haya modificado el nodo o se haya llamado a Update() manualmente.
		Cada vez que llamas a Update(), Godot agenda una redibuja para el siguiente frame, y entonces llama a _Draw().
	*/
#endregion



	public override void _Draw()
	{
		base._Draw();
		GD.Print("[BirdPlayer][ _Draw ] node is drawing.");
	}


#region [DOC] _IntegrateForces
	/*
	 	Funcionalidad:
	 	Se utiliza si activas la opción de custom integrator (CustomIntegrator = true) en tu RigidBody2D, 
	 	lo que te permite personalizar la integración de las fuerzas antes de que el motor de física actualice la posición y la velocidad del cuerpo.

		En Godot, cuando usas el nodo RigidBody3D o RigidBody2D, el método _IntegrateForces(PhysicsDirectBodyState state) es 
		una parte especial del ciclo de simulación física que te permite intervenir directamente en el proceso de integración de 
		fuerzas y movimiento del cuerpo rígido.

		🌀 Ciclo de Vida de _IntegrateForces()
		¿Cuándo se ejecuta?

		_IntegrateForces() se ejecuta durante el paso de simulación física interno del motor de física, es decir:

			Antes de que el motor aplique los resultados de simulación al RigidBody.

			En cada frame de física, al igual que _PhysicsProcess().

			🔧 _Sí se ejecuta antes de que tú veas los cambios de posición en _PhysicsProcess().
	 */
#endregion
	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{

		GD.Print($"[BirdPlayer][ _IntegrateForces ] node is integrating forces. State:");

		if (Input.IsActionPressed("ui_right"))
		{
			GD.Print($"[BirdPlayer][ _IntegrateForces ] ui_right.");
		}
	}


#region [DOC] _PhysicsProcess
	/*
		Utilice _physics_process() cuando necesite un tiempo delta entre fotogramas independiente de la velocidad de fotogramas. 
		Si el código necesita actualizaciones consistentes en el tiempo, independientemente de lo rápido o lento que avance el tiempo, 
		este es el lugar adecuado. Las operaciones cinemáticas y de transformación de objetos recurrentes deberían ejecutarse aquí.	
	 */
#endregion
	public override void _PhysicsProcess(double delta)
	{
		GD.Print($"[BirdPlayer][ _PhysicsProcess ] node is processing. Delta: {delta}");

		if (Input.IsActionPressed("ui_right"))
		{
			GD.Print($"[BirdPlayer][ _PhysicsProcess ] ui_right.");
			Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
			

		}
	}


#region [DOC] _Process
	/*  
	 	Called before that _Input function. 
		Detectar la entrada del usuario en cada fotograma, se activa la accion justo al detectar.
	 	Utilice _process() cuando necesite un tiempo delta entre fotogramas dependiente de la velocidad de fotogramas. 
		Si el código que actualiza datos de objetos necesita actualizarse tan a menudo como sea posible, 
		este es el lugar adecuado. Las comprobaciones lógicas recurrentes y el almacenamiento de datos en caché a 
		menudo se ejecutan aquí, pero todo depende de la frecuencia con la que se necesite que se actualicen las evaluaciones. 
		Si no es necesario que se ejecuten en cada fotograma, otra opción es implementar un bucle Timer-timeout.
	*/
#endregion
	public override void _Process(double delta)
	{
		GD.Print($"[BirdPlayer][ _Process ] node is processing. Delta: {delta}");
		GD.Print($"[BirdPlayer][ _Process ] node position: {_sprite.Position.X},{_sprite.Position.Y}");
		GD.Print($"[BirdPlayer][ _Process ] node position: {_sprite.GlobalPosition.X},{_sprite.GlobalPosition.Y}");

		// Update the label with the current position of the bird.
		_labelLife.Text = $"{_sprite.GlobalPosition.X},{_sprite.GlobalPosition.Y}";

		// Logica de rotación del pájaro.
		if (Input.IsActionPressed("ui_up"))
		{
			// Rota el pájaro hacia arriba.
			Rotation += (float)_angularSpeed * (float)delta;
			GD.Print($"[BirdPlayer][ _Process ] ui_up.");
		}
		else if (Input.IsActionPressed("ui_down"))
		{
			// Rota el pájaro hacia abajo.
			//_sprite.Rotation -= (float)_angularSpeed * (float)delta;
			GD.Print($"[BirdPlayer][ _Process ] ui_down.");
		}

		// Lógica de movimiento del pájaro.
		if (Input.IsActionPressed("ui_right"))
		{
			// Mueve el pájaro a la derecha.
			Vector2 velocity = Vector2.Right * (float)speed; 
			Position += velocity * (float)delta;
			_sprite.FlipH = false;
			GD.Print($"[BirdPlayer][ _Process ] ui_right.");
		}
		else if (Input.IsActionPressed("ui_left"))
		{
			// Mueve el pájaro a la izquierda.
			//Vector2 velocity = Vector2.Left * (float)speed; 
			//_sprite.Position += velocity * (float)delta;
			//_sprite.FlipH = true;
			GD.Print($"[BirdPlayer][ _Process ] ui_left.");
		}

	}


#region [DOC] _Input
	/*
		Aunque es posible, para conseguir el mejor rendimiento, uno debería evitar hacer comprobaciones de entrada durante estas 
		llamadas de retorno. _process() y _physics_process() se dispararán en cada oportunidad (no «descansan» por defecto). 
		Por el contrario, *_input() se activará sólo en los fotogramas en los que el motor haya detectado la entrada.

		IsActionPressed(action, exactMatch = false)

			Qué comprueba: si la acción está siendo mantenida pulsada.

			Cuándo es true: en cada frame/tick mientras la entrada siga abajo.

			Uso típico: movimientos continuos, desplazamientos, mantener fuego de armas.

		IsActionJustPressed(action, exactMatch = false)

			Qué comprueba: si la acción acaba de empezar a pulsarse.

			Cuándo es true: solo en el primer frame/tick de la pulsación.

			Uso típico: disparar un proyectil, abrir un menú, un “click” puntual.

		IsActionJustReleased(action, exactMatch = false)

			Qué comprueba: si la acción acaba de soltarse.

			Cuándo es true: solo en el frame/tick en que el botón/tecla se libera.

			Uso típico: animaciones de fin de pulsación, medir duración de la pulsación.

		GetActionStrength(action, exactMatch = false)

			Qué devuelve: un float entre 0 y 1 con la intensidad de la acción.

				Ejes analógicos: proporción respecto al “dead zone”.

				Teclas/botones digitales: 0 o 1.

			Uso típico: control suave de máquinas, velocidad variable según presión.

		GetActionRawStrength(action, exactMatch = false)

			Qué devuelve: un float entre 0 y 1 con la intensidad cruda, sin aplicar dead zone.

			Uso típico: casos muy específicos donde necesites el valor directo del eje, sin filtrado.
	*/
#endregion
	public override void _Input(InputEvent e)
	{
		GD.Print($"[BirdPlayer][ _Input ] node is processing input events. {e.AsText()}");
		
		// To stop the event from propagating to other nodes.
		//GetViewport().SetInputAsHandled();

		if (e is InputEventMouseButton mouseEvent)
		{
			GD.Print("[BirdPlayer][ _Input ] mouse button event at ", mouseEvent.Position);
		}
	}


#region [DOC] _UnhandledInput
	/*
	 *  Called after _Input function.
	 *	
	 *	Se llama cuando el nodo no maneja un evento de entrada.
	 *	Se utiliza para manejar eventos que no han sido procesados por otros nodos.
	 *	Por ejemplo, si el evento no es consumido por el nodo padre o por otros nodos en la jerarquía.
	 *	Se puede usar para manejar eventos de entrada globales o para implementar lógica personalizada.
	*/
#endregion
	public override void _UnhandledInput(InputEvent @event)
    {

		GD.Print($"[BirdPlayer][ _UnhandledInput ] node is processing unhandled input events. {@event.AsText()}");

		if (@event.IsActionPressed("ui_right"))
		{
			GD.Print($"[BirdPlayer][ _UnhandledInput ] ui_right.");
		}

		/*
		if (@event is InputEventKey eventKey)
			if (eventKey.Pressed && eventKey.Keycode == Key.Escape)
				GetTree().Quit();
		*/
	}


#region [DOC] _ExitTree
	/*
		Called when the node is removed from the scene tree.
		Se utiliza para limpiar recursos, desconectar señales o realizar cualquier tarea de limpieza necesaria antes de que el nodo sea destruido.
	*/
#endregion

	public override void _ExitTree()
	{
		base._ExitTree();
		// Cleanup or disconnection of signals.
		GD.Print("[BirdPlayer][ _ExitTree ] node is exiting the scene tree.");
	}
}

#region Documentation
/*
	                    Order of events in Godot:

						[ Constructor ]
						[[ _Notification ]] Ejecutada varias veces.
						[ _EnterTree ]
						[ _Ready ] 
						[ _IntegrateForces ]
						[ _PhysicsProcess ] Delta fijo
						[ _Draw ] 
						[ _Process ] Delta variable

						[ _Input ] 
						[ _UnhandledInput ] 
						[ _InputEventGUI ] 
						[ _UnhandledInputEventGUI ]

						
						LOOP:
						[ _PhysicsProcess ] Delta fijo
						[ _Process ] 		Delta variable
						[ _Process ] 		Delta variable
						[ _Process ] 		Delta variable
						[ _PhysicsProcess ] Delta fijo
						[ _Process ] 		Delta variable
						[ _Process ] 		Delta variable
						[ _PhysicsProcess ] Delta fijo

						When keyboard or mouse events are detected, the following functions are called:

						[ _InputEvent ] 
						[ _UnhandledInputEvent ] 
						[ _InputEventGUI ] 
						[ _UnhandledInputEventGUI ] 

						When the node is removed from the scene tree:

						[ _ExitTree ] 

						When the node is drawn on the screen:

						[ _Draw ] 

						When a notification is received:

						[ _Notification ]



*/
#endregion