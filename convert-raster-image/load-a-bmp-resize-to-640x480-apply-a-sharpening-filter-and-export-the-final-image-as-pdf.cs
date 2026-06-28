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
            string inputPath = "input.bmp";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Resize(640, 480);
                raster.Save(outputPath, new PdfOptions());
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
 * 1. When a developer needs to convert legacy BMP screenshots from an industrial machine into a compact PDF report while scaling them to a standard 640x480 resolution for consistent layout.
 * 2. When an e‑learning platform must generate printable PDF handouts from high‑resolution BMP diagrams, automatically resizing each image to fit a 640x480 page thumbnail.
 * 3. When a document management system ingests scanned BMP files and stores them as searchable PDF files, applying a resize to reduce storage size and improve loading speed.
 * 4. When a Windows desktop application creates PDF invoices that embed product photos originally saved as BMP, resizing the images to 640x480 to maintain a uniform appearance across all pages.
 * 5. When a batch‑processing script prepares marketing assets by converting BMP banners into PDF flyers, resizing each banner to 640x480 and optionally applying a sharpening filter to enhance visual clarity before saving.
 */