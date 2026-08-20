// HOW-TO: Validate PNG Pixel Values After Applying Custom Convolution Kernel in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                bool allValid = true;
                for (int i = 0; i < pixels.Length; i++)
                {
                    int argb = pixels[i];
                    int a = (argb >> 24) & 0xFF;
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    if (a < 0 || a > 255 || r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
                    {
                        allValid = false;
                        Console.WriteLine($"Pixel out of range at index {i}: A={a}, R={r}, G={g}, B={b}");
                        break;
                    }
                }

                Console.WriteLine(allValid ? "All pixel values are within 0-255." : "Some pixel values are out of range.");

                PngOptions options = new PngOptions();
                raster.Save(outputPath, options);
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
 * 1. When you need to ensure that a PNG image processed with a custom edge‑detection kernel does not produce overflow or underflow pixel values before saving it with Aspose.Imaging in C#.
 * 2. When you want to verify that applying any convolution filter (sharpen, blur, emboss) to a raster image keeps all ARGB components within the 0‑255 range to avoid corrupted output files.
 * 3. When building an automated image‑processing pipeline that must detect out‑of‑range pixel values after transformations to maintain compatibility with downstream systems.
 * 4. When debugging a C# application that uses Aspose.Imaging’s Filter method and you need to log the first pixel that exceeds valid color bounds.
 * 5. When creating a quality‑control step for batch‑processed PNG files to confirm that custom kernels do not introduce invalid color data before archiving or publishing.
 */
