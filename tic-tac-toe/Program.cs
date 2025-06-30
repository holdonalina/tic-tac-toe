string[] board = new string[9];
for (int i = 0; i < board.Length; i++)
  board[i] = (i + 1).ToString();
static void DrawBoard(string[] board)
{
  Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
  Console.WriteLine("---------");
  Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
  Console.WriteLine("---------");
  Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
}
DrawBoard(board);

bool playerXTurn = true;
bool gameEnded = false;

while (!gameEnded)
{
  string currentPlayer = playerXTurn ? "X" : "O";
  Console.WriteLine($"Player {currentPlayer}, enter a number (1-9):");

  string input = Console.ReadLine();
  int choice;

  if (!int.TryParse(input, out choice) || choice < 1 || choice > 9)
  {
    Console.WriteLine("Invalid input. Try again");
    continue;
  }

  int index = choice - 1;

  if (board[index] == "X" || board[index] == "O")
  {
    Console.WriteLine("That spot is already taken. Try again");
    continue;
  }

  board[index] = currentPlayer;

  DrawBoard(board);

  playerXTurn = !playerXTurn;

  if (CheckForWin(board))
  {
    Console.WriteLine($"Player {currentPlayer} wins!");
    gameEnded = true;
    continue;
  }

  bool isDraw = true;
  for (int i = 0; i < board.Length; i++)
  {
    if (board[i] != "X" && board[i] != "O")
    {
      isDraw = false;
      break;
    }
  }

  if (isDraw)
  {
    Console.WriteLine("It's a draw!");
    gameEnded = true;
  }
}

static bool CheckForWin(string[] board)
{
  int[,] winCombos = new int[,]
  {
        {0, 1, 2},
        {3, 4, 5},
        {6, 7, 8},
        {0, 3, 6},
        {1, 4, 7},
        {2, 5, 8},
        {0, 4, 8},
        {2, 4, 6}
  };

  for (int i = 0; i < 8; i++)
  {
    int a = winCombos[i, 0];
    int b = winCombos[i, 1];
    int c = winCombos[i, 2];

    if (board[a] == board[b] && board[b] == board[c])
    {
      return true;
    }
  }

  return false;

}

