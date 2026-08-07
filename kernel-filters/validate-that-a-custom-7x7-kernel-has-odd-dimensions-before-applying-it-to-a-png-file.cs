using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define kernel size and validate it is odd
            int kernelSize = 7;
            if (kernelSize % 2 == 0)
            {
                Console.Error.WriteLine("Kernel size must be an odd number.");
                return;
            }

            // Create a 7x7 averaging kernel
            double[,] kernel = new double[kernelSize, kernelSize];
            double value = 1.0 / (kernelSize * kernelSize);
            for (int i = 0; i < kernelSize; i++)
            {
                for (int j = 0; j < kernelSize; j++)
                {
                    kernel[i, j] = value;
                }
            }

            // Load the PNG image, apply the custom kernel, and save the result
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
                raster.Save(outputPath);
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
 * 1. When a developer wants to apply a custom 7×7 averaging convolution filter to a PNG image and must ensure the kernel dimensions are odd to avoid runtime errors in Aspose.Imaging for .NET.
 * 2. When building an automated image‑enhancement pipeline that smooths PNG files using a user‑defined kernel, the code validates the kernel size before invoking the ConvolutionFilterOptions.
 * 3. When creating a desktop C# application that lets users upload PNG pictures and apply custom blur effects, the odd‑size check guarantees the filter works correctly with Aspose’s raster image processing.
 * 4. When integrating image preprocessing into a machine‑learning workflow that requires consistent padding, the developer uses this snippet to confirm the kernel’s odd dimensions before filtering PNG inputs.
 * 5. When troubleshooting a batch job that processes thousands of PNG assets with a 7×7 kernel, the validation step helps quickly detect mis‑configured kernel sizes and prevents exceptions during the raster filter operation.
 */