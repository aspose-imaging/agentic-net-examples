using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\output.tif";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare TIFF save options (default format)
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the image as TIFF
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
 * 1. When a print shop needs to convert vector EPS artwork into high‑resolution TIFF files for raster‑based prepress workflows.
 * 2. When a document management system must ingest legacy EPS diagrams and store them as TIFF images for archival and thumbnail generation.
 * 3. When a web application generates PDF reports that include EPS logos and must provide a TIFF version for compatibility with older imaging APIs.
 * 4. When an automated batch process validates that EPS files exist, creates missing output folders, and converts them to TIFF for downstream OCR processing.
 * 5. When a C# desktop utility needs to read an EPS file from disk, apply Aspose.Imaging’s TiffOptions, and save it as a TIFF to be used in GIS or CAD software that only accepts raster formats.
 */