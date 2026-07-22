using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.djvu";
        string outputPath = "output/output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                // Retrieve original dimensions
                int originalWidth = djvu.Width;
                int originalHeight = djvu.Height;

                // Proportional scaling: double the width (height adjusts automatically)
                djvu.ResizeWidthProportionally(originalWidth * 2, ResizeType.NearestNeighbourResample);

                // Save the resized image as TIFF
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                djvu.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to import a scanned DjVu document, double its size while preserving aspect ratio, and store it as a high‑resolution TIFF for archival or printing purposes.
 * 2. When a legal‑tech application must convert multi‑page DjVu case files into TIFF images with proportional scaling to meet court‑required image specifications.
 * 3. When a digital library system processes DjVu e‑books, enlarges each page for better readability on high‑DPI displays, and saves the result as TIFF for compatibility with legacy viewers.
 * 4. When an OCR pipeline requires DjVu source pages to be upscaled proportionally before converting them to TIFF, ensuring the text extraction engine receives sufficiently detailed raster images.
 * 5. When a medical imaging workflow receives DjVu scans of patient records, needs to double the width while maintaining aspect ratio, and output TIFF files for integration with DICOM‑compatible software.
 */