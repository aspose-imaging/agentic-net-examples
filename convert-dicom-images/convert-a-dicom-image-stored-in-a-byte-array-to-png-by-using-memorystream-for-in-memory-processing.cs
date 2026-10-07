// HOW-TO: Convert DICOM Byte Array to PNG Using MemoryStream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            byte[] dicomBytes = File.ReadAllBytes(inputPath);
            using (var inputStream = new MemoryStream(dicomBytes))
            {
                using (var dicomImage = (DicomImage)Image.Load(inputStream))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    var pngOptions = new PngOptions();
                    dicomImage.Save(outputPath, pngOptions);
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
 * 1. When a medical imaging application receives DICOM data over a network as a byte array and needs to display or store it as a PNG for web viewing.
 * 2. When a PACS system exports DICOM files and you must convert them in‑memory to PNG without writing temporary files to disk.
 * 3. When you are building a C# service that processes radiology scans and requires conversion of raw DICOM bytes to PNG for downstream AI analysis.
 * 4. When you need to generate thumbnail previews of DICOM images in a Windows desktop app by loading the bytes into a MemoryStream and saving as PNG.
 * 5. When you want to archive DICOM images as lossless PNGs in a cloud storage bucket while keeping the conversion process entirely in memory for performance.
 */
