using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary PNG path for rasterizing EPS
        string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_eps.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

        // Load EPS image and rasterize to PNG
        using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
        {
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new EpsRasterizationOptions
                {
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                }
            };
            epsImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG
        using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
        {
            // Determine canvas size (add space for caption)
            int captionHeight = 50;
            int canvasWidth = raster.Width;
            int canvasHeight = raster.Height + captionHeight;

            // Create SVG graphics canvas
            var graphics = new SvgGraphics2D(canvasWidth, canvasHeight, 96);

            // Draw the rasterized EPS image at the top
            graphics.DrawImage(raster, new Point(0, 0), new Size(raster.Width, raster.Height));

            // Draw caption text at the bottom center
            var font = new Font("Arial", 24, FontStyle.Regular);
            graphics.DrawString(
                font,
                "Caption Text",
                new Point(canvasWidth / 2, raster.Height + 30),
                Color.Black);

            // Finalize SVG and save
            using (SvgImage svgImage = graphics.EndRecording())
            {
                svgImage.Save(outputPath, new SvgOptions());
            }
        }

        // Clean up temporary PNG file
        try
        {
            if (File.Exists(tempPngPath))
                File.Delete(tempPngPath);
        }
        catch
        {
            // Ignore any cleanup errors
        }
    }
}