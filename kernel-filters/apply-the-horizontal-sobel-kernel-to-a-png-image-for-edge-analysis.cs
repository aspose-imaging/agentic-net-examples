// HOW-TO: Apply Horizontal Sobel Edge Detection to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "c:\\temp\\input.png";
            string outputPath = "c:\\temp\\output_sobel.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access pixel data and filtering
                RasterImage raster = (RasterImage)image;

                // Horizontal Sobel kernel (3x3)
                double[,] kernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                // Apply the convolution filter with the Sobel kernel
                var filterOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image
                raster.Save(outputPath);
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
 * 1. When you need to highlight horizontal edges in a PNG for computer‑vision preprocessing using Aspose.Imaging in C#.
 * 2. When you want to generate an edge map of scanned documents to improve OCR accuracy by applying a Sobel filter.
 * 3. When you are building a medical‑imaging tool that requires fast horizontal gradient extraction from PNG X‑ray images.
 * 4. When you need to create visual diagnostics for quality‑control pipelines by detecting surface defects via Sobel convolution.
 * 5. When you are developing a game asset pipeline that extracts silhouette outlines from PNG sprites for collision detection.
 */
