using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        const string inputPath = "Images/sample.png";
        const string outputPath = "Output/filtered.png";

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
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));
                raster.Save(outputPath, new PngOptions());
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
 * 1. When a web application must accept a PNG upload, apply a median filter to reduce noise, and send the processed image back to the browser as a FileResult in an ASP.NET Core MVC controller.
 * 2. When an e‑commerce site wants to generate a clean product thumbnail on‑the‑fly by filtering a JPEG image and returning it as a downloadable file from a controller action.
 * 3. When a medical imaging portal needs to preprocess DICOM‑converted PNG scans with a median filter and deliver the filtered image as a FileResult for further analysis.
 * 4. When a content management system provides an API endpoint that receives an image path, applies a median filter using Aspose.Imaging, and streams the filtered PNG back to client applications.
 * 5. When a reporting dashboard dynamically creates noise‑reduced charts in BMP format, filters them, and returns the result as a FileResult for embedding in PDF reports.
 */