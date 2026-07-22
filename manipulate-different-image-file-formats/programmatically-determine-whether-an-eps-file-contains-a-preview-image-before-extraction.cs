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
            // Load the EPS image
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
                            // Save the preview image to the output path as PNG
                            preview.Save(outputPath, new PngOptions());
                            Console.WriteLine($"Preview image saved to: {outputPath}");
                        }
                        else
                        {
                            Console.WriteLine("Preview image retrieval returned null.");
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
 * 1. When a graphic designer’s workflow requires automatically checking EPS files for embedded raster previews before converting them to PNG thumbnails for a web gallery.
 * 2. When a print‑prepress automation script needs to verify that incoming EPS assets contain a low‑resolution preview so it can extract and embed the preview into a PDF preview pane.
 * 3. When a document management system processes uploaded EPS files and must decide whether to generate a preview image or flag the file for manual review if no raster preview exists.
 * 4. When a batch conversion tool for a digital asset pipeline wants to skip EPS files without previews to avoid unnecessary processing and only save existing previews as PNG files.
 * 5. When a C# application integrates Aspose.Imaging to validate EPS files received from third‑party vendors, ensuring they include a raster preview before storing them in a media library.
 */