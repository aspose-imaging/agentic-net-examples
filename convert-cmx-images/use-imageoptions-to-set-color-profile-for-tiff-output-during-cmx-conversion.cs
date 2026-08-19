// HOW-TO: Convert CMX File to TIFF with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cmx";
            string outputPath = "Output/output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);

            using (Image cmxImage = Image.Load(inputPath))
            {
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
 * 1. When a CAD application needs to export legacy CorelDRAW CMX drawings as high‑resolution TIFF images for printing or archival.
 * 2. When a document‑management system must batch‑convert uploaded CMX files to TIFF to ensure compatibility with downstream OCR engines.
 * 3. When a web service receives CMX artwork and must provide a TIFF version for clients that only support raster formats.
 * 4. When a migration script has to transform CMX assets into TIFF while preserving image options using Aspose.Imaging in a .NET environment.
 * 5. When an automated workflow requires converting CMX files to TIFF on a server without installing CorelDRAW, using C# code.
 */
