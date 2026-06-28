using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        const string inputPath = @"C:\temp\input.png";
        const string outputPath = @"C:\temp\output.bmp";

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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Offsets for cropping (pixels to remove from each side)
                int leftOffset = 10;
                int topOffset = 20;
                int rightOffset = 10;
                int bottomOffset = 20;

                // Crop the image using the specified offsets
                image.Crop(leftOffset, rightOffset, topOffset, bottomOffset);

                // Save the cropped image as BMP
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
 * 1. When a C# application needs to trim unwanted borders from a PNG screenshot and store the result as a BMP for legacy Windows printing, this code can be used.
 * 2. When an automated batch job must convert user‑uploaded PNG icons into BMP thumbnails with consistent left, top, right, and bottom padding removed, the example shows how to do it with Aspose.Imaging.
 * 3. When a developer is building a document generation system that requires PNG graphics to be cropped to a specific region and saved as BMP to meet a third‑party API’s image format constraints, this snippet provides the needed steps.
 * 4. When a Windows service processes scanned PNG images, removes a fixed number of pixels from each edge to eliminate scanner artifacts, and saves the cleaned image as BMP for further analysis, the code demonstrates the required workflow.
 * 5. When a game asset pipeline needs to programmatically crop PNG textures by defined offsets and export them as BMP files for compatibility with an older game engine, this example shows the exact C# implementation.
 */