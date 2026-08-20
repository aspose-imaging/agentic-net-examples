// HOW-TO: Resize BMP Image with Nearest Neighbor and Export to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.svg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image, resize it using the default NearestNeighbourResample,
            // and save the result as an SVG document.
            using (Image image = Image.Load(inputPath))
            {
                // Example resize dimensions – adjust as needed
                int newWidth = 200;
                int newHeight = 200;

                // Resize with nearest‑neighbor interpolation (default)
                image.Resize(newWidth, newHeight);

                // Save as SVG
                image.Save(outputPath, new SvgOptions());
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
 * 1. When you need to generate a scalable vector version of a low‑resolution bitmap for web graphics, you can resize the BMP and save it as SVG.
 * 2. When a legacy application only outputs BMP files but the downstream system requires SVG, this code converts and scales the image in one step.
 * 3. When creating thumbnails for a UI that must remain crisp at any zoom level, you can resize the bitmap with nearest‑neighbor interpolation and output SVG.
 * 4. When preparing assets for responsive design where vector format is preferred, you can quickly downscale a BMP and export it to SVG using C#.
 * 5. When automating a batch process that standardizes image dimensions and converts raster BMPs to vector SVG for printing pipelines, this snippet handles the resize and conversion.
 */
