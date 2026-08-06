using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (Image cmxImage = Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise (adjust as needed)
                cmxImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the rotated image as TIFF
                cmxImage.Save(outputPath, tiffOptions);
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
 * 1. When a printing workflow receives CMX artwork that was scanned upside‑down and must be rotated before archiving it as a TIFF file for downstream printers.
 * 2. When a document management system imports legacy CorelDRAW CMX drawings and needs to correct their orientation before converting them to searchable TIFF images.
 * 3. When a batch‑processing service handles CAD‑style CMX files from field engineers, applying a 90‑degree rotation to match map orientation before saving them as TIFF for GIS integration.
 * 4. When an e‑learning platform converts user‑uploaded CMX diagrams into TIFF thumbnails and must ensure the diagrams are displayed upright on the course pages.
 * 5. When a medical imaging application receives CMX scans of handwritten notes, rotates them to the proper view, and stores them as TIFF for compliance and long‑term storage.
 */