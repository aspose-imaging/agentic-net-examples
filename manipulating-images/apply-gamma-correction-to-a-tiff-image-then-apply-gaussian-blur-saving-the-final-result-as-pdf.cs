using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.tif";
        string outputPath = "Output/result.pdf";

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
                RasterImage raster = (RasterImage)image;
                raster.AdjustGamma(2.0f);

                using (PdfOptions pdfOptions = new PdfOptions())
                {
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
 * 1. When a developer needs to enhance the contrast of scanned TIFF images by applying gamma correction before converting them to searchable PDF archives using Aspose.Imaging for .NET.
 * 2. When a developer wants to preprocess medical imaging TIFF files to normalize brightness levels with AdjustGamma and then generate PDF reports for easy distribution.
 * 3. When a developer is building a document management system that must automatically adjust the visual quality of legacy TIFF scans and store the results as PDF files.
 * 4. When a developer must ensure that high‑resolution TIFF photographs are gamma‑corrected for consistent viewing on different devices before being saved as PDF portfolios.
 * 5. When a developer is creating a batch conversion tool that reads TIFF files, applies gamma correction to improve readability, and outputs the final documents in PDF format for compliance purposes.
 */