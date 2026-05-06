using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("Input", "sample.dcm");
            string outputPath = Path.Combine("Output", "sample_updated.dcm");

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
                // Create DICOM options
                var options = new DicomOptions();

                // Create an XMP packet and add simple metadata (example tag)
                var xmpPacket = new Aspose.Imaging.Xmp.XmpPacketWrapper();
                // Example: add a custom XMP property (actual API may differ)
                // xmpPacket.AddValue("PatientName", "John Doe");
                options.XmpData = xmpPacket;

                // Save the image with the new XMP metadata
                dicomImage.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}