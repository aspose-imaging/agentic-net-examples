using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "template.png";
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

                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                double sum = 0;
                foreach (double v in kernel)
                    sum += v;
                if (sum == 0) sum = 1;

                double[,] normalizedKernel = new double[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        normalizedKernel[i, j] = kernel[i, j] / sum;
                    }
                }

                var filterOptions = new ConvolutionFilterOptions(normalizedKernel, 1.0, 0);
                raster.Filter(raster.Bounds, filterOptions);

                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to sharpen a PNG logo by applying a custom convolution kernel to enhance edges before embedding it in a web page.
 * 2. When an e‑commerce platform wants to automatically improve product thumbnail clarity by loading a PNG template, normalizing a sharpening filter, and saving the processed image.
 * 3. When a desktop application generates printable certificates and must apply a custom image filter to the background PNG to ensure crisp text rendering.
 * 4. When a game developer preprocesses sprite sheets in PNG format, applying a normalized convolution filter to boost contrast without altering the file size.
 * 5. When a medical imaging tool prepares PNG scans for analysis by applying a custom kernel to emphasize details while preserving the original dimensions.
 */