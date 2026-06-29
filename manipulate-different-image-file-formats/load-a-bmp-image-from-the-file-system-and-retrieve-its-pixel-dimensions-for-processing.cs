using System;
using System.IO;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\output.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (BmpImage bmpImage = new BmpImage(inputPath))
            {
                // Retrieve pixel dimensions
                int width = bmpImage.Width;
                int height = bmpImage.Height;

                // Output dimensions
                Console.WriteLine($"Width: {width} px");
                Console.WriteLine($"Height: {height} px");

                // Example of using the output path (optional save or write)
                // Here we simply write the dimensions to a text file
                File.WriteAllText(outputPath, $"Width: {width} px{Environment.NewLine}Height: {height} px");
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
 * 1. When a developer needs to validate that an uploaded BMP file meets required width and height constraints before further processing in a C# web application.
 * 2. When a desktop utility must generate a report of image sizes for a batch of BMP files stored on a local drive using Aspose.Imaging for .NET.
 * 3. When a game engine loads texture assets in BMP format and must retrieve their pixel dimensions to allocate appropriate GPU memory.
 * 4. When an automated script extracts BMP image dimensions to create thumbnails with correct aspect ratios in a C# image processing pipeline.
 * 5. When a document conversion service reads BMP files to embed their size metadata into a generated PDF using Aspose.Imaging.
 */