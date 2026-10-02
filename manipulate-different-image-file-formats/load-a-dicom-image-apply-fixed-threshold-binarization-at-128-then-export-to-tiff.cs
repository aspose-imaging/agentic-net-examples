// HOW-TO: Load DICOM Image Apply Fixed Threshold Binarization Save As TIFF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.dcm";
            string outputPath = "output\\result.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            try
            {
                using (var dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
                {
                    var raster = (RasterImage)dicomImage;
                    if (!raster.IsCached) raster.CacheData();
                    raster.BinarizeFixed(128);
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    raster.Save(outputPath, tiffOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to convert DICOM scans into high‑contrast black‑and‑white TIFF files for easier viewing on standard picture viewers.
 * 2. When a radiology workflow requires batch processing of DICOM files to produce printable TIFF reports with a fixed threshold of 128 for consistent binary output.
 * 3. When a research project wants to archive DICOM images as lossless TIFFs after applying a fixed binarization step to simplify image analysis algorithms.
 * 4. When a healthcare integration service must extract pixel data from DICOM, apply a 128‑level threshold, and store the result in a TIFF format compatible with legacy PACS systems.
 * 5. When a developer needs to programmatically load a DICOM file in C#, perform fixed‑threshold binarization, and save the result as a TIFF for downstream processing in non‑medical software.
 */
