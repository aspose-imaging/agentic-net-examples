// HOW-TO: Extract Low Resolution EPS Preview and Save as TIFF in C# (Aspose.Imaging for .NET)
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Retrieve the TIFF preview (low‑resolution)
                var preview = epsImage.GetPreviewImage(EpsPreviewFormat.TIFF);
                if (preview == null)
                {
                    Console.Error.WriteLine("No TIFF preview available in the EPS file.");
                    return;
                }

                // Save the preview as a TIFF file
                preview.Save(outputPath);
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
 * 1. When a publishing workflow needs to generate quick thumbnail previews of EPS artwork for catalog listings without rendering the full vector image.
 * 2. When a document management system must store a low‑resolution raster version of an EPS file for faster web preview while keeping the original vector file intact.
 * 3. When a batch process extracts embedded TIFF previews from legacy EPS files to create printable low‑quality drafts in a C# application.
 * 4. When a graphic designer wants to preview EPS logos in a Windows file explorer thumbnail view by converting the preview to a TIFF image.
 * 5. When an automated reporting tool requires converting EPS chart files to TIFF format for inclusion in PDF reports where only low‑resolution images are needed.
 */
