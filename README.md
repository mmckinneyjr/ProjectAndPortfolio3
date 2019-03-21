 ![header](misc/gitPortHeader.png) 
This repository is a collection of my work from Project and Portfolio III
<br>
<br>
> ### Code Exercise 01: Event Handlers
> This code provides the following:<br>
Two (2) columns (ListBoxes), The ability to enter items into a form that in turn sends that data back to the appropriate list (using a custom event handler).
The ability for the user to move an item between the columns. The ability for the user to delete an individual item from both columns. The ability for the user to edit an individual item from either column.
The ability for the user to save a list that can be loaded back into the app. The ability to load the saved list back into the app. The ability to save the list in a format that the user can print and hand to someone.

> Load List, Save List (As XML data), Print List, and Exit.  A mechanism allowing the user to load the apps list data. An Exit command to gracefully quit the application

> All menu commands have appropriate shortcut keys (CTRL+L, CTRL+S, CTRL+Q)
<br><br><br><br>

> ### Code Exercise 02: Database Connectivity
> This application contains a database. The application passes information to and from the database, ie: the database updates when the ListView is updated. It has the ability to add new records. Each of the fields is also validated. (Names cannot contain numbers and number fields cannot contain letters.) Icon (ImageList) are assigned to each record. The user can edit individual records as well as delete individual records. The user can has the ability to move through the records and lastly the user can save the records as a list that can be printed.
<br><br><br><br>

> ### Code Exercise 03: Tic Tac Toe
> This application is a Tic Tac Toe game. 
> Logic:<br><br> File Menu:<br>
The File menu contains the following commands: Load Game, Save Game, and Exit. The logic allows the user to save and load a game as XML data. A mechanism exists that will not allow the user to load anything except TicTacToe data. The Exit command gracefully quits the application. All menu commands have appropriate shortcut keys (CTRL+L, CTRL+S, CTRL+Q)
<br><br>View Menu:<br>The View menu contains two selections: Blue and Red. By default, the Blue command is selected. Selecting red changes the command which is checked and changes the color of the images on any buttons already selected during play. (That is, any blue X’s and O’s become red X’s and O’s, the Blue command is unchecked and the Red command is checked if the user selects Red on the View menu and vice versa.)
<br><br>New Game button:<br>Clicking the New Game button on the toolStrip allows the players to begin a new game. It clears the board without reloading the Form.
<br><br>Game play:<br>The user is able to pick the starter (X or O) from the Select menu. This means the user selects X or O, clicking a button will assign the choice to the first button selected. Once a location on the board is filled, it cannot be overridden. The turns are alternate; that is, an X or an O cannot be played consecutively. It is X, O, X, O or O, X, O, X until the game is complete. The game auto-checks the board after each play to determine when a user has a legal three-in-a-row and displays a messageBox to indicate who won (X or O). The game also is able to tell when all buttons have been selected and if a stalemate (draw) exists.