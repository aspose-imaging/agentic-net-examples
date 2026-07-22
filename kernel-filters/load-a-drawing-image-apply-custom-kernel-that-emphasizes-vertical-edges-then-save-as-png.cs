using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

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

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Define a vertical edge detection kernel (Sobel operator)
                double[,] verticalKernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                // Apply the custom convolution filter using the kernel
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(verticalKernel));

                // Save the processed image as PNG
                rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to extract vertical edges from a scanned engineering drawing and save the result as a PNG for further analysis.
 * 2. When an application must preprocess blueprint images by applying a Sobel vertical kernel to highlight structural lines before feeding them into a CAD recognition engine.
 * 3. When a C# service processes user‑uploaded PNG drawings, applies a custom convolution filter to emphasize vertical features, and stores the enhanced image for quality‑control review.
 * 4. When a batch job converts legacy PNG schematics to edge‑enhanced PNGs using Aspose.Imaging’s RasterImage filtering to improve visual clarity in documentation.
 * 5. When a desktop tool loads a drawing, detects vertical edges with a convolution filter, and saves the output as a PNG to be displayed in a web viewer that requires high‑contrast line art.
 */