// HOW-TO: Load DICOM, Adjust Brightness and Contrast, Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new Aspose.Imaging.LoadOptions { BufferSizeHint = 256 * 1024 };

            using (Aspose.Imaging.Image img = Aspose.Imaging.Image.Load(inputPath, loadOptions))
            {
                var dicomImage = (DicomImage)img;

                dicomImage.AdjustBrightness(30);
                dicomImage.AdjustContrast(20f);

                using (var tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    dicomImage.Save(outputPath, tiffOptions);
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
 * 1. When a medical imaging application needs to convert raw DICOM scans to high‑resolution TIFF files while enhancing visibility by increasing brightness and contrast.
 * 2. When processing large DICOM datasets on limited memory, developers can use a buffer size hint to load images efficiently before exporting them.
 * 3. When integrating radiology images into a document management system that only accepts TIFF, the code adjusts image quality and saves the result in a compatible format.
 * 4. When building a C# tool that prepares DICOM images for printing or archival, adjusting brightness and contrast ensures consistent visual appearance across devices.
 * 5. When automating batch conversion of DICOM files to TIFF for machine‑learning preprocessing, the memory strategy and pixel adjustments improve performance and data quality.
 */
