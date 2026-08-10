// HOW-TO: How To Load A CMX Image And Get Dimensions In C# (Aspose.Imaging for .NET)
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

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the CMX image using Aspose.Imaging.Image.Load
            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                // Output basic information about the loaded image
                Console.WriteLine($"Loaded CMX image: {inputPath}");
                Console.WriteLine($"Width: {image.Width}, Height: {image.Height}");
                Console.WriteLine($"Page count: {image.PageCount}");
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to read a Corel Metafile (CMX) file in a .NET application to display its size or page count.
 * 2. When you want to verify that a CMX file exists on disk before attempting any image processing to prevent runtime errors.
 * 3. When building a batch conversion tool that first extracts width, height, and page count from CMX files for later resizing or format conversion.
 * 4. When integrating CMX support into a C# service that logs basic image metadata for auditing or reporting purposes.
 * 5. When troubleshooting image import issues and require a quick console output of a CMX file’s dimensions and page count.
 */
