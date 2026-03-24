using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.avif";
        string outputPath = "output\\processed.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        throw new NotSupportedException("AVIF format is not supported by Aspose.Imaging.");
    }
}