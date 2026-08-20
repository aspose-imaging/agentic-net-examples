// HOW-TO: Create Gaussian Blur Kernel Using Aspose.Imaging Convolution Filter In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputPath = "Input\\input.txt";
        string outputPath = "Output\\result.txt";

        // Input path check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Generate a Gaussian blur kernel of size 5 with sigma 1.0
            double[,] kernel = ConvolutionFilter.GetGaussian(5, 1.0);

            // Output the kernel values
            Console.WriteLine("Gaussian kernel (size=5, sigma=1.0):");
            int rows = kernel.GetLength(0);
            int cols = kernel.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(kernel[i, j]);
                    if (j < cols - 1)
                        Console.Write(", ");
                }
                if (i < rows - 1)
                    Console.WriteLine();
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to apply a custom Gaussian blur to an image using Aspose.Imaging's convolution filter in a C# application.
 * 2. When you want to generate the exact kernel values for debugging or visualizing the blur effect before applying it to raster images.
 * 3. When you are building a real‑time image processing pipeline and require a 5×5 Gaussian kernel with sigma 1.0 for edge‑preserving smoothing.
 * 4. When you need to export the kernel matrix to a text file or console for documentation or teaching purposes in a .NET project.
 * 5. When you are comparing different blur strengths and need a consistent kernel size to benchmark performance of Aspose.Imaging filters.
 */
