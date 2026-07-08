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
            string inputPath = "input.eps";
            string outputPath = "output.tif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x768 using Mitchell interpolation
                image.Resize(1024, 768, ResizeType.Mitchell);

                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the resized image as TIFF
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
 * 1. When a developer needs to generate a high‑resolution preview thumbnail of a vector EPS artwork for a web gallery, they can resize it to 1024×768 pixels and save it as a TIFF using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform must convert supplier‑provided EPS logos into TIFF files that match a fixed 1024×768 size for product catalog PDFs, this code automates the resizing and format conversion.
 * 3. When a document management system requires archival of EPS drawings as lossless TIFF images with a standard 1024×768 dimension for consistent indexing, the sample demonstrates the necessary C# workflow.
 * 4. When a printing service needs to prepare EPS artwork for raster‑based proofing by scaling it to 1024×768 and exporting to TIFF to preserve color fidelity, the code provides a reliable solution.
 * 5. When a GIS application must display EPS map overlays as fixed‑size TIFF tiles of 1024×768 pixels for fast rendering in a tiled map viewer, this snippet shows how to perform the resize and save operation.
 */