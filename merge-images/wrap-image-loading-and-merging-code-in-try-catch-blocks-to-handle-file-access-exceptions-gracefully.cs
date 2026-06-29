using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath1 = "input1.png";
        string inputPath2 = "input2.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Collect sizes of input images
            List<Size> sizes = new List<Size>();
            using (RasterImage img1 = (RasterImage)Image.Load(inputPath1))
            {
                sizes.Add(img1.Size);
            }
            using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
            {
                sizes.Add(img2.Size);
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Create output source and options
            Source src = new FileCreateSource(outputPath, false);
            PngOptions options = new PngOptions() { Source = src };

            // Create canvas image
            using (RasterImage canvas = (RasterImage)Image.Create(options, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string path in new[] { inputPath1, inputPath2 })
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                // Save the bound canvas
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
 * 1. When a developer needs to create a side‑by‑side PNG banner by merging two promotional images for a web page, this C# Aspose.Imaging code loads the raster images, combines them on a canvas, and saves the result while gracefully handling missing files or file‑access exceptions.
 * 2. When an automated batch process must generate composite product thumbnails from separate front‑view and back‑view PNG files, the code can read each image, calculate the combined dimensions, and output a single merged PNG with robust error handling for unavailable or locked files.
 * 3. When a reporting tool has to embed two chart PNGs into one horizontal image for inclusion in a PDF report, developers can use this snippet to load the charts, merge them on a raster canvas, and ensure any I/O errors are caught and logged.
 * 4. When a desktop application offers users the ability to stitch together scanned document pages saved as PNGs into a single wide image, this code provides the necessary file existence checks, canvas creation, and exception handling to prevent crashes on inaccessible files.
 * 5. When a CI/CD pipeline needs to validate that two generated PNG assets can be merged without errors before publishing them to a CDN, the code performs the merge and catches file‑access exceptions, allowing the build to fail gracefully if any image is missing or locked.
 */