using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Retrieve the TIFF preview image
                using (Image preview = epsImage.GetPreviewImage(EpsPreviewFormat.TIFF))
                {
                    if (preview == null)
                    {
                        Console.Error.WriteLine("No TIFF preview found in the EPS file.");
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
 * 1. When a developer needs to extract a high‑resolution TIFF preview from an EPS file for printing or archival workflows.
 * 2. When a C# application must convert embedded EPS preview images to TIFF to display them in a Windows Forms viewer that only supports raster formats.
 * 3. When an automated batch process validates that EPS files contain a TIFF preview before sending them to a digital asset management system.
 * 4. When a .NET service generates thumbnail TIFFs from EPS documents to embed in PDF portfolios or email attachments.
 * 5. When a graphics pipeline requires extracting the EPS preview as a TIFF to perform further image processing such as resizing or color correction using Aspose.Imaging.
 */