// HOW-TO: Convert DICOM Byte Array to PNG Using MemoryStream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.dcm";
        string outputPath = @"C:\Temp\output.png";

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

            // Read DICOM file into a byte array
            byte[] dicomBytes = File.ReadAllBytes(inputPath);

            // Load DICOM image from memory stream
            using (MemoryStream inputStream = new MemoryStream(dicomBytes))
            {
                // Optional: configure load options (e.g., buffer size)
                LoadOptions loadOptions = new LoadOptions();

                using (DicomImage dicomImage = new DicomImage(inputStream, loadOptions))
                {
                    // Save the first page (or the whole image) as PNG to output file
                    using (FileStream outputStream = File.OpenWrite(outputPath))
                    {
                        // Empty rectangle means use the whole image bounds
                        Rectangle bounds = new Rectangle();

                        // Save using PNG options
                        PngOptions pngOptions = new PngOptions();

                        dicomImage.Save(outputStream, pngOptions, bounds);
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
 * 1. When a medical imaging application receives DICOM data over a network as a byte array and must display or store it as a PNG without writing temporary files.
 * 2. When a cloud‑based service needs to convert uploaded DICOM scans to PNG thumbnails for web preview while keeping the conversion entirely in memory.
 * 3. When a desktop tool processes PACS‑exported DICOM files and wants to save them as PNG for integration with non‑medical image viewers.
 * 4. When a batch job reads DICOM files from a database BLOB column, converts each to PNG, and writes the results to a file system using Aspose.Imaging.
 * 5. When a unit test validates that a DICOM image can be loaded from a MemoryStream and correctly saved as PNG without accessing the disk.
 */
