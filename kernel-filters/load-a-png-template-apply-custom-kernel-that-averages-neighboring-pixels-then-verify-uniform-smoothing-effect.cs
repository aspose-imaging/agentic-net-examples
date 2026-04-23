using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "template.png";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG template
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel operations
                RasterImage raster = (RasterImage)image;

                // Capture pixel data before filtering
                int[] beforePixels = raster.LoadArgb32Pixels(raster.Bounds);

                // Create a 3x3 averaging kernel (each weight = 1/9)
                double[,] kernel = new double[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        kernel[i, j] = 1.0 / 9.0;
                    }
                }

                // Apply the custom convolution filter
                var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, convOptions);

                // Capture pixel data after filtering
                int[] afterPixels = raster.LoadArgb32Pixels(raster.Bounds);

                // Verify that smoothing changed pixel values
                bool changed = false;
                int length = Math.Min(beforePixels.Length, afterPixels.Length);
                for (int i = 0; i < length; i++)
                {
                    if (beforePixels[i] != afterPixels[i])
                    {
                        changed = true;
                        break;
                    }
                }

                if (changed)
                {
                    Console.WriteLine("Smoothing applied: pixel values have changed.");
                }
                else
                {
                    Console.WriteLine("No change detected after applying the filter.");
                }

                // Save the resulting image
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