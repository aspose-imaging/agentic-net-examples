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
            string inputPath = "input.dcm";
            string outputPath = "output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Define the cropping rectangle (0,0,200,200)
                var cropArea = new Aspose.Imaging.Rectangle(0, 0, 200, 200);

                // Perform the crop
                dicomImage.Crop(cropArea);

                // Save the cropped image as GIF
                dicomImage.Save(outputPath, new GifOptions());
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
 * 1. When a medical imaging application needs to extract a 200 × 200 pixel region from a DICOM scan and embed it in a web page as a GIF.
 * 2. When a radiology workflow requires converting a specific area of a DICOM file into a lightweight GIF for quick preview on mobile devices.
 * 3. When a health‑tech startup wants to generate thumbnail GIFs from large DICOM studies by cropping the top‑left corner of each image.
 * 4. When a developer is building a PACS viewer that must save cropped DICOM sections as GIFs for reporting or documentation purposes.
 * 5. When an automated C# script processes DICOM files, crops a region of interest, and stores the result in GIF format for archival or sharing.
 */