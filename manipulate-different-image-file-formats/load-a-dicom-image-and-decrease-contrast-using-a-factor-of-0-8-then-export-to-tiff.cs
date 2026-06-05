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
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image img = Image.Load(inputPath))
            {
                DicomImage dicom = (DicomImage)img;

                // Decrease contrast by 20% (factor 0.8)
                dicom.AdjustContrast(-20f);

                // Save the result as a TIFF file
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
 * 1. When a medical imaging application needs to convert DICOM scans to a universally viewable TIFF format while reducing contrast to improve visual clarity for radiologists.
 * 2. When a healthcare data pipeline must preprocess DICOM files by decreasing contrast before archiving them as lossless TIFF images for long‑term storage.
 * 3. When a C#‑based diagnostic tool requires batch processing of DICOM images to adjust contrast and export them to TIFF for integration with third‑party reporting software.
 * 4. When a telemedicine platform wants to lower the contrast of patient DICOM images to reduce file size and then save them as TIFF for easy transmission over low‑bandwidth networks.
 * 5. When a research project needs to programmatically load DICOM images, apply a 20 % contrast reduction, and save the results as TIFF files for analysis in image‑processing libraries that do not support DICOM.
 */