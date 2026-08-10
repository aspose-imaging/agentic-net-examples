// HOW-TO: Batch Convert DICOM Images to GIF with Contrast Adjustment in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input DICOM files (modify paths as needed)
            string[] inputPaths = new[]
            {
                @"C:\Images\Input1.dcm",
                @"C:\Images\Input2.dcm",
                @"C:\Images\Input3.dcm"
            };

            // Hard‑coded output directory for GIF files
            string outputDirectory = @"C:\Images\Output";

            // Ensure the output directory exists (unconditional per requirements)
            Directory.CreateDirectory(outputDirectory);

            foreach (string inputPath in inputPaths)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the DICOM image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to DicomImage to access AdjustContrast
                    DicomImage dicomImage = (DicomImage)image;

                    // Adjust contrast by 30 (approximately a 1.3 factor)
                    dicomImage.AdjustContrast(30f);

                    // Build output file path (same base name with .gif extension)
                    string outputPath = Path.Combine(outputDirectory,
                        Path.GetFileNameWithoutExtension(inputPath) + ".gif");

                    // Ensure the directory for this output file exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as GIF
                    dicomImage.Save(outputPath, new GifOptions());
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
 * 1. When a medical imaging application needs to generate lightweight GIF previews of DICOM scans after enhancing contrast for better visibility.
 * 2. When a hospital’s reporting system must automatically process a batch of DICOM files and export them as GIFs for inclusion in web‑based patient records.
 * 3. When a research project requires converting multiple DICOM images to GIF format while applying a 1.3 contrast factor to improve feature detection in presentations.
 * 4. When a radiology workflow needs to create animated GIF sequences from DICOM slices with consistent contrast enhancement for training materials.
 * 5. When a C# utility must read several DICOM files, adjust their contrast, and save them as GIFs to reduce file size for email distribution.
 */
