using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff.Enums;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/result.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                dicomImage.BinarizeOtsu();

                // Add XMP metadata describing processing steps
                dicomImage.XmpData = new Aspose.Imaging.Xmp.XmpPacketWrapper();

                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
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
 * 1. When a medical imaging application needs to convert DICOM scans to TIFF for archiving while applying Otsu thresholding to enhance binary segmentation and embedding processing details in XMP metadata.
 * 2. When a radiology workflow requires automated preprocessing of DICOM images to produce high‑contrast black‑and‑white TIFF files for downstream analysis, and wants to record the binarization step in the image’s XMP tags.
 * 3. When a healthcare data integration system must ingest DICOM files, perform Otsu binarization to isolate structures, and store the results as TIFF with searchable XMP metadata for audit trails.
 * 4. When a research project needs to batch‑process DICOM images, apply Otsu threshold to prepare them for machine‑learning models, and preserve the processing history in XMP before saving as TIFF.
 * 5. When a PACS‑to‑document conversion tool has to generate printable TIFF copies of DICOM studies, apply Otsu threshold for clearer visual contrast, and embed XMP metadata describing the conversion steps for compliance reporting.
 */