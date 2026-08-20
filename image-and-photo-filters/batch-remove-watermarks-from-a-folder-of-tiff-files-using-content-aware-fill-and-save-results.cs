// HOW-TO: Batch Remove Watermarks From TIFF Files Using Content Aware Fill In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            foreach (string filePath in Directory.GetFiles(inputFolder, "*.tif"))
            {
                string inputPath = filePath;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(filePath) + "_cleaned.tif");
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                using (Image image = Image.Load(inputPath))
                {
                    TiffImage tiffImage = (TiffImage)image;

                    // Create a mask covering the whole image (placeholder)
                    GraphicsPath mask = new GraphicsPath();
                    Figure figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(0, 0, tiffImage.Width, tiffImage.Height)));
                    mask.AddFigure(figure);

                    var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                    {
                        MaxPaintingAttempts = 4
                    };

                    using (RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(tiffImage, options))
                    {
                        result.Save(outputPath);
                    }
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
 * 1. When a company needs to automatically clean scanned contract pages stored as TIFFs by removing embedded watermarks before archiving them.
 * 2. When a medical imaging system must strip branding watermarks from a batch of DICOM‑converted TIFF scans for anonymized research data.
 * 3. When a publishing workflow requires bulk removal of publisher watermarks from high‑resolution TIFF artwork before printing.
 * 4. When a legal firm wants to process thousands of TIFF evidence files, erasing confidential watermarks while preserving image quality.
 * 5. When a GIS application has to prepare satellite TIFF tiles by programmatically erasing watermarks using content‑aware fill for further analysis.
 */
