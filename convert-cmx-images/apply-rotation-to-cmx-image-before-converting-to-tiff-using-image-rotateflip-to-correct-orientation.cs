// HOW-TO: Rotate CMX Image 90 Degrees and Convert to TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cmx";
            string outputPath = "Output\\sample.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    image.Save(outputPath, tiffOptions);
                }
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
 * 2. When a document management system requires all incoming images in TIFF format, but the source CMX files must be rotated to match the standard portrait layout.
 * 3. When generating printable PDFs from legacy CMX artwork and you must first rotate the image and save it as a high‑resolution TIFF for the printing workflow.
 * 4. When automating batch conversion of CMX files to TIFF and need to ensure each image is rotated 90° to align with downstream GIS applications.
 * 5. When integrating Aspose.Imaging into a C# application that processes CAD drawings, and you must rotate the CMX image before saving it as a TIFF for compliance reporting.
 */
