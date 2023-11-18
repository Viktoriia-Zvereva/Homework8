void FillArray(int[,] matrix, int minValue = -9, int maxValue = 9)
{
    maxValue ++;
    Random random = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = random.Next(minValue, maxValue);
        }
    }
}

void PrintArray(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}\t"); //t - Табуляция для ровности вывода столбцов
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int Input(string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

void Task54()
{
    //Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы
    //каждой строки двумерного массива.
    Console.WriteLine("Задача 54");

    int rows = Input("Введите количество строк матрицы: ");
    int columns = Input("Введите количество столбцов матрицы: ");
    
    int[,] matrix = new int[rows, columns];

    FillArray(matrix, 1, 20);
    PrintArray(matrix);

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(1) - 1 - j; k++)
            {
                if (matrix[i, k] < matrix[i, k + 1])
                {
                    int temp = matrix[i, k];
                    matrix[i, k] = matrix[i, k + 1];
                    matrix[i, k + 1] = temp;
                }
            }
        }
    }
        PrintArray(matrix);
        Console.WriteLine();
}

int SumInRow(int[,] matrix, int row)
{
    int sum = 0;
    int columns = matrix.GetLength(1);
    for(int j = 0; j < columns; j ++) sum += matrix[row, j];
    return sum;
}

void Task56()
{
    //Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку 
    //с наименьшей суммой элементов.
    Console.WriteLine("Задача 56");

    int rows = Input("Введите количество строк матрицы: ");
    int columns = Input("Введите количество столбцов матрицы: ");
    int[,] matrix = new int[rows, columns];
    FillArray(matrix);
    PrintArray(matrix);

    int index = 0;
    int minSum = SumInRow(matrix, index);

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int sum = SumInRow(matrix, i);

        if (sum < minSum)
        {
            minSum = sum;
            index = i;
        }
    }
    Console.WriteLine($"Минимальная сумма находится в строке {index + 1} и равна {minSum} ");
}

void Task58()
{
    //Напишите программу, которая заполнит спирально массив 4 на 4.
    // Например, на выходе получается вот такой массив:
    Console.WriteLine("Задача 58");

    int rows = 4;
    int columns = 4;
    int[,] matrix = new int[rows, columns];
    int counter = 0;
    int i = 0;
    int j = 0;
    int turns = 0;

    int bias_i = 0;
    int bias_j = 1;
    int steps = columns;

    while (counter < matrix.Length)
    {
        matrix[i, j] = counter + 1;
        steps --;
        if (steps == 0)
        {
            steps = rows - 1 - turns/2;
            turns ++;
            int temp = -bias_i;
            bias_i = bias_j;
            bias_j = temp;
        }

        counter ++;

        i += bias_i;
        j += bias_j;
    }
    PrintArray(matrix);
}

Console.Clear();
Console.WriteLine("54 - Задача 54\n56 - Задача 56\n58 - Задача 58");
int TaskNumber = Input("Введите номер задачи: ");

switch(TaskNumber)
{
    case 54:
        Task54();
        break;
    case 56:
        Task56();
        break;
    case 58:
        Task58();
        break;
    default:
        Console.WriteLine("Введен неверный номер задачи");
        break;
}
