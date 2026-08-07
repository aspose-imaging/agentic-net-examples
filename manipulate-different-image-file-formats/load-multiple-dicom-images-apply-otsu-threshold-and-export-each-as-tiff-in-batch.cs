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
            // Define input and output directories (relative paths)
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Get all DICOM files in the input directory
            string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (string inputPath in dicomFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path with .tiff extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tiff");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DICOM image, apply Otsu threshold, and save as TIFF
                using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
                {
                    dicomImage.BinarizeOtsu();

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
 * 1. When a medical imaging application needs to convert a batch of DICOM scans into TIFF files for archival or further analysis while applying Otsu thresholding to enhance contrast.
 * 2. When a radiology workflow requires automated preprocessing of multiple DICOM images to produce binary TIFF outputs for integration with legacy PACS systems that only accept TIFF.
 * 3. When a research project must extract region‑of‑interest masks from a folder of DICOM X‑ray images by binarizing them with Otsu and saving the results as TIFF for downstream machine‑learning pipelines.
 * 4. When a hospital IT script has to generate printable, high‑contrast TIFF copies of DICOM ultrasound frames in bulk for inclusion in patient reports.
 * 5. When a developer is building a batch conversion tool that reads DICOM files from a directory, applies Otsu binarization to each image, and writes the processed images as TIFF to a separate output folder for compliance auditing.
 */