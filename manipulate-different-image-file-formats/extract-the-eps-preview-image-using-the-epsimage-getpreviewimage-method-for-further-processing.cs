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
        string outputPath = "preview.png";

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

            // Load the EPS image
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

                    // Save the preview image as PNG
                    preview.Save(outputPath, new PngOptions());
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
 * 1. When a C# web application needs to show a thumbnail of an uploaded EPS logo, it can use Aspose.Imaging’s EpsImage.GetPreviewImage to extract the preview and save it as a PNG for fast display.
 * 2. When a document conversion service must embed a low‑resolution representation of an EPS illustration into generated PDFs, it extracts the preview image with GetPreviewImage and saves it in a raster format.
 * 3. When a desktop publishing tool wants to display quick previews of EPS assets in a file‑browser pane, it calls GetPreviewImage to obtain the embedded preview and renders it as a PNG thumbnail.
 * 4. When an e‑commerce platform processes EPS product images, it extracts the preview image via GetPreviewImage to create lightweight PNG previews that improve page‑load performance.
 * 5. When an automated testing suite validates that EPS files contain a preview, it uses GetPreviewImage to retrieve the image and verify its existence and correctness.
 */