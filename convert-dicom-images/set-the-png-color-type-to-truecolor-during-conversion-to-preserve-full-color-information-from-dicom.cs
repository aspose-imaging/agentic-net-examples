// HOW-TO: Convert DICOM to Truecolor PNG in C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.dcm";
        string outputPath = "output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // Configure PNG options with Truecolor color type
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.Truecolor
            };

            // Load the DICOM image and save it as PNG using the specified options
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, pngOptions);
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
 * 1. When a medical imaging application needs to export DICOM scans as high‑fidelity PNG files for web viewers or reports.
 * 2. When a radiology workflow requires preserving the full color palette of PET or color Doppler images during format conversion.
 * 3. When a C# service processes DICOM files and must generate truecolor PNG thumbnails for patient portals.
 * 4. When developers need to ensure that no color data is lost while converting DICOM to PNG for archival or AI analysis.
 * 5. When integrating Aspose.Imaging into a .NET project to batch‑convert DICOM studies to PNG with truecolor settings for downstream processing.
 */
