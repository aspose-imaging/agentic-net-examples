using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.png";

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

            // Load DICOM data into a byte array
            byte[] dicomData = File.ReadAllBytes(inputPath);

            // Use MemoryStream for in‑memory processing
            using (MemoryStream inputStream = new MemoryStream(dicomData))
            {
                // Create DicomImage from the stream
                using (DicomImage dicomImage = new DicomImage(inputStream))
                {
                    // Prepare PNG save options
                    PngOptions pngOptions = new PngOptions();

                    // Save the entire image as PNG to the output file
                    using (FileStream outputStream = File.OpenWrite(outputPath))
                    {
                        // Use empty rectangle to indicate full image bounds
                        dicomImage.Save(outputStream, pngOptions, new Rectangle());
                    }
                }
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
 * 1. When a medical imaging web app must show a DICOM scan in browsers that only support PNG, developers can load the DICOM bytes into a MemoryStream and convert them to PNG on the fly.
 * 2. When a hospital information system needs to archive diagnostic images as lossless PNG files while keeping the original DICOM data in memory, this code enables in‑memory conversion without creating temporary files.
 * 3. When a telemedicine platform receives DICOM data over a network socket as a byte array and must generate a thumbnail PNG for patient portals, the MemoryStream approach provides fast server‑side image processing.
 * 4. When a research tool extracts DICOM files stored in a database BLOB column and needs to export them as PNG for scientific publications, developers can read the BLOB into a byte array and use this code to create PNG images.
 * 5. When a mobile health app downloads encrypted DICOM images as byte streams and must render them as PNG on the device without persisting the raw DICOM file, the in‑memory conversion using Aspose.Imaging simplifies the workflow.
 */