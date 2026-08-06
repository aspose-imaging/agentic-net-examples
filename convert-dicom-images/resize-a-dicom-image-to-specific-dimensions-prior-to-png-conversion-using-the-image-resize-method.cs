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
            string inputPath = @"c:\temp\sample.dicom";
            string outputPath = @"c:\temp\resized.png";

            // Verify input file exists
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
                // Desired dimensions for resizing
                int newWidth = 800;   // set your target width
                int newHeight = 600;  // set your target height

                // Resize using Bilinear resampling
                dicomImage.Resize(newWidth, newHeight, ResizeType.BilinearResample);

                // Save the resized image as PNG
                dicomImage.Save(outputPath, new PngOptions());
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
 * 1. When a medical imaging application needs to generate thumbnail previews of large DICOM scans for a web portal, a developer can resize the DICOM image to 800×600 pixels and save it as a PNG for fast loading.
 * 2. When integrating DICOM files into a hospital’s electronic health record system that only supports PNG, a developer can use the Image.Resize method to downscale the image before conversion to meet size constraints.
 * 3. When preparing DICOM radiology images for machine‑learning preprocessing pipelines that require uniform input dimensions, a developer can resize each image to a fixed width and height and export it as PNG.
 * 4. When creating printable reports that embed DICOM images as PNG graphics with consistent layout, a developer can resize the original DICOM to the desired dimensions to ensure the report fits on standard paper sizes.
 * 5. When sending DICOM images over a low‑bandwidth network to a remote diagnostic workstation, a developer can reduce the pixel count by resizing the image and converting it to PNG to minimize transfer time.
 */