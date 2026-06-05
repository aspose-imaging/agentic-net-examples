using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

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

            // Load the JPEG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a custom kernel (example 3x3 kernel)
                double[,] kernel = new double[,]
                {
                    { 1, 2, 1 },
                    { 2, 4, 2 },
                    { 1, 2, 1 }
                };

                // Normalize the kernel so that the sum of coefficients equals 1
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
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                // Apply the custom kernel to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as JPEG
                var jpegOptions = new JpegOptions();
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
 * 1. When a developer wants to apply a custom blur or sharpening effect to a JPEG photo and must ensure the filter does not change the overall brightness, they can normalize the kernel and use Aspose.Imaging’s ConvolutionFilterOptions in C#.
 * 2. When building an automated image‑processing pipeline that prepares product photos for an e‑commerce site, a developer can normalize a custom edge‑enhancement kernel and apply it to each JPEG to keep color balance consistent.
 * 3. When creating a desktop application that lets users apply artistic filters to their pictures, a developer can use the code to normalize a user‑defined 3×3 kernel and apply it to JPEG images without introducing artifacts.
 * 4. When implementing a batch‑processing tool that reduces JPEG noise using a custom smoothing kernel, a developer needs to normalize the coefficients so the filtered images retain the original exposure.
 * 5. When integrating Aspose.Imaging into a C# web service that generates thumbnails with a custom sharpening kernel, a developer must normalize the kernel to ensure the resulting JPEG thumbnails have uniform brightness.
 */