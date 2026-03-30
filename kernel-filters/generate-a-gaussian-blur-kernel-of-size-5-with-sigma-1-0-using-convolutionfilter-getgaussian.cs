using System;
using System.IO;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output/kernel.txt";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        double[,] kernel = ConvolutionFilter.GetGaussian(5, 1.0);

        using (StreamWriter writer = new StreamWriter(outputPath))
        {
            int rows = kernel.GetLength(0);
            int cols = kernel.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    writer.WriteLine(kernel[i, j]);
                }
            }
        }

        Console.WriteLine("Gaussian kernel (size=5, sigma=1.0):");
        int r = kernel.GetLength(0);
        int c = kernel.GetLength(1);
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                Console.WriteLine(kernel[i, j]);
            }
        }
    }
}