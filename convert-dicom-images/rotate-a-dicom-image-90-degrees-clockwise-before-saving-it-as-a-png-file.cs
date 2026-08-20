// HOW-TO: Rotate DICOM Image 90 Degrees Clockwise and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.dcm";
            string outputPath = "sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load DICOM image, rotate 90 degrees clockwise, and save as PNG
            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                image.Save(outputPath, new PngOptions());
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
 * 1. When a medical imaging application needs to display a DICOM scan in portrait orientation on a web page, developers can rotate the image 90° clockwise and convert it to PNG for browser compatibility.
 * 2. When integrating radiology data into a reporting system that only accepts PNG files, developers must reorient the original DICOM image and save it as a PNG to preserve the correct view.
 * 3. When preparing DICOM images for machine‑learning pipelines that require uniformly oriented PNG inputs, the code rotates the scan and outputs a PNG that matches the expected layout.
 * 4. When a hospital’s PACS export tool must generate thumbnail previews for mobile devices, developers can rotate the DICOM slice and save it as a lightweight PNG.
 * 5. When automating batch processing of DICOM files to create printable documents, the rotation and PNG conversion ensure the images appear correctly on standard printers.
 */
