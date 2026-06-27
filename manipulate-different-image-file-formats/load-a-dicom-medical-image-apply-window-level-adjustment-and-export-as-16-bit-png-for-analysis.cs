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
            string inputPath = @"C:\Images\sample.dcm";
            string outputPath = @"C:\Images\output_16bit.png";

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
                // Cast to DicomImage to access DICOM‑specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply window‑level adjustment (example using brightness and contrast)
                // AdjustBrightness: range [-255,255]; AdjustContrast: range [-100,100]
                dicomImage.AdjustBrightness(40);   // example window centre offset
                dicomImage.AdjustContrast(30f);    // example window width scaling

                // Save as 16‑bit PNG
                var pngOptions = new PngOptions
                {
                    BitDepth = 16
                };
                dicomImage.Save(outputPath, pngOptions);
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
 * 1. When a radiology software needs to convert a DICOM CT scan to a high‑precision 16‑bit PNG for integration with a third‑party image analysis tool, the code can load the DICOM, apply window‑level adjustments, and save the result.
 * 2. When a research lab wants to batch‑process DICOM MRI images to enhance contrast using brightness and contrast settings before feeding them into a machine‑learning pipeline that requires PNG input, this snippet provides the necessary C# workflow.
 * 3. When a hospital’s PACS system must generate printable 16‑bit PNG snapshots of DICOM X‑ray images with custom window centre and width for diagnostic reporting, developers can use this example to read, adjust, and export the images.
 * 4. When a medical imaging startup needs to create web‑friendly 16‑bit PNG previews of DICOM ultrasound files while preserving diagnostic detail through window level tuning, the code demonstrates the required steps in .NET.
 * 5. When a quality‑control application must verify DICOM image integrity by converting the files to 16‑bit PNG after applying specific brightness and contrast corrections for visual inspection, this program offers a straightforward solution.
 */