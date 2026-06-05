using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.eps";
            string outputPath = @"C:\Images\output\preview.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Retrieve the preview image (default format)
                using (var preview = epsImage.GetPreviewImage())
                {
                    if (preview == null)
                    {
                        Console.Error.WriteLine("No preview image found in the EPS file.");
                        return;
                    }

                    // Save preview as JPEG with default settings
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
 * 1. When a developer needs to create a thumbnail for an EPS logo to display in a web‑based asset manager, they can extract the EPS preview and save it as a JPEG using Aspose.Imaging for .NET.
 * 2. When a desktop publishing application must generate a low‑resolution preview of a vector illustration for quick preview in a file explorer, the code can load the EPS, get its preview image, and save it as a JPEG.
 * 3. When an e‑commerce platform wants to show a product’s vector artwork as a JPEG preview on product pages without rendering the full EPS, this snippet converts the EPS preview to a JPEG file.
 * 4. When a batch‑processing tool processes a folder of EPS files and needs to store each file’s preview as a JPEG for archival or reporting purposes, the Save method with default settings simplifies the conversion.
 * 5. When a mobile app backend must deliver a JPEG snapshot of an EPS design to devices that cannot render EPS, the code extracts the preview image and saves it as a JPEG for easy consumption.
 */