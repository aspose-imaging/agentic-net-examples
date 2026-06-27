using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "preview.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Determine if a raster preview is present
                bool hasPreview = epsImage.HasRasterPreview;
                Console.WriteLine($"Has raster preview: {hasPreview}");

                if (hasPreview)
                {
                    // Retrieve the preview image (default format)
                    using (Image preview = epsImage.GetPreviewImage())
                    {
                        if (preview != null)
                        {
                            // Save the preview image as PNG
                            preview.Save(outputPath, new PngOptions());
                            Console.WriteLine($"Preview image saved to: {outputPath}");
                        }
                        else
                        {
                            Console.WriteLine("Preview image property reported true, but GetPreviewImage returned null.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No raster preview available in the EPS file.");
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
 * 1. When a document management system imports EPS files and needs to display a thumbnail, a developer can use this code to check for a raster preview before extracting and saving it as a PNG.
 * 2. When an e‑commerce platform generates product catalogs from EPS artwork, the code helps verify the presence of an embedded preview image to create fast‑loading preview thumbnails for web pages.
 * 3. When a print‑shop workflow validates incoming EPS submissions, the developer can programmatically detect whether a preview exists to decide if a low‑resolution preview should be shown to the client before printing.
 * 4. When a digital asset management (DAM) tool indexes EPS assets, this snippet allows the system to determine if a raster preview is available so it can store or skip generating a separate preview image.
 * 5. When a batch conversion utility processes large numbers of EPS files, the code enables the utility to skip files without raster previews, avoiding unnecessary GetPreviewImage calls and saving processing time.
 */