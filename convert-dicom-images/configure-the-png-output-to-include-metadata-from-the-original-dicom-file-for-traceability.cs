using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the DICOM image
            using (var dicomImage = Image.Load(inputPath) as DicomImage)
            {
                if (dicomImage == null)
                {
                    Console.Error.WriteLine("Failed to load DICOM image.");
                    return;
                }

                // Retrieve XMP metadata from the original DICOM image
                var xmpMetadata = dicomImage.XmpData;

                // Prepare PNG save options and embed the retrieved metadata
                var pngOptions = new PngOptions
                {
                    XmpData = xmpMetadata,
                    KeepMetadata = true
                };

                // Save the first DICOM page as PNG with metadata
                var firstPage = dicomImage.DicomPages[0];
                firstPage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}