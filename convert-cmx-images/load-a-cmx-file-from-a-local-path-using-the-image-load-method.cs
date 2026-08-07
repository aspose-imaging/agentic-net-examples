using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\Images\sample.cmx";

        // Ensure the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the CMX image using Aspose.Imaging.Image.Load
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Example: output some basic information about the loaded image
                Console.WriteLine($"Loaded CMX image: {Path.GetFileName(inputPath)}");
                Console.WriteLine($"Dimensions: {cmxImage.Width}x{cmxImage.Height} pixels");
                Console.WriteLine($"Bits per pixel: {cmxImage.BitsPerPixel}");
                Console.WriteLine($"Page count: {cmxImage.PageCount}");
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
 * 1. When a developer needs to read metadata such as dimensions, bits per pixel, and page count from a CorelDRAW CMX file in a C# application, they can use Aspose.Imaging.Image.Load to load the file and extract this information.
 * 2. When building a batch conversion tool that validates the existence and basic properties of CMX files before converting them to other formats, loading the CMX image with Image.Load provides the necessary data for decision‑making.
 * 3. When integrating a document management system that must display thumbnail previews of legacy CMX drawings, developers can load the CMX image using Aspose.Imaging to retrieve its size and render a preview.
 * 4. When implementing error handling for file‑system operations that involve CMX graphics, using Image.Load allows the code to catch exceptions early and report missing or corrupted files.
 * 5. When creating a reporting dashboard that lists all CMX assets along with their resolution and color depth, developers can load each CMX file with Aspose.Imaging.Image.Load to gather the required image properties in C#.
 */