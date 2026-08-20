// HOW-TO: Normalize 3x3 Sharpen Kernel and Apply to JPEG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output\\sharpened.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Sharpen3x3;

                int rows = kernel.GetLength(0);
                int cols = kernel.GetLength(1);
                double sum = 0;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        sum += kernel[i, j];
                    }
                }

                double[,] normalized = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        normalized[i, j] = kernel[i, j] / sum;
                    }
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(normalized);

                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };
                rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to enhance the details of a JPEG photo without darkening the overall image, you can normalize a 3x3 sharpening kernel and apply it using Aspose.Imaging in C#.
 * 2. When processing a batch of product images for an e‑commerce site, you may want to sharpen each picture while keeping consistent brightness before saving them as high‑quality JPEGs.
 * 3. When preparing medical scans for diagnostic review, you can use a normalized sharpening filter to improve edge clarity without altering the image’s exposure levels.
 * 4. When developing a photo‑editing desktop application, you can implement a custom convolution filter that preserves brightness, ensuring the edited JPEGs look natural after sharpening.
 * 5. When automating image preprocessing for a machine‑learning pipeline, you can apply a brightness‑preserving sharpen filter to JPEG inputs to improve feature detection while maintaining original luminance.
 */
