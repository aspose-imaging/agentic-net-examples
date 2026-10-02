// HOW-TO: Check PNG File Size Increase After Applying Emboss Filter In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "Output/output_emboss.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, options);
            }

            long originalSize = new FileInfo(inputPath).Length;
            long newSize = new FileInfo(outputPath).Length;
            double increase = (double)(newSize - originalSize) / originalSize * 100;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Embossed size: {newSize} bytes");
            Console.WriteLine($"Size increase: {increase:F2}%");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to apply an emboss effect to a PNG and verify that the resulting file does not become excessively larger for web delivery.
 * 2. When optimizing a batch of product images, you want to ensure the emboss filter does not cause a noticeable increase in storage size before uploading to a CDN.
 * 3. When developing a photo‑editing feature that adds a 3‑x‑3 emboss convolution, you must compare the original and filtered PNG sizes to maintain performance budgets.
 * 4. When generating printable assets with a stylized emboss look, you need to confirm the output PNG stays within size limits for email attachments.
 * 5. When troubleshooting unexpected PNG bloat after applying filters, this code lets you measure the percentage size growth caused by the emboss operation.
 */
