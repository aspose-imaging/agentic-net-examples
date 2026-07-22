using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tga";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Prepare PNG save options (alpha channel is preserved by default)
                var pngOptions = new PngOptions();

                // Save as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a game developer needs to convert legacy TGA texture files with alpha transparency to PNG for use in modern engines, this C# code with Aspose.Imaging preserves the transparent channel.
 * 2. When a web designer must process uploaded TGA logos and export them as PNGs while keeping their transparent backgrounds, the snippet shows how to load and save the images in .NET.
 * 3. When an automation script has to verify that a TGA asset exists before converting it to a PNG with the original alpha channel intact, the example demonstrates the required file checks and conversion steps.
 * 4. When a desktop application only supports PNG but receives TGA images, developers can use this code to load the RasterImage and save it as a PNG without losing transparency.
 * 5. When a CI/CD pipeline for a graphics workflow requires converting source TGA files to PNG format while preserving alpha transparency, this C# routine using Aspose.Imaging provides a reliable solution.
 */