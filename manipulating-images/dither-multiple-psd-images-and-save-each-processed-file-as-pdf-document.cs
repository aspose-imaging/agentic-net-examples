// HOW-TO: Dither PSD Images and Save as PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            string[] inputPaths = {
                @"C:\Images\image1.psd",
                @"C:\Images\image2.psd"
            };

            string outputDirectory = @"C:\ProcessedPdf";

            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    if (image is RasterImage raster)
                    {
                        raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);
                    }

                    var pdfOptions = new PdfOptions();
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
 * 1. When you need to convert a batch of Photoshop PSD files into print‑ready PDF documents while applying Floyd‑Steinberg dithering to reduce color depth.
 * 2. When you want to generate lightweight PDF previews of high‑resolution PSD artwork for quick sharing or web display.
 * 3. When an automated workflow must process multiple PSD layers, apply 8‑bit dithering, and store the results as PDFs for archival purposes.
 * 4. When a desktop application requires converting user‑uploaded PSD files to PDFs with consistent dithering to ensure uniform appearance across different printers.
 * 5. When you are building a server‑side service that receives PSD files, dithers them to reduce file size, and returns PDF versions for downstream processing.
 */
