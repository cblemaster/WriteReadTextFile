
const int MAX_DIR_NAME_AND_FILENAME_LENGTH = 12;

Console.WriteLine("\n\nLet's write and read some text files!!!\n\n");

string root = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}";
string dirName = GetValidInputString("Enter the name for your directory folder:", $"Error: Directory input is invalid!\nDirectory is required and must be {MAX_DIR_NAME_AND_FILENAME_LENGTH} characters or fewer.\"");
string fileName = GetValidInputString("Enter the name for your file:", $"Error: Filename input is invalid!\nFilename is required and must be {MAX_DIR_NAME_AND_FILENAME_LENGTH} characters or fewer.");
string rootAndDir = $"{root}\\{dirName}";
string fullPath = $"{root}\\{dirName}\\{fileName}.txt";

if (!Directory.Exists(rootAndDir))
{
    _ = Directory.CreateDirectory(rootAndDir);
}
if (!File.Exists(fullPath))
{
    _ = File.Create(fullPath);
}

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
        input = Console.ReadLine()?.Trim();
    }

    return input;

    bool InputStringIsValid(string s) => !string.IsNullOrWhiteSpace(s) && s.Length <= MAX_DIR_NAME_AND_FILENAME_LENGTH;
}
