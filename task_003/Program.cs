// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

void OutputMatrix(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    Console.WriteLine("Сгенерирован двумерный массив размером " + rows + "×" + columns + ", заполненный псевдослучайными целыми числами: \n");

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write(matrix[i,j] + "\t");
        }
        Console.WriteLine("\n");
    }
}

double[] CalcAvgForEachColumn(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int sum = 0;
    double avg = 0;
    double[] averages = new double[columns];
    
    for (int i = 0; i < columns; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            sum += matrix[j, i];
        }

        avg = Convert.ToDouble(sum) / Convert.ToDouble(rows);
        double avgRnd = Math.Round(avg, 2);
        averages[i] = avgRnd; // saving results in a new array

        // Reset counters
        avg = 0;
        sum = 0;
    }
    return averages;
}

int[,] GenerateMatrix(int minDim, int maxDim, int minRange, int maxRange)
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

Console.Clear();
int[,] matrix = GenerateMatrix(3, 10, -99, 100);
double[] averages = CalcAvgForEachColumn(matrix);
OutputMatrix(matrix);
foreach (double avg in averages) Console.Write(avg + "\t");
Console.Write("<- среднее арифметическое элементов в каждом столбце \n\n");
