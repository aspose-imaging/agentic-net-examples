// HOW-TO: Flip CorelDRAW Image Horizontally and Save as TIFF in C# (Aspose.Imaging for .NET)
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
        string inputPath = "Input/input.cdr";
        string outputPath = "Output/output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When you need to mirror a CDR illustration before printing it on a label, you can load the CorelDRAW file, flip it horizontally, and export it as a high‑resolution TIFF for the printer.
 * 2. When a workflow requires converting legacy CorelDRAW graphics to a lossless TIFF format for archival or compliance purposes, this code flips the image to match the original orientation and saves it.
 * 3. When generating side‑by‑side product mockups, you may need to programmatically reverse a CDR design and store the result as a TIFF that can be layered in Photoshop.
 * 4. When automating a batch process that prepares CorelDRAW assets for a publishing pipeline, you can use this snippet to horizontally flip each drawing and output TIFF files compatible with desktop publishing software.
 * 5. When integrating a C# application with a document management system that only accepts TIFF images, this code lets you transform a CorelDRAW file, apply a horizontal flip, and upload the resulting TIFF.
 */
