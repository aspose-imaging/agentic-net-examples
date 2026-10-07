// HOW-TO: Test Pixel Clamping for Convolution Filter with Large Kernel Coefficients in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "TestImages";
            string inputPath = Path.Combine(inputDir, "input.png");
            string outputPath = Path.Combine(inputDir, "output.png");

            Directory.CreateDirectory(Path.GetDirectoryName(inputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!File.Exists(inputPath))
            {
                using (Aspose.Imaging.RasterImage img = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(new PngOptions(), 3, 3))
                {
                    int[] pixels = new int[9];
                    int argb = unchecked((int)0xFF646464);
                    for (int i = 0; i < pixels.Length; i++) pixels[i] = argb;
                    img.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, 3, 3), pixels);
                    img.Save(inputPath, new PngOptions());
                }
            }

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                double[,] kernel = new double[,] {
                    {10, 10, 10},
                    {10, 10, 10},
                    {10, 10, 10}
                };
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                image.Filter(image.Bounds, filterOptions);
                image.Save(outputPath, new PngOptions());
            }

            using (Aspose.Imaging.RasterImage result = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(outputPath))
            {
                int[] outPixels = result.LoadArgb32Pixels(result.Bounds);
                bool allClamped = true;
                foreach (int p in outPixels)
                {
                    int a = (p >> 24) & 0xFF;
                    int r = (p >> 16) & 0xFF;
                    int g = (p >> 8) & 0xFF;
                    int b = p & 0xFF;
                    if (a != 255 || r != 255 || g != 255 || b != 255)
                    {
                        allClamped = false;
                        break;
                    }
                }
                Console.WriteLine(allClamped ? "Test Passed" : "Test Failed");
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
 * 1. When you need to verify that applying a high‑gain convolution kernel does not produce invalid color values in a PNG image.
 * 2. When you want to ensure your image‑processing pipeline correctly clamps pixel values after sharpening or edge‑detection filters in C#.
 * 3. When you are writing automated tests to confirm that Aspose.Imaging prevents overflow when custom filter coefficients exceed the normal range.
 * 4. When you need to generate a small test image, apply an extreme convolution, and check that the resulting ARGB values stay within 0‑255 bounds.
 * 5. When you are debugging a bug where brightening filters produce negative or overly bright pixels and you require a reproducible unit test.
 */
