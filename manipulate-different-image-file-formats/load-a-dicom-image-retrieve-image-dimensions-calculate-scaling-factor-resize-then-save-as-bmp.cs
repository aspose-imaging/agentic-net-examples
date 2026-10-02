// HOW-TO: Resize DICOM Image to Half Size and Save as BMP in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
            {
                int originalWidth = dicomImage.Width;
                int originalHeight = dicomImage.Height;

                double scale = 0.5;
                int newWidth = (int)(originalWidth * scale);
                int newHeight = (int)(originalHeight * scale);

                dicomImage.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                using (BmpOptions bmpOptions = new BmpOptions())
                {
                    dicomImage.Save(outputPath, bmpOptions);
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
 * 1. When you need to convert a medical DICOM scan into a smaller BMP file for quick preview in a Windows application.
 * 2. When you must read the dimensions of a DICOM image and generate a scaled‑down version for embedding in a clinical report.
 * 3. When a healthcare system requires batch processing of DICOM files to create thumbnail BMP images for a PACS web portal.
 * 4. When integrating legacy imaging software that only accepts BMP files, you can resize and convert DICOM images on the fly.
 * 5. When performing performance testing, you may need to reduce DICOM image size before saving to BMP to evaluate rendering speed.
 */
