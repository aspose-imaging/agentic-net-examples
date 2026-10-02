// HOW-TO: Batch Convert TIFF to PDF with Anti-Aliasing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var inputFiles = new List<string>
            {
                "Input/image1.tif",
                "Input/image2.tif"
            };

            foreach (var inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.ChangeExtension(inputPath, ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height,
                            SmoothingMode = SmoothingMode.AntiAlias
                        }
                    };

                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate printable PDFs from a collection of high‑resolution TIFF scans while preserving image quality with anti‑alias smoothing.
 * 2. When an application must automatically convert scanned documents stored as TIFF files into PDF for archiving or sharing without manual intervention.
 * 3. When a reporting tool requires each page of a multi‑page TIFF to be rendered as a separate PDF page with exact dimensions and a white background.
 * 4. When you want to ensure that vector‑rasterized PDFs retain smooth edges and reduced jaggedness for graphics‑intensive TIFF images in a .NET service.
 * 5. When a batch job processes incoming TIFF files from a folder, creates corresponding PDF files, and saves them to a designated output directory using Aspose.Imaging.
 */
