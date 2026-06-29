using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.txt";
            string outputPath = "output\\result.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string content = File.ReadAllText(inputPath);
            File.WriteAllText(outputPath, content);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to copy configuration settings from a source *.txt file to a deployment folder, using File.Exists to verify the file, Directory.CreateDirectory to ensure the output path exists, and File.ReadAllText/File.WriteAllText to preserve the content.
 * 2. When an application must read user‑provided input data stored in a plain‑text file and generate a result file in a separate output directory, handling missing files with a clear error message.
 * 3. When a batch job processes log files by reading the original log.txt, creating the target results folder if necessary, and writing an exact copy for archival or further analysis.
 * 4. When a utility script validates the presence of a required text resource before proceeding, using C# file I/O operations to gracefully abort with a console error if the file is not found.
 * 5. When a C# service migrates legacy documentation files to a new folder structure, employing File.ReadAllText and File.WriteAllText to move the content while preserving formatting and line endings.
 */