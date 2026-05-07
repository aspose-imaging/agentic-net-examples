using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\sample.eps";
        string outputPath = "output\\result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
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

                    using (var raster = (RasterImage)Image.Load(memoryStream))
                    {
                        // Apply a simple vignette by drawing concentric semi‑transparent ellipses
                        var graphics = new Graphics(raster);
                        int width = raster.Width;
                        int height = raster.Height;
                        int steps = 10;
                        for (int i = 0; i < steps; i++)
                        {
                            float opacityFactor = (float)(i + 1) / steps * 0.5f; // up to 50% opacity
                            var brush = new SolidBrush(Color.Black)
                            {
                                Opacity = (int)(opacityFactor * 100)
                            };
                            int inset = i * Math.Min(width, height) / (steps * 2);
                            var rect = new Rectangle(inset, inset, width - 2 * inset, height - 2 * inset);
                            graphics.FillEllipse(brush, rect);
                        }

                        // Save the final PNG with transparency
                        var finalOptions = new PngOptions();
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