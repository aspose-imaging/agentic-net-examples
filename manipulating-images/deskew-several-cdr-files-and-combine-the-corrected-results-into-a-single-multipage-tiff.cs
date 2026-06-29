using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                using (RasterImage raster = (RasterImage)tiff)
                {
                    PngOptions pngOptions = new PngOptions();
                    raster.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert a multi‑page TIFF scan of a document into a PNG image for display in a web application.
 * 2. When an automated batch process must verify that a source TIFF file exists before converting it to PNG to avoid runtime errors.
 * 3. When a document management system requires rasterizing a TIFF into PNG format to enable thumbnail generation and faster preview loading.
 * 4. When a legacy CAD workflow exports drawings as TIFF and the developer must programmatically transform them into lossless PNG files for further image analysis.
 * 5. When a cloud‑based service needs to create the output directory dynamically and save the converted PNG while handling exceptions gracefully.
 */