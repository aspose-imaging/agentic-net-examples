using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input DICOM file path
        string inputPath = "input.dcm";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output directory for PNG pages
        string outputDir = "output";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputDir));

        // Load the DICOM image
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Prepare PNG options with metadata preservation
            var pngOptions = new PngOptions
            {
                KeepMetadata = true,
                XmpData = dicomImage.XmpData // Transfer XMP metadata from DICOM to PNG
            };

            // Iterate through each DICOM page and save as PNG
            foreach (DicomPage page in dicomImage.DicomPages)
            {
                string outputPath = Path.Combine(outputDir, $"page_{page.Index}.png");

                // Ensure the directory for the specific file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the page as PNG with the prepared options
                page.Save(outputPath, pngOptions);
            }
        }
    }
}