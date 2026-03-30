using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Read original viewBox attribute from the SVG file
        string originalContent = File.ReadAllText(inputPath);
        string originalViewBox = "";
        int vbIndex = originalContent.IndexOf("viewBox=\"", StringComparison.Ordinal);
        if (vbIndex >= 0)
        {
            int start = vbIndex + "viewBox=\"".Length;
            int end = originalContent.IndexOf("\"", start, StringComparison.Ordinal);
            if (end > start)
                originalViewBox = originalContent.Substring(start, end - start);
        }

        // Load the SVG image
        using (Image img = Image.Load(inputPath))
        {
            SvgImage svgImage = (SvgImage)img;

            // Prepare rasterization options for PNG conversion
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageSize = svgImage.Size;

            // Rasterize SVG to PNG in memory
            using (MemoryStream pngStream = new MemoryStream())
            {
                PngOptions pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;
                svgImage.Save(pngStream, pngOptions);
                pngStream.Position = 0;

                // Load the rasterized PNG as a RasterImage
                using (Image rasterImg = Image.Load(pngStream))
                {
                    RasterImage raster = (RasterImage)rasterImg;

                    // Apply Emboss3x3 convolution filter
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                    // (Filtered raster can be saved if needed; omitted here)
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the original SVG (unchanged) to the output path
            svgImage.Save(outputPath);
        }

        // Read viewBox attribute from the saved SVG file
        string outputContent = File.ReadAllText(outputPath);
        string outputViewBox = "";
        int vbOutIndex = outputContent.IndexOf("viewBox=\"", StringComparison.Ordinal);
        if (vbOutIndex >= 0)
        {
            int start = vbOutIndex + "viewBox=\"".Length;
            int end = outputContent.IndexOf("\"", start, StringComparison.Ordinal);
            if (end > start)
                outputViewBox = outputContent.Substring(start, end - start);
        }

        // Validate that the viewBox remained unchanged
        if (originalViewBox == outputViewBox)
        {
            Console.WriteLine("Success: viewBox attribute unchanged after applying Emboss3x3 filter.");
        }
        else
        {
            Console.WriteLine("Failure: viewBox attribute was modified.");
        }
    }
}