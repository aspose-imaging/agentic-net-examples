// HOW-TO: Convert DICOM Image to PNG in ASP.NET Core API C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions())
                {
                    dicom.Save(outputPath, options);
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
 * 1. When a healthcare web service needs to deliver radiology scans as PNG thumbnails to browsers.
 * 2. When a PACS integration requires converting DICOM files to PNG for storage in a non‑medical image repository.
 * 3. When a mobile app consumes an ASP.NET Core endpoint that returns PNG byte arrays instead of raw DICOM data.
 * 4. When a reporting tool must embed DICOM images into PDF documents that only support PNG format.
 * 5. When an automated pipeline processes incoming DICOM files and exposes them via a REST API as PNG streams for downstream analytics.
 */
