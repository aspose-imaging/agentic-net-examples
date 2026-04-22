using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = "sample.dcm";
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

            // Load DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage (safe because we loaded a DICOM file)
                using (DicomImage dicomImage = (DicomImage)image)
                {
                    // Save first page as PNG (single‑page DICOMs have one page)
                    dicomImage.Save(outputPath, new PngOptions());
                }
            }

            // Compare file sizes
            long inputSize = new FileInfo(inputPath).Length;
            long outputSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Input DICOM size: {inputSize} bytes");
            Console.WriteLine($"Output PNG size: {outputSize} bytes");

            if (outputSize == 0)
            {
                Console.Error.WriteLine("Conversion failed: output file is empty.");
            }
            else
            {
                Console.WriteLine("Conversion succeeded.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}