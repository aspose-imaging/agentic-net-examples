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
            string outputPath = "output\\sample.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Apply Floyd‑Steinberg dithering with 1‑bit palette
                dicomImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Save the result as TIFF
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
 * 1. When a hospital IT system needs to convert high‑resolution DICOM scans into 1‑bit black‑and‑white TIFF files for fast archival and lossless storage, developers can use this code.
 * 2. When a radiology web portal must display DICOM images on browsers that only support TIFF, applying Floyd‑Steinberg dithering ensures the visual quality of the monochrome conversion.
 * 3. When a medical device manufacturer wants to generate printable hard‑copy reports from DICOM data, the code creates TIFF files with dithering that are suitable for laser printers.
 * 4. When a research lab requires batch processing of DICOM images into TIFF format with a reduced file size for machine‑learning pipelines, this snippet provides the necessary C# workflow.
 * 5. When a healthcare compliance audit demands that diagnostic images be stored in a non‑proprietary format with a fixed 1‑bit palette, developers can employ this code to transform DICOM to TIFF using Aspose.Imaging.
 */