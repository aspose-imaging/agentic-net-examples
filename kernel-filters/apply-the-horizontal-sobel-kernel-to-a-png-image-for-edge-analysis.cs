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
            // Hardcoded input and output paths
            string inputPath = "c:\\temp\\input.png";
            string outputPath = "c:\\temp\\output_sobel.png";

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
                // Cast to RasterImage for pixel manipulation
                RasterImage raster = (RasterImage)image;

                // Horizontal Sobel kernel
                double[,] kernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                // Apply convolution filter over the whole image
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

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
 * 1. When a developer needs to detect horizontal edges in scanned PNG documents such as receipts to improve OCR accuracy, they can apply the Sobel filter using Aspose.Imaging.
 * 2. When building a C# desktop application that highlights road lane markings in aerial PNG images for traffic analysis, the horizontal Sobel kernel isolates the lane edges.
 * 3. When creating an automated quality‑control pipeline that checks printed circuit board (PCB) PNG images for missing traces, applying the Sobel filter reveals horizontal discontinuities.
 * 4. When developing a medical imaging viewer that emphasizes bone edges in X‑ray PNG files, the convolution filter provides fast edge detection without external libraries.
 * 5. When generating visual previews for a web service that extracts text lines from handwritten notes saved as PNG, the Sobel filter isolates horizontal line structures for downstream processing.
 */