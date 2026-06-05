using System;
using System.IO;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\image_dimensions.txt";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BMP image using Aspose.Imaging
            using (BmpImage bmpImage = new BmpImage(inputPath))
            {
                // Retrieve pixel dimensions
                int width = bmpImage.Width;
                int height = bmpImage.Height;

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Write dimensions to the output file
                File.WriteAllText(outputPath, $"Width: {width}{Environment.NewLine}Height: {height}");
                
                // Optionally, also display them on the console
                Console.WriteLine($"Image dimensions - Width: {width}, Height: {height}");
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
 * 1. When a C# developer needs to read a BMP file from disk and log its width and height for downstream image processing pipelines.
 * 2. When an application must validate that a BMP image meets specific pixel dimensions before performing batch conversion or resizing.
 * 3. When a reporting tool generates a text summary of BMP image metadata, such as dimensions, for audit or documentation purposes.
 * 4. When a graphics workflow requires extracting the pixel size of a BMP image to calculate layout constraints in a UI or PDF generation process.
 * 5. When a diagnostic script checks the existence of a BMP file, reads its dimensions, and writes the values to a log file for troubleshooting image handling errors.
 */