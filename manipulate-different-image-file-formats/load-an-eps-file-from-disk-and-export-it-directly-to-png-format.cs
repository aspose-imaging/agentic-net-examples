using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.eps";
        string outputPath = "sample.png";

        try
        {
            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the EPS image, convert and save it as PNG
            using (var image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to display vector graphics from legacy EPS files as raster PNG images for browser compatibility, a developer can use this code to load the EPS and save it as PNG on the server.
 * 2. When an automated batch job processes design assets and must convert customer‑supplied EPS logos to PNG thumbnails for a product catalog, the snippet provides a simple C# solution with Aspose.Imaging.
 * 3. When a desktop utility must verify that an EPS file exists and then generate a PNG preview for quick visual inspection, this code handles the file check, directory creation, and conversion in one flow.
 * 4. When integrating a document management system that stores EPS diagrams but requires PNG snapshots for indexing and search, developers can employ this example to load the EPS and export it directly to PNG.
 * 5. When a CI/CD pipeline needs to ensure that all EPS assets in a repository are converted to PNG for downstream testing or documentation generation, the code demonstrates how to perform the conversion safely with error handling in C#.
 */