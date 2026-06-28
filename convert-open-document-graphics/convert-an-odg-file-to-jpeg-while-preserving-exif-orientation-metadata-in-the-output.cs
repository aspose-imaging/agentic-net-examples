using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample_converted.jpg";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Prepare JPEG save options – keep original metadata (including EXIF)
                var jpegOptions = new JpegOptions
                {
                    KeepMetadata = true,
                    // Rasterize the vector ODG using appropriate options
                    VectorRasterizationOptions = new OdgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = odgImage.Size
                    }
                };

                // Save as JPEG while preserving EXIF orientation data
                odgImage.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to convert an OpenDocument Graphics (ODG) illustration to a JPEG thumbnail for a web gallery while preserving the original EXIF orientation so the image displays correctly in browsers.
 * 2. When an application must batch‑process vector drawings from LibreOffice and generate JPEG previews for mobile devices without losing metadata required by photo‑management tools.
 * 3. When a document management system imports ODG files and stores them as JPEGs for faster indexing, preserving EXIF orientation to maintain consistent sorting and display.
 * 4. When a C# service creates printable JPEG versions of ODG logos for e‑commerce product listings, ensuring the orientation metadata is retained for downstream image editors.
 * 5. When a migration script moves legacy ODG assets to a JPEG‑based digital asset library and needs to keep the original EXIF orientation to avoid manual rotation after conversion.
 */