using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.cmx";
        string outputPath = "output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cmx.Width,
                        PageHeight = cmx.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                cmx.Save(outputPath, pdfOptions);
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
 * 1. When a CAD firm needs to batch‑convert multi‑page CMX drawings into searchable PDFs on a server with limited RAM, they can stream each page to keep memory usage low.
 * 2. When an automated document‑management system processes thousands of high‑resolution CMX blueprints overnight, streaming pages prevents out‑of‑memory crashes during PDF generation.
 * 3. When a cloud‑based microservice receives large CMX files from clients and must return PDF previews without allocating the entire file in memory, page‑by‑page streaming is essential.
 * 4. When a desktop engineering application offers a “Save as PDF” feature for multi‑sheet CMX projects on low‑end workstations, streaming each sheet reduces the application's memory footprint.
 * 5. When a mobile app synchronizes multi‑page CMX drawings from a remote server and needs to convert them to PDF on‑device, streaming pages enables conversion within the device’s limited memory constraints.
 */