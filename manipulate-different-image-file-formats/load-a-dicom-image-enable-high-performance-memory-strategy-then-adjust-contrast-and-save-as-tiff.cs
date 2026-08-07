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
            using (Stream stream = File.OpenRead(inputPath))
            {
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.BufferSizeHint = 1024 * 1024; // 1 MB buffer for high‑performance memory usage

                using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
                {
                    dicomImage.AdjustContrast(50f); // Adjust contrast

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a radiology software needs to convert DICOM scans to TIFF for archival while preserving image quality and adjusting contrast, this code can be used.
 * 2. When a healthcare IT system must process large DICOM files on limited‑memory servers and export them as TIFF for integration with PACS, the high‑performance buffer strategy helps.
 * 3. When a research application requires batch conversion of DICOM images to TIFF with standardized contrast enhancement for analysis in MATLAB, this snippet provides the needed steps.
 * 4. When a medical imaging web service needs to load a DICOM image, apply a contrast boost, and return a TIFF file to browsers without loading the entire image into memory, the code demonstrates the approach.
 * 5. When a diagnostic device developer wants to implement C# code that reads DICOM, tweaks contrast for better visibility, and saves the result as a TIFF file for downstream reporting, this example is applicable.
 */