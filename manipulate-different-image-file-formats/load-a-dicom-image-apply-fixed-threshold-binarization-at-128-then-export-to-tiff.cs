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
            string inputPath = "Input\\sample.dcm";
            string outputPath = "Output\\sample.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;
                dicomImage.BinarizeFixed(128);
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
 * 1. When a medical imaging application needs to convert DICOM X‑ray scans into high‑contrast black‑and‑white TIFF files for archival or printing, developers can use this code to load the DICOM, apply a fixed threshold of 128, and save the result as TIFF.
 * 2. When a radiology research pipeline requires preprocessing of DICOM CT slices into binary images for segmentation algorithms, the code provides a quick C# solution to binarize each slice at a fixed intensity and export it to a TIFF format compatible with most analysis tools.
 * 3. When a hospital’s PACS integration needs to generate thumbnail previews of DICOM images in a web‑friendly TIFF format, developers can employ this snippet to threshold the image and produce a lightweight binary TIFF for fast loading.
 * 4. When a health‑tech startup builds a machine‑learning dataset of binary medical images, they can use the example to transform raw DICOM files into standardized TIFF binaries, ensuring consistent pixel values across the dataset.
 * 5. When a compliance system must create immutable, lossless copies of DICOM examinations for legal records, the code allows developers to apply a fixed 128 threshold, convert the image to a TIFF, and store it with guaranteed bit‑depth preservation.
 */