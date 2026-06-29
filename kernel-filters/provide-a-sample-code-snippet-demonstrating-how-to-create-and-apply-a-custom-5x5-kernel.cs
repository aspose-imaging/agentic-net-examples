using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Png;

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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the image as a RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a custom 5x5 kernel (example: edge detection)
                double[,] kernel = new double[5, 5]
                {
                    { -1, -1, -1, -1, -1 },
                    { -1,  2,  2,  2, -1 },
                    { -1,  2,  8,  2, -1 },
                    { -1,  2,  2,  2, -1 },
                    { -1, -1, -1, -1, -1 }
                };

                // Create convolution filter options with the custom kernel
                ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel);

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

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
 * 1. When a developer needs to enhance the edges of a PNG photograph by applying a custom 5x5 convolution kernel for edge detection using Aspose.Imaging for .NET.
 * 2. When a C# application must preprocess scanned documents to highlight fine details before OCR by applying a custom 5x5 filter to a raster image.
 * 3. When a graphics tool requires a user‑defined sharpening effect on a PNG image and the developer wants to implement it with a 5x5 convolution matrix via Aspose.Imaging.
 * 4. When an automated image‑processing pipeline needs to reduce noise while preserving texture by applying a custom 5x5 kernel to each frame of a PNG sequence.
 * 5. When a developer wants to experiment with custom image‑filter algorithms, such as embossing or edge enhancement, by creating and applying a 5x5 kernel to a raster image in C#.
 */