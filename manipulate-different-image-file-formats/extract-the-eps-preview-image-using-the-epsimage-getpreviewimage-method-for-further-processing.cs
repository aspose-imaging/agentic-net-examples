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
            string inputPath = "input.eps";
            string outputPath = "preview.png";

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
                // Retrieve the default preview image
                Image preview = epsImage.GetPreviewImage(EpsPreviewFormat.Default);

                if (preview == null)
                {
                    Console.Error.WriteLine("No preview image found in the EPS file.");
                    return;
                }

                // Save the preview image as PNG
                preview.Save(outputPath, new PngOptions());
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
 * 1. When a web application needs to display a quick thumbnail of an uploaded EPS logo, a developer can use this code to extract the default preview and save it as a PNG for fast rendering in browsers.
 * 2. When a document management system must generate preview images for EPS files stored in a repository, the code can be run to create PNG previews that can be indexed and shown in search results.
 * 3. When a print‑to‑PDF workflow requires a rasterized version of an EPS artwork for preview before final printing, the developer can extract the preview image and embed the PNG in the preview pane.
 * 4. When an email client wants to attach a lightweight visual representation of an EPS attachment, the code can produce a PNG preview that can be displayed inline without loading the full vector file.
 * 5. When a batch processing script needs to validate that EPS files contain a preview image and convert it to a standard format for downstream image analysis, this code provides the extraction and conversion step.
 */