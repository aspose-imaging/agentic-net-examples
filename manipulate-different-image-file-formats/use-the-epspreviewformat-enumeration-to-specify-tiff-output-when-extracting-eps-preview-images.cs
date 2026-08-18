// HOW-TO: Extract TIFF Preview Image From EPS File Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;

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
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Check if a raster preview is present
                if (!epsImage.HasRasterPreview)
                {
                    Console.Error.WriteLine("No raster preview available in the EPS file.");
                    return;
                }

                // Retrieve the TIFF preview image
                using (var preview = epsImage.GetPreviewImage(EpsPreviewFormat.TIFF))
                {
                    if (preview == null)
                    {
                        Console.Error.WriteLine("Failed to retrieve TIFF preview.");
                        return;
                    }

                    // Save the preview as a TIFF file
                    preview.Save(outputPath);
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
 * 1. When a designer needs to generate a low‑resolution TIFF thumbnail of an EPS artwork for quick preview in a web gallery.
 * 2. When a printing workflow requires extracting the embedded raster preview from an EPS file to verify colors before sending to a printer.
 * 3. When a document management system stores EPS vectors but must provide TIFF previews for users on devices that cannot render PostScript.
 * 4. When a batch conversion tool must extract TIFF previews from multiple EPS files to create preview PDFs without rendering the full vector data.
 * 5. When a legacy application only accepts TIFF images, developers can pull the EPS preview and save it as TIFF to maintain compatibility.
 */
