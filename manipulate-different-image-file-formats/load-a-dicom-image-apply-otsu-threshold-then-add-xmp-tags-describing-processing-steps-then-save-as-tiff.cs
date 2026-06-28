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
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                dicomImage.BinarizeOtsu();

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
 * 1. When a radiology application needs to convert raw DICOM scans into high‑contrast binary TIFF files for downstream image analysis pipelines.
 * 2. When a hospital’s PACS integration requires automated preprocessing of CT images using Otsu binarization before storing them in a TIFF‑based archival system.
 * 3. When a research project wants to batch‑process DICOM ultrasound frames in C# with Aspose.Imaging to produce thresholded TIFFs that can be easily opened in standard image viewers.
 * 4. When a medical device manufacturer must generate printable TIFF reports from DICOM data, applying Otsu’s method to highlight regions of interest for quality‑control documentation.
 * 5. When a health‑tech startup needs to expose a web API that receives DICOM files, applies Otsu thresholding via Aspose.Imaging, and returns the result as a TIFF for integration with third‑party analytics tools.
 */