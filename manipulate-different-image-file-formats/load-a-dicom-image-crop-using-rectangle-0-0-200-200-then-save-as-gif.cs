// HOW-TO: Crop DICOM Image to 200x200 and Save as GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.dcm";
            string outputPath = "Output\\cropped.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                if (!dicom.IsCached) dicom.CacheData();

                Rectangle cropRect = new Rectangle(0, 0, 200, 200);
                dicom.Crop(cropRect);

                using (GifOptions gifOptions = new GifOptions())
                {
                    dicom.Save(outputPath, gifOptions);
                }
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
 * 1. When a medical imaging application needs to extract a small region from a DICOM scan and deliver it as a lightweight GIF for web preview.
 * 2. When a radiology workflow requires converting high‑resolution DICOM frames into GIFs after cropping to a specific area for patient reports.
 * 3. When a developer wants to generate thumbnail GIFs from DICOM files for inclusion in a PACS viewer’s thumbnail gallery.
 * 4. When integrating DICOM data into a mobile app that only supports GIF, and only a 200 × 200 region of interest is needed.
 * 5. When automating batch processing to crop and re‑encode DICOM images into GIF format for archival or sharing with non‑medical users.
 */
