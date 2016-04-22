# Snake
Snake game in Unity 5.

### General Walkthrough

1. The [GameBootstrap](/Assets/Scripts/Game/GameBootstrap.cs) instantiates `GameContext`.

2. The [GameContext](/Assets/Scripts/Game/Config/GameContext.cs) then binds various signals to various commands. Namely:
  - `BindDataSignal` to `BindDataCommand`
  - `BindInputHandlerSignal` to `BindInputHandlerCommand`
  - `SetupMainMenuSignal` to `SetupMainMenuCommand`
  - `StartGameSignal` to `StartGameCommand`
  - `GameOverSignal` to `GameOverCommand`

3. Upon launch, the `GameContext` dispatches the `BindDataSignal` and the `ShowSignal` to show the main menu.

4. The [BindDataCommand](/Assets/Scripts/Game/Controller/BindDataCommand.cs) is invoked which then binds the interfaces of `Grid`, `Pellet`, `Snake` and `Game` to the configured values which it retrieves from the [IDataConfigService](/Assets/Scripts/Game/Interface/IDataConfigService.cs) which in turn is bound to [LocalDataConfigService](/Assets/Scripts/Game/Service/LocalDataConfigService.cs) which loads the data config from the locally present [DataConfig](/Assets/Resources/DataConfig.json) JSON file, and dispatches it back to the command for it to use.

5. The `ShowSignal` is retrieved by the [GameMediator](/Assets/Scripts/Game/View/GameMediator.cs) which then shows the screen based on the value that the signal was dispatched with, in this case - the main menu.

6. When the `GameMediator` invokes the method to show the main menu, it also dispatches the `SetupMainMenuSignal`.

7. The [SetupMainMenuCommand](/Assets/Scripts/Game/Controller/SetupMainMenuCommand.cs) is invoked by the `SetupMainMenuSignal`, whose sole purpose is to set up the high score if its available, by dispatching the `SetHighScoreSignal`.

8. The [MainMenuMediator](/Assets/Scripts/Game/View/MainMenuMediator.cs) which is active by now listens for the `SetHighScoreSignal`, and if it has been dispatched by the `SetupMainMenuCommand`, shows the high score text label in the main menu, else it keeps it in the deactive state.

9. From here on, with the main menu showing, the user has three options to choose from:
  - **Play**
    + This option lets the user play the game.
  - **Bounded AI**
    + This option lets the AI control the game with a bounded pathfinder.
  - **Unbounded AI**
    + This option lets the AI control the game with an unbounded pathfinder.

10. Whichever option is picked from the above list, the `BindInputHandlerSignal` is dispatched with the proper type, and the [BindInputHandlerCommand](/Assets/Scripts/Game/Controller/BindInputHandlerCommand.cs) is invoked. This properly binds the `IInputHandler` with the right handler, whether it be [KeyboardHandler](/Assets/Scripts/Game/Model/InputHandler/KeyboardHandler.cs) if the user is on PC, or the [SwipeHandler](/Assets/Scripts/Game/Model/InputHandler/SwipeHandler.cs) if the user is on some mobile device, or the [AIHandler](/Assets/Scripts/Game/Model/InputHandler/AIHandler.cs) if an AI option is picked.

11. If the user chooses one of the two AI options, the [BoundedPathfinder](/Assets/Scripts/Game/Model/Pathfinder/BoundedPathfinder.cs) or the [UnboundedPathfinder](/Assets/Scripts/Game/Model/Pathfinder/UnboundedPathfinder.cs) are bound to the `IPathfinder` which the `AIHandler` uses to find the path for the `Snake`. Both these pathfinders inherit from the [AbstractPathfinder](/Assets/Scripts/Game/Abstract/AbstractPathfinder.cs) which implements an A* algorithm to find the optimum path.

12. Now that all values are set, the `StartGameSignal` is dispatched, and the gameplay starts. Scores are updated with the dispatch of the `UpdateScoreSignal`. The [Game](/Assets/Scripts/Game/Model/Game.cs) class holds the game loop, while the implementations of `IInputHandler` handle the input in the game appropriately.

13. When the snake collides with itself, the `GameOverSignal` is dispatched which invokes the [GameOverCommand](/Assets/Scripts/Game/Controller/GameOverCommand.cs) which resets the game and shows the after game screen.

### Input

- **Keyboard**
  + Use **W**, **A**, **S**, **D** keys to move the snake around.
  + Pressing the **Escape** key during the gameplay would bring the game back to the main menu.

- **Swipe**
  + On mobile devices, swiping **Up**, **Left**, **Down** or **Right** would get the snake moving in that direction.
  + Pressin the back button of the device during the gameplay would bring the game back to the main menu.

### AI

- **AIHandler** is the third way to control the snake. It uses one of the two implemented pathfinders to make the snake move on the grid.
- The **BoundedPathfinder** is restricted to the bounds of the grid, and doesn't move beyond the grid to come out from the other side, even if doing so would yield a shorter path for the snake to travel.
- The **UnboundedPathfinder** is not restricted to the above contraint and so this pathfinder would utilise the boundless nature of the grid to reach the pellet sooner, if such path is available.
- Both of these pathfinders implement from the **AbstractPathfinder** which carries with it the crux of the pathfinder implementation. Its the one that implements the A* algorithm.

### Game Scripts Structure
- **Game**
  - **Abstract**
    - AbstractInputHandler
    - AbstractPathfinder
    - UserInputHandler
  - **Config**
    - GameContext
    - GameSignals
  - **Controller**
    - BindDataCommand
    - BindInputHandlerCommand
    - StartGameCommand
    - SetupMainMenuCommand
    - GameOverCommand
  - **Data Containers**
    - DataConfig
    - Position
  - **Enum**
    - Direction
    - InputHandlerType
    - ShowType
  - **Interface**
    - IGrid
    - ISnake
    - IPellet
    - IGame
    - IPathfinder
    - IInputHandler
    - IRoutineRunner
    - IHighScoreService
    - IDataConfigService
  - **Model**
    - **InputHandler**
      - AIHandler
      - KeyboardHandler
      - SwipeHandler
    - **Pathfinder**
      - BoundedPathfinder
      - UnboundedPathfinder
    - Cell
    - Grid
    - Snake
    - Pellet
    - Game
    - RoutineRunner
  - **Service**
    - HighScoreService
    - LocalDataConfigService
  - **View**
    - MainMenuView
    - MainMenuMediator
    - InGameView
    - InGameMediator
    - AfterGameView
    - AfterGameMediator
    - GameView
    - GameMediator
  - GameBootstrap
