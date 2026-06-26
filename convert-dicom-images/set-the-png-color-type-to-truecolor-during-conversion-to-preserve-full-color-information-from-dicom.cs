using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.png";
            string outputPath = "output.dcm";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Set DICOM options to preserve truecolor (RGB 24‑bit)
                var dicomOptions = new DicomOptions
                {
                    ColorType = ColorType.Rgb24Bit
                };

                // Save as DICOM using the specified options
                image.Save(outputPath, dicomOptions);
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
 * 1. A radiology software developer needs to convert high‑resolution PNG scans of pathology slides to DICOM while preserving the full 24‑bit RGB color data for accurate diagnostic review.
 * 2. When building a C# medical imaging archive, a programmer uses this code to ensure that color‑rich PNG photographs of surgical procedures are stored in DICOM format without losing truecolor information.
 * 3. A healthcare IT team integrates Aspose.Imaging to transform PNG dermatology images into DICOM files, requiring truecolor preservation to maintain skin tone details for AI‑driven analysis.
 * 4. In a telemedicine application, developers convert patient‑submitted PNG images of wound healing into DICOM, setting the color type to Rgb24Bit so clinicians can view the exact color gradients remotely.
 * 5. A research project that aggregates PNG microscopy images into a DICOM dataset relies on this conversion code to keep the original truecolor fidelity for quantitative image processing.
 */