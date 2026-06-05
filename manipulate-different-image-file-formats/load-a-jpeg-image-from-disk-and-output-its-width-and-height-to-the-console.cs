using System;
using System.IO;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\temp\sample.jpg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image using Aspose.Imaging
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Output width and height
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
 * 1. When a developer needs to validate that user‑uploaded JPEG photos meet minimum width and height requirements using Aspose.Imaging in a C# web application.
 * 2. When a batch‑processing script logs the dimensions of JPEG images from a media library to the console for inventory tracking.
 * 3. When an e‑commerce platform extracts JPEG image width and height to ensure product pictures conform to layout specifications before publishing.
 * 4. When a desktop utility reads JPEG files from a folder and outputs their dimensions to the console for quality‑control reporting.
 * 5. When a C# console tool gathers basic image metadata, such as width and height, from JPEG files to populate a database of asset specifications.
 */