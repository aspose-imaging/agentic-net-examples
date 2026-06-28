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
        string inputPath = "input.cmx";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);
                    memoryStream.Position = 0;

                    using (Image cmxImage = Image.Load(memoryStream))
                    {
                        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        cmxImage.Save(outputPath, tiffOptions);
                    }
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
 * 1. When a web service receives a CorelDRAW CMX file as a byte stream and must generate a high‑resolution TIFF for printing without creating temporary files on disk.
 * 2. When an automated document workflow reads CMX data from a database BLOB, converts it to TIFF in memory, and stores the TIFF back to the repository for archival compliance.
 * 3. When a desktop application loads a CMX image from a network stream, transforms it to a multi‑page TIFF for inclusion in a PDF report, and saves the result directly to the user‑specified folder.
 * 4. When a cloud‑based image processing pipeline needs to convert uploaded CMX files to TIFF for downstream OCR or barcode detection while keeping the conversion entirely in RAM to improve performance.
 * 5. When a batch job processes a large collection of CMX files stored in a zip archive, extracts each file to a memory stream, converts it to TIFF, and writes the TIFFs to an output directory without intermediate temporary files.
 */