// HOW-TO: Convert DICOM to TIFF with Gamma Adjustment Based on Resolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output/output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                double hRes = dicomImage.HorizontalResolution;
                double vRes = dicomImage.VerticalResolution;

                float gamma = 1.0f;
                if (vRes != 0)
                {
                    gamma = (float)(hRes / vRes);
                    if (gamma <= 0) gamma = 1.0f;
                }

                if (dicomImage is RasterImage raster)
                {
                    raster.AdjustGamma(gamma);
                }

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a medical imaging application needs to export DICOM scans to TIFF for compatibility while preserving visual fidelity by adjusting gamma based on image resolution.
 * 2. When a radiology workflow requires batch conversion of DICOM files to high‑resolution TIFFs and wants automatic gamma correction to match horizontal and vertical DPI.
 * 3. When a developer integrates Aspose.Imaging into a C# service that receives DICOM images and must deliver them as TIFFs for downstream archival systems that expect correct aspect‑ratio rendering.
 * 4. When a research tool processes DICOM images and needs to normalize brightness by computing a gamma factor from the image’s horizontal and vertical resolution before saving as TIFF.
 * 5. When a hospital’s PACS integration needs to convert DICOM studies to TIFF for printing on devices that rely on resolution metadata and proper gamma settings.
 */
