# SolitaireUndoMove
Sample project showcasing the undo move mechanic in a Solitaire game


# What I Built
I created a simplified Solitaire-style feature focusing on an Undo Move system. 
The project includes:
Card and Pile Structures: Card, Pile, and supporting enums and utilities to manage suits, numbers, and piles.
EventBus pattern to modularize different parts of the code.
Drag-and-Drop Mechanics: A centralized DragDropManager handles mouse input, card dragging, and drop detection onto pile placeholders.
Undo System: Implement the Command pattern (ICommand, MoveCommand) and a GameManager with a command stack to revert the last card move.

# What I’d Improve With More Time
Using ScriptableObject for storing serialized data, such as a sprite for each suite.
Using OOP to remove enums such as PileNames and instead define a base class for Pile.
Animations and Polish: Using dotween and particle system to enhance the visuals
Mobile Touch Support: Adapt drag-and-drop to touch gestures and multi-touch for mobile devices.
State Persistence: Save and load game state so players can resume mid-game.
Solitaire Logic 

# AI-Assisted Parts
Code Snippets: Used ChatGPT and GitHub Copilot to generate boilerplate for drag-and-drop, the Command pattern, and the Fisher–Yates shuffle.
Prompt Strategy: Prompted AI with specific requests such as:
Shuffle Utility: A Fisher–Yates shuffle implementation in ShuffleUtils to randomize a deck or any list of cards.
"Generate a Unity C# script for drag-and-drop of 2D cards using Collider2D."
"Implement the Command pattern in C# for move/undo logic."
Documentation Drafting: Drafted README sections via AI and then iterated to clarify project scope and future improvements.
