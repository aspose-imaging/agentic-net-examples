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
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputDir = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = image as DicomImage;
                if (dicomImage == null)
                {
                    Console.Error.WriteLine("The input file is not a DICOM image.");
                    return;
                }

                // Capture XMP metadata from the original DICOM image
                var xmpMetadata = dicomImage.XmpData;

                int pageIndex = 0;
                foreach (var dicomPage in dicomImage.DicomPages)
                {
                    // Build output file path for each page
                    string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.png");

                    // Ensure the directory for the specific file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure PNG options to keep metadata and embed the captured XMP data
                    var pngOptions = new PngOptions
                    {
                        KeepMetadata = true,
                        XmpData = xmpMetadata
                    };

                    // Save the page as PNG with metadata
                    dicomPage.Save(outputPath, pngOptions);
                    pageIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}