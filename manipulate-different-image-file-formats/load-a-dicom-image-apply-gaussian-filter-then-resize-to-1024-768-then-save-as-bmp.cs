// HOW-TO: Apply Gaussian Blur and Resize DICOM to BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\input.dcm";
            string outputPath = "output\\output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Dicom.DicomImage image = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
            {
                var gaussianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                image.Filter(image.Bounds, gaussianOptions);
                image.Resize(1024, 768);
                var bmpOptions = new BmpOptions();
                image.Save(outputPath, bmpOptions);
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
 * 1. When a medical imaging application needs to preprocess DICOM scans by smoothing and scaling them before converting to BMP for display in a Windows viewer.
 * 2. When a radiology workflow requires batch conversion of high‑resolution DICOM files to a smaller BMP format with a Gaussian blur to reduce noise for machine‑learning training data.
 * 3. When a healthcare system must generate thumbnail BMP images from DICOM studies, applying a blur filter to protect patient details while resizing for quick preview.
 * 4. When a developer integrates Aspose.Imaging in a C# service that transforms DICOM images into BMP files with standardized dimensions for archival in a non‑DICOM PACS.
 * 5. When a diagnostic tool needs to load a DICOM image, apply a Gaussian smoothing filter, resize it to 1024×768, and save as BMP to embed in a PDF report.
 */
