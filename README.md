## Design motivations

The following objects have been identified from the requirements:

#### Game (Aggregate Root):

* This is the central aggregate.
* A Game controls the flow of Frames and ultimately calculates the Score.
* Manage the state of the game, including whose turn it is and if the game is over.
* Contains a collection of Frame objects (10 frames).
* Accepts rolls from a player.
* Calculates the total score for the game.

#### Frame (Entity):

* Represents a single frame in the game.
* Conceptual boundary for a player's turns and rolls within the game.
* Encapsulates the rolls and their scores for that specific frame.
* Knows if it's a strike or a spare.
* Calculates the pins knocked down within itself (base score for the frame).
* Determines if it's complete (i.e., no more rolls can be added to this frame).

#### Roll (Value Object):

* Represents a single roll within a frame.
* Roll represents the number of pins knocked down in a single attempt.
* It doesn't have a life cycle independent of a Frame and doesn't have a unique identity.

#### BonusCalculatorService

* This service will be responsible for the complex logic of calculating the bonus points for strikes and spares across frames.
* It will interact with the Game and Frame objects but won't hold state itself.
* It acts as an orchestrator for scoring.

The main focus of the design was to identify key objects and ensure that their responsibilities are properly encapsulated.
The potentially more complex logic is extracted out of the object and into stateless service(s) that can be tested independently.
