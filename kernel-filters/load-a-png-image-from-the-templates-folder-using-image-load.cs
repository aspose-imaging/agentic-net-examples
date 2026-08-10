// HOW-TO: Load PNG Image from Templates Folder and Save with Aspose Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "templates/sample.png";
            string outputPath = "output/loaded.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image using Aspose.Imaging.Image.Load
            using (Image image = Image.Load(inputPath))
            {
                // Optionally perform processing here

                // Save the loaded image to the output path
                image.Save(outputPath);
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
 * 1. When you need to read a PNG template, optionally edit it, and write the result to an output folder in a C# application.
 * 2. When you want to confirm that a required PNG file exists before performing any image processing in a batch workflow.
 * 3. When you are generating dynamic graphics and must load a base PNG from a resources or templates directory.
 * 4. When you must automatically create the destination directory to ensure the saved image does not cause a file‑system error.
 * 5. When you need to handle image loading and saving exceptions gracefully in a .NET service that works with PNG files.
 */
