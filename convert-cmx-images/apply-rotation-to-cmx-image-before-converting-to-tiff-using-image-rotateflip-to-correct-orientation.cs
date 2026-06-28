using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Rotate the image 90 degrees clockwise (adjust as needed)
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save the rotated image as TIFF
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a CAD application exports drawings as CMX files that appear sideways, a developer can use this code to rotate the image and convert it to a correctly oriented TIFF for printing or archiving.
 * 2. When an automated document processing pipeline receives scanned engineering schematics in CMX format and needs to standardize them to TIFF while fixing orientation, this snippet provides the necessary rotation and conversion steps.
 * 3. When integrating legacy CorelDRAW assets into a modern .NET web service, developers can employ this code to rotate misaligned CMX images before saving them as TIFF for web display.
 * 4. When building a batch job that prepares CMX drawings for OCR, the code can rotate each image to the proper orientation and output TIFF files compatible with OCR engines.
 * 5. When a desktop utility must ensure that CMX files exported from different workstations have a uniform orientation before being stored in a digital asset management system, this example shows how to rotate and convert them to TIFF using Aspose.Imaging for .NET.
 */