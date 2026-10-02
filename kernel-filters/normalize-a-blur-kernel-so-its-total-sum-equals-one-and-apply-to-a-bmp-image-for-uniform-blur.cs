// HOW-TO: Normalize Blur Kernel and Apply Uniform Blur to BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output\\output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 }
                };

                double sum = 0;
                for (int i = 0; i < kernel.GetLength(0); i++)
                {
                    for (int j = 0; j < kernel.GetLength(1); j++)
                    {
                        sum += kernel[i, j];
                    }
                }

                if (sum != 0)
                {
                    for (int i = 0; i < kernel.GetLength(0); i++)
                    {
                        for (int j = 0; j < kernel.GetLength(1); j++)
                        {
                            kernel[i, j] /= sum;
                        }
                    }
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                image.Filter(image.Bounds, filterOptions);

                BmpOptions saveOptions = new BmpOptions();
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
 * 1. When you need to blur a BMP photograph evenly without changing its overall brightness, you can normalize the convolution kernel and apply it with Aspose.Imaging in C#.
 * 2. When preparing thumbnail previews for a desktop application, you may want a consistent softening effect on BMP assets, requiring kernel sum normalization before filtering.
 * 3. When correcting lighting variations in scanned documents saved as BMP, a normalized blur kernel ensures the smoothing filter does not darken or brighten the page.
 * 4. When implementing a custom image‑processing pipeline that must preserve color intensity while applying a 5×5 blur to BMP files, you use the shown code to normalize and convolve the image.
 * 5. When automating batch processing of BMP graphics for a game’s UI, you can apply a uniform blur across all images by normalizing the kernel to keep the total weight equal to one.
 */
