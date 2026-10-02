// HOW-TO: Compare Center Pixel Before and After Edge Detection on PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                int centerX = width / 2;
                int centerY = height / 2;

                var region = new Rectangle(centerX - 1, centerY - 1, 3, 3);
                int[] originalPixels = raster.LoadArgb32Pixels(region);
                int beforePixel = originalPixels[4];

                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                double sumA = 0, sumR = 0, sumG = 0, sumB = 0;
                for (int ky = 0; ky < 3; ky++)
                {
                    for (int kx = 0; kx < 3; kx++)
                    {
                        int srcIdx = ky * 3 + kx;
                        int argb = originalPixels[srcIdx];
                        double coeff = kernel[ky, kx];

                        byte a = (byte)((argb >> 24) & 0xFF);
                        byte r = (byte)((argb >> 16) & 0xFF);
                        byte g = (byte)((argb >> 8) & 0xFF);
                        byte b = (byte)(argb & 0xFF);

                        sumA += coeff * a;
                        sumR += coeff * r;
                        sumG += coeff * g;
                        sumB += coeff * b;
                    }
                }

                int aC = (int)Math.Round(sumA);
                int rC = (int)Math.Round(sumR);
                int gC = (int)Math.Round(sumG);
                int bC = (int)Math.Round(sumB);

                aC = Math.Max(0, Math.Min(255, aC));
                rC = Math.Max(0, Math.Min(255, rC));
                gC = Math.Max(0, Math.Min(255, gC));
                bC = Math.Max(0, Math.Min(255, bC));

                int afterPixel = (aC << 24) | (rC << 16) | (gC << 8) | bC;

                Console.WriteLine($"Central pixel before: 0x{beforePixel:X8}");
                Console.WriteLine($"Central pixel after: 0x{afterPixel:X8}");

                originalPixels[4] = afterPixel;
                raster.SaveArgb32Pixels(region, originalPixels);
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
 * 1. Use this code to verify that an edge‑detection filter alters the intensity of the central pixel in a PNG image.
 * 2. Apply it to log pixel‑level differences for debugging image‑processing pipelines in a C# application.
 * 3. Employ the routine in automated tests that compare original and filtered images for quality assurance.
 * 4. Extract a 3×3 region around the image center and apply a custom convolution kernel for scientific analysis.
 * 5. Generate a report of pixel changes after applying sharpening or edge‑enhancement operations in a .NET project.
 */
