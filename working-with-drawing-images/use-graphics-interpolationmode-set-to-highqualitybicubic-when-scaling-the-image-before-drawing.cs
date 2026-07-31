using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load source image
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Define new canvas size (e.g., double the original dimensions)
                int canvasWidth = sourceImage.Width * 2;
                int canvasHeight = sourceImage.Height * 2;

                // Create a PNG canvas
                PngOptions pngOptions = new PngOptions();
                using (Image canvas = Image.Create(pngOptions, canvasWidth, canvasHeight))
                {
                    // Initialize graphics for the canvas
                    Graphics graphics = new Graphics(canvas);
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    // Draw the source image scaled to the canvas size
                    graphics.DrawImage(sourceImage, new Rectangle(0, 0, canvasWidth, canvasHeight));

                    // Save the resulting image
                    canvas.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to generate high‑resolution thumbnails from user‑uploaded JPEG photos and save them as lossless PNG files for display on retina screens.
 * 2. When a desktop publishing tool must enlarge scanned documents while preserving smooth edges by using HighQualityBicubic interpolation before embedding them in a PDF.
 * 3. When an e‑commerce platform wants to create double‑size product images from original photos to improve zoom‑in quality without introducing pixelation.
 * 4. When a batch‑processing script converts legacy JPEG assets to PNG format and scales them to a larger canvas for use in print‑ready marketing materials.
 * 5. When a mobile app prepares background images by upscaling them to fit larger device resolutions while maintaining color fidelity and anti‑aliasing.
 */