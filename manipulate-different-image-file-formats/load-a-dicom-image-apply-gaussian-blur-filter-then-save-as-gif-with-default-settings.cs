// HOW-TO: Convert DICOM to GIF with Gaussian Blur in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicom = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
            {
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions();
                blurOptions.Radius = 5;
                blurOptions.Sigma = 1.0;

                dicom.Filter(dicom.Bounds, blurOptions);

                var gifOptions = new GifOptions();
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
 * 1. When you need to anonymize patient scans by blurring sensitive details before sharing them as lightweight GIFs for web review.
 * 2. When a medical imaging application must generate animated GIF previews of DICOM slices with a soft blur effect for quick visual assessment.
 * 3. When integrating Aspose.Imaging into a C# workflow to convert high‑resolution DICOM files to GIF format while applying a Gaussian blur to reduce noise.
 * 4. When creating a batch process that prepares DICOM images for presentation in PowerPoint by converting them to GIFs with a consistent blur radius.
 * 5. When developing a tele‑medicine portal that requires server‑side C# code to blur and compress DICOM images into GIFs for faster browser loading.
 */
