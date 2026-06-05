using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/kernel.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] kernel2D = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(5, 1.0);

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                int rows = kernel2D.GetLength(0);
                int cols = kernel2D.GetLength(1);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        writer.WriteLine(kernel2D[i, j]);
                    }
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
 * 1. When a developer needs to generate a 5×5 Gaussian blur kernel with sigma 1.0 in C# to apply a softening effect to PNG images using Aspose.Imaging’s convolution filter.
 * 2. When building a preprocessing pipeline that exports the Gaussian kernel to a .txt file for reuse in external scripts or cross‑platform image‑processing tools.
 * 3. When creating a reusable kernel file that will be loaded by a real‑time video filter written in C# to blur each frame consistently.
 * 4. When validating the correctness of Aspose.Imaging’s GetGaussian method by writing the kernel values to a text file and comparing them against a reference dataset.
 * 5. When documenting a step‑by‑step example that shows how to serialize a Gaussian blur kernel to a text file for educational or debugging purposes.
 */