using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                // Example operation: resize the EPS image
                image.Resize(400, 400, ResizeType.NearestNeighbourResample);

                // Save as PNG
                image.Save(outputPath, new PngOptions());
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
 * 1. When a web application needs to convert user‑uploaded EPS logos to PNG thumbnails and must gracefully handle missing or corrupted files without crashing the service.
 * 2. When an automated build script processes design assets, converting EPS illustrations to PNG for documentation, and requires try‑catch blocks to log errors and continue the pipeline.
 * 3. When a desktop utility resizes EPS drawings for printing, it uses exception handling to alert the user if the source EPS cannot be loaded due to format incompatibility.
 * 4. When a batch job iterates over a folder of EPS files to generate PNG previews, it employs catch blocks to skip unreadable files and record detailed error messages for later review.
 * 5. When integrating Aspose.Imaging into a C# microservice that serves PNG versions of EPS diagrams, developers use try‑catch to return a meaningful HTTP error response if Image.Load throws an exception.
 */