using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string rasterPath = @"C:\Images\overlay.png";
        string targetPath = @"C:\Images\background.jpg";
        string tempSvgRasterPath = @"C:\Images\temp_rasterized.png";
        string outputPath = @"C:\Images\composited.png";

        // Validate input files
        if (!File.Exists(rasterPath))
        {
            Console.Error.WriteLine($"File not found: {rasterPath}");
            return;
        }
        if (!File.Exists(targetPath))
        {
            Console.Error.WriteLine($"File not found: {targetPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(tempSvgRasterPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the target image to obtain canvas size
        using (Aspose.Imaging.RasterImage targetImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(targetPath))
        {
            // Create an SVG graphics canvas matching the target size
            int canvasWidth = targetImage.Width;
            int canvasHeight = targetImage.Height;
            int dpi = 96;
            SvgGraphics2D svgGraphics = new SvgGraphics2D(canvasWidth, canvasHeight, dpi);

            // Load the raster image to be drawn onto the SVG layer
            using (Aspose.Imaging.RasterImage overlayImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(rasterPath))
            {
                // Draw the raster image at the top-left corner of the SVG canvas
                svgGraphics.DrawImage(overlayImage, new Aspose.Imaging.Point(0, 0));
            }

            // Finalize SVG image
            using (SvgImage svgImage = svgGraphics.EndRecording())
            {
                // Rasterize the SVG to a temporary PNG file
                PngOptions pngOpts = new PngOptions();
                svgImage.Save(tempSvgRasterPath, pngOpts);
            }

            // Load the rasterized SVG image
            using (Aspose.Imaging.RasterImage rasterizedSvg = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(tempSvgRasterPath))
            {
                // Composite the rasterized SVG onto the target image at (0,0)
                Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(0, 0, rasterizedSvg.Width, rasterizedSvg.Height);
                targetImage.SaveArgb32Pixels(destRect, rasterizedSvg.LoadArgb32Pixels(rasterizedSvg.Bounds));
            }

            // Save the composited image to the final output path as PNG
            PngOptions outputOptions = new PngOptions();
            targetImage.Save(outputPath, outputOptions);
        }
    }
}