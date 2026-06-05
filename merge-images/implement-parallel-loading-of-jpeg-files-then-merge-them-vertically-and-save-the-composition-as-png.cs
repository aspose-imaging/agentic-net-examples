using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output file
            string inputDirectory = "Input";
            string outputPath = "Output/merged.png";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get JPEG files
            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");

            // Parallel loading of JPEG images
            var imageDict = files.AsParallel()
                .Select(file =>
                {
                    if (!File.Exists(file))
                    {
                        Console.Error.WriteLine($"File not found: {file}");
                        return null;
                    }
                    var img = (RasterImage)Image.Load(file);
                    return new { file, img };
                })
                .Where(x => x != null)
                .ToDictionary(x => x.file, x => x.img);

            if (imageDict.Count == 0)
            {
                Console.WriteLine("No JPEG files found to process.");
                return;
            }

            // Calculate canvas size (vertical merge)
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (var kvp in imageDict)
            {
                var img = kvp.Value;
                if (img.Width > canvasWidth) canvasWidth = img.Width;
                canvasHeight += img.Height;
            }

            // Create PNG canvas
            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                // Preserve order by sorting file names
                foreach (var file in files.OrderBy(f => f))
                {
                    if (!imageDict.TryGetValue(file, out RasterImage img))
                        continue;

                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
                // Save the merged PNG
                canvas.Save();
            }

            // Dispose loaded images
            foreach (var img in imageDict.Values)
            {
                img.Dispose();
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
 * 1. When a developer needs to batch‑process a folder of JPEG photographs and create a single high‑resolution PNG strip for printing or web galleries.
 * 2. When an e‑commerce platform must combine product thumbnail JPEGs into a vertically stacked PNG sprite to reduce HTTP requests.
 * 3. When a medical imaging application has to merge scanned JPEG X‑ray images into one PNG report for easier review by clinicians.
 * 4. When a digital signage system requires fast parallel loading of multiple JPEG ads and concatenates them vertically into a PNG slideshow asset.
 * 5. When a document generation tool assembles scanned JPEG pages into a single PNG file for inclusion in a PDF or archive.
 */