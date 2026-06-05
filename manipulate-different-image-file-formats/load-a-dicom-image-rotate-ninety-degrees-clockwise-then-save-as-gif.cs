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
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\input.dcm";
            string outputPath = @"C:\Temp\output.gif";

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
                // Rotate 90 degrees clockwise, resize proportionally, white background
                dicomImage.Rotate(90f, true, Color.White);

                // Save as GIF
                dicomImage.Save(outputPath, new GifOptions());
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
 * 1. When a medical imaging application needs to display a DICOM scan on a web page, a developer can load the .dcm file, rotate it 90° clockwise, and convert it to a lightweight GIF for browser compatibility.
 * 2. When integrating radiology data into a patient portal, a programmer can use this code to transform orientation‑incorrect DICOM images into correctly oriented GIF thumbnails for quick preview.
 * 3. When building a batch‑processing tool that archives scanned ultrasound images, a developer can rotate each DICOM slice and save it as a GIF to reduce storage size while preserving visual information.
 * 4. When creating a diagnostic report that includes side‑by‑side image comparisons, a developer can rotate the original DICOM image and export it as a GIF to embed in PDF or Word documents.
 * 5. When developing a mobile health app that cannot render DICOM directly, a developer can convert the DICOM file to a rotated GIF on the server so the app can display the image without additional libraries.
 */