// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

void OutputMatrix(double[,] dummy2DArray)
{
    int rows = dummy2DArray.GetLength(0);
    int columns = dummy2DArray.GetLength(1);
    Console.WriteLine("Сгенерирован двумерный массив размером " + rows + "×" + columns + ", заполненный псевдослучайными вещественными числами: \n");

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write(dummy2DArray[i,j] + "\t");
        }
        Console.WriteLine("\n");
    }
}

double[,] GenerateMatrix(int[] dimData, int min, int max, int roundTo)
{
    int rows = dimData[0], columns = dimData[1];
    double prgn, prgnRounded;
    double[,] dummy2DArray = new double[rows,columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            prgn = new Random().NextDouble() * (max - min) + min;
            prgnRounded = Math.Round(prgn, roundTo);
            dummy2DArray[i,j] = prgnRounded;
        }
    }
    return dummy2DArray;
}

int[] GetDimensions()
{
    int dimensions = 2;
    int[] dimData = new int[dimensions];
    
    for (int i = 0; i < dimensions; i++)
    {
        string id = (i == 0) ? "строк" : "столбцов";
        Console.Write("Введите количество " + id + ": ");
        string userInput = Console.ReadLine();

        if (Int32.TryParse(userInput, out _))
        {
            int userData = Convert.ToInt32(userInput);
            if (userData > 0)
            {
                dimData[i] = userData;
            }
            else
            {
                Console.WriteLine("Количество " + id + " должно быть больше нуля, повторите ввод!");
                return GetDimensions();
            }
        } 
        else
        {
            Console.WriteLine("Неправильный тип данных, повторите ввод!");
            return GetDimensions();
        }
    }

    return dimData;
}

Console.Clear();
int[] dimData = GetDimensions();
double[,] matrix = GenerateMatrix(dimData, -10, 10, 2);
OutputMatrix(matrix);
