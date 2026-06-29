using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.dcm";
        string outputPath = @"C:\Images\output.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Resize to 800x600 using bilinear resampling
                dicomImage.Resize(800, 600, ResizeType.BilinearResample);

                // Save the resized image as BMP
                dicomImage.Save(outputPath, new BmpOptions());
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
 * 1. When a medical imaging application needs to convert DICOM scans into BMP files for display on legacy Windows viewers, a developer can load the DICOM image, resize it to 800×600, and save it as BMP using Aspose.Imaging for .NET.
 * 2. When a radiology workflow requires generating thumbnail previews of large DICOM studies for a web portal, a developer can use this code to resize the DICOM image to 800×600 pixels and export it to BMP for fast loading.
 * 3. When integrating DICOM data into a C# desktop reporting tool that only supports BMP graphics, a developer can employ this snippet to transform the DICOM file, adjust its dimensions, and save it in BMP format.
 * 4. When an automated batch process must standardize the size of incoming DICOM images before archiving them in a BMP‑based image repository, a developer can apply the resize‑and‑save routine shown above.
 * 5. When a healthcare IT system needs to extract a DICOM image, downscale it for email attachment, and ensure compatibility with non‑medical image viewers, a developer can use this code to resize to 800×600 and export to BMP.
 */