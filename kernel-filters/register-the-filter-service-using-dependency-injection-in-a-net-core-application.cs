using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions());
                rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to automatically enhance the clarity of uploaded PNG thumbnails before storing them in a web gallery, they can load the image, apply a Sharpen filter, and save the result using Aspose.Imaging in a .NET Core service.
 * 2. When building a batch processing tool that prepares product photos for an e‑commerce catalog, the code can iterate over PNG files, sharpen each raster image, and write the improved files to an output folder.
 * 3. When integrating image preprocessing into an ASP.NET Core API that receives user‑submitted screenshots, the developer can use this snippet to sharpen the image and return a PNG response.
 * 4. When creating a desktop utility that cleans up scanned documents saved as PNG by increasing edge definition, the program loads the raster image, applies the SharpenFilterOptions, and saves the enhanced version.
 * 5. When implementing a CI/CD pipeline step that validates visual assets by applying a sharpen filter to detect loss of detail in PNG files, the code provides a quick way to process each file and verify the output.
 */