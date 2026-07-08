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
            // Hardcoded input and output folders
            string inputFolder = @"C:\InputSvgs";
            string outputFolder = @"C:\OutputBmps";

            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output BMP path (same name, .bmp extension)
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".bmp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Set BMP save options to 24‑bit color depth
                    var bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 24
                    };

                    // Save as BMP
                    image.Save(outputPath, bmpOptions);
                }
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
 * 1. When a developer needs to automatically convert a large collection of SVG icons into 24‑bit BMP files for legacy Windows applications that only accept BMP images.
 * 2. When a batch image processing pipeline must generate high‑resolution bitmap thumbnails from SVG assets stored in a folder for use in a desktop publishing workflow.
 * 3. When a migration script has to transform vector graphics from a design repository into BMP format with a specific color depth to ensure compatibility with an older printing system.
 * 4. When an automated build process needs to include BMP versions of SVG logos in a resource folder, preserving 24‑bit color fidelity for consistent rendering across devices.
 * 5. When a C# utility is required to scan a directory of SVG diagrams and export each as a BMP file so that non‑vector‑aware tools can display the images without additional plugins.
 */