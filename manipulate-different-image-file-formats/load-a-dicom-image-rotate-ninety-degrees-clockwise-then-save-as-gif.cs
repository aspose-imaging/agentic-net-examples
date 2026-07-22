using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.gif";

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

            // Load the DICOM image
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise
                dicomImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save as GIF
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
 * 1. When a medical imaging application needs to display a DICOM X‑ray on a web page, it can load the DICOM file, rotate it to the correct orientation, and convert it to a lightweight GIF for browser compatibility.
 * 2. When a radiology reporting tool must embed a rotated DICOM scan into a PDF report, the code can rotate the image and save it as a GIF that the PDF generator can easily embed.
 * 3. When a hospital’s PACS integration script has to generate thumbnail previews of DICOM studies for a mobile app, it can rotate the image and output a GIF thumbnail.
 * 4. When a research project requires batch processing of DICOM brain scans to standardize orientation before statistical analysis, the code can rotate each image and save it as GIF for quick visual inspection.
 * 5. When a telemedicine platform needs to stream patient DICOM images to a low‑bandwidth client, it can rotate the image to the proper view and convert it to a GIF to reduce file size and simplify rendering.
 */