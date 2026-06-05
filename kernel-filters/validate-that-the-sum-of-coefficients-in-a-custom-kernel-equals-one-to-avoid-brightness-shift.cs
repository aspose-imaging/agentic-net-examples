using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
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
                RasterImage rasterImage = (RasterImage)image;

                // Define a custom convolution kernel (example sharpen kernel)
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                // Validate that the sum of kernel coefficients equals 1
                double sum = 0.0;
                foreach (double value in kernel)
                {
                    sum += value;
                }

                const double tolerance = 1e-6;
                if (Math.Abs(sum - 1.0) > tolerance)
                {
                    // Normalize the kernel to ensure the sum equals 1
                    for (int i = 0; i < kernel.GetLength(0); i++)
                    {
                        for (int j = 0; j < kernel.GetLength(1); j++)
                        {
                            kernel[i, j] /= sum;
                        }
                    }
                }

                // Apply the convolution filter with the (possibly normalized) kernel
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel));

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
 * 1. When a developer needs to apply a custom sharpening filter to PNG images without unintentionally brightening the picture, they can use this code to normalize the convolution kernel.
 * 2. When processing a batch of scanned documents in JPEG format and applying edge‑enhancement kernels, the validation step ensures consistent exposure across all pages.
 * 3. When building a C# desktop application that lets users adjust image contrast using user‑defined kernels, the sum‑check prevents the resulting bitmap from appearing washed out.
 * 4. When integrating Aspose.Imaging into an automated photo‑processing pipeline that adds a custom blur kernel to TIFF files, normalizing the kernel avoids unwanted brightness shifts in the output.
 * 5. When creating a real‑time image‑filtering service that receives arbitrary kernel matrices via an API, the code safeguards against brightness artifacts before applying the convolution filter.
 */