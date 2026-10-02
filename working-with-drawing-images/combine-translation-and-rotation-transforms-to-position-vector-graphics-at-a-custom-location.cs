// HOW-TO: How to Translate and Rotate an SVG When Converting to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputVectorPath = "input.svg";
            string outputPath = "output.png";
            string tempRasterPath = "temp_raster.png";

            if (!File.Exists(inputVectorPath))
            {
                Console.Error.WriteLine($"File not found: {inputVectorPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath));

            // Rasterize SVG to PNG
            using (Image vectorImage = Image.Load(inputVectorPath))
            {
                PngOptions rasterOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions()
                };
                vectorImage.Save(tempRasterPath, rasterOptions);
            }

            // Load rasterized image
            using (RasterImage rasterImage = (RasterImage)Image.Load(tempRasterPath))
            {
                // Create canvas
                Source canvasSource = new FileCreateSource(outputPath, false);
                PngOptions canvasOptions = new PngOptions { Source = canvasSource };
                int canvasWidth = 800;
                int canvasHeight = 600;

                using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.TranslateTransform(200, 150);
                    graphics.RotateTransform(45);
                    graphics.DrawImage(rasterImage, 0, 0);
                    canvas.Save();
                }
            }

            // Clean up temporary raster file
            if (File.Exists(tempRasterPath))
            {
                try { File.Delete(tempRasterPath); } catch { }
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
 * 1. When you need to place a logo SVG at a specific position and angle on a larger PNG report canvas.
 * 2. When generating thumbnails that require rotating and offsetting vector artwork before embedding into a fixed‑size image.
 * 3. When creating custom‑oriented watermarks from SVG files on background images in a .NET application.
 * 4. When preparing marketing banners where an SVG illustration must be shifted and tilted on a preset PNG layout.
 * 5. When automating batch conversion of SVG icons that must be aligned and rotated consistently on a standard‑size PNG sprite sheet.
 */
