using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "template.svg";
            string originalPath = "output\\original.png";
            string filteredPath = "output\\filtered.png";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(originalPath));
            Directory.CreateDirectory(Path.GetDirectoryName(filteredPath));

            // Load SVG image
            using (Image img = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)img;

                // Rasterization options
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                // Save original rasterized PNG
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svgImage.Save(originalPath, pngOptions);
            }

            // Load rasterized original PNG
            using (Image origImg = Image.Load(originalPath))
            using (RasterImage originalRaster = (RasterImage)origImg)
            {
                // Apply motion blur filter (size 7, angle 315)
                originalRaster.Filter(originalRaster.Bounds, new MotionWienerFilterOptions(7, 1.0, 315.0));
                originalRaster.Save(filteredPath, new PngOptions());
            }

            // Compare original and filtered images
            using (Image origImg = Image.Load(originalPath))
            using (RasterImage originalRaster = (RasterImage)origImg)
            using (Image filtImg = Image.Load(filteredPath))
            using (RasterImage filteredRaster = (RasterImage)filtImg)
            {
                int[] originalPixels = originalRaster.LoadArgb32Pixels(originalRaster.Bounds);
                int[] filteredPixels = filteredRaster.LoadArgb32Pixels(filteredRaster.Bounds);
                bool identical = originalPixels.SequenceEqual(filteredPixels);
                Console.WriteLine($"Images identical: {identical}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}