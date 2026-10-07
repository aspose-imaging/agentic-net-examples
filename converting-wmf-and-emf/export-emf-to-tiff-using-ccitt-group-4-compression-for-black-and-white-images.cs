// HOW-TO: Convert EMF to TIFF with CCITT Group 4 Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output\\output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.CcittFax4;

                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White
                };

                tiffOptions.VectorRasterizationOptions = vectorOptions;

                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to archive vector‑based EMF drawings as compact black‑and‑white TIFF files for long‑term storage or fax transmission.
 * 2. When a document‑management system requires incoming EMF diagrams to be converted to TIFF using CCITT Group 4 to meet size‑reduction standards.
 * 3. When generating printable PDFs from legacy EMF assets, you first convert them to high‑quality, monochrome TIFFs before embedding.
 * 4. When integrating with a medical imaging workflow that only accepts TIFF images with CCITT compression, you can transform EMF charts accordingly.
 * 5. When building a batch‑processing tool that prepares EMF logos for inclusion in scanned contracts, converting them to TIFF with Group 4 ensures fast loading and minimal file size.
 */
