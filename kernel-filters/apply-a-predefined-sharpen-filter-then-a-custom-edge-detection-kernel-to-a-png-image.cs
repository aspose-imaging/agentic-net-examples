using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply a sharpen filter (kernel size 5, sigma 4.0)
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Apply a custom edge‑detection kernel (Emboss 3x3)
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

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
 * 1. When a developer needs to enhance the details of a PNG screenshot before embedding it in a technical report, they can use this code to apply a sharpen filter followed by an emboss edge‑detection kernel.
 * 2. When an e‑commerce platform wants to automatically improve product photo clarity and add a subtle texture for visual appeal, the code can process each PNG image with sharpening and custom convolution.
 * 3. When a medical imaging application must highlight subtle structures in PNG scans while preserving overall contrast, the developer can chain a sharpen filter and an emboss convolution to emphasize edges.
 * 4. When a game asset pipeline requires batch processing of PNG textures to make them appear crisper and give a stylized edge effect, this C# snippet provides a straightforward solution.
 * 5. When a document‑generation service needs to prepare PNG diagrams for print by sharpening fine lines and adding a defined edge outline, the code demonstrates how to achieve it with Aspose.Imaging.
 */