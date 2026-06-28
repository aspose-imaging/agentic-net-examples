using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with kernel size 11 and sigma 4.5 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(11, 4.5));

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to soften the edges of an SVG illustration by applying a Gaussian blur with a kernel size of 11 and sigma 4.5 before converting it to a PNG thumbnail for a web gallery.
 * 2. When an e‑commerce platform wants to add a subtle background blur to SVG product icons using Aspose.Imaging for .NET and then save the result as PNG for faster page loads.
 * 3. When a reporting service generates SVG charts and the developer applies a Gaussian blur filter to reduce visual noise before embedding the rasterized PNG into PDF documents.
 * 4. When a mobile app pre‑processes SVG assets with a Gaussian blur (kernel 11, sigma 4.5) to create a consistent soft‑focus look across different screen resolutions, saving the output as PNG files.
 * 5. When a batch script automatically loads multiple SVG files, applies a Gaussian blur filter with the specified parameters, and saves each image as a PNG for use in email newsletters or social media posts.
 */