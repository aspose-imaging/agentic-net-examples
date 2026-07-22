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

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = new double[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        kernel[i, j] = 1.0 / 25.0;
                    }
                }

                var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, convOptions);

                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to reduce noise in a scanned PNG document before performing OCR, they can use this 5x5 averaging kernel to smooth the image.
 * 2. When preparing product photos for an e‑commerce website, a C# application can apply the convolution filter to soften harsh edges in PNG files.
 * 3. When creating a thumbnail generator that must preserve PNG transparency while removing grainy artifacts, the code can be used to apply a uniform blur.
 * 4. When building a batch image‑processing pipeline that normalizes lighting across a series of PNG screenshots, the 5x5 average filter helps even out pixel intensity variations.
 * 5. When implementing a custom pre‑processing step for computer‑vision analysis on PNG images, developers can use this code to apply a simple smoothing filter to improve detection accuracy.
 */