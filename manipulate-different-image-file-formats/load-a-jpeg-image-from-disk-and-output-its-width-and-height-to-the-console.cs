using System;
using System.IO;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = @"C:\temp\sample.jpg";

            // Verify the file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image and output its dimensions
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                Console.WriteLine($"Width: {jpegImage.Width}");
                Console.WriteLine($"Height: {jpegImage.Height}");
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
 * 1. When a C# application must verify that an uploaded JPEG meets specific size requirements before further processing, developers can load the image with Aspose.Imaging and print its width and height to the console.
 * 2. When creating a batch inventory of image assets on a server, a developer can use this code to read each JPEG file and output its dimensions for quality‑control reporting.
 * 3. When building a command‑line tool that checks if a JPEG meets a minimum resolution for printing, the snippet demonstrates how to load the file and display its width and height using Aspose.Imaging for .NET.
 * 4. When troubleshooting an image‑processing pipeline, a developer may quickly confirm that the source JPEG’s dimensions are correct by loading it with JpegImage and writing the size to the console.
 * 5. When designing a simple C# utility that logs image metadata for archival scripts, this example shows how to retrieve and output a JPEG’s width and height without requiring additional libraries.
 */