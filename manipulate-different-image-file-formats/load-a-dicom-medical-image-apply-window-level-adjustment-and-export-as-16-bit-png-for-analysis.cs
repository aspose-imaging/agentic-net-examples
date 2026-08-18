// HOW-TO: Load DICOM Image, Adjust Window Level, Export 16‑Bit PNG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;

                // Apply window level adjustment (approximated with brightness and contrast)
                // These values should be derived from the desired window width/level.
                dicomImage.AdjustBrightness(40);      // Example brightness adjustment
                dicomImage.AdjustContrast(30f);       // Example contrast adjustment

                // Prepare PNG options for 16‑bit output
                var pngOptions = new PngOptions
                {
                    BitDepth = 16
                };

                // Save as 16‑bit PNG
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
 * 1. When a radiology software needs to convert DICOM scans to high‑precision PNG files for downstream analysis, this code loads the DICOM, applies window‑level adjustments, and saves a 16‑bit PNG.
 * 2. When a research project requires batch processing of CT or MRI images to standard PNG format while preserving grayscale depth, developers can use this snippet to adjust brightness/contrast and export 16‑bit PNGs.
 * 3. When integrating a medical imaging viewer that lets clinicians fine‑tune window width and level before exporting images for reports, the code demonstrates how to programmatically apply those adjustments in C#.
 * 4. When a diagnostic AI pipeline expects 16‑bit PNG inputs but the source data is stored as DICOM, this example shows how to transform the files while maintaining image fidelity.
 * 5. When automating quality‑control scripts that verify DICOM files exist and need to be converted to PNG for archival or web display, the code provides a simple error‑checked workflow using Aspose.Imaging for .NET.
 */
