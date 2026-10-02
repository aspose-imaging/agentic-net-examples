// HOW-TO: Rotate and Overwrite TIFF Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, options);
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
 * 1. When you need to rotate scanned TIFF documents 90 degrees and save the changes back to the original location without creating a new file.
 * 2. When a batch job must reorient multi‑page TIFF files from a scanner before archiving them on a server.
 * 3. When a medical imaging application requires correcting the orientation of DICOM‑derived TIFF images and overwriting the existing files.
 * 4. When a GIS system processes satellite TIFF tiles, rotates them to match map coordinates, and replaces the old tiles in the dataset.
 * 5. When an automated document workflow needs to flip TIFF pages for proper display and ensure the updated file overwrites the previous version.
 */
