// HOW-TO: Apply Zero Sum Laplacian Edge Detection to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

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

            // Load the PNG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a zero‑sum Laplacian kernel for edge detection
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                // Apply convolution filter with the kernel
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                // Save the processed image as PNG
                PngOptions saveOptions = new PngOptions();
                image.Save(outputPath, saveOptions);
            }

            // Simple verification comment:
            // The resulting image should have a black background with highlighted edges.
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to highlight object boundaries in a PNG for computer‑vision preprocessing using Aspose.Imaging’s convolution filter.
 * 2. When you want to generate a high‑contrast black‑background image that emphasizes edges for UI thumbnails or documentation screenshots.
 * 3. When you are building an automated pipeline that detects edges in scanned diagrams and saves the result as a PNG without external libraries.
 * 4. When you must verify that a custom Laplacian kernel produces the expected black background with highlighted edges in a .NET application.
 * 5. When you need to process large batches of PNG files on a server, applying zero‑sum edge detection before further analysis or storage.
 */
