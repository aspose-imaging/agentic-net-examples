using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\output.tif";

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
                TiffOptions exportOptions = new TiffOptions(TiffExpectedFormat.Default);

                if (image is VectorImage)
                {
                    exportOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };
                }

                image.Save(outputPath, exportOptions);
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
 * 1. When a printing workflow requires archiving multi‑page CMX vector drawings as a single multi‑page TIFF document while keeping the original page sequence for downstream raster‑based printers.
 * 2. When a document management system needs to ingest legacy CMX files and store them as searchable TIFF images that preserve page order for consistent pagination.
 * 3. When a medical imaging application converts multi‑page CMX schematics into TIFF files to embed them in patient records while maintaining the correct slide order.
 * 4. When an e‑learning platform batch‑processes CMX lesson slides into multi‑page TIFFs so that the slides appear in the intended sequence during PDF generation.
 * 5. When a GIS tool exports multi‑page CMX maps to multi‑page TIFFs to ensure that each map layer retains its original ordering for accurate overlay rendering.
 */