// HOW-TO: Batch Adjust Brightness of DICOM Images and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
                {
                    dicom.AdjustBrightness(10);

                    using (PngOptions pngOptions = new PngOptions())
                    {
                        dicom.Save(outputPath, pngOptions);
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
 * 1. When a medical imaging application needs to preprocess a folder of DICOM scans by brightening them and exporting them as PNGs for web display.
 * 2. When a radiology workflow requires automated conversion of multiple DICOM files to a lightweight format while applying a uniform brightness correction.
 * 3. When a research project must batch‑process DICOM datasets to improve visibility before feeding the images into a machine‑learning model that expects PNG input.
 * 4. When a hospital IT system wants to generate patient‑friendly PNG thumbnails from DICOM studies with consistent brightness for inclusion in reports.
 * 5. When a developer builds a command‑line tool to scan an input directory, adjust each DICOM image’s brightness by ten units, and save the results as PNG files for archival or sharing.
 */
