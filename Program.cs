// 1. Создать репозиторий на GitHub - почему нельзя использовать старый? :( это же типа имя придумывать ещё
// 2. Нарисовать блок-схему алгоритма (можно обойтись блок-схемой основной содержательной части, если вы выделяете её в отдельный метод) - мех, потом как-нибудь
// 3. Снабдить репозиторий оформленным текстовым описанием решения (файл README.md) - позже
// 4. Написать программу, решающую поставленную задачу
// 5. Использовать контроль версий в работе над этим небольшим проектом (не должно быть так, что всё залито одним коммитом, как минимум этапы 2, 3, и 4 должны быть расположены в разных коммитах) - ну окей :\

// Задача: Написать программу, которая из имеющегося массива строк формирует новый массив из строк, 
// длина которых меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры, 
// либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

// функция для заполнения массива строк
string[] StringsInput(int n)
{
    string[] str = new string[n];
    for (int i = 0; i < n; i++)
    {
        Console.Write($"Введите {i + 1}-ую строку: ");
        str[i] = Console.ReadLine();
    }
    Console.Clear();
    PrintText("Ваш массив: ", str, n);
    return str;
}

// функция для вывода массива
void PrintText(string text, string[] arr, int n)
{
    Console.WriteLine($"{text}");
    for (int i = 0; i < n; i++)
        Console.Write($"{arr[i]}\t");
    Console.WriteLine();
}

// делаем новый массив
string[] Only3OrLessSymbols(string[] primaryArray, int n1)
{
    int n2 = 0;
    for (int i = 0; i < n1; i++)
        if (primaryArray[i].Length <= 3) n2++;
    string[] resultArray = new string[n2];
    int j = 0;
    for (int i = 0; i < n2; i++)
    {
        while (primaryArray[j].Length > 3 && j <= n1) j++;
        resultArray[i] = primaryArray[j];
        j++;
    }
    return resultArray;
}

int n = Positive("введите количество строк в массиве: ");
string[] str = StringsInput(n);
string[] str2 = Only3OrLessSymbols(str, n);
Console.WriteLine();
PrintText("Новый массив: ", str2, str2.GetLength(0));

// фукнция для ввода числа
double InputNumber(string text)
{
    Console.Write(text);
    string? inpTemp;
    while (true)
    {
        inpTemp = Console.ReadLine();
        double check;
        if (Double.TryParse(inpTemp, out check)) break;
        else Console.Write("Это не число, попробуйте ещё раз: ");
    }
    return Convert.ToDouble(inpTemp);
}

// функция для ввода целого положительного числа
int Positive(string text)
{
    double number;
    while (true)
    {
        number = InputNumber(text);
        if (number == Math.Round(number) && number > 0) break;
        else Console.WriteLine("Введите целое положительное число.");
    }
    return Convert.ToInt32(number);
}