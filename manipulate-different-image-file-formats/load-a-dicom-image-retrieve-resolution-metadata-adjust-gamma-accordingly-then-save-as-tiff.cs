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
        string inputPath = "input.dcm";
        string outputPath = "output.tiff";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;

                double horizontalResolution = dicomImage.HorizontalResolution;
                double verticalResolution = dicomImage.VerticalResolution;

                float gamma = (float)((horizontalResolution + verticalResolution) / 200.0);
                if (gamma <= 0) gamma = 1.0f;

                dicomImage.AdjustGamma(gamma);

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
 * 1. When a medical imaging application needs to convert DICOM scans to TIFF for archival while preserving resolution‑based gamma correction.
 * 2. When a radiology workflow requires extracting horizontal and vertical resolution metadata from a DICOM file to dynamically adjust image brightness before saving as a TIFF for reporting.
 * 3. When a healthcare data integration service must validate the existence of a DICOM file, read its resolution, apply gamma correction, and output a TIFF compatible with PACS viewers.
 * 4. When a C# developer builds a batch‑processing tool that reads DICOM images, computes gamma from resolution values, and stores the adjusted images as TIFF files for downstream analysis.
 * 5. When a diagnostic imaging platform needs to ensure that converted TIFF images retain proper visual contrast by using resolution‑derived gamma adjustment during the DICOM‑to‑TIFF conversion.
 */