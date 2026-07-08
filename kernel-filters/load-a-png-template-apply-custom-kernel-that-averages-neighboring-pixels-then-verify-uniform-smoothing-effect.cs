using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "template.png";
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

                double[,] kernel = new double[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        kernel[i, j] = 1.0 / 9.0;
                    }
                }

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

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
 * 1. When a developer needs to smooth a PNG template to reduce visual noise before embedding it in a PDF report.
 * 2. When an application must apply a uniform averaging filter to a raster image to create a consistent blur effect for UI thumbnails.
 * 3. When a batch processing script has to load PNG files, perform convolution with a 3x3 kernel, and save the result without losing transparency.
 * 4. When a game developer wants to pre‑process sprite sheets by applying a simple low‑pass filter to avoid jagged edges during scaling.
 * 5. When a web service generates custom PNG graphics and needs to ensure a uniform smoothing effect across the entire image using C# and Aspose.Imaging.
 */