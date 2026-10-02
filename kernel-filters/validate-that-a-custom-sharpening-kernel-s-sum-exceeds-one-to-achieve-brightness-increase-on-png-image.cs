// HOW-TO: Check Sharpen Kernel Sum for Brightness Increase on PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                double sum = 0;
                for (int i = 0; i < kernel.GetLength(0); i++)
                {
                    for (int j = 0; j < kernel.GetLength(1); j++)
                    {
                        sum += kernel[i, j];
                    }
                }

                if (sum > 1)
                {
                    Console.WriteLine($"Kernel sum is {sum} (>1): brightness increase expected.");
                }
                else
                {
                    Console.WriteLine($"Kernel sum is {sum} (<=1): brightness increase not expected.");
                }

                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to verify that a custom sharpening kernel will brighten a PNG before applying it in a C# image‑processing pipeline.
 * 2. When you want to ensure a user‑defined convolution matrix has a sum greater than one to avoid unexpected darkening of PNG assets.
 * 3. When building an automated batch job that validates image enhancement parameters for PNG files in a .NET application.
 * 4. When debugging why a sharpen filter does not increase brightness on PNG images and need to log the kernel’s total weight.
 * 5. When creating a quality‑control step that checks image‑processing settings for PNG exports in a C# reporting tool.
 */
