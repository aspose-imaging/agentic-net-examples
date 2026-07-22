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
        string inputPath = "Input/sample.dcm";
        string outputPath = "Output/output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            var loadOptions = new LoadOptions { BufferSizeHint = 256 * 1024 };
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath, loadOptions))
            {
                dicomImage.AdjustBrightness(30);
                dicomImage.AdjustContrast(20f);

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
 * 1. When a medical imaging application needs to convert DICOM scans to TIFF for archival while adjusting brightness and contrast to improve visual quality, a developer can use this code.
 * 2. When a radiology workflow requires batch processing of large DICOM files on limited memory by enabling a buffer size hint and then exporting them as TIFF for compatibility with PACS viewers, this snippet is applicable.
 * 3. When a healthcare research project wants to preprocess DICOM images in C# by enhancing contrast and brightness before feeding them into analysis tools that only accept TIFF format, the code provides a solution.
 * 4. When a hospital IT system must generate printable TIFF copies of DICOM X‑ray images with standardized brightness and contrast settings while ensuring efficient memory usage, developers can implement this approach.
 * 5. When a diagnostic software needs to load a DICOM image, apply image processing adjustments, and save the result as a high‑resolution TIFF for integration with third‑party reporting software, this example demonstrates the required steps.
 */