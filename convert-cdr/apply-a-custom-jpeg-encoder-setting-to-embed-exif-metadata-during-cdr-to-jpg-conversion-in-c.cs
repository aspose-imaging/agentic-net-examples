using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
            {
                cdr.CacheData();

                int width = cdr.Width;
                int height = cdr.Height;

                using (var jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    KeepMetadata = true,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = width,
                        PageHeight = height
                    }
                })
                {
                    cdr.Save(outputPath, jpegOptions);
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
 * 1. When a graphic design studio needs to batch‑convert CorelDRAW (CDR) files to high‑quality JPEGs while preserving EXIF metadata for downstream cataloging.
 * 2. When an e‑commerce platform wants to generate product thumbnails from vendor‑supplied CDR artwork and embed camera‑like metadata for SEO‑friendly image indexing.
 * 3. When a digital archiving system must rasterize vector CDR drawings into JPEGs with a white background and retain original metadata for compliance audits.
 * 4. When a mobile app backend processes user‑uploaded CDR logos and converts them to JPEGs at 90 % quality, keeping EXIF data for later image analytics.
 * 5. When a printing service automates the preparation of CDR designs for web preview, using custom JPEG encoder settings to embed metadata that tracks source file information.
 */