// HOW-TO: Rotate DICOM Image 90 Degrees Clockwise and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

public class Program
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

            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = ".";
            }
            Directory.CreateDirectory(outputDir);

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, options);
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
 * 1. When a radiology system needs to display a DICOM scan in a web portal that only supports PNG, the image can be rotated correctly and saved as PNG.
 * 2. When integrating a PACS viewer that expects upright images, developers can rotate the original DICOM orientation and convert it to PNG for consistent UI rendering.
 * 3. When generating thumbnails of DICOM files for a patient dashboard, rotating the image to the proper orientation before saving as PNG ensures accurate preview.
 * 4. When exporting DICOM images to a reporting tool that requires PNG format, applying a 90‑degree clockwise rotation fixes orientation issues caused by scanner metadata.
 * 5. When automating batch processing of DICOM studies for archival, rotating each image and converting it to PNG simplifies storage and downstream image analysis.
 */
