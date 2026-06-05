using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load source image as RasterImage
            using (RasterImage source = (RasterImage)Image.Load(inputPath))
            {
                // Define scaled dimensions (e.g., 2x scaling)
                int scaledWidth = source.Width * 2;
                int scaledHeight = source.Height * 2;

                // Create a new PNG canvas with the scaled size
                PngOptions pngOptions = new PngOptions();
                using (Image canvas = Image.Create(pngOptions, scaledWidth, scaledHeight))
                {
                    // Initialize Graphics for drawing on the canvas
                    Graphics graphics = new Graphics(canvas);

                    // Set high-quality bicubic interpolation for scaling
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    // Optional: clear background to white
                    graphics.Clear(Color.White);

                    // Draw the source image scaled to the new dimensions
                    graphics.DrawImage(source, new Rectangle(0, 0, scaledWidth, scaledHeight));

                    // Save the resulting image
                    canvas.Save(outputPath);
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
 * 1. When a web application needs to generate high‑resolution product thumbnails from user‑uploaded JPEG photos and must preserve visual quality by scaling them with high‑quality bicubic interpolation before saving as PNG.
 * 2. When a desktop C# tool creates printable marketing brochures and must enlarge source images to fit a larger layout while avoiding pixelation, using Aspose.Imaging’s Graphics.InterpolationMode.HighQualityBicubic to maintain smooth gradients.
 * 3. When an automated batch process converts legacy scanned documents into PNG assets for an archive, scaling each image to double its original size to improve OCR accuracy and requiring bicubic interpolation for crisp edges.
 * 4. When a mobile‑first backend service resizes profile pictures for retina displays, applying high‑quality bicubic scaling in C# to ensure the enlarged PNGs look sharp on high‑density screens.
 * 5. When a reporting engine embeds charts as JPEGs into PDF reports and needs to upscale them to match the report’s DPI, using Aspose.Imaging’s Graphics with HighQualityBicubic interpolation to avoid jagged lines and preserve color fidelity.
 */