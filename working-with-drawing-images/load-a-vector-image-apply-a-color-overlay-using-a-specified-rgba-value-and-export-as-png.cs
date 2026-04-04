using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector image (SVG)
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Set up rasterization options for SVG
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = vectorImage.Size
            };

            // Configure PNG export options with rasterization
            var pngExportOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVG to PNG in memory
            using (MemoryStream rasterStream = new MemoryStream())
            {
                vectorImage.Save(rasterStream, pngExportOptions);
                rasterStream.Position = 0;

                // Load the rasterized PNG as a RasterImage
                using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                {
                    // Create graphics for drawing
                    Graphics graphics = new Graphics(rasterImage);

                    // Define overlay color (RGBA)
                    byte overlayAlpha = 128; // 0-255
                    byte overlayRed = 255;
                    byte overlayGreen = 0;
                    byte overlayBlue = 0;
                    var overlayColor = Aspose.Imaging.Color.FromArgb(overlayAlpha, overlayRed, overlayGreen, overlayBlue);

                    // Apply color overlay using a semi‑transparent solid brush
                    using (SolidBrush brush = new SolidBrush(overlayColor))
                    {
                        graphics.FillRectangle(brush, rasterImage.Bounds);
                    }

                    // Save the final image as PNG
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}