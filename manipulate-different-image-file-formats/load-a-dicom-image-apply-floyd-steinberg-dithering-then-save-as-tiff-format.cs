// HOW-TO: Convert DICOM to TIFF with Floyd Steinberg Dithering in C# (Aspose.Imaging for .NET)
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
        string outputPath = "output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.FileFormats.Dicom.DicomImage image = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
            {
                image.Dither(DitheringMethod.FloydSteinbergDithering, 1);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When a medical imaging application needs to archive high‑contrast DICOM scans as lossless TIFF files with Floyd‑Steinberg dithering for better visual quality on monochrome displays.
 * 2. When a radiology workflow requires converting DICOM X‑ray images to TIFF for integration with legacy PACS systems that only accept TIFF inputs.
 * 3. When a developer wants to generate printable TIFF versions of DICOM images with dithering to preserve detail while reducing file size for batch printing.
 * 4. When a research project needs to preprocess DICOM images by applying Floyd‑Steinberg dithering before saving them as TIFF for use in image analysis tools that do not support DICOM.
 * 5. When an application must automatically transform incoming DICOM files into TIFF format with dithering to ensure consistent rendering across non‑medical image viewers.
 */
