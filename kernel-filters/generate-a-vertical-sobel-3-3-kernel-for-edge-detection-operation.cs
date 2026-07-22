using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            // Load image as RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Define vertical Sobel 3x3 kernel
                double[,] sobelKernel = new double[,]
                {
                    { -1, -2, -1 },
                    {  0,  0,  0 },
                    {  1,  2,  1 }
                };

                // Apply convolution filter
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new ConvolutionFilterOptions(sobelKernel, 1.0, 0));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When a developer uses Aspose.Imaging for .NET to apply a vertical Sobel 3×3 convolution filter on a PNG image to highlight building edges in architectural visualizations.
 * 2. When an OCR preprocessing pipeline needs to enhance vertical text boundaries in JPEG scans by running a C# convolution filter with a Sobel kernel via Aspose.Imaging.
 * 3. When a security application processes BMP frames from a surveillance camera in C# and uses Aspose.Imaging’s ConvolutionFilterOptions to detect vertical motion edges for intrusion alerts.
 * 4. When a medical imaging software analyzes grayscale X‑ray PNG files in .NET and applies a vertical Sobel filter with Aspose.Imaging to emphasize bone structures for diagnosis.
 * 5. When a game developer generates stylized edge‑enhanced textures from PNG assets by applying a vertical Sobel kernel using Aspose.Imaging’s raster image filtering in C#.
 */