// HOW-TO: Convert DICOM to PNG while Preserving XMP Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputPath = "output\\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image img = Image.Load(inputPath))
            {
                DicomImage dicomImage = img as DicomImage;
                if (dicomImage == null)
                {
                    Console.Error.WriteLine("Failed to load DICOM image.");
                    return;
                }

                // Extract XMP metadata from the DICOM image
                var xmpMetadata = dicomImage.XmpData;

                // Configure PNG options and embed the extracted metadata
                var pngOptions = new PngOptions
                {
                    KeepMetadata = true,
                    XmpData = xmpMetadata
                };

                // Save the image as PNG with metadata
                dicomImage.Save(outputPath, pngOptions);
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
 * 1. When a medical imaging system must export DICOM scans as PNG files for web viewers while keeping the original XMP metadata for audit trails.
 * 2. When a research project needs to convert patient scans to a lightweight format for machine‑learning pipelines but still retain the embedded metadata for later reference.
 * 3. When a hospital’s PACS integration requires generating PNG thumbnails that include the DICOM’s metadata to ensure traceability across different software tools.
 * 4. When a compliance audit demands that any converted image files preserve the source metadata, enabling verification that the PNG originated from a specific DICOM study.
 * 5. When a developer builds a document‑management workflow that stores diagnostic images as PNGs yet must retain the original DICOM tags for regulatory reporting.
 */
