// HOW-TO: Convert TIFF Text to Vector EMF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image tiffImage = Image.Load(inputPath))
            {
                int width = tiffImage.Width;
                int height = tiffImage.Height;

                var frame = new Rectangle(0, 0, width, height);
                var deviceSize = new Size(width, height);
                var deviceSizeMm = new Size((int)(width / 100f), (int)(height / 100f));

                EmfRecorderGraphics2D emfGraphics = new EmfRecorderGraphics2D(frame, deviceSize, deviceSizeMm);
                emfGraphics.DrawImage((RasterImage)tiffImage,
                    new Rectangle(0, 0, width, height),
                    new Rectangle(0, 0, width, height),
                    GraphicsUnit.Pixel);

                using (EmfImage emfImage = emfGraphics.EndRecording())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new EmfRasterizationOptions
                        {
                            PageSize = new Size(width, height),
                            BackgroundColor = Color.White
                        }
                    };

                    emfImage.Save(outputPath, pngOptions);
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
 * 1. When you need to convert scanned TIFF pages that contain searchable text into high‑resolution PNGs while keeping the text as scalable vector shapes.
 * 2. When generating thumbnail previews of TIFF documents for a web portal and want the text to remain crisp at any zoom level.
 * 3. When automating a batch process that extracts text‑rich graphics from TIFF files and saves them as PNGs with a white background for consistent printing.
 * 4. When integrating legacy TIFF assets into a modern C# application that requires PNG output but must preserve the original vector quality of embedded text.
 * 5. When creating PDF‑like visualizations from TIFF sources and need a PNG representation that can be further edited without losing text clarity.
 */
