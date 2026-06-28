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
            string inputPath = "Images/sample.png";
            string outputPath = "Output/filtered.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));
                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to accept a user‑uploaded PNG, apply a sharpen filter using Aspose.Imaging’s SharpenFilterOptions, and send the processed image back as a FileResult in an ASP.NET Core MVC controller.
 * 2. When an e‑commerce site wants to dynamically enhance product photos on‑the‑fly (e.g., increase edge contrast) and deliver the sharpened PNG directly to the browser without storing a temporary file.
 * 3. When a content‑management system must generate a high‑quality preview of a PNG after applying a custom sharpening strength and return it as a downloadable FileResult for editors.
 * 4. When a reporting dashboard requires real‑time image processing of PNG charts—sharpening them for better readability—and streams the result as a FileResult to the client.
 * 5. When a mobile‑backend API needs to receive a PNG payload, perform server‑side sharpening with Aspose.Imaging, and respond with the filtered image as a FileResult for the mobile app to display.
 */