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

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image using Aspose.Imaging
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Output image dimensions
                Console.WriteLine($"Width: {jpegImage.Width}");
                Console.WriteLine($"Height: {jpegImage.Height}");
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to validate that uploaded JPEG files meet size constraints before further processing, they can load the image with Aspose.Imaging and read its Width and Height properties.
 * 2. When generating a dynamic image gallery, a C# application can use this code to retrieve each JPEG's dimensions to calculate layout grids or thumbnail sizes.
 * 3. When integrating with a printing service, developers can read the JPEG's pixel dimensions to ensure the image resolution matches the required print size.
 * 4. When performing batch metadata extraction, the code can quickly enumerate JPEG files on disk and log their width and height for inventory or reporting purposes.
 * 5. When building a file‑upload validator for a web API, the server can load the incoming JPEG using Aspose.Imaging and reject files that are too large or too small based on their dimensions.
 */