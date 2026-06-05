using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\output.tif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (Image cmxImage = Image.Load(inputPath))
            {
                // Configure TIFF save options
                TiffOptions tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);

                // Example of embedding a custom tag: set a known TIFF field (ImageDescription)
                // In a real scenario you could use AddTag/AddTags to add proprietary tags.
                tiffOptions.ImageDescription = "Converted from CMX with custom metadata";

                // Save the image as TIFF using the configured options
                cmxImage.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}