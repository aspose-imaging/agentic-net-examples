using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\large.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary raster file path
            string tempPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            // Load SVG, rasterize to a smaller PNG
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    // Preserve original page size
                    PageSize = svgImage.Size,
                    // Reduce size to 50% (adjust as needed)
                    ScaleX = 0.5f,
                    ScaleY = 0.5f,
                    // Optional: improve quality
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempPath, pngOptions);
            }

            // Load the rasterized PNG, apply Gaussian blur, and save final output
            using (RasterImage rasterImage = (RasterImage)Image.Load(tempPath))
            {
                // Apply Gaussian blur with kernel size 5 and sigma 4.0
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                rasterImage.Save(outputPath);
            }

            // Clean up temporary file
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}