// HOW-TO: Apply Vignette Effect to EPS and Save as Transparent PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Rasterize EPS to PNG in memory
                var rasterOptions = new PngOptions
                {
                    VectorRasterizationOptions = new EpsRasterizationOptions
                    {
                        PageWidth = epsImage.Width,
                        PageHeight = epsImage.Height
                    }
                };

                using (var memoryStream = new MemoryStream())
                {
                    epsImage.Save(memoryStream, rasterOptions);
                    memoryStream.Position = 0;

                    // Load rasterized image for pixel manipulation
                    using (var raster = (RasterImage)Image.Load(memoryStream))
                    {
                        var bounds = raster.Bounds;
                        int[] pixels = raster.LoadArgb32Pixels(bounds);

                        int width = raster.Width;
                        int height = raster.Height;
                        double centerX = width / 2.0;
                        double centerY = height / 2.0;
                        double maxDist = Math.Sqrt(centerX * centerX + centerY * centerY);

                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                int index = y * width + x;
                                int pixel = pixels[index];

                                int a = (pixel >> 24) & 0xFF;
                                double dx = x - centerX;
                                double dy = y - centerY;
                                double dist = Math.Sqrt(dx * dx + dy * dy);
                                double factor = 1.0 - Math.Pow(dist / maxDist, 2.0);
                                factor = Math.Max(0.0, Math.Min(1.0, factor));

                                int newA = (int)(a * factor);
                                pixel = (newA << 24) | (pixel & 0x00FFFFFF);
                                pixels[index] = pixel;
                            }
                        }

                        raster.SaveArgb32Pixels(bounds, pixels);

                        // Save final PNG with transparency
                        var finalOptions = new PngOptions
                        {
                            Source = new FileCreateSource(outputPath, false)
                        };
                        raster.Save(outputPath, finalOptions);
                    }
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
 * 1. When you need to convert a vector EPS logo into a PNG with a soft vignette border for web display while preserving transparency.
 * 2. When preparing print‑ready artwork for a marketing brochure that requires a faded edge effect around the image and must be saved as a transparent PNG for further compositing.
 * 3. When generating thumbnails of EPS diagrams for a mobile app and want to add a subtle vignette to focus attention without losing the alpha channel.
 * 4. When automating a batch process that rasterizes EPS files to PNG and applies a vignette to match a brand’s visual style across all product images.
 * 5. When integrating Aspose.Imaging into a C# service that receives EPS files, adds a decorative vignette, and returns a transparent PNG for use in UI overlays.
 */
