using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Retrieve the built‑in 3×3 sharpen kernel
                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Sharpen3x3;

                // Compute the sum of kernel elements
                double sum = 0;
                for (int i = 0; i < kernel.GetLength(0); i++)
                {
                    for (int j = 0; j < kernel.GetLength(1); j++)
                    {
                        sum += kernel[i, j];
                    }
                }

                // Normalize the kernel to preserve overall brightness
                double[,] normalizedKernel = new double[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        normalizedKernel[i, j] = kernel[i, j] / sum;
                    }
                }

                // Create convolution filter options with the normalized kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(normalizedKernel);

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Prepare JPEG save options (default settings)
                var jpegOptions = new JpegOptions();

                // Save the processed image as JPEG
                raster.Save(outputPath, jpegOptions);
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
 * 1. When a C# developer needs to sharpen JPEG product photos for an e‑commerce website while keeping the overall brightness consistent, they can use Aspose.Imaging to normalize a 3×3 sharpening kernel before applying the convolution filter.
 * 2. When processing scanned documents in a .NET application, normalizing the sharpen kernel ensures text edges become clearer without over‑exposing the page background.
 * 3. When creating a batch image‑enhancement tool that prepares travel blog pictures for fast web loading, the code preserves color balance by adjusting the kernel sum before sharpening each JPEG.
 * 4. When integrating image‑processing into a medical imaging workflow, normalizing the 3×3 sharpen filter prevents artificial brightness shifts that could affect diagnostic interpretation of JPEG scans.
 * 5. When building a desktop photo‑editing utility that offers a “quick sharpen” feature, developers can rely on this Aspose.Imaging snippet to apply a brightness‑preserving convolution filter to any loaded JPEG image.
 */