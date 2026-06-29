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
            string outputPath = "output/output.png";

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

                // Define a 3x3 kernel with center weight 0.7 and surrounding weights 0.075
                double[,] kernel = new double[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        kernel[i, j] = 0.075;
                    }
                }
                kernel[1, 1] = 0.7; // center weight

                // Normalize the kernel so that the sum of all weights equals 1
                double sum = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        sum += kernel[i, j];
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        kernel[i, j] /= sum;
                    }
                }

                // Apply the custom convolution filter to the entire image
                var filterOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Save the filtered image as PNG
                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer wants to smooth a PNG photograph while preserving edges by applying a custom weighted blur filter using a 3x3 convolution kernel in C# with Aspose.Imaging.
 * 2. When an e‑commerce platform needs to automatically reduce noise in product PNG images before uploading them to a CDN, using a normalized kernel to ensure consistent brightness.
 * 3. When a medical imaging application must apply a gentle blur to PNG scans to hide patient identifiers while keeping diagnostic details intact, leveraging the custom kernel in Aspose.Imaging for .NET.
 * 4. When a game developer wants to create a real‑time post‑processing effect that slightly softens PNG sprite textures without altering their overall color balance, using the normalized 3x3 filter.
 * 5. When a document management system processes scanned PNG pages and requires a lightweight smoothing step to improve OCR accuracy, employing the defined kernel and convolution filter in C#.
 */