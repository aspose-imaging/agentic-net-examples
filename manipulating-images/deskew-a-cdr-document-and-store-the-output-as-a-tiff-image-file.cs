using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input.cdr";
        string outputPath = @"C:\output.tif";

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
            // Load the CDR document as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Deskew the image (do not resize, use LightGray background)
                image.NormalizeAngle(false, Color.LightGray);

                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the deskewed image as TIFF
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
 * 1. When a printing service receives scanned CorelDRAW (CDR) artwork that is slightly rotated and must be corrected before converting it to a high‑resolution TIFF for press‑ready output.
 * 2. When an archival system needs to automatically normalize the angle of legacy CDR files and store them as lossless TIFF images for long‑term preservation.
 * 3. When a document management workflow requires batch processing of CDR drawings, deskewing each file and saving the result as a TIFF to ensure consistent orientation for downstream OCR.
 * 4. When a graphic‑design automation tool must load a CDR file, remove skew without resizing, and export a TIFF with a LightGray background for preview generation.
 * 5. When a .NET application integrates Aspose.Imaging to clean up user‑uploaded CDR sketches, straighten them, and deliver a TIFF version that can be displayed in web browsers or printed.
 */