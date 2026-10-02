// HOW-TO: Load DICOM, Adjust Contrast, and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            var loadOptions = new LoadOptions { BufferSizeHint = 1024 };
            using (var dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath, loadOptions))
            {
                var raster = (RasterImage)dicomImage;
                raster.AdjustContrast(50f);

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a radiology software needs to convert DICOM scans to TIFF for archival while enhancing image contrast for better visual inspection.
 * 2. When a medical imaging workflow requires fast, low‑memory loading of large DICOM files before exporting them to a format compatible with standard picture viewers.
 * 3. When a developer builds a C# service that processes DICOM images, adjusts contrast to highlight details, and stores the result as TIFF for downstream analysis.
 * 4. When integrating Aspose.Imaging into a PACS system to batch‑convert DICOM studies to high‑resolution TIFFs with optimized memory usage.
 * 5. When creating a diagnostic reporting tool that reads DICOM, applies a contrast boost, and saves the output as TIFF for inclusion in PDF reports.
 */
