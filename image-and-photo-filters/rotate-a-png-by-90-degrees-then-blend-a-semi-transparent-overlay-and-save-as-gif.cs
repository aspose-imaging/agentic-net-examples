using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.gif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (RasterImage png = (RasterImage)Image.Load(inputPath))
            {
                if (!png.IsCached) png.CacheData();

                // Rotate the image by 90 degrees clockwise
                png.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Create a semi‑transparent red overlay of the same size
                using (RasterImage overlay = (RasterImage)Image.Create(
                    new PngOptions { Source = new StreamSource(new MemoryStream()) },
                    png.Width, png.Height))
                {
                    // Prepare ARGB pixel data (alpha 128, red 255)
                    int pixelCount = png.Width * png.Height;
                    int[] overlayPixels = new int[pixelCount];
                    int argb = (128 << 24) | (255 << 16) | (0 << 8) | 0; // 50% transparent red
                    for (int i = 0; i < pixelCount; i++)
                    {
                        overlayPixels[i] = argb;
                    }

                    // Apply pixels to the overlay
                    overlay.SaveArgb32Pixels(new Rectangle(0, 0, png.Width, png.Height), overlayPixels);

                    // Blend the overlay onto the rotated image
                    png.Blend(new Point(0, 0), overlay, 255);
                }

                // Save the result as GIF
                GifOptions gifOptions = new GifOptions { Source = new FileCreateSource(outputPath, false) };
                png.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}