// HOW-TO: Rotate DICOM Image 90 Degrees Clockwise and Save as GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "Output\\output.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                dicom.RotateFlip(RotateFlipType.Rotate90FlipNone);
                GifOptions gifOptions = new GifOptions();
                dicom.Save(outputPath, gifOptions);
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
 * 1. When a healthcare application needs to display a DICOM scan in a web viewer that only supports GIF, rotating it for correct orientation.
 * 2. When a radiology system must convert patient DICOM images to animated GIFs for quick preview in electronic health records.
 * 3. When a developer wants to generate thumbnail GIFs from DICOM files and ensure they are oriented correctly for mobile devices.
 * 4. When integrating DICOM images into a presentation, rotating the image and saving as GIF simplifies embedding in PowerPoint.
 * 5. When building a diagnostic reporting tool that extracts DICOM images, rotates them to match the acquisition angle, and saves as GIF for easy sharing with clinicians.
 */
