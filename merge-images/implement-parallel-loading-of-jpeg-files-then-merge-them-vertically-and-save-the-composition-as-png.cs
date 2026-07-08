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
            // Hardcoded input JPEG files
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Hardcoded output PNG file
            string outputPath = "output.png";

            // Validate input files
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect sizes in parallel
            List<Size> sizes = new List<Size>();
            object lockObj = new object();

            System.Threading.Tasks.Parallel.ForEach(inputPaths, path =>
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    lock (lockObj)
                    {
                        sizes.Add(img.Size);
                    }
                }
            });

            // Calculate canvas dimensions for vertical merge
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            // Prepare PNG options with bound output source
            Source src = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = src };

            // Create canvas
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        // Center each image horizontally if narrower than canvas
                        int offsetX = (canvasWidth - img.Width) / 2;
                        Rectangle bounds = new Rectangle(offsetX, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                // Save the composed image (bound source, so just call Save())
                canvas.Save();
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
 * 1. When a developer needs to combine several JPEG screenshots into one tall PNG sprite for a web dashboard, they can use this parallel loading and vertical merge code.
 * 2. When an e‑commerce site must generate a single printable catalog page by stacking product JPEG images vertically and saving as PNG, this C# Aspose.Imaging routine handles it efficiently.
 * 3. When a mobile app creates a continuous scrolling background by merging user‑uploaded JPEG tiles into a single PNG canvas, the parallel image loading speeds up the process.
 * 4. When a reporting tool assembles daily JPEG charts into a single vertical PNG report image for email distribution, this code provides fast composition using Aspose.Imaging.
 * 5. When a document management system needs to archive multiple scanned JPEG pages as one high‑resolution PNG file, the parallel load and vertical merge approach reduces processing time.
 */