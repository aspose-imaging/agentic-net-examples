// HOW-TO: Sharpen SVG Template and Save as PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\template.svg";
            string outputPath = @"C:\Images\sharpened.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Prepare rasterization options for SVG -> raster conversion
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();

                // Prepare PNG save options with the rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Rasterize SVG into a memory stream as PNG
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    svgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0;

                    // Load the rasterized PNG as a RasterImage to apply filters
                    using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                    {
                        // Apply the predefined 3x3 sharpen convolution filter
                        rasterImage.Filter(
                            rasterImage.Bounds,
                            new ConvolutionFilterOptions(ConvolutionFilter.Sharpen3x3));

                        // Save the sharpened image as PNG
                        rasterImage.Save(outputPath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to enhance the visual clarity of a vector logo before embedding it in a web page, you can rasterize the SVG, apply a sharpen filter, and output a high‑quality PNG.
 * 2. When generating product thumbnails from SVG designs that must appear crisp on high‑DPI screens, applying a 3×3 sharpen filter ensures the PNGs retain edge detail.
 * 3. When preparing SVG‑based icons for email newsletters where only raster images are supported, you can sharpen them to avoid blurriness after conversion.
 * 4. When automating a batch process that converts SVG diagrams to printable PNGs with improved sharpness for reports, this code provides the necessary steps.
 * 5. When integrating Aspose.Imaging into a C# application to dynamically render and sharpen user‑uploaded SVG artwork before saving it as a PNG for further processing.
 */
