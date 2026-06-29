using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = @"C:\Images\input1.jpg";
            string inputPath2 = @"C:\Images\input2.jpg";
            string outputPath = @"C:\Images\merged.png";

            // Verify input files exist
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG images with a memory limit (50 MB)
            var loadOptions = new JpegLoadOptions { BufferSizeHint = 50 };
            using (Image img1 = Image.Load(inputPath1, loadOptions))
            using (Image img2 = Image.Load(inputPath2, loadOptions))
            {
                // Cast to RasterImage for drawing
                var raster1 = (RasterImage)img1;
                var raster2 = (RasterImage)img2;

                // Determine dimensions of the merged image
                int mergedWidth = raster1.Width + raster2.Width;
                int mergedHeight = Math.Max(raster1.Height, raster2.Height);

                // Create a new image (PNG) with the same memory limit
                var createOptions = new PngOptions
                {
                    BufferSizeHint = 50,
                    Source = new FileCreateSource(outputPath, false)
                };

                using (Image merged = Image.Create(createOptions, mergedWidth, mergedHeight))
                {
                    // Draw the first image at the left side
                    var graphics = new Graphics(merged);
                    graphics.DrawImage(raster1, new Rectangle(0, 0, raster1.Width, raster1.Height));

                    // Draw the second image to the right of the first
                    graphics.DrawImage(raster2, new Rectangle(raster1.Width, 0, raster2.Width, raster2.Height));

                    // Save the merged image (source already set to outputPath)
                    merged.Save();
                }
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
 * 1. When a web service needs to combine two high‑resolution JPEG photos into a single panoramic PNG while keeping the server’s RAM usage under control, developers can use ImageLoadOptions.BufferSizeHint to limit memory consumption.
 * 2. When a desktop application creates side‑by‑side product comparison images from user‑uploaded JPEGs on low‑end machines, the code ensures the images are loaded and merged without exceeding a 50 MB buffer.
 * 3. When an automated batch job processes thousands of JPEG scans and outputs merged PNG thumbnails, setting BufferSizeHint prevents out‑of‑memory crashes during the horizontal merge.
 * 4. When a cloud function generates a combined banner from two marketing JPEG assets and must stay within the platform’s memory quota, the JpegLoadOptions with a buffer hint enables safe image loading and PNG creation.
 * 5. When an IoT device captures two camera JPEG frames and needs to stitch them together into a single PNG for transmission, the memory‑limited loading technique helps maintain performance on constrained hardware.
 */