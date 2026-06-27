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
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;

                // Decrease contrast (negative value reduces contrast)
                dicomImage.AdjustContrast(-20f); // approx. 0.8 factor

                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the adjusted image as TIFF
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
 * 1. When a radiology application must convert a DICOM scan to a TIFF file with reduced contrast for clearer visualization on standard monitors.
 * 2. When a healthcare data pipeline needs to preprocess DICOM images by lowering contrast before storing them as TIFFs for integration with legacy PACS systems.
 * 3. When a research project requires batch conversion of DICOM MRI slices to TIFF format while applying a 0.8 contrast factor to enhance tissue differentiation for analysis.
 * 4. When a medical imaging web service uses C# and Aspose.Imaging to adjust the contrast of uploaded DICOM files and deliver the results as TIFFs to non‑DICOM‑aware viewers.
 * 5. When an archival system needs to preserve diagnostic images by converting DICOM files to lossless TIFFs with a consistent contrast reduction to ensure uniform appearance across different viewing platforms.
 */