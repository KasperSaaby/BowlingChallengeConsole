## Design motivations

The following classes have been identified from the requirements:

* Game (Aggregate Root):

This is the central aggregate.
A Game controls the flow of Frames and ultimately calculates the Score.
Manage the state of the game, including whose turn it is and if the game is over.

* Frame (Entity):

Represents a single frame in the game.
Conceptual boundary for a player's turns and rolls within the game.
Encapsulates the rolls and their scores for that specific frame.

* Roll (Value Object):

Represents a single roll within a frame.
Roll represents the number of pins knocked down in a single attempt.
It doesn't have a life cycle independent of a Frame and doesn't have a unique identity.
