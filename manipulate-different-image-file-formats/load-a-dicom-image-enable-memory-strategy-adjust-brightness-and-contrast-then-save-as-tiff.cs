// HOW-TO: Load DICOM, Adjust Brightness and Contrast, Save as TIFF in C# (Aspose.Imaging for .NET)
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
        string outputPath = "output\\output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            var loadOptions = new LoadOptions { BufferSizeHint = 50 };
            using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath, loadOptions))
            {
                var raster = (RasterImage)dicomImage;
                raster.AdjustBrightness(50);
                raster.AdjustContrast(0.2f);

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
 * 1. When a medical imaging application needs to convert raw DICOM scans to TIFF for archival while enhancing visibility by brightening and increasing contrast.
 * 2. When a radiology workflow requires processing large DICOM files with limited memory, using a buffer hint to avoid out‑of‑memory errors.
 * 3. When a developer wants to prepare DICOM images for downstream analysis tools that only accept TIFF format.
 * 4. When an imaging system must programmatically improve the visual quality of DICOM images before displaying them in a .NET UI.
 * 5. When integrating Aspose.Imaging into a C# service that automatically transforms incoming DICOM uploads into high‑contrast TIFF files for reporting.
 */
