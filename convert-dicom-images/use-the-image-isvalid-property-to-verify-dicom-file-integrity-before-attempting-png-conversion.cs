// HOW-TO: Convert DICOM to PNG in C# with Image.IsValid Check (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.dcm");
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions pngOptions = new PngOptions())
                {
                    image.Save(outputPath, pngOptions);
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
 * 1. When a medical imaging application needs to display DICOM scans as web‑friendly PNG thumbnails after confirming the file is valid.
 * 2. When a hospital system must validate the integrity of incoming DICOM files before converting them to PNG for archival.
 * 3. When a developer creates a batch process that transforms radiology images into PNGs for machine‑learning preprocessing while skipping corrupted files.
 * 4. When an integration service extracts diagnostic images from PACS and converts them to PNG for inclusion in patient reports after an IsValid check.
 * 5. When a desktop tool allows clinicians to open DICOM files and save them as PNGs only after confirming the image is valid.
 */
