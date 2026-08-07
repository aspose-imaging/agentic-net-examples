using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output_laplacian.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (PngImage pngImage = new PngImage(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage raster = (RasterImage)pngImage;

                // 3×3 Laplacian kernel for edge detection
                double[,] laplacianKernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 4, -1 },
                    { 0, -1, 0 }
                };

                // Apply the convolution filter with the Laplacian kernel
                var filterOptions = new ConvolutionFilterOptions(laplacianKernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image
                pngImage.Save(outputPath);
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
 * 1. When a developer needs to highlight edges in a PNG screenshot for a visual inspection tool, they can apply a 3×3 Laplacian kernel using Aspose.Imaging in C#.
 * 2. When preparing PNG assets for a machine‑learning pipeline, a developer may use this code to perform edge detection as a preprocessing step.
 * 3. When building a C# desktop application that generates stylized thumbnails, a developer can use the Laplacian filter to create outline‑enhanced PNG previews.
 * 4. When automating quality‑control checks on scanned PNG documents, a developer can run the Laplacian convolution to detect missing or blurred lines.
 * 5. When creating a custom PNG watermark detection routine, a developer can apply the Laplacian edge detector to isolate watermark contours before further analysis.
 */