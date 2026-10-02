// HOW-TO: Batch Convert DICOM to TIFF with Otsu Threshold in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".tiff");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicom = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
                {
                    RasterCachedImage rci = dicom as RasterCachedImage;
                    if (rci != null)
                    {
                        if (!rci.IsCached) rci.CacheData();
                        rci.BinarizeOtsu();
                    }

                    using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                    {
                        dicom.Save(outputPath, tiffOptions);
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
 * 1. When a hospital needs to preprocess a series of DICOM scans for archival storage as binary TIFF files.
 * 2. When a medical imaging researcher wants to apply Otsu binarization to multiple DICOM images before feeding them into a machine‑learning model.
 * 3. When a radiology software vendor must convert patient DICOM files to TIFF for integration with a legacy PACS that only supports TIFF.
 * 4. When a developer automates batch processing of DICOM images to generate high‑contrast TIFFs for printing or reporting.
 * 5. When a health‑tech startup needs to generate lightweight, thresholded TIFF thumbnails from DICOM datasets for web preview.
 */
