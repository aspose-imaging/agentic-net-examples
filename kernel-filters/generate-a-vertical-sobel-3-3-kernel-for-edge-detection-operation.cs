using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.png";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] sobelKernel = new double[,]
                {
                    { -1, -2, -1 },
                    {  0,  0,  0 },
                    {  1,  2,  1 }
                };

                var options = new ConvolutionFilterOptions(sobelKernel, 1.0, 0);
                raster.Filter(raster.Bounds, options);
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
 * 1. When a developer needs to detect vertical edges in a PNG image—such as enhancing scanned documents before OCR—they can apply the Sobel 3×3 kernel using Aspose.Imaging’s ConvolutionFilterOptions in C#.
 * 2. When building a traffic‑analysis system, a developer can highlight vertical lane markings in camera‑captured PNG frames by applying the vertical Sobel filter with Aspose.Imaging.
 * 3. When creating GIS maps, a developer may extract building outlines from aerial PNG imagery by detecting vertical edges using the Sobel convolution kernel provided by Aspose.Imaging.
 * 4. When preparing product photos for e‑commerce, a developer can emphasize product contours by applying the vertical Sobel filter to PNG files before background removal.
 * 5. When processing medical X‑ray images, a developer can isolate bone structures by detecting vertical gradients using the Sobel 3×3 kernel in a C# Aspose.Imaging workflow.
 */