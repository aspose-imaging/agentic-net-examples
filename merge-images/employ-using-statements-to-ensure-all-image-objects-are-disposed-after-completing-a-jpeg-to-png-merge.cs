using System;
using System.IO;
using System.Collections.Generic;
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
            // Hardcoded input and output paths
            string jpegPath = "input.jpg";
            string pngPath = "input.png";
            string outputPath = "output.png";

            // Validate input files
            if (!File.Exists(jpegPath))
            {
                Console.Error.WriteLine($"File not found: {jpegPath}");
                return;
            }
            if (!File.Exists(pngPath))
            {
                Console.Error.WriteLine($"File not found: {pngPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load both images to determine canvas size
            using (RasterImage jpegImage = (RasterImage)Image.Load(jpegPath))
            using (RasterImage pngImage = (RasterImage)Image.Load(pngPath))
            {
                int canvasWidth = jpegImage.Width + pngImage.Width;
                int canvasHeight = Math.Max(jpegImage.Height, pngImage.Height);

                // Prepare PNG options with file source
                Source src = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions() { Source = src };

                // Create canvas image
                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
                {
                    // Copy JPEG image onto canvas at (0,0)
                    Rectangle jpegBounds = new Rectangle(0, 0, jpegImage.Width, jpegImage.Height);
                    canvas.SaveArgb32Pixels(jpegBounds, jpegImage.LoadArgb32Pixels(jpegImage.Bounds));

                    // Copy PNG image onto canvas next to JPEG
                    Rectangle pngBounds = new Rectangle(jpegImage.Width, 0, pngImage.Width, pngImage.Height);
                    canvas.SaveArgb32Pixels(pngBounds, pngImage.LoadArgb32Pixels(pngImage.Bounds));

                    // Save the merged image
                    canvas.Save();
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
 * 1. When a web application needs to combine a product photo (JPEG) with a transparent logo (PNG) into a single PNG for display on an e‑commerce site.
 * 2. When a desktop utility must merge a scanned document (JPEG) with a watermark image (PNG) before archiving the result as a lossless PNG file.
 * 3. When a batch processing script creates a side‑by‑side comparison image by placing a camera‑captured JPEG next to a rendered PNG diagram for quality analysis.
 * 4. When a reporting tool overlays a PNG badge onto a JPEG screenshot to generate a composite PNG that can be embedded in PDF reports.
 * 5. When a mobile backend service assembles a JPEG background and a PNG icon into a single PNG sprite to reduce network requests for UI assets.
 */