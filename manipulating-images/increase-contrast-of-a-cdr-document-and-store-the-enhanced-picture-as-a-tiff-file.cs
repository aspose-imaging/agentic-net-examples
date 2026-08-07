using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.cdr";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR document
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access AdjustContrast
                var raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Increase contrast (value in range [-100, 100])
                raster.AdjustContrast(50f);

                // Save the enhanced image as TIFF
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                raster.Save(outputPath, tiffOptions);
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
 * 1. When a printing service needs to convert a CorelDRAW (CDR) artwork to a high‑resolution TIFF for offset printing and wants to boost the image contrast to make colors pop.
 * 2. When an archival system ingests legacy CDR files and stores them as lossless TIFFs, applying contrast enhancement to improve legibility of scanned drawings.
 * 3. When a document‑management workflow automatically processes design files, increasing contrast of CDR diagrams before saving them as TIFF for OCR processing.
 * 4. When a web application generates preview thumbnails of CDR graphics, adjusting contrast to ensure visual clarity and then exporting the result as a TIFF for downstream editing.
 * 5. When a batch‑conversion utility needs to programmatically load CDR files, apply a 50‑point contrast boost, and output the enhanced images as TIFF files for compliance with industry file‑format standards.
 */