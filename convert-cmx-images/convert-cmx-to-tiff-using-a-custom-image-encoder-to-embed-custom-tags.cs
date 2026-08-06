using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

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

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (Image cmxImage = Image.Load(inputPath))
            {
                // Configure TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Example of embedding a custom tag – here we use ImageDescription,
                // but any supported tag can be added via AddTag/AddTags if needed.
                tiffOptions.ImageDescription = "Converted from CMX with custom tag";

                // If you need to add a truly custom tag, you could use:
                // tiffOptions.AddTag(new TiffDataType(...));
                // (implementation of the custom TiffDataType is beyond this example)

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

/*
 * Real-World Use Cases:
 * 1. When a CAD workflow requires converting legacy CorelDRAW CMX drawings to high‑resolution TIFF files for archival or printing while preserving metadata via custom tags.
 * 2. When an automated document‑processing pipeline in C# must batch‑convert CMX assets to TIFF to feed into a downstream OCR engine that reads custom image description tags.
 * 3. When a medical imaging system needs to ingest CMX diagrams and store them as TIFF files with embedded custom tags for patient‑specific information using Aspose.Imaging for .NET.
 * 4. When a web service that accepts user‑uploaded CMX files must generate TIFF previews with custom metadata for SEO and asset‑management purposes.
 * 5. When a migration script needs to replace CMX files in a legacy database with TIFF equivalents while adding custom tags to maintain versioning and audit trails in a C# application.
 */