using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Obtain a blur kernel (e.g., 5x5 box blur)
                double[,] rawKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurBox(5);

                // Compute the sum of all kernel elements
                double sum = 0;
                int rows = rawKernel.GetLength(0);
                int cols = rawKernel.GetLength(1);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        sum += rawKernel[i, j];
                    }
                }

                // Normalize the kernel so that its total sum equals one
                double[,] normalizedKernel = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        normalizedKernel[i, j] = rawKernel[i, j] / sum;
                    }
                }

                // Create convolution filter options with the normalized kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(normalizedKernel);

                // Apply the filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the processed image as BMP
                var bmpOptions = new BmpOptions();
                rasterImage.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to apply a uniform blur to a BMP file in a C# application, they can normalize a 5×5 box blur kernel so its sum equals one and use Aspose.Imaging’s convolution filter to preserve overall image brightness.
 * 2. When preparing images for machine‑learning pipelines, normalizing the blur kernel before applying it to raster images ensures consistent pixel intensity distribution across BMP, PNG, or JPEG inputs using Aspose.Imaging for .NET.
 * 3. When building a photo‑editing tool that lets users smooth edges without darkening the picture, the code demonstrates how to compute the kernel sum, normalize it, and apply the filter to maintain color balance in the output BMP.
 * 4. When automating batch processing of scanned documents, developers can use the normalized blur kernel to reduce noise in each BMP page while keeping the total luminance unchanged, leveraging Aspose.Imaging’s Image.Load and FilterOp classes.
 * 5. When integrating image preprocessing into a C# desktop application, the example shows how to verify file existence, create the output directory, and apply a normalized convolution filter to achieve a consistent blur effect on BMP images.
 */