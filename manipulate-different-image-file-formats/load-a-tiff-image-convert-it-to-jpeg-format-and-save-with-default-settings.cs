// HOW-TO: Convert TIFF Image to JPEG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Save as JPEG with default options
                image.Save(outputPath, new JpegOptions());
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
 * 1. When you need to reduce the file size of high‑resolution TIFF scans for web display by converting them to JPEG in a C# application.
 * 2. When a document management system receives TIFF uploads and must store them as JPEG thumbnails using Aspose.Imaging.
 * 3. When automating migration of legacy TIFF assets to a JPEG‑based media library without custom compression settings.
 * 4. When integrating image conversion into a C# service that validates the source file exists and creates the output folder automatically.
 * 5. When building a simple utility to batch‑process scanned TIFF files into JPEG format with default quality settings.
 */
