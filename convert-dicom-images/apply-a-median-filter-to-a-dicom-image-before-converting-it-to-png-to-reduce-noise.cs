// HOW-TO: Apply Median Filter to DICOM and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (DicomImage dicom = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                dicom.Filter(dicom.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                PngOptions pngOptions = new PngOptions();
                dicom.Save(outputPath, pngOptions);
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
 * 1. When you need to reduce speckle noise in a medical DICOM scan before creating a PNG thumbnail for a web viewer.
 * 2. When you want to preprocess radiology images with a median filter to improve visual quality before storing them in a PNG archive.
 * 3. When an application must convert DICOM files to PNG for reporting while preserving diagnostic details by smoothing noise.
 * 4. When integrating Aspose.Imaging into a C# workflow that cleans up noisy CT images prior to exporting them as lossless PNGs.
 * 5. When building a PACS export tool that applies a 3×3 median filter to DICOM images to enhance readability before saving as PNG files.
 */
