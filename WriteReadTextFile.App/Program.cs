
const int MAX_DIR_NAME_AND_FILENAME_LENGTH = 12;

string AppDataDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}";

Console.WriteLine("Hello !!!");

string UserFolderName = GetValidInputString("Enter the name for your directory folder:", $"Error: Directory input is invalid!\nDirectory is required and must be {MAX_DIR_NAME_AND_FILENAME_LENGTH} characters or fewer.");
string UserFileName = GetValidInputString("Enter the name for your file:", $"Error: Filename input is invalid!\nFilename is required and must be {MAX_DIR_NAME_AND_FILENAME_LENGTH} characters or fewer.");

string FullUserDirPath = Path.Combine(AppDataDir, UserFolderName);
string FullUserFilePath = Path.Combine(FullUserDirPath, $"{UserFileName}.txt");

CreateDirectoryIfNotExists(FullUserDirPath);
CreateFileIfNotExists(FullUserFilePath);

Console.WriteLine("\n\nLet's read and write some text files!!!\n\n");
Console.WriteLine("\nReading file...\n");
string text = TryReadFileToString(FullUserFilePath);
if (!string.IsNullOrEmpty(text))
{
    Console.WriteLine('\n' + text + '\n');
}

text = $"Hello World! The date is currently {DateTime.Now.ToLongDateString()}";

Console.WriteLine("\nWriting file...\n");
TryWriteStreamToFile(FullUserFilePath, text);

Console.WriteLine("\nGoodbye!!!\n");

string GetValidInputString(string prompt, string validationError)
{
    string input = string.Empty;
    string error = string.Empty;
    while (!InputStringIsValid(input))
    {
        if (!string.IsNullOrWhiteSpace(error))
        {
            Console.WriteLine($"\n{error}\n");
        }
        error = validationError;
        Console.WriteLine('\n' + prompt + '\n');
        input = Console.ReadLine()?.Trim() ?? string.Empty;
    }
    return input;

    bool InputStringIsValid(string s) => !string.IsNullOrWhiteSpace(s) && s.Length <= MAX_DIR_NAME_AND_FILENAME_LENGTH;
}
void CreateDirectoryIfNotExists(string FullUserDirPath)
{
    if (!Directory.Exists(FullUserDirPath))
    {
        Console.WriteLine("\nDirectory does not exist, creating directory...\n");
        _ = Directory.CreateDirectory(FullUserDirPath);
    }
}
void CreateFileIfNotExists(string FullUserFilePath)
{
    if (!File.Exists(FullUserFilePath))
    {
        Console.WriteLine("\nFile does not exist, creating file...\n");
        using FileStream _ = File.Create(FullUserFilePath);
    }
}
string TryReadFileToString(string path)
{
    try
    {
        using StreamReader sr = new(path);
        return sr.ReadToEnd();
    }
    catch (Exception)
    {
        throw;  // TODO >> error handling
    }
}
bool TryWriteStreamToFile(string path, string text)
{
    try
    {
        using StreamWriter sw = new(path, false);
        sw.Write(text);
        return true;
    }
    catch (Exception)
    {
        throw;  // TODO >> error handling
    }
}
