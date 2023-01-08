char symbol = 'v';
int size = 0;
int row = int.Parse(Console.ReadLine());
int col = int.Parse(Console.ReadLine());
char[,] matrix = new char[row, col];
var areas = new List<Area>();

for (int i = 0; i < row; i++)
{
    var items = Console.ReadLine();

    for (int j = 0; j < col; j++)
    {
        matrix[i, j] = items[j];
    }
}

for (int i = 0; i < row; i++)
{
    for (int j = 0; j < col; j++)
    {
        ExploreArea(i, j);

        if (size != 0)
        {
            areas.Add(new Area { Row  = i, Col = j, Size = size});
        }
    }
}

areas = areas.OrderByDescending(x => x.Size)
            .ThenBy(x => x.Row)
            .ThenBy(x => x.Col)
            .ToList();

Console.WriteLine($"Total areas found: {areas.Count}");

for (int i = 0; i < areas.Count; i++)
{
    var area = areas[i];
    Console.WriteLine($"Area #{i+1} at ({area.Row}, {area.Col}), size: {area.Size}");
}


void ExploreArea(int row, int col)
{
    if (IsOutSide(row, col) || IsWall(row, col) || IsVisited(row, col))
    {
        return;
    }

    size += 1;
    matrix[row, col] = symbol;

    ExploreArea(row - 1, col);
    ExploreArea(row + 1, col);
    ExploreArea(row, col - 1);
    ExploreArea(row, col + 1);
}

bool IsVisited(int row, int col)
{
    return matrix[row, col] == symbol;
}

bool IsWall(int row, int col)
{
    return matrix[row, col] == '*';
}

bool IsOutSide(int row, int col)
{
    return row < 0 | col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1);
}

class Area
{
    public int Row { get; set; }
    public int Col { get; set; }
    public int Size { get; set; }
}