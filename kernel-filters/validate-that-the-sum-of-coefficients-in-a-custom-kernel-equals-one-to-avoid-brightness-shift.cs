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
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
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
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Define a custom convolution kernel
                double[,] kernel = new double[,]
                {
                    { 0.0, 0.5, 0.0 },
                    { 0.5, 0.0, 0.5 },
                    { 0.0, 0.5, 0.0 }
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
                    Console.Error.WriteLine($"Kernel sum is {sum}, which does not equal 1. Adjust the kernel to avoid brightness shift.");
                    return;
                }

                // Apply the convolution filter using the validated kernel
                rasterImage.Filter(rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When a .NET developer wants to apply a custom convolution filter to PNG or JPEG images using Aspose.Imaging and must guarantee that the filter does not introduce a brightness shift, they can use this code to validate that the kernel coefficients sum to one.
 * 2. When building an automated image‑processing pipeline that sharpens scanned documents, the code ensures the custom kernel is normalized so the output retains the original document’s exposure levels.
 * 3. When creating a photo‑editing tool that lets users define their own blur or emboss kernels, the validation step prevents accidental over‑exposure by checking the kernel sum before applying the filter.
 * 4. When integrating Aspose.Imaging into a C# web service that resizes and enhances user‑uploaded avatars, the code confirms the custom kernel is correctly weighted to maintain consistent brightness across all images.
 * 5. When performing batch processing of satellite imagery where precise radiometric balance is critical, the kernel‑sum check safeguards against unintended brightness changes during convolution filtering.
 */