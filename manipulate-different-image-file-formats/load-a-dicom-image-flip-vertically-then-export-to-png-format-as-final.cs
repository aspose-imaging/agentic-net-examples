// HOW-TO: Flip DICOM Image Vertically and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "output\\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                PngOptions options = new PngOptions();
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
 * 1. When you need to display a medical DICOM scan in a web portal that only supports PNG, you can flip the image vertically and convert it to PNG using C#.
 * 2. When a radiology workflow requires correcting the orientation of DICOM images before archiving them as lossless PNG files, this code automates the process.
 * 3. When building a desktop application that extracts DICOM frames and creates PNG thumbnails with proper orientation for quick preview, the snippet provides the necessary steps.
 * 4. When integrating a PACS system with a reporting tool that expects PNG assets, you can use this code to reorient and export DICOM images on the fly.
 * 5. When performing batch processing of DICOM files to generate vertically corrected PNG assets for machine‑learning training datasets, the example shows how to achieve it in C#.
 */
