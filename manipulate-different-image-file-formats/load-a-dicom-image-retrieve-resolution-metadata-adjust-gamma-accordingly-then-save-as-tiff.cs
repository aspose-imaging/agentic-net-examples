// HOW-TO: Load DICOM, Adjust Gamma Based on Resolution, Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "output.tiff";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Retrieve resolution metadata
                double horizontalResolution = dicomImage.HorizontalResolution;
                double verticalResolution = dicomImage.VerticalResolution;

                // Determine gamma based on resolution ratio (example logic)
                float gamma = 1.0f;
                if (verticalResolution != 0)
                {
                    gamma = (float)(horizontalResolution / verticalResolution);
                    if (gamma < 0.1f) gamma = 0.1f;
                    if (gamma > 5.0f) gamma = 5.0f;
                }

                // Adjust gamma
                dicomImage.AdjustGamma(gamma);

                // Save as TIFF
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                dicomImage.Save(outputPath, tiffOptions);
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
 * 1. When converting medical DICOM scans to a standard TIFF format while preserving image quality by applying a gamma correction derived from the scan’s pixel resolution.
 * 2. When extracting horizontal and vertical resolution metadata from a DICOM file to compute a custom gamma value for consistent brightness across different imaging devices.
 * 3. When automating a workflow that reads DICOM images, adjusts their contrast based on resolution ratios, and stores the results as TIFF files for archival or further analysis.
 * 4. When integrating Aspose.Imaging into a C# application to programmatically modify DICOM images’ gamma before exporting them for use in non‑medical imaging software.
 * 5. When needing to validate the existence of a DICOM file, create the output directory, and safely handle errors while converting the image to TIFF with resolution‑aware gamma adjustment.
 */
