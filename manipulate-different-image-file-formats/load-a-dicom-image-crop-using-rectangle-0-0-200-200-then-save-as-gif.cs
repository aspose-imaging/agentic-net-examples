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
        string inputPath = "input.dcm";
        string outputPath = "output.gif";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Define the cropping rectangle (0,0,200,200)
                Rectangle cropArea = new Rectangle(0, 0, 200, 200);

                // Perform the crop operation
                dicomImage.Crop(cropArea);

                // Save the cropped image as GIF
                dicomImage.Save(outputPath, new GifOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to extract a 200 × 200 pixel region from a DICOM scan and deliver it as a lightweight GIF for quick web preview.
 * 2. When a radiology workflow requires converting a specific area of a DICOM file into an animated‑compatible GIF to embed in electronic health record (EHR) reports.
 * 3. When a developer builds a C# tool that automatically crops the central portion of DICOM images and saves them as GIFs for use in mobile health apps.
 * 4. When a hospital’s PACS integration script must generate thumbnail GIFs from DICOM files by cropping a defined rectangle for faster indexing.
 * 5. When a research project needs to preprocess DICOM images by cropping a region of interest and exporting the result as a GIF for inclusion in presentation slides.
 */