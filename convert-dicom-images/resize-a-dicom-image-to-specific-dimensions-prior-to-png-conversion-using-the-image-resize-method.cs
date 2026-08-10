// HOW-TO: Resize DICOM Image to Specific Size and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.dicom";
        string outputPath = @"c:\temp\resized.png";

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

            // Desired dimensions
            int targetWidth = 800;
            int targetHeight = 600;

            // Load the DICOM image, resize, and save as PNG
            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                // Resize using nearest neighbour resampling (choose any ResizeType as needed)
                image.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);

                // Save the resized image as PNG
                image.Save(outputPath, new PngOptions());
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
 * 1. When a medical imaging application needs to display DICOM scans as smaller PNG thumbnails on a web dashboard.
 * 2. When a radiology workflow requires converting high‑resolution DICOM files to a fixed PNG size for inclusion in patient reports.
 * 3. When a hospital PACS system must generate uniformly sized PNG images for mobile device viewing from original DICOM data.
 * 4. When a developer wants to preprocess DICOM images to a set dimension before applying further image analysis or machine‑learning models that accept PNG input.
 * 5. When an electronic health record (EHR) integration needs to resize and convert DICOM scans to PNG to meet storage or bandwidth constraints.
 */
