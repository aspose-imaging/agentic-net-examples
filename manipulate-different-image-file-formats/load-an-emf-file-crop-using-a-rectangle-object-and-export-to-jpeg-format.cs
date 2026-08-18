// HOW-TO: Crop EMF Image to Specific Area and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Define the cropping rectangle (x, y, width, height)
                Rectangle cropRect = new Rectangle(50, 50, 200, 200);

                // Crop the image
                emfImage.Crop(cropRect);

                // Save the cropped image as JPEG
                JpegOptions jpegOptions = new JpegOptions();
                emfImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to extract a portion of a vector‑based EMF diagram and deliver it as a lightweight JPEG for web display.
 * 2. When generating thumbnails of selected regions from engineering drawings stored as EMF files for inclusion in reports.
 * 3. When converting a cropped section of a Windows Metafile into a raster format to embed in email newsletters.
 * 4. When automating batch processing that trims unnecessary margins from EMF logos before saving them as JPEG assets.
 * 5. When creating a preview image of a specific area of a CAD‑exported EMF file for a mobile application.
 */
