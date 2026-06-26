using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "sample.dcm";
            string outputPath = "sample.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the DICOM image and save it as PNG in a single API call
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
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
 * 1. When a medical imaging application needs to convert DICOM scans to PNG thumbnails for quick preview in a web portal.
 * 2. When a radiology workflow requires exporting DICOM files to PNG format for inclusion in patient reports or presentations.
 * 3. When a healthcare data integration service must transform DICOM images into PNG to store them in a non‑medical image repository.
 * 4. When a desktop utility needs to batch‑process DICOM files and save them as PNGs for compatibility with standard image viewers.
 * 5. When a diagnostic software needs to load a DICOM image and instantly save it as PNG to perform further image analysis using generic PNG libraries.
 */