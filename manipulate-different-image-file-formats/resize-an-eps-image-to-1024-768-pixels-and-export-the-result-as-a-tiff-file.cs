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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

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
 * 1. When a developer needs to convert a vector EPS logo into a raster TIFF thumbnail of 1024×768 for inclusion in a print‑ready PDF brochure.
 * 2. When an e‑commerce platform must generate high‑resolution TIFF product images from EPS artwork to meet marketplace image specifications.
 * 3. When a document management system automatically resizes uploaded EPS diagrams to 1024×768 and stores them as TIFF files for archival and preview purposes.
 * 4. When a GIS application requires EPS map overlays to be rasterized to a fixed 1024×768 TIFF size for fast rendering on low‑bandwidth devices.
 * 5. When a batch processing script needs to validate the existence of an EPS file, resize it with Mitchell interpolation, and save the result as a TIFF for downstream image‑analysis pipelines.
 */