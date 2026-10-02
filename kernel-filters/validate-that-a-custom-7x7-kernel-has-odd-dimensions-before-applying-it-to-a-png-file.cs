// HOW-TO: Validate Odd-Sized Convolution Kernel Before Applying to PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            double[,] kernel = new double[7, 7]
            {
                { -2, -1, 0, 0, 0, -1, -2 },
                { -1,  1, 1, 0, 1,  1, -1 },
                {  0,  1, 2, 1, 2,  1,  0 },
                {  0,  0, 1, 4, 1,  0,  0 },
                {  0,  1, 2, 1, 2,  1,  0 },
                { -1,  1, 1, 0, 1,  1, -1 },
                { -2, -1, 0, 0, 0, -1, -2 }
            };

            int rows = kernel.GetLength(0);
            int cols = kernel.GetLength(1);
            if (rows % 2 == 0 || cols % 2 == 0)
            {
                Console.Error.WriteLine("Kernel dimensions must be odd.");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                image.Filter(image.Bounds, filterOptions);

                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to sharpen or blur a PNG image using a custom 7x7 convolution matrix and must ensure the kernel dimensions are odd to avoid runtime errors.
 * 2. When building an automated image‑processing pipeline that applies a custom filter to PNG files and you want to validate the kernel size before processing each image.
 * 3. When integrating Aspose.Imaging in a C# application to perform edge‑detection on PNG graphics and you must check that the filter kernel meets the odd‑dimension requirement.
 * 4. When creating a desktop tool that lets users upload PNG pictures and apply user‑defined convolution filters, you need to verify the kernel dimensions to guarantee correct filter application.
 * 5. When writing unit tests for image‑filtering code that uses Aspose.Imaging, you validate odd kernel sizes to confirm that invalid even‑sized kernels are rejected before saving the filtered PNG.
 */
