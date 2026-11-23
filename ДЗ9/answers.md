
Часть 1

Задача 1

а) При стандартной сериализации в JSON попадут только Name и Score, так как они являются публичными свойствами с get и set.
Поле secretCode не попадёт в JSON, т.к. оно приватное.
Поле IsAlive не попадёт в JSON, т.к. по умолчанию System.Text.Json не сериализует обычные поля.

б) Чтобы secretCode попал в JSON, но остался приватным, можно добавить публичное свойство, которое возвращает его значение:

private int secretCode = 42;
public int SecretCode => secretCode;

в) 

1: public bool IsAlive { get; set; }
2: [JsonInclude]
public bool IsAlive;
p.s.: для второго подключить допом System.Text.Json.Serialization

Задача 2

а)

public class Game
{
    public string Title { get; set; } = "";
    public int Year { get; set; }
    public double Rating { get; set; }
    public string[] Genres { get; set; } = Array.Empty<string>();
    public bool IsMultiplayer { get; set; }
}

б) По умолчанию System.Text.Json учитывает регистр букв при десериализации. Поэтому "Title" и "title" считаются разными именами, и свойство Title не получает значение из JSON.

Чтобы исправить это, можно установить PropertyNameCaseInsensitive = true:

var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};

Game? game = JsonSerializer.Deserialize<Game>(json, options);

в) Да, строка [1, "hello", true, null] является валидным JSON. В JSON массив может содержать элементы разных типов.

В C# такую строку можно десериализовать в массив JsonElement[].

JsonElement[]? data = JsonSerializer.Deserialize<JsonElement[]>(json);

Для использования JsonElement и JsonSerializer необходимо подключить System.Text.Json.

Задача 3

1. File, т.к. файл небольшой и его нужно прочитать целиком. Метод File.ReadAllText() позволяет сделать это одной строкой кода.
2. File, т.к. при автосохранении можно просто записывать все данные игрового персонажа в файл с помощью File.WriteAllText(). Это удобно для небольших файлов сохранений.
3. FileStream, т.к. лог-файл может быть очень большим. Он позволяет дописывать данные постепенно, не загружая весь файл в память.
4. File, т.к. он содержит готовые методы File.Exists() для проверки существования файла и File.ReadAllText() для чтения его содержимого.
5. FileStream, т.к. он позволяет переместиться к нужной позиции в файле с помощью Seek() и изменить только необходимые 10 байт без перезаписи всего файла.

