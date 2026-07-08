using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define kernel size (e.g., 5x5 box blur)
                int kernelSize = 5;

                // Obtain the box blur kernel
                double[,] kernel = ConvolutionFilter.GetBlurBox(kernelSize);

                // Compute sum of kernel elements
                double sum = 0;
                for (int i = 0; i < kernelSize; i++)
                {
                    for (int j = 0; j < kernelSize; j++)
                    {
                        sum += kernel[i, j];
                    }
                }

                // Normalize kernel so that its total sum equals one
                double[,] normalizedKernel = new double[kernelSize, kernelSize];
                for (int i = 0; i < kernelSize; i++)
                {
                    for (int j = 0; j < kernelSize; j++)
                    {
                        normalizedKernel[i, j] = kernel[i, j] / sum;
                    }
                }

                // Create convolution filter options with the normalized kernel
                var filterOptions = new ConvolutionFilterOptions(normalizedKernel);

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the result as BMP
                var bmpOptions = new BmpOptions();
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
 * 1. When a developer needs to preprocess a BMP photograph with a consistent blur before performing OCR, they can normalize a box‑blur kernel so its sum equals one and apply it using Aspose.Imaging’s convolution filter.
 * 2. When a C# application must generate a smooth background effect for a BMP sprite sheet in a game, normalizing the blur kernel ensures the blur intensity remains uniform across all pixels.
 * 3. When an image‑processing service has to reduce noise in scanned BMP documents while preserving overall brightness, a normalized blur kernel applied via Aspose.Imaging guarantees that the image’s average luminance stays unchanged.
 * 4. When a batch‑processing tool converts raw BMP scans into a softened version for visual inspection, using a normalized kernel prevents unintended darkening or brightening of the output image.
 * 5. When a developer integrates a BMP image‑enhancement feature into a .NET desktop app and wants the blur to be mathematically accurate, normalizing the kernel to a sum of one provides a predictable, uniform blur effect.
 */