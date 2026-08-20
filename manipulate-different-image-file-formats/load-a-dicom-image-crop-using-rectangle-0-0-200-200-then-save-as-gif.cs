// HOW-TO: Crop DICOM Image to 200x200 and Save as GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.dcm";
            string outputPath = @"C:\Images\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Crop rectangle (0,0,200,200)
                var cropArea = new Rectangle(0, 0, 200, 200);
                dicomImage.Crop(cropArea);

                // Save as GIF
                var gifOptions = new GifOptions();
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
 * 1. When a medical imaging application needs to extract a small region from a DICOM scan and deliver it as a lightweight GIF for web preview.
 * 2. When a radiology workflow requires converting DICOM slices into static GIFs after cropping to focus on a specific lesion.
 * 3. When a healthcare portal must generate thumbnail GIFs from large DICOM files to improve page load times.
 * 4. When a developer wants to automate batch processing of DICOM images, cropping a fixed area and saving in a format compatible with browsers.
 * 5. When integrating DICOM data into a reporting tool that only supports GIF, requiring cropping and format conversion in C#.
 */
