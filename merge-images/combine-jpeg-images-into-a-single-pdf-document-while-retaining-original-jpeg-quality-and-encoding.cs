using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input JPEG file paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Hardcoded output PDF file path
        string outputPath = @"C:\Images\Combined.pdf";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image (PDF) from the JPEG files
        using (Image pdfImage = Image.Create(inputPaths))
        {
            // Save the multipage image as PDF; format is inferred from the .pdf extension
            pdfImage.Save(outputPath);
        }
    }
}