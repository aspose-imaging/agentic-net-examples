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
            string outputPath = "output.tiff";

            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (var image = Image.Load(inputPath))
            {
                // Resize to 1024×768 using Mitchell cubic interpolation
                image.Resize(1024, 768, ResizeType.Mitchell);

                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the resized image as TIFF
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a vector EPS logo into a raster TIFF thumbnail of 1024×768 for inclusion in a print‑ready PDF catalog.
 * 2. When an automated C# batch job must downscale high‑resolution EPS artwork to a standard 1024×768 size and store it as a lossless TIFF for archival in a digital asset management system.
 * 3. When a web service generates preview images of uploaded EPS files by resizing them to 1024×768 pixels and returning the result as a TIFF to ensure compatibility with legacy imaging pipelines.
 * 4. When a desktop application prepares EPS illustrations for a slide deck by resizing them to 1024×768 and exporting them as TIFF files that can be embedded in PowerPoint.
 * 5. When a document conversion tool needs to transform EPS diagrams into 1024×768 TIFF images to meet the input requirements of a third‑party OCR engine.
 */