using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/sample.png";
        string outputPath = "output/filtered.png";

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
                // Cast to RasterImage for filtering
                Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

                // Apply Gaussian blur filter with radius 5 and sigma 4.0
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Save the filtered image as PNG
                PngOptions pngOptions = new PngOptions();
                rasterImage.Save(outputPath, pngOptions);
            }

            // TODO: Broadcast the filtered image at 'outputPath' to connected SignalR clients.
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}