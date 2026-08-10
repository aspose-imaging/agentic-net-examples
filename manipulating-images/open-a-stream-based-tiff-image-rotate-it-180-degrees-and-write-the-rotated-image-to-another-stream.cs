// HOW-TO: Rotate a TIFF Image 180 Degrees From Stream and Save in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputStream))
            {
                tiffImage.RotateFlip(RotateFlipType.Rotate180FlipNone);

                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffImage.Save(outputPath, saveOptions);
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
 * 1. When a document management system receives multi‑page TIFF files via a network stream and needs to flip them upside down before archiving them.
 * 2. When a medical imaging application must rotate scanned radiology TIFF images by 180° while reading them directly from a file stream to preserve memory usage.
 * 3. When a batch‑processing service processes large TIFF files from cloud storage, rotates them, and writes the result to another stream for further downstream processing.
 * 4. When a desktop utility needs to correct orientation of user‑uploaded TIFF photos without loading the entire image into memory, using Aspose.Imaging’s stream‑based API.
 * 5. When an automated workflow converts incoming TIFF scans into a standardized orientation before embedding them into PDF reports, handling the files as streams for performance.
 */
