// HOW-TO: Normalize Custom Convolution Kernel and Apply to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                double[,] kernel = new double[,]
                {
                    { 1, 2, 1 },
                    { 2, 4, 2 },
                    { 1, 2, 1 }
                };

                double sum = 0;
                foreach (double value in kernel)
                {
                    sum += value;
                }
                if (sum != 0)
                {
                    int rows = kernel.GetLength(0);
                    int cols = kernel.GetLength(1);
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            kernel[i, j] /= sum;
                        }
                    }
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to smooth a JPEG photo using a custom Gaussian‑like kernel while ensuring the filter does not change overall brightness.
 * 2. When you want to apply a user‑defined convolution matrix to an image and must normalize its coefficients to keep pixel values within the valid range.
 * 3. When you are building a C# image‑processing pipeline that requires consistent results across different kernels by scaling them to sum to one before filtering.
 * 4. When you need to programmatically enhance scanned documents in JPEG format with a blur or edge‑detect filter that you design yourself.
 * 5. When you are creating a batch‑processing tool that loads JPEG files, applies a normalized custom filter, and saves the output without losing image quality.
 */
