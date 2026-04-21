using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
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

            // Retry mechanism for transient I/O errors during loading
            const int maxRetries = 3;
            Image image = null;
            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    image = Image.Load(inputPath);
                    break; // Success
                }
                catch (IOException ioEx)
                {
                    if (attempt == maxRetries)
                    {
                        Console.Error.WriteLine($"Failed to load image after {maxRetries} attempts: {ioEx.Message}");
                        return;
                    }
                    // Optionally, could log the transient error and retry
                }
            }

            // If loading failed unexpectedly
            if (image == null)
            {
                Console.Error.WriteLine("Image loading failed.");
                return;
            }

            // Process the image within a using block to ensure disposal
            using (image)
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply a sharpen filter to the entire image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save the filtered image
                rasterImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}