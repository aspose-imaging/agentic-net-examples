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
            string inputPath = "input.tif";
            string outputPath = "thumbnail.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                int thumbWidth = raster.Width / 4;
                int thumbHeight = raster.Height / 4;
                if (thumbWidth == 0) thumbWidth = 1;
                if (thumbHeight == 0) thumbHeight = 1;

                raster.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                WebPOptions options = new WebPOptions();
                raster.Save(outputPath, options);
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
 * 1. When a developer needs to generate a small preview image from a high‑resolution TIFF file for a web gallery, they can extract and resize the thumbnail and save it as a lightweight WebP file.
 * 2. When building a document management system that stores scanned TIFF pages, the code can create fast‑loading WebP thumbnails for quick browsing in the UI.
 * 3. When integrating with a mobile app that only supports WebP, a developer can convert embedded TIFF thumbnails to WebP to reduce bandwidth and improve performance.
 * 4. When automating batch processing of archival TIFF images, the snippet can produce standardized thumbnail sizes for cataloging and search indexing.
 * 5. When implementing a PDF generation workflow that requires a small preview of each page, the code can resize the TIFF page and output a WebP thumbnail for inclusion in the PDF’s navigation pane.
 */