using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output\filtered.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Lazy‑load the image; loading is deferred until the filter is applied
            Lazy<Image> lazyImage = new Lazy<Image>(() => Image.Load(inputPath));

            // Apply a filter (the act of accessing lazyImage.Value triggers loading)
            ApplyGrayscaleFilter(lazyImage);

            // Save the processed image
            var saveOptions = new PngOptions(); // Save as PNG
            lazyImage.Value.Save(outputPath, saveOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Example filter that forces the image to be loaded and could modify it
    static void ApplyGrayscaleFilter(Lazy<Image> lazyImage)
    {
        // Access the image to trigger loading
        Image img = lazyImage.Value;

        // If the image is a raster image, you could convert it to grayscale here.
        // This placeholder demonstrates where image processing would occur.
        // Example (actual API may vary):
        // if (img is RasterImage raster)
        // {
        //     raster.ConvertPixelFormat(PixelFormat.Format8bppIndexed);
        // }
    }
}