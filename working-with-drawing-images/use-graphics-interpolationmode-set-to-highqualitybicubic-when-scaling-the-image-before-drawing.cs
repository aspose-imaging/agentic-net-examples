using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage source = (RasterImage)Image.Load(inputPath))
            {
                int scaledWidth = source.Width * 2;
                int scaledHeight = source.Height * 2;

                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);

                using (Image canvas = Image.Create(pngOptions, scaledWidth, scaledHeight))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.DrawImage(source, new Rectangle(0, 0, scaledWidth, scaledHeight));
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
 * 1. When a developer needs to generate a high‑resolution version of a PNG logo for printing, they can use this code to double its size with HighQualityBicubic interpolation to preserve sharp edges.
 * 2. When an e‑commerce site must create larger product thumbnails from original images without pixelation, the code scales the raster image and saves it as a new PNG.
 * 3. When a mobile app requires on‑the‑fly resizing of user‑uploaded photos before uploading to a server, this snippet provides a C# solution that maintains image quality using Aspose.Imaging.
 * 4. When a desktop publishing tool needs to upscale scanned documents for OCR preprocessing, the code enlarges the bitmap while applying high‑quality bicubic interpolation to keep text legible.
 * 5. When a game developer wants to convert low‑resolution sprite sheets into higher‑resolution assets for retina displays, they can employ this example to resize PNG frames with minimal distortion.
 */