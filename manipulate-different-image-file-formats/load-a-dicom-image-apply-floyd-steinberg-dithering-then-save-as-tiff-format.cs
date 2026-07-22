using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.dcm";
            string outputPath = "sample.tif";

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
                // Cast to DicomImage to access DICOM-specific methods
                var dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)image;

                // Apply Floyd‑Steinberg dithering with 1‑bit palette
                dicomImage.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 1, null);

                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the processed image as TIFF
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
 * 1. When a medical imaging application must convert high‑resolution DICOM scans to 1‑bit black‑and‑white TIFF files for archival storage while preserving visual detail using Floyd‑Steinberg dithering.
 * 2. When a radiology workflow needs to generate printable TIFF copies of DICOM X‑ray images for paper reports, applying dithering to maintain contrast on monochrome printers.
 * 3. When a healthcare data‑migration script has to batch‑process DICOM files into TIFF format for integration with legacy PACS systems that only accept TIFF images.
 * 4. When a C# developer wants to create a lightweight thumbnail of a DICOM image by dithering it to a 1‑bit palette and saving it as a TIFF for quick preview in a web portal.
 * 5. When a diagnostic software tool requires converting DICOM images to TIFF with Floyd‑Steinberg dithering to ensure compatibility with third‑party image analysis libraries that operate on TIFF files.
 */