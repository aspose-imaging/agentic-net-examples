// HOW-TO: Scale DjVu Image Proportionally and Convert to TIFF in C# (Aspose.Imaging for .NET)
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
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputPath = "output.tiff";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load DjVu document
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                // Retrieve original dimensions
                int originalWidth = djvu.Width;
                int originalHeight = djvu.Height;

                // Apply proportional scaling (double the size)
                int newWidth = originalWidth * 2;
                djvu.ResizeWidthProportionally(newWidth, ResizeType.NearestNeighbourResample);

                // Convert and save as TIFF
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
 * 1. When you need to enlarge scanned DjVu pages for better readability before archiving them as high‑resolution TIFF files.
 * 2. When a document‑management system requires DjVu documents to be converted to TIFF while maintaining aspect ratio for downstream processing.
 * 3. When generating printable TIFF copies of DjVu illustrations that must be scaled up without distortion.
 * 4. When integrating a C# service that automatically resizes DjVu graphics to double size and stores them in a TIFF format for compatibility with legacy software.
 * 5. When creating a batch workflow that reads DjVu files, extracts their dimensions, applies proportional scaling, and saves the results as TIFF for OCR or archival purposes.
 */
