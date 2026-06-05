using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load source BMP image
            using (RasterImage source = (RasterImage)Image.Load(inputPath))
            {
                // Draw a rectangle on the source image
                Graphics srcGraphics = new Graphics(source);
                srcGraphics.Clear(Color.White);
                Pen rectPen = new Pen(Color.Blue, 2);
                srcGraphics.DrawRectangle(rectPen, new Rectangle(10, 10, 80, 80));

                // Prepare destination canvas (2x scaling)
                int destWidth = source.Width * 2;
                int destHeight = source.Height * 2;

                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                using (Image dest = Image.Create(bmpOptions, destWidth, destHeight))
                {
                    // Set high-quality interpolation before scaling
                    Graphics destGraphics = new Graphics(dest);
                    destGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    // Draw the source image onto the destination canvas with scaling
                    destGraphics.DrawImage(source, new Rectangle(0, 0, destWidth, destHeight));

                    // Save the destination image (output file already bound)
                    dest.Save();
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
 * 1. When a developer needs to create a high‑resolution thumbnail of a BMP diagram that includes vector shapes such as rectangles, they can draw the shape, set InterpolationMode to HighQualityBicubic, and scale the image to preserve smooth edges.
 * 2. When generating printable marketing material from a BMP logo that contains a drawn border, using HighQualityBicubic interpolation ensures the scaled‑up logo retains crisp lines on the final output.
 * 3. When converting legacy BMP screenshots with annotated rectangles into larger images for documentation, applying HighQualityBicubic interpolation before scaling prevents jagged edges around the annotations.
 * 4. When building a C# application that resizes BMP floor‑plan images with overlaid shapes for a web viewer, setting InterpolationMode to HighQualityBicubic provides a visually appealing zoomed‑in view.
 * 5. When automating batch processing of BMP files that require a 2× size increase while preserving the quality of drawn shapes, using HighQualityBicubic interpolation guarantees smooth scaling across all processed images.
 */