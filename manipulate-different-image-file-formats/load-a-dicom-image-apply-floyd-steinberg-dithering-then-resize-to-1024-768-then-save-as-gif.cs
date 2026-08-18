// HOW-TO: Convert DICOM to GIF With Floyd‑Steinberg Dithering And Resize In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply Floyd‑Steinberg dithering (8‑bit palette)
                dicomImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                // Resize to 1024×768
                dicomImage.Resize(1024, 768);

                // Save as GIF
                dicomImage.Save(outputPath, new GifOptions());
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
 * 1. When a medical imaging application needs to generate a web‑friendly GIF preview of a DICOM scan with reduced color banding.
 * 2. When a radiology workflow requires converting high‑resolution DICOM files to a smaller 1024×768 GIF for inclusion in patient reports.
 * 3. When a developer wants to apply Floyd‑Steinberg dithering to a DICOM image before resizing to preserve visual detail in limited‑palette formats.
 * 4. When an electronic health record system must automatically transform DICOM images into GIFs for quick viewing on mobile devices.
 * 5. When a batch processing script needs to load DICOM files, dither them, resize, and save as GIFs for archival or transmission over low‑bandwidth networks.
 */
