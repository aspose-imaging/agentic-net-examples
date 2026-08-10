// HOW-TO: Convert DICOM to BMP with Gaussian Blur and Resize in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicom = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Apply Gaussian blur filter to the entire image
                dicom.Filter(dicom.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Resize to 1024x768 using nearest neighbor resampling
                dicom.Resize(1024, 768, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                // Save as BMP
                dicom.Save(outputPath, new BmpOptions());
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
 * 1. When a medical imaging application needs to export DICOM scans as BMP thumbnails with a softening effect for quick preview in a Windows UI.
 * 2. When a radiology workflow requires batch processing of DICOM files to standardize size to 1024×768 and apply Gaussian blur before archiving them as BMP for compatibility with legacy systems.
 * 3. When a developer is building a diagnostic reporting tool that converts high‑resolution DICOM images to BMP format while reducing noise using a Gaussian filter and resizing for consistent layout.
 * 4. When integrating Aspose.Imaging into a C# service that transforms incoming DICOM images into BMP files for downstream image analysis pipelines that expect a fixed resolution.
 * 5. When creating a cross‑platform C# utility that prepares DICOM images for printing by applying blur, resizing, and saving them as BMP to meet printer driver requirements.
 */
