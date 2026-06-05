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
            string outputPath = "output\\converted.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Process pages sequentially to avoid loading all at once
                tiffImage.PageExportingAction = delegate (int index, Image page)
                {
                    // Example per-page operation
                    GC.Collect();
                };

                WebPOptions webpOptions = new WebPOptions
                {
                    Lossless = false,
                    Quality = 80
                };

                tiffImage.Save(outputPath, webpOptions);
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
 * 1. When a developer needs to convert scanned multi‑page TIFF documents into lightweight WebP images for faster web delivery while keeping memory usage low.
 * 2. When building a C# service that processes large TIFF archives from medical imaging equipment and must export each page as a compressed WebP without loading the entire file into RAM.
 * 3. When creating an automated batch job that transforms multi‑page TIFF invoices into WebP thumbnails for preview in a portal, using Aspose.Imaging’s sequential page exporting to avoid out‑of‑memory errors.
 * 4. When integrating a document management system that receives multi‑page TIFF uploads and needs to store them as WebP files for mobile apps, leveraging the PageExportingAction to handle each page individually.
 * 5. When developing a cloud‑based image pipeline that streams multi‑page TIFF files from storage and converts them to WebP on‑the‑fly, using sequential batch export mode to ensure scalability and low latency.
 */