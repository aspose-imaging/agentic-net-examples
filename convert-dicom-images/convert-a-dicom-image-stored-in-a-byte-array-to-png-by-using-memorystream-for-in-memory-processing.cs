using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM image from a byte array using MemoryStream
            byte[] dicomBytes = File.ReadAllBytes(inputPath);
            using (var inputStream = new MemoryStream(dicomBytes))
            {
                var loadOptions = new LoadOptions(); // default load options
                using (var dicomImage = new DicomImage(inputStream, loadOptions))
                {
                    // Save the DICOM image as PNG to the output file
                    using (var outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        var pngOptions = new PngOptions();
                        // Empty rectangle indicates the whole image bounds should be used
                        var emptyRect = new Aspose.Imaging.Rectangle();
                        dicomImage.Save(outputStream, pngOptions, emptyRect);
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
 * 1. When a medical imaging web app must show a DICOM scan in a browser without creating temporary files, a developer can load the DICOM byte array into a MemoryStream and convert it to PNG for fast in‑memory rendering.
 * 2. When integrating a PACS system with a reporting tool that only accepts PNG images, a developer can read the DICOM bytes, transform them to PNG using Aspose.Imaging, and embed the result directly into the report.
 * 3. When building a mobile health application that receives DICOM data over a network API, a developer can use MemoryStream to convert the received byte array to PNG for efficient thumbnail generation on the device.
 * 4. When automating a batch job that extracts DICOM images stored as BLOBs in a database and needs to archive them as PNG files for machine‑learning preprocessing, a developer can stream the bytes and save them without intermediate disk I/O.
 * 5. When creating a HIPAA‑compliant service that sanitizes patient images by converting DICOM to PNG in memory before sending them to a third‑party analytics platform, a developer can use this code to avoid persisting raw DICOM files on disk.
 */