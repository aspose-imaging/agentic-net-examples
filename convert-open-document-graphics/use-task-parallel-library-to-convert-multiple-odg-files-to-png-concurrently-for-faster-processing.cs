// HOW-TO: Convert Multiple ODG Files to PNG in Parallel with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded list of ODG files to convert
            string[] inputFiles = new[]
            {
                @"C:\Images\sample1.odg",
                @"C:\Images\sample2.odg",
                @"C:\Images\sample3.odg"
            };

            // Process files in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PNG path
                string outputPath = Path.ChangeExtension(inputPath, ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load ODG image and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions();

                    // Set rasterization options required for vector formats
                    var rasterOptions = new OdgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    image.Save(outputPath, pngOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑convert a large collection of OpenDocument graphics (ODG) to PNG images quickly, this parallel code speeds up processing on multi‑core machines.
 * 2. When an automated workflow must generate raster previews of ODG diagrams for web thumbnails, the example shows how to rasterize each page with a white background using Aspose.Imaging.
 * 3. When a server‑side service processes user‑uploaded ODG files and must save them as PNGs without blocking other requests, the Parallel.ForEach pattern keeps the API responsive.
 * 4. When you are building a desktop utility that converts many vector drawings to PNG in one click, the code demonstrates directory handling and error checking for each file.
 * 5. When you want to leverage the Task Parallel Library to maximize CPU utilization while converting vector formats to raster formats in C#, this sample provides a ready‑to‑use implementation.
 */
