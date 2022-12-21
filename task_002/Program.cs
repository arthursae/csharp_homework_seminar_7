// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

// 17 -> такого числа в массиве нет

void OutputMatrixAndMarkedPosition(int[,] matrix, int searchRow, int searchColumn)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    if (searchRow < matrix.GetLength(0) && searchColumn < matrix.GetLength(1))
    {
        int elementValue = matrix[searchRow, searchColumn];
        //Console.WriteLine("Значение элемента, находящегося в " + searchRow + "-й строке и " + searchColumn + "-м cтолбце, равно = " + elementValue);
        Console.WriteLine("Позиция искомого элемента выделена квадратными скобками [" + elementValue + "]: \n");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (i == searchRow && j == searchColumn)
                {
                    Console.Write("[" + matrix[i,j] + "]\t");
                }
                else
                {
                    Console.Write(matrix[i,j] + "\t");
                }
            }
            Console.WriteLine("\n");
        }
    }
    else
    {
        Console.WriteLine("Значения позиций элемента находятся за пределами данного массива!");
    }
}

int[,] Generate2DArray(int minDim, int maxDim, int minRange, int maxRange)
{
    int rows = new Random().Next(minDim, maxDim);
    int columns = new Random().Next(minDim, maxDim);
    int[,] dummy2DArray = new int[rows,columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            dummy2DArray[i,j] = new Random().Next(minRange,maxRange); 
        }
    }
    return dummy2DArray;
}

int GetUserInputData(string msg)
{
    Console.Write(msg);
    string userInput = Console.ReadLine();

    if (Int32.TryParse(userInput, out _))
    {
        int num = Convert.ToInt32(userInput);
        return (num >= 0) ? num : GetUserInputData(msg);
    }
    else
    {
        Console.WriteLine("Неправильный тип данных, повторите ввод!");
        return GetUserInputData(msg);
    }
}

Console.Clear();
int[,] matrix = Generate2DArray(3, 10, 1, 100);
int rows = matrix.GetLength(0);
int columns = matrix.GetLength(1);
Console.WriteLine("Сгенерирован двумерный массив " + rows + "x" + columns + ", заполненный псевдослучайными целыми числами.");
int searchRow = GetUserInputData("Введите позицию строки от 0 до " + (rows - 1) + ": ");
int searchColumn = GetUserInputData("Введите позицию столбца от 0 до " + (columns - 1) + ": ");
OutputMatrixAndMarkedPosition(matrix, searchRow, searchColumn);
