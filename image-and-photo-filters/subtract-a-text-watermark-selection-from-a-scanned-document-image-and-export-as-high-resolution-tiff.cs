// HOW-TO: Remove Text Watermark from Scanned Image and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.tif";

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
                RasterImage raster = (RasterImage)image;

                // Define mask covering the watermark area (example coordinates)
                GraphicsPath mask = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50, 50, 200, 50)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                using (RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    result.Save(outputPath, tiffOptions);
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
 * 1. When you need to clean up a scanned JPEG page by removing a printed text watermark before archiving it as a high‑resolution TIFF.
 * 2. When an OCR pipeline requires a watermark‑free image to improve text recognition accuracy, and you must output the result in TIFF format for downstream processing.
 * 3. When a document management system stores scanned documents as JPEGs with confidential watermarks that must be stripped before converting them to lossless TIFF for legal compliance.
 * 4. When a batch job processes scanned invoices, removing the “Paid” stamp watermark and saving the cleaned images as TIFF to preserve detail for printing.
 * 5. When a medical imaging workflow receives scanned reports with overlay text that must be removed and the clean image saved as a high‑resolution TIFF for archival standards.
 */
