// HOW-TO: Convert DICOM to GIF with Crop Rotate and Flip in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                if (!dicom.IsCached)
                    dicom.CacheData();

                Aspose.Imaging.Rectangle cropRect = new Aspose.Imaging.Rectangle(50, 50, 200, 200);
                dicom.Crop(cropRect);

                dicom.RotateFlip(RotateFlipType.Rotate90FlipX);

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
 * 1. When a medical imaging application needs to extract a specific region from a DICOM scan, re‑orient it, and deliver it as a lightweight GIF for web viewers.
 * 2. When a radiology workflow requires converting DICOM slices into animated GIFs after applying a 90‑degree rotation and horizontal flip for consistent patient positioning.
 * 3. When a healthcare portal wants to display cropped DICOM thumbnails as GIFs on mobile devices, ensuring the image is correctly rotated and mirrored.
 * 4. When a developer must batch‑process DICOM files, trim unnecessary borders, rotate them for standard orientation, and save them in GIF format for inclusion in reports.
 * 5. When integrating Aspose.Imaging into a C# service that transforms DICOM images into GIFs with custom cropping and flip operations for archival or sharing purposes.
 */
