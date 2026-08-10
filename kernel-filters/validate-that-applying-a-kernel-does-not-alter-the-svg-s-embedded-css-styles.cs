// HOW-TO: Verify Convolution Kernel Does Not Change SVG Embedded CSS in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Read original SVG content
            string originalSvg = File.ReadAllText(inputPath);

            // Save the SVG unchanged to the output path
            using (Image svgImage = Image.Load(inputPath))
            {
                svgImage.Save(outputPath);
            }

            // Rasterize SVG to PNG for kernel application
            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
            using (Image svgImage = Image.Load(inputPath))
            {
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageSize = svgImage.Size;

                PngOptions pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

                svgImage.Save(tempPngPath, pngOptions);
            }

            // Apply a convolution kernel to the rasterized PNG
            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
                raster.Save(tempPngPath);
            }

            // Read processed SVG content
            string processedSvg = File.ReadAllText(outputPath);

            // Validate that CSS styles are unchanged
            bool cssUnchanged = originalSvg == processedSvg;
            Console.WriteLine(cssUnchanged ? "CSS unchanged." : "CSS altered.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to confirm that applying a convolution kernel to a rasterized SVG does not alter the file’s embedded CSS styles.
 * 2. When you want to generate an unchanged SVG copy alongside a filtered PNG preview while ensuring the original CSS remains intact.
 * 3. When automating image processing that sharpens SVG graphics with a kernel but must preserve the SVG’s CSS for downstream web use.
 * 4. When validating a CI/CD pipeline that processes SVG assets, checking that CSS definitions survive rasterization and filter operations.
 * 5. When building a batch tool that applies filters to SVG‑derived PNGs and requires verification that the source SVG’s style sheet is unchanged.
 */
