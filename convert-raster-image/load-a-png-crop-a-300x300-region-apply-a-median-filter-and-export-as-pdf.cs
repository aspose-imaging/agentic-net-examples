using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "Input/sample.png";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (PngImage png = (PngImage)Image.Load(inputPath))
            {
                using (RasterImage raster = (RasterImage)png)
                {
                    raster.Crop(new Rectangle(0, 0, 300, 300));
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));
                    raster.Save(outputPath, new PdfOptions());
                }
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
 * 1. When a developer needs to generate a clean, printable PDF thumbnail from a large PNG logo by extracting a 300 × 300 pixel area and removing noise with a median filter.
 * 2. When an e‑commerce platform must convert product PNG images into PDF brochures, cropping a specific region and smoothing it before embedding in the document.
 * 3. When a medical imaging app requires extracting a 300 × 300 pixel region from a scanned PNG X‑ray, applying a median filter to reduce speckle, and saving the result as a PDF report.
 * 4. When a document management system automates the creation of PDF previews from uploaded PNG scans, using C# and Aspose.Imaging to crop, denoise, and export the selected area.
 * 5. When a GIS tool needs to isolate a 300 × 300 pixel tile from a PNG map, clean it with a median filter, and deliver the tile as a PDF for offline viewing.
 */