// HOW-TO: Apply Sharpen Then Edge Detection Filter to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Apply predefined Sharpen filter
                raster.Filter(raster.Bounds, new SharpenFilterOptions());

                // Apply custom edge‑detection kernel
                double[,] edgeKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(edgeKernel));

                // Save the result as PNG
                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, options);
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
 * 1. When you need to enhance the details of a scanned PNG document by sharpening it and highlighting edges before OCR processing.
 * 2. When preparing product photos for an e‑commerce site and want to make edges pop while keeping the image in PNG format.
 * 3. When creating visual assets for a game and require a custom edge‑detection kernel to generate stylized outlines after sharpening.
 * 4. When processing medical imaging scans saved as PNG and need to emphasize structural boundaries for better visual analysis.
 * 5. When automating a batch workflow that improves the clarity of PNG screenshots by applying a sharpen filter followed by edge detection.
 */
