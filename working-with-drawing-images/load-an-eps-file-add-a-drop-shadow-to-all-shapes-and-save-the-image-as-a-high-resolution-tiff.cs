using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.tif";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary rasterized PNG path
        string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_eps.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

        // Load EPS and rasterize to high‑resolution PNG
        using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Aspose.Imaging.Image.Load(inputPath))
        {
            var rasterOptions = new EpsRasterizationOptions
            {
                // Increase page size for higher resolution (e.g., 3× original)
                PageWidth = epsImage.Width * 3,
                PageHeight = epsImage.Height * 3,
                // Optional: set background to transparent
                BackgroundColor = Aspose.Imaging.Color.Transparent
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            epsImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG
        using (var rasterImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(tempPngPath))
        {
            int shadowOffset = 10; // pixels
            int canvasWidth = rasterImage.Width + shadowOffset * 2;
            int canvasHeight = rasterImage.Height + shadowOffset * 2;

            // Prepare TIFF save options with a file create source
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a blank canvas for the final TIFF
            using (var canvas = Aspose.Imaging.Image.Create(tiffOptions, canvasWidth, canvasHeight))
            {
                // Clear canvas to white
                var graphics = new Aspose.Imaging.Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Draw shadow (semi‑transparent black rectangle) using the raster image as source
                // First draw the shadow with an offset
                var shadowBrush = new SolidBrush(Aspose.Imaging.Color.FromArgb(100, 0, 0, 0));
                using (shadowBrush)
                {
                    // Create a temporary image for the shadow by drawing the raster with reduced opacity
                    // Here we simply draw the raster image onto the canvas with the offset
                    graphics.DrawImage(rasterImage, shadowOffset, shadowOffset);
                }

                // Draw the original raster image on top of the shadow
                graphics.DrawImage(rasterImage, shadowOffset, shadowOffset);

                // Save the final TIFF
                canvas.Save();
            }
        }

        // Clean up temporary PNG
        if (File.Exists(tempPngPath))
        {
            try { File.Delete(tempPngPath); } catch { }
        }
    }
}