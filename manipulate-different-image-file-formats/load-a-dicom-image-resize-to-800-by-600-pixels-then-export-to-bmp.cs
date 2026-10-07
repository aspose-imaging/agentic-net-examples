// HOW-TO: Resize DICOM Image to 800x600 and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output\\resized.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
            {
                if (!dicomImage.IsCached)
                    dicomImage.CacheData();

                dicomImage.Resize(800, 600, ResizeType.NearestNeighbourResample);

                BmpOptions bmpOptions = new BmpOptions();
                dicomImage.Save(outputPath, bmpOptions);
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
 * 4. When a C# desktop application needs to display DICOM images in a UI component that only supports BMP, resizing them to fit the control’s layout.
 * 5. When an integration service has to transform DICOM images into a uniform BMP size before uploading them to a cloud storage bucket that enforces size limits.
 */
