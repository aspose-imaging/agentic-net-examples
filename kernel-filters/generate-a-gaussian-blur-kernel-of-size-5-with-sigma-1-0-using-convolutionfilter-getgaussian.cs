using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.txt";
            string outputPath = "output\\kernel.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(5, 1.0);

            Console.WriteLine("Gaussian kernel (size=5, sigma=1.0):");
            int rows = kernel.GetLength(0);
            int cols = kernel.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.WriteLine(kernel[i, j]);
                }
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
 * 1. When a developer needs to apply a Gaussian blur to JPEG or PNG images in a .NET application, they can generate a 5×5 kernel with sigma 1.0 using Aspose.Imaging’s ConvolutionFilter.GetGaussian to feed into a convolution operation.
 * 2. When building a medical imaging analysis tool that requires smoothing of DICOM scans before edge detection, the code can create the Gaussian kernel to standardize the blur strength across all slices.
 * 3. When creating a custom thumbnail generator that reduces noise in BMP files, the developer can use the generated kernel to perform a lightweight blur before resizing.
 * 4. When implementing a real‑time video frame pre‑processor in a C# WPF app, the kernel provides a deterministic blur filter that can be applied to each frame’s pixel buffer for consistent visual quality.
 * 5. When writing automated tests for an image‑processing pipeline, the developer can output the kernel values to a text file to verify that the Gaussian parameters (size 5, sigma 1.0) match expected mathematical results.
 */