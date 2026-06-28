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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Create TIFF options with default format
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Example of embedding a custom tag: set the Artist tag
                tiffOptions.Artist = "Custom Artist";

                // If you need to add a truly custom tag, you can use AddTag method.
                // Example (placeholder, replace with actual tag implementation):
                // tiffOptions.AddTag(new CustomTiffTag(...));

                // Save the image as TIFF with the custom options
                image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert legacy CorelDRAW CMX files to a widely supported TIFF format for archival while embedding the Artist metadata using Aspose.Imaging in C#.
 * 2. When a printing workflow requires batch conversion of CMX artwork to high‑resolution TIFF images with custom tags for downstream color management.
 * 3. When a document management system must ingest CMX files and store them as TIFFs with additional metadata such as the creator’s name for searchable indexing.
 * 4. When a GIS application needs to transform CMX map layers into TIFF tiles and embed custom tags to retain layer attribution information.
 * 5. When a medical imaging pipeline converts CMX diagrams to TIFF format and adds custom tags to comply with regulatory metadata standards.
 */