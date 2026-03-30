using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "template.svg";
        string originalPngPath = "output\\original.png";
        string blurredPngPath = "output\\blurred.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(originalPngPath));
        Directory.CreateDirectory(Path.GetDirectoryName(blurredPngPath));

        // Load SVG and rasterize to original PNG
        using (Image image = Image.Load(inputPath))
        {
            SvgImage svgImage = (SvgImage)image;

            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                BackgroundColor = Color.White
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            svgImage.Save(originalPngPath, pngOptions);
        }

        // Load the rasterized PNG, apply motion blur, and save blurred PNG
        using (Image img = Image.Load(originalPngPath))
        {
            RasterImage rasterImage = (RasterImage)img;

            // Apply motion blur: size 7, smooth factor 1.0, angle 315 degrees
            rasterImage.Filter(rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(7, 1.0, 315.0));

            rasterImage.Save(blurredPngPath);
        }

        // Simple comparison: compare file sizes
        long originalSize = new FileInfo(originalPngPath).Length;
        long blurredSize = new FileInfo(blurredPngPath).Length;

        Console.WriteLine($"Original PNG size: {originalSize} bytes");
        Console.WriteLine($"Blurred PNG size: {blurredSize} bytes");
        Console.WriteLine(originalSize == blurredSize
            ? "Images have the same file size."
            : "Images differ in file size.");
    }
}