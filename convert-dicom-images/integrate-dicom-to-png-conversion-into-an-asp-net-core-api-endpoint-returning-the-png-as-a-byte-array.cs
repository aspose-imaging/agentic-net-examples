// HOW-TO: Convert DICOM File To PNG Byte Array In ASP.NET Core (Aspose.Imaging for .NET)
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
        string inputPath = "Input/sample.dcm";
        string outputPath = "Output/sample.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    dicomImage.Save(memoryStream, pngOptions);
                    byte[] pngBytes = memoryStream.ToArray();

                    File.WriteAllBytes(outputPath, pngBytes);
                    Console.WriteLine($"PNG byte array length: {pngBytes.Length}");
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
 * 1. When a medical imaging web service needs to deliver DICOM scans as PNG images for browser display.
 * 2. When integrating a PACS system with a .NET API that must provide thumbnails of DICOM studies as PNG byte streams.
 * 3. When building a telemedicine portal that converts uploaded DICOM files to PNG for inclusion in patient reports.
 * 4. When creating a microservice that transforms DICOM images into PNG for downstream AI models that accept raster formats.
 * 5. When developing a mobile app backend that fetches DICOM scans from storage and returns them as PNG byte arrays to reduce client‑side processing.
 */
