using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPathTelea = "output_telea.png";
        string outputPathContentAware = "output_contentaware.png";

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage (PngImage derives from RasterImage)
            RasterImage raster = (RasterImage)image;

            // ------------------------------
            // Create a mask using GraphicsPath
            // ------------------------------
            GraphicsPath mask = new GraphicsPath();
            Figure figure = new Figure();
            // Example ellipse mask (adjust coordinates as needed)
            figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 150)));
            mask.AddFigure(figure);

            // -------------------------------------------------
            // 1. Remove watermark using Telea algorithm (fast)
            // -------------------------------------------------
            var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
            // Optional: adjust half patch size
            teleaOptions.HalfPatchSize = 3;

            // Perform watermark removal
            using (RasterImage resultTelea = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, teleaOptions))
            {
                // Save the result
                resultTelea.Save(outputPathTelea, new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPathTelea, false)
                });
            }

            // ---------------------------------------------------------------
            // 2. Remove watermark using Content Aware Fill algorithm (higher quality)
            // ---------------------------------------------------------------
            var contentAwareOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
            {
                MaxPaintingAttempts = 4 // optional parameter to control attempts
            };

            using (RasterImage resultContentAware = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, contentAwareOptions))
            {
                resultContentAware.Save(outputPathContentAware, new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPathContentAware, false)
                });
            }
        }
    }
}