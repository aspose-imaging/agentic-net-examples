using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input DICOM files and output directory
        string[] inputFiles = new string[]
        {
            @"C:\Images\image1.dcm",
            @"C:\Images\image2.dcm",
            @"C:\Images\image3.dcm"
        };
        string outputDirectory = @"C:\Output\";

        try
        {
            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output GIF path
                string outputPath = Path.Combine(
                    outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".gif");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DICOM image, adjust contrast, and save as GIF
                using (Image image = Image.Load(inputPath))
                {
                    DicomImage dicomImage = (DicomImage)image;

                    // Adjust contrast by 30 (approximately 1.3 factor)
                    dicomImage.AdjustContrast(30f);

                    // Save the processed image as GIF
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
 * 1. When a medical imaging application must convert a set of DICOM scans to lightweight GIF files with enhanced contrast for quick web preview.
 * 2. When a radiology research pipeline needs to batch‑process multiple DICOM images, apply a 1.3 contrast factor, and store the results in a shared folder for downstream analysis.
 * 3. When a hospital’s PACS integration script has to generate GIF thumbnails from DICOM files while improving visibility of subtle details.
 * 4. When a C# desktop tool is built to automate the export of DICOM series to GIF format for inclusion in patient reports, ensuring consistent contrast across all images.
 * 5. When a health‑tech startup wants to preprocess DICOM datasets by adjusting contrast and converting them to GIFs in one pass to reduce storage and simplify image handling in a .NET environment.
 */