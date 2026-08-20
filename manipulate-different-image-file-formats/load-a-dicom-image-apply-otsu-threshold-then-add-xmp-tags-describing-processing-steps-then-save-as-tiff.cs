// HOW-TO: Convert DICOM to TIFF with Otsu Binarization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.dcm";
            string outputPath = "Output\\processed.tif";

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
 * 1. When a medical imaging application needs to create a high‑contrast binary version of a DICOM scan for easier analysis or segmentation, developers can load the DICOM, apply Otsu thresholding, and save the result as a TIFF file.
 * 2. When a radiology workflow requires archiving processed images in a widely supported format, the code converts the original DICOM to TIFF after binarization, ensuring compatibility with PACS and document management systems.
 * 3. When a research project needs to generate binary masks from CT or MRI slices for quantitative measurements, developers can use Aspose.Imaging to perform Otsu binarization and export the masks as lossless TIFFs.
 * 4. When a diagnostic tool must preprocess DICOM images before feeding them into a machine‑learning model, this snippet provides a quick way to produce thresholded TIFF inputs in C#.
 * 5. When a healthcare IT system wants to automate batch conversion of DICOM files to TIFF with built‑in contrast enhancement, the example shows how to integrate Otsu binarization into a C# processing pipeline.
 */
