namespace RealSolutionFolders.Validation;

using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;

public class FolderNameRule : ValidationRule
{
    private readonly char[] InvalidChars = { '<', '>', ':', '"', '/', '\\', '|', '?', '*'};
    private readonly List<string> ReservedNames = new() 
    { 
        "CON", "PRN", "AUX", "NUL", 
        "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
        "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
    };

    public FolderNameRule()
    {
    }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        string folderName = value.ToString();
        string errorMsg = "Empty or invalid folder name";

        return (
            // Step 1 - Check if empty
            folderName.Length == 0
            // Step 2 - Check if name consists only of whitespace
            || folderName.Trim() == string.Empty
            // Step 3 - Check if name ends with whitespace or dot (.)
            || folderName.EndsWith(" ") || folderName.EndsWith(".")
            // Step 4 - Check against reserved file/folder names
            || ReservedNames.Contains(folderName.ToUpper())
            // Step 5 - Check against invalid characters
            || folderName.IndexOfAny(InvalidChars) >= 0) 
            ? new ValidationResult(false, errorMsg) 
            : ValidationResult.ValidResult;
    }
}
