// HOW-TO: Normalize Blur Kernel and Apply Uniform Blur to BMP in C# (Aspose.Imaging for .NET)
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
                RasterImage raster = (RasterImage)image;

                // Create a blur kernel (e.g., 5x5 box blur)
                double[,] kernel = ConvolutionFilter.GetBlurBox(5);

                // Compute the sum of all kernel elements
                double sum = 0;
                int rows = kernel.GetLength(0);
                int cols = kernel.GetLength(1);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        sum += kernel[i, j];
                    }
                }

                // Normalize the kernel so that its total sum equals one
                double[,] normalizedKernel = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        normalizedKernel[i, j] = kernel[i, j] / sum;
                    }
                }

                // Apply the normalized blur kernel to the entire image
                var options = new ConvolutionFilterOptions(normalizedKernel);
                raster.Filter(raster.Bounds, options);

                // Save the processed image as BMP
                BmpOptions bmpOptions = new BmpOptions();
                raster.Save(outputPath, bmpOptions);
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
 * 1. When you need to soften a BMP photograph without changing its overall brightness, you can normalize a blur kernel and apply it using Aspose.Imaging in C#.
 * 2. When preparing bitmap assets for a game, you may want a consistent box blur that preserves pixel intensity, which requires kernel normalization before convolution.
 * 3. When processing scanned documents to reduce noise while keeping the average gray level unchanged, a normalized blur filter ensures uniform smoothing.
 * 4. When creating thumbnails of BMP images for a web gallery, applying a normalized blur helps achieve a smooth look without darkening the image.
 * 5. When integrating image preprocessing into an automated C# pipeline, normalizing the convolution kernel guarantees that subsequent analysis receives images with unchanged overall luminance.
 */
