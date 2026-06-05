using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "templates/sample.png";
        string outputPath = "output/loaded.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image using Aspose.Imaging.Image.Load
            using (Image image = Image.Load(inputPath))
            {
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
 * 1. When a developer needs to load a template PNG from a resources folder, verify the file exists, and save a copy to an output directory for further processing.
 * 2. When building a batch image conversion tool that reads PNG files from a predefined templates folder, uses Aspose.Imaging.Image.Load to open them, and writes the result to an output path.
 * 3. When creating a web service that generates dynamic graphics by loading a base PNG template, modifying it later, and storing the intermediate image on the server.
 * 4. When implementing automated testing that verifies PNG assets are correctly loaded and saved without corruption using Aspize.Imaging in a C# test suite.
 * 5. When developing a desktop application that needs to ensure the output directory exists before loading a PNG template and saving a processed version for user download.
 */