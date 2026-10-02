// HOW-TO: Resize JPEG to 1200px Width and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                int newWidth = 1200;
                int newHeight = (int)(raster.Height * (newWidth / (double)raster.Width));

                raster.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to generate web‑optimized thumbnails from high‑resolution JPEG photos while keeping the original aspect ratio and delivering them as PNG files for lossless display.
 * 2. When an e‑commerce platform must resize product photos to a uniform 1200‑pixel width and convert them to PNG to ensure consistent image quality across browsers.
 * 3. When a content management system processes user‑uploaded JPEG images, scaling them down for faster page loads and storing the results in PNG format for transparent backgrounds.
 * 4. When a digital asset pipeline requires batch conversion of large JPEG images to a standard width and PNG format before archiving or further editing.
 * 5. When a mobile app backend needs to prepare JPEG screenshots for responsive design by resizing them to 1200 px wide and saving as PNG to preserve visual fidelity.
 */
