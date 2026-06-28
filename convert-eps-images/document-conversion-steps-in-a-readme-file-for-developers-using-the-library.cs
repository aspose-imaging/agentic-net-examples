using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = @"C:\temp\input.tif";
            string outputPath = @"C:\temp\output.png";
            string readmePath = @"C:\temp\README.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(readmePath));

            // Load the source TIFF image
            using (var image = (TiffImage)Image.Load(inputPath))
            {
                // Prepare PNG options
                var pngOptions = new PngOptions();

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
            }

            // Write a README file describing the conversion steps
            string readmeContent = @"README - Aspose.Imaging Conversion Steps

1. Load the source image using Image.Load.
2. Choose appropriate output format options (e.g., PngOptions for PNG).
3. Call Image.Save with the output path and options.
4. Ensure output directories exist before saving.
5. Handle errors with try/catch and check file existence.

Sample code is provided in Program.cs.";
            File.WriteAllText(readmePath, readmeContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a high‑resolution TIFF scan into a PNG thumbnail for a web gallery, they can use this code to load the TIFF, set PngOptions, and save the PNG to a web‑accessible folder.
 * 2. When an automated batch job must verify that source image files exist before processing and create missing output directories, this snippet demonstrates the necessary File.Exists and Directory.CreateDirectory checks.
 * 3. When integrating Aspose.Imaging into a C# application to replace legacy command‑line tools for image format conversion, the example shows how to use Image.Load and Image.Save with format‑specific options.
 * 4. When generating documentation alongside image conversion, the program writes a README.txt that outlines the conversion steps, illustrating how to combine file I/O with image processing in .NET.
 * 5. When handling unexpected errors during image conversion, the try/catch block in this code provides a pattern for logging error messages without crashing the application.
 */