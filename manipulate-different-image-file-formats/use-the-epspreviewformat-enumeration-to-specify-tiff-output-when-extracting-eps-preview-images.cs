using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.tiff";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Check for raster preview
                if (!epsImage.HasRasterPreview)
                {
                    Console.Error.WriteLine("No raster preview available in the EPS file.");
                    return;
                }

                // Retrieve TIFF preview image
                var previewImage = epsImage.GetPreviewImage(EpsPreviewFormat.TIFF);
                if (previewImage == null)
                {
                    Console.Error.WriteLine("TIFF preview not found.");
                    return;
                }

                // Save the preview image as TIFF
                previewImage.Save(outputPath);
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
 * 1. When a developer needs to extract the embedded raster preview from an EPS file and save it as a TIFF for high‑resolution printing workflows.
 * 2. When integrating a C# application that converts EPS artwork into TIFF thumbnails for preview in a document management system.
 * 3. When automating batch processing to verify that EPS files contain raster previews and generate TIFF copies for archival in a digital asset repository.
 * 4. When building a graphics pipeline that reads EPS files, checks for preview availability, and outputs TIFF images for compatibility with legacy imaging software.
 * 5. When creating a server‑side service that receives EPS uploads, extracts the TIFF preview, and stores it for fast web display in a .NET web application.
 */