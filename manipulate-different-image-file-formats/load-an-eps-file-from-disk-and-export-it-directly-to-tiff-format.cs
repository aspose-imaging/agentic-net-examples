using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.eps";
        string outputPath = "sample.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare TIFF save options (default format)
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the image as TIFF
                image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert vector EPS artwork received from a designer into a raster TIFF file for high‑resolution printing workflows using C# and Aspose.Imaging.
 * 2. When an automated document processing service must ingest EPS logos and store them as TIFF images for archival in a Windows file system.
 * 3. When a batch job in a .NET application has to validate that an EPS file exists, then transform it to a TIFF format for compatibility with legacy imaging software.
 * 4. When a web API written in C# must accept uploaded EPS files, convert them on the server side to TIFF, and return the rasterized result to the client.
 * 5. When a desktop utility needs to ensure the output directory exists, load an EPS file, and save it as a TIFF using Aspose.Imaging’s TiffOptions for further image analysis.
 */