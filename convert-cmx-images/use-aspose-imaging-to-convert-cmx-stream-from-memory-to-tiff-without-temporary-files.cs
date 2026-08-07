using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.cmx";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            byte[] cmxData = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(cmxData))
            {
                using (CmxImage cmxImage = (CmxImage)Image.Load(ms))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.Source = new FileCreateSource(outputPath, false);
                    cmxImage.Save(outputPath, tiffOptions);
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
 * 1. When a CAD application receives a CMX drawing as a byte array from a web service and must generate a TIFF preview for display in a browser without writing intermediate files.
 * 2. When an automated document processing pipeline reads CMX files stored in a database BLOB and needs to convert them to multi‑page TIFF for archival while keeping the conversion entirely in memory.
 * 3. When a Windows service monitors a network share, loads CMX files into memory, and creates high‑resolution TIFF images for OCR engines without creating temporary disk files.
 * 4. When a cloud‑based microservice receives CMX data via an API request and must return a TIFF response stream to the client, using Aspose.Imaging to avoid filesystem I/O.
 * 5. When a batch job processes large volumes of CMX drawings stored in memory buffers and converts them to TIFF for printing, ensuring performance by eliminating temporary file overhead.
 */