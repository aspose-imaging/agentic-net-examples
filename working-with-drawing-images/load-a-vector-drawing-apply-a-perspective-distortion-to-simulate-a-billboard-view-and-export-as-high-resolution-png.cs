using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG vector image
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Prepare rasterization options for high‑resolution PNG output
            var svgRasterOptions = new SvgRasterizationOptions
            {
                PageSize = vectorImage.Size,
                // Increase resolution by scaling (e.g., 2×)
                ScaleX = 2.0f,
                ScaleY = 2.0f,
                BackgroundColor = Color.White,
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = svgRasterOptions,
                Source = new FileCreateSource(outputPath, false)
            };

            // Rasterize SVG to a temporary raster image in memory
            using (MemoryStream ms = new MemoryStream())
            {
                vectorImage.Save(ms, pngOptions);
                ms.Position = 0;

                using (RasterImage raster = (RasterImage)Image.Load(ms))
                {
                    // Create the final high‑resolution canvas bound to the output file
                    using (Image canvas = Image.Create(pngOptions, raster.Width, raster.Height))
                    {
                        // Apply perspective distortion using destination points
                        // Source rectangle corners: (0,0), (W,0), (W,H), (0,H)
                        // Destination points simulate a billboard view
                        var destPoints = new[]
                        {
                            new Point(0, 0),                                 // top‑left
                            new Point(raster.Width, 0),                      // top‑right
                            new Point((int)(raster.Width * 0.8), raster.Height), // bottom‑right (shifted left)
                            new Point((int)(raster.Width * 0.2), raster.Height)  // bottom‑left (shifted right)
                        };

                        var graphics = new Graphics(canvas);
                        graphics.DrawImage(raster, destPoints);

                        // Save the canvas (output file is already bound)
                        canvas.Save();
                    }
                }
            }
        }
    }
}