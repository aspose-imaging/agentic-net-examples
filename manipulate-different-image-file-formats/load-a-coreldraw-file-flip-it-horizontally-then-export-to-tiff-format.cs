using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\sample.tif";

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

            // Load the CorelDRAW (CDR) file
            using (Image image = Image.Load(inputPath))
            {
                // Flip the image horizontally
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Prepare TIFF save options with default format
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the flipped image as TIFF
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a CorelDRAW CDR illustration into a high‑resolution TIFF for printing while mirroring the artwork horizontally for a right‑to‑left layout.
 * 2. When an automated batch job must read CDR files, apply a horizontal flip to correct reversed designs, and save them as TIFF images for archival in a document management system.
 * 3. When a web service receives user‑uploaded CorelDRAW files and must generate flipped TIFF thumbnails for preview in a gallery view.
 * 4. When a desktop application processes engineering diagrams stored in CDR format, flips them to match a mirrored CAD view, and exports them to TIFF for inclusion in PDF reports.
 * 5. When a migration script needs to transform legacy CDR assets into TIFF format with a horizontal mirror effect to comply with a new branding guideline.
 */