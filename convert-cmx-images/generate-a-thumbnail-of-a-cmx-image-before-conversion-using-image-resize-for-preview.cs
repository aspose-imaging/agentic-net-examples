using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\sample_thumbnail.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                // Define thumbnail dimensions
                int thumbWidth = 200;
                int thumbHeight = 200;

                // Resize the image to create a thumbnail (default NearestNeighbourResample)
                image.Resize(thumbWidth, thumbHeight);

                // Save the thumbnail as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a CAD application needs to display a quick preview of a large CMX vector drawing in a file explorer, a developer can generate a 200 × 200 PNG thumbnail using Aspose.Imaging’s Image.Resize before conversion.
 * 2. When building a web portal that lists engineering diagrams stored as CMX files, a developer can create lightweight PNG thumbnails on the server to improve page load times and provide visual cues to users.
 * 3. When integrating a document management system with .NET, a developer may need to produce a small preview image of each CMX file for search results, using the Resize method to maintain consistent thumbnail dimensions.
 * 4. When automating batch processing of legacy CMX drawings, a developer can generate preview PNGs to verify content before performing further conversion or analysis steps.
 * 5. When implementing a desktop file‑picker dialog that supports CMX files, a developer can use this code to render a thumbnail so users can recognize the correct drawing without opening the full file.
 */