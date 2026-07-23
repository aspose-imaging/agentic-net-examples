// HOW-TO: How To Load And Save PNG Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to read an existing PNG file, apply Aspose.Imaging transformations, and write the result back without changing its format.
 * 2. When a web service must validate that a PNG can be opened and re‑saved to ensure it isn’t corrupted before further processing.
 * 3. When automating a batch job that copies PNG assets to a new directory while preserving metadata using Aspose.Imaging in C#.
 * 4. When integrating image handling into a .NET application that requires reliable PNG loading and saving across different Windows environments.
 * 5. When writing unit tests that confirm a PNG file can be loaded and saved without throwing exceptions, proving the Aspose.Imaging library is correctly configured.
 */
