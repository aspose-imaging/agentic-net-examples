using System;
using System.IO;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = @"C:\Images\sample.bmp";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BMP image
            using (BmpImage bmp = new BmpImage(inputPath))
            {
                // Retrieve pixel dimensions
                int width = bmp.Width;
                int height = bmp.Height;

                // Output dimensions
                Console.WriteLine($"Width: {width} px");
                Console.WriteLine($"Height: {height} px");
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
 * 1. When a developer needs to validate that a BMP file uploaded to a .NET web application meets specific size requirements before further processing.
 * 2. When a desktop C# utility must read the width and height of a BMP image from the local file system to generate a thumbnail of the correct aspect ratio.
 * 3. When an automated batch script processes a folder of BMP images and logs their pixel dimensions for quality‑control reporting.
 * 4. When a game engine imports BMP textures and requires the exact pixel dimensions to allocate appropriate graphics buffers.
 * 5. When a document conversion service reads BMP images to determine scaling factors for embedding them into PDF pages.
 */