// HOW-TO: Resize DICOM Image to 800x600 and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.dcm";
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Resize to 800x600 using bilinear resampling
                dicomImage.Resize(800, 600, ResizeType.BilinearResample);

                // Save as BMP
                dicomImage.Save(outputPath, new BmpOptions());
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
 * 1. When a hospital IT system needs to convert high‑resolution DICOM scans into smaller BMP thumbnails for quick preview in a web portal.
 * 2. When a research application must batch‑process DICOM files, resize them to a standard 800×600 size, and store them as BMP for compatibility with legacy analysis tools.
 * 3. When a medical imaging workflow requires exporting patient scans to BMP format for inclusion in printed reports while maintaining a consistent image dimension.
 * 4. When a C# desktop program has to display DICOM images on screens with limited resolution, it can resize the images to 800×600 and save them as BMP for fast rendering.
 * 5. When integrating Aspose.Imaging into a PACS system to generate BMP copies of DICOM images that fit a predefined UI layout without losing aspect ratio.
 */
