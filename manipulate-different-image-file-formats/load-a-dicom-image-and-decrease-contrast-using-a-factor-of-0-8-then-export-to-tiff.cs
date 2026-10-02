// HOW-TO: Load DICOM Image Reduce Contrast and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\input.dcm";
            string outputPath = "output\\output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
            {
                var raster = (RasterImage)dicomImage;
                raster.AdjustContrast(0.8f);
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
 * 1. When a medical imaging application needs to lower the contrast of a DICOM scan before converting it to a TIFF file for easier viewing on standard picture viewers.
 * 2. When a radiology workflow requires exporting DICOM images with adjusted contrast to TIFF for inclusion in patient reports or documentation.
 * 3. When a developer wants to preprocess DICOM images by reducing contrast to improve OCR accuracy after saving them as high‑resolution TIFF files.
 * 4. When integrating legacy systems that only accept TIFF, you can load DICOM, tweak contrast, and save the result in a compatible format using C#.
 * 5. When building a batch conversion tool that normalizes contrast of DICOM scans and archives them as TIFF files for long‑term storage.
 */
