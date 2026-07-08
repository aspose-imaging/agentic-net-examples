using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\sample.dcm";
        string outputPath = @"c:\temp\sample_flipped.png";

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

            // Load the DICOM image, flip vertically, and save as PNG
            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                // Flip vertically (no rotation, vertical flip)
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                // Save the transformed image as PNG
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
 * 1. When a medical imaging application must convert a DICOM radiology scan to a PNG thumbnail for web preview while correcting the orientation by flipping the image vertically.
 * 2. When a healthcare data pipeline needs to standardize DICOM files into PNG format for machine‑learning models that require upright images, using C# and Aspose.Imaging’s RotateFlip operation.
 * 3. When a hospital’s PACS integration script has to export vertically mirrored DICOM ultrasound frames as PNGs for inclusion in patient reports.
 * 4. When a diagnostic software tool automates the preparation of DICOM X‑ray images for mobile devices, flipping them vertically and saving as PNG to reduce file size.
 * 5. When a research project extracts DICOM brain scans, applies a vertical flip to match anatomical orientation, and stores the results as PNG files for visualization in non‑medical viewers.
 */