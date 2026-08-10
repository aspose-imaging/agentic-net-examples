// HOW-TO: How To Reduce Contrast Of DICOM Image And Save As TIFF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
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
            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                // Decrease contrast by 20% (negative value reduces contrast)
                dicom.AdjustContrast(-20f);

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                dicom.Save(outputPath, tiffOptions);
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
 * 1. When a medical imaging application needs to lower the contrast of a DICOM scan before archiving it as a TIFF file.
 * 2. When a radiology workflow requires converting DICOM images to TIFF format with adjusted contrast for better visualization on non‑DICOM viewers.
 * 3. When a developer wants to preprocess DICOM X‑ray images by decreasing contrast and then store them in a lossless TIFF for reporting purposes.
 * 4. When integrating Aspose.Imaging into a C# service that normalizes image contrast and outputs TIFFs for downstream image analysis tools.
 * 5. When building a batch script that reads DICOM files, applies a 20 % contrast reduction, and saves the results as TIFFs for electronic health record (EHR) systems.
 */
