// HOW-TO: Rotate CMX Image 90 Degrees and Convert to TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\output.tif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image, rotate it, and save as TIFF
            using (Image image = Image.Load(inputPath))
            {
                // Cast to the specific CMX image type
                CmxImage cmxImage = (CmxImage)image;

                // Rotate the image 90 degrees clockwise (no flip)
                cmxImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the rotated image as a TIFF file
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
 * 1. When you receive a CMX drawing that was scanned sideways and need to correct its orientation before archiving it as a TIFF file.
 * 2. When an automated workflow must batch‑process legacy CorelDRAW CMX files, rotate them to portrait, and store them in a TIFF format for compatibility with document management systems.
 * 3. When a web service imports user‑uploaded CMX images, applies a 90‑degree rotation to match display requirements, and returns the result as a high‑resolution TIFF.
 * 4. When migrating a design archive, you need to programmatically rotate each CMX page and save it as a TIFF to preserve visual fidelity while standardizing file types.
 * 5. When generating printable assets, you must rotate a CMX logo correctly and export it as a TIFF to ensure proper orientation in print workflows.
 */
