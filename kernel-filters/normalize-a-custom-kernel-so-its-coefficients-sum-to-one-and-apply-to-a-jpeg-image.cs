using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

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
                RasterImage rasterImage = (RasterImage)image;

                // Define a custom kernel (example 3x3)
                double[,] kernel = new double[,]
                {
                    { 1, 2, 1 },
                    { 2, 4, 2 },
                    { 1, 2, 1 }
                };

                // Normalize kernel so that sum equals 1
                double sum = 0;
                foreach (double value in kernel)
                {
                    sum += value;
                }
                if (sum != 0)
                {
                    for (int i = 0; i < kernel.GetLength(0); i++)
                    {
                        for (int j = 0; j < kernel.GetLength(1); j++)
                        {
                            kernel[i, j] /= sum;
                        }
                    }
                }

                // Create convolution filter options with the normalized kernel
                var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                // Apply the filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, convOptions);

                // Prepare JPEG save options
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the processed image
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
 * 1. When a developer needs to apply a custom Gaussian blur to a JPEG photo while preserving overall brightness, they can normalize the 3×3 kernel and use Aspose.Imaging’s ConvolutionFilterOptions in C#.
 * 2. When building an automated image‑preprocessing pipeline that reduces high‑frequency noise in scanned JPEG documents, normalizing the filter coefficients ensures the filtered output does not become unintentionally darker or lighter.
 * 3. When creating a web service that sharpens user‑uploaded JPEG images with a custom edge‑enhancement kernel, developers must normalize the kernel so the sum equals one before applying the convolution filter with Aspose.Imaging.
 * 4. When integrating a photo‑editing feature into a .NET desktop application that applies a custom emboss effect to JPEG pictures, the code normalizes the kernel to maintain consistent exposure across the image.
 * 5. When generating thumbnails for an e‑commerce platform and need to apply a custom smoothing filter to JPEG product images without altering their average color, developers use the normalized kernel and Aspose.Imaging’s convolution filter in C#.
 */