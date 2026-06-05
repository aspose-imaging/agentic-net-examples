using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/preview.tiff";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                // Check for raster preview
                if (!epsImage.HasRasterPreview)
                {
                    Console.Error.WriteLine("No raster preview available in the EPS file.");
                    return;
                }

                // Get the TIFF preview image
                using (Image preview = epsImage.GetPreviewImage(Aspose.Imaging.FileFormats.Eps.EpsPreviewFormat.TIFF))
                {
                    if (preview == null)
                    {
                        Console.Error.WriteLine("Failed to retrieve the TIFF preview.");
                        return;
                    }

                    // Save preview as TIFF
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    preview.Save(outputPath, tiffOptions);
                }
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
 * 1. When a developer needs to generate a low‑resolution preview of an EPS vector artwork for quick display in a web gallery, they can extract the embedded TIFF preview using Aspose.Imaging for .NET and save it as a TIFF file.
 * 2. When a document management system must create thumbnail images of EPS files for search indexing, the code can retrieve the raster preview and store it as a TIFF to be used by indexing services.
 * 3. When an e‑commerce platform wants to show a fast‑loading preview of product designs supplied as EPS files, the developer can use this snippet to pull the TIFF preview and serve it to browsers.
 * 4. When a batch processing tool has to convert a large collection of EPS files into low‑resolution TIFF previews for archival or printing workflows, the code provides a reliable way to automate the extraction.
 * 5. When a desktop application needs to verify that an EPS file contains an embedded raster preview before further processing, the example shows how to check HasRasterPreview and save the preview as a TIFF for validation purposes.
 */