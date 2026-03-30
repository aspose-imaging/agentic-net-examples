using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        const int maxRetries = 3;
        const int delayMs = 500;
        int attempt = 0;
        RasterImage rasterImage = null;

        // Retry loading the image on transient I/O errors
        while (attempt < maxRetries)
        {
            try
            {
                rasterImage = (RasterImage)Image.Load(inputPath);
                break; // Success
            }
            catch (IOException)
            {
                attempt++;
                if (attempt >= maxRetries)
                {
                    Console.Error.WriteLine($"Failed to load image after {maxRetries} attempts: {inputPath}");
                    return;
                }
                System.Threading.Thread.Sleep(delayMs);
            }
        }

        // Proceed if image was loaded
        using (rasterImage)
        {
            // Apply a Gaussian blur filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Prepare output options
            Source source = new FileCreateSource(outputPath, false);
            PngOptions options = new PngOptions() { Source = source };

            // Save the filtered image
            rasterImage.Save(outputPath, options);
        }
    }
}