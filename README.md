# Game-Fifteen

A sliding puzzle game.This is our teamwork project for the High Quality Code course @ TelerikAcademy.

## Refactoring

1. Rename  IfOutOfMAtrix to IsOutOfMatrix.
2. Rename IfEqualMatrix to IsEqualMatrix.
3. Rename IfGoesToBoard to IsGoseOnBoard.
4. Rename tocki to Points.
5. Rename pe4at to Print.
6. Remove comment // pozdravi na vsi4ki ot pernik!
7. Removed all unneeded empty lines,in the methods:
GenerateMatrix,IsOutOfMatrix,MoveEmptyCell,PrintMatrix,
IsEqualMatrix,Print,ExecuteComand.
8. Inserted empty lines between the methods.
9. Make methods GenerateMatrix, PrintMatrix, PrintWelcome,
MainAlgorithm internal.
10. Make constant MatrixLength private.
11. Add constant HorizontalBorder and VerticalBorder.
12. Make class  MainGameFifteen and move Main method in it.
13. Intruduce static class Constants
14. Renamed solution and project name
15. Introduced GameFifteen.UI.Console project
16. Changed the type of GameFifteen.Logic project to class library and deleted the MainGameFifteen class from it
17. Moved the logic to GameFifteen.Logic folder
18. Moved static field Random randomNumber to local variable in GenerateMatrix method
19. Changed the solution platform to 'Any CPU' to avoid the warning for possible platform incompatibility
20. Removed unnecessary for loops in GenerateMatrix method
21. Renamed method GenerateMatrix to ShuffleMatrix
22. Moved the calling of ShuffleMatrix, PrintWelcome and PrintMatrix to MainAlgorithm
23. Moved static field scoreboard to MainAlgorithm
24. Introduced Engine class
25. Moved logic of MainAlgorithm to Engine.Run method
26. Intruduced IPrinter, Printer and Validator
27. Introduced IReader and Reader
28. Removed PrintMatrix method
29. Inlined ExecuteComand method in Engine.Run, still needs refactoring
30. System.Console dependency removed from Engine
31. Extracted Scoreboard class, needs refactoring
32. Refactor Scoreboard
33. Refactor Scoreboard