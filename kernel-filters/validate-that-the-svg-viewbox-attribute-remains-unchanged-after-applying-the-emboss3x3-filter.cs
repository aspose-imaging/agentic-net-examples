using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "filtered.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Read original SVG content and extract viewBox attribute
            string originalContent = File.ReadAllText(inputPath);
            string originalViewBox = ExtractViewBox(originalContent);

            // Rasterize SVG to PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                svgImage.Save(outputPath, pngOptions);
            }

            // Apply Emboss3x3 filter to the rasterized image
            using (RasterImage raster = (RasterImage)Image.Load(outputPath))
            {
                var filterOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3);
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath);
            }

            // Re-read viewBox after processing (should be unchanged)
            string postContent = File.ReadAllText(inputPath);
            string postViewBox = ExtractViewBox(postContent);

            if (originalViewBox == postViewBox)
            {
                Console.WriteLine("ViewBox attribute remains unchanged after applying Emboss3x3 filter.");
            }
            else
            {
                Console.WriteLine("ViewBox attribute has changed.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Simple extraction of viewBox attribute value from SVG content
    static string ExtractViewBox(string svgContent)
    {
        const string viewBoxKey = "viewBox=\"";
        int startIndex = svgContent.IndexOf(viewBoxKey, StringComparison.Ordinal);
        if (startIndex == -1)
            return string.Empty;

        startIndex += viewBoxKey.Length;
        int endIndex = svgContent.IndexOf('"', startIndex);
        if (endIndex == -1)
            return string.Empty;

        return svgContent.Substring(startIndex, endIndex - startIndex);
    }
}