// HOW-TO: Apply Custom Diagonal Edge Detection Kernel to PNG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a custom diagonal edge‑detection kernel
                double[,] kernel = new double[,]
                {
                    { -1, 0, 1 },
                    {  0, 0, 0 },
                    {  1, 0,-1 }
                };

                // Apply the convolution filter with the custom kernel
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the processed image as PNG
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to highlight diagonal edges in a PNG for computer‑vision preprocessing.
 * 2. When you want to create a stylized outline effect on screenshots before publishing.
 * 3. When you must generate edge‑enhanced thumbnails for a web gallery using C#.
 * 4. When you are building a custom image‑analysis pipeline that requires a specific convolution kernel.
 * 5. When you need to detect diagonal features in scanned documents for OCR improvement.
 */
