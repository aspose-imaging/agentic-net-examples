// HOW-TO: Batch Remove Watermarks from TIFF Files Using Content Aware Fill in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";

            string[] tiffFiles = Directory.GetFiles(inputFolder, "*.tif");
            foreach (string inputPath in tiffFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage rasterImage = (RasterImage)image;

                    // Create a mask covering the whole image
                    var mask = new GraphicsPath();
                    var figure = new Figure();
                    var rect = new RectangleF(0, 0, rasterImage.Width, rasterImage.Height);
                    figure.AddShape(new RectangleShape(rect));
                    mask.AddFigure(figure);

                    var options = new ContentAwareFillWatermarkOptions(mask);

                    using (RasterImage result = WatermarkRemover.PaintOver(rasterImage, options))
                    {
                        string fileName = Path.GetFileNameWithoutExtension(inputPath);
                        string outputPath = Path.Combine(outputFolder, fileName + "_clean.tif");

                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        var tiffSaveOptions = new TiffOptions(TiffExpectedFormat.Default);
                        result.Save(outputPath, tiffSaveOptions);
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
 * 1. When you need to automatically clean a large collection of scanned TIFF documents that contain printed watermarks before archiving them.
 * 2. When a document management system must strip watermarks from multi‑page TIFF files on upload to improve OCR accuracy.
 * 3. When a medical imaging workflow requires batch removal of annotation watermarks from DICOM‑converted TIFF images while preserving image quality.
 * 4. When a GIS application processes satellite TIFF tiles and must eliminate branding watermarks using content‑aware fill without manual editing.
 * 5. When a legal firm wants to prepare TIFF evidence files for court by programmatically removing watermarks in bulk using C# and Aspose.Imaging.
 */
