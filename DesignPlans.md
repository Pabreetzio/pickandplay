#Design Plans
##DeclareConstants
- size of board
- Zero position
-current position
- Things about each piece.
	- height of each piece
	- Last position of each piece
	- Default starting positions
	

##Calculated fields
-Square size = boardsize/8
- Interpret square name to coordinates

##Functions
-Interpret/ Parse chess movement to set of coordinates - requires know positions
- interpret / parse specific movement agnostic of piece positions
- Different routes/heights: how high to move piece - Movement styles

##Set Up
enter Custom starting positions / mid-game positions.
-store custom starting positions.


##Move Entering
algebraic notation vs descriptive notation

##Translation Layers
From Notation to piece, starting square, ending square. 
From piece starting square to ending square to gcode.

#Newer Plans
##configurable
Whole solution is a a bunch of configurable pieces that work together to interpret moves
and send out the gcode commands that make the bot move.
Need default just for testing, but you can send in commands to the library to dynamically change
the default settings. 
