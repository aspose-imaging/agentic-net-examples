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
            // Hardcoded input and output file paths
            string inputPath = "C:\\temp\\input.cmx";
            string outputPath = "C:\\temp\\output.tif";

            // Verify that the input file exists
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
                // Prepare default TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the image as a single‑page TIFF
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
 * 1. When a CAD application needs to export a single‑page CMX drawing to a TIFF file for inclusion in a PDF report, a developer can use this code to perform the conversion with default compression.
 * 2. When an archival system requires storing legacy CorelDRAW CMX graphics as lossless TIFF images for long‑term preservation, the snippet provides a straightforward C# solution.
 * 3. When a document management workflow must convert incoming CMX files to TIFF so they can be indexed by OCR engines, this code enables the format transformation using Aspose.Imaging.
 * 4. When a batch‑processing service needs to generate thumbnail previews of CMX drawings by first converting them to single‑page TIFFs, the example shows how to load and save the image in C#.
 * 5. When a Windows desktop utility must ensure compatibility with printers that only accept TIFF input, developers can use this code to convert a CMX file to a single‑page TIFF with default compression.
 */