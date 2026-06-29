using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.cmx";
            string previewPath = "preview.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(previewPath) ?? ".");

            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Define thumbnail dimensions (example: 200x200)
                int thumbWidth = 200;
                int thumbHeight = 200;

                // Resize the image for preview (default NearestNeighbourResample)
                cmxImage.Resize(thumbWidth, thumbHeight);

                // Save the thumbnail as PNG
                cmxImage.Save(previewPath, new PngOptions());
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
 * 1. When a web application needs to display a quick preview of a large CMX vector file in a gallery, a developer can generate a 200×200 PNG thumbnail using Aspose.Imaging’s Image.Resize before converting the full image.
 * 2. When an automated document processing pipeline must create low‑resolution previews for CMX drawings to be shown in a PDF index, the code can resize the CMX image and save it as a PNG thumbnail for fast loading.
 * 3. When a desktop design tool wants to show a thumbnail in its file‑open dialog for CMX files, developers can use the Resize method to produce a small PNG preview without loading the entire image into memory.
 * 4. When an e‑commerce site stores product schematics in CMX format and needs to display a small preview on product pages, the snippet creates a resized PNG thumbnail for quick rendering in browsers.
 * 5. When a batch conversion utility processes many CMX files and must generate preview images for user verification before full conversion, the code resizes each CMX to a thumbnail and saves it as PNG for easy review.
 */