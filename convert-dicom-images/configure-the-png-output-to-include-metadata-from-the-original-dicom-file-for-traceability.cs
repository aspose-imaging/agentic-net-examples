using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output locations
        string inputPath = "sample.dcm";
        string outputDirectory = "output";

        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the DICOM image
            using (DicomImage dicomImage = Image.Load(inputPath) as DicomImage)
            {
                if (dicomImage == null)
                {
                    Console.Error.WriteLine("Failed to load DICOM image.");
                    return;
                }

                // Preserve the original XMP metadata for traceability
                var originalXmp = dicomImage.XmpData;

                int pageIndex = 0;
                foreach (var dicomPage in dicomImage.DicomPages)
                {
                    // Build the PNG output path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.png");

                    // Ensure the output directory exists (unconditional per requirements)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure PNG options and embed the original XMP metadata
                    var pngOptions = new PngOptions
                    {
                        KeepMetadata = true,
                        XmpData = originalXmp
                    };

                    // Save the page as PNG with the configured options
                    dicomPage.Save(outputPath, pngOptions);

                    pageIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}