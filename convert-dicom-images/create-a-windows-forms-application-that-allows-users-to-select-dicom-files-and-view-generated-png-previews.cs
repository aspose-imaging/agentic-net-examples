// HOW-TO: Generate PNG Previews from Multi‑Page DICOM Files in C# (Aspose.Imaging for .NET)
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
            string inputPath = "sample.dcm";
            string outputDir = "Previews";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = image as DicomImage;
                if (dicomImage == null)
                {
                    Console.Error.WriteLine("The file is not a DICOM image.");
                    return;
                }

                int pageIndex = 0;
                foreach (DicomPage page in dicomImage.DicomPages)
                {
                    string outputPath = Path.Combine(outputDir, $"preview_{pageIndex}.png");
                    page.Save(outputPath, new PngOptions());
                    pageIndex++;
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
 * 1. When a radiology application needs to show quick thumbnail previews of each slice in a multi‑frame DICOM study, developers can use this code to export the slices as PNG images.
 * 2. When building a web portal that displays medical images, the code lets developers convert DICOM files to web‑friendly PNG files for fast browser rendering.
 * 3. When preparing training data for a machine‑learning model, developers can batch‑convert DICOM series into PNG files to feed into image‑processing pipelines.
 * 4. When generating printable reports that include patient scans, the code provides a simple way to create high‑quality PNG snapshots of each DICOM page.
 * 5. When integrating a Windows Forms viewer that lets users select DICOM files and see preview images, this snippet handles the conversion and storage of PNG previews automatically.
 */
