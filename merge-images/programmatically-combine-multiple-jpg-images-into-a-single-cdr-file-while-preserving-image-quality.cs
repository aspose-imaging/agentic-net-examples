using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputFiles = new string[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Verify each input file exists
        foreach (string inputPath in inputFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Hardcoded output CDR file
        string outputPath = @"C:\Combined\combined.cdr";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the JPG files
        using (Image multipageImage = Image.Create(inputFiles))
        {
            // Save the multipage image as a CDR file
            multipageImage.Save(outputPath);
        }
    }
}