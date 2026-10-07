// HOW-TO: Apply Vignette Effect to EPS and Save as Transparent PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var eps = (EpsImage)Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    PageWidth = eps.Width,
                    PageHeight = eps.Height,
                    BackgroundColor = Color.Transparent
                };

                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = rasterOptions,
                    Source = new FileCreateSource(outputPath, false)
                };

                eps.Save(outputPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(outputPath))
            {
                Graphics graphics = new Graphics(raster);

                int centerX = raster.Width / 2;
                int centerY = raster.Height / 2;
                int maxRadius = Math.Min(raster.Width, raster.Height) / 2;

                for (int i = 0; i < 10; i++)
                {
                    double factor = (double)i / 10.0;
                    int radius = maxRadius + i * 5;
                    int alpha = (int)(255 * (1.0 - factor) * 0.5);
                    Color brushColor = Color.FromArgb(alpha, 0, 0, 0);
                    SolidBrush brush = new SolidBrush(brushColor);
                    Rectangle ellipseRect = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);
                    graphics.FillEllipse(brush, ellipseRect);
                }

                raster.Save(outputPath);
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
 * 1. When you need to convert a vector EPS logo into a PNG with a soft dark border for web thumbnails.
 * 2. When you want to generate transparent PNG assets from EPS illustrations while adding a vignette to focus viewer attention.
 * 3. When an e‑commerce site requires product EPS drawings to be displayed as PNGs with a subtle edge shading for a polished look.
 * 4. When preparing marketing materials that combine EPS artwork with a vignette effect and need the final image in PNG format with alpha channel support.
 * 5. When automating a batch process that rasterizes EPS files to PNG, applies a fade‑out border, and preserves transparency for use in UI overlays.
 */
