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
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputPath = "output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM image
            using (DicomImage dicomImage = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Crop the image (example rectangle)
                Aspose.Imaging.Rectangle cropRect = new Aspose.Imaging.Rectangle(50, 50, 200, 200);
                dicomImage.Crop(cropRect);

                // Rotate the image 45 degrees clockwise, resize proportionally, gray background
                dicomImage.Rotate(45f, true, Aspose.Imaging.Color.Gray);

                // Flip the image horizontally
                dicomImage.RotateFlip(Aspose.Imaging.RotateFlipType.RotateNoneFlipX);

                // Save the processed image as GIF
                GifOptions gifOptions = new GifOptions();
                dicomImage.Save(outputPath, gifOptions);
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
 * 1. When a radiology software needs to extract a region of interest from a DICOM X‑ray, rotate it for proper orientation, flip it for left‑right correction, and then embed the result as a lightweight GIF in a web‑based patient report.
 * 2. When a medical research tool must batch‑process DICOM MRI slices, crop out the brain area, apply a 45° rotation to align with a standard view, and save the images as GIFs for inclusion in presentations.
 * 3. When a hospital’s PACS integration requires converting DICOM ultrasound frames into animated GIFs after cropping and flipping, enabling quick preview on mobile devices.
 * 4. When a C# desktop application for dental imaging needs to isolate a tooth region from a DICOM scan, rotate it to match the chart orientation, flip it horizontally, and export to GIF for patient education material.
 * 5. When a tele‑medicine portal wants to display processed DICOM CT images with custom cropping and orientation adjustments as GIF thumbnails to reduce bandwidth while preserving visual details.
 */