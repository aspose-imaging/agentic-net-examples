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
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

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

                    // Save preview as JPEG using default settings
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
 * 1. When a web application needs to generate thumbnail JPEGs from uploaded EPS vector files for quick preview in a product catalog.
 * 2. When a desktop publishing workflow converts EPS artwork previews to JPEGs to embed in PDF reports without rendering the full vector content.
 * 3. When an automated batch job extracts the embedded preview from EPS logos and saves them as JPEG images for use in email newsletters.
 * 4. When a mobile app backend receives EPS files and must provide a low‑resolution JPEG snapshot for display on low‑bandwidth devices.
 * 5. When a document management system validates EPS files by extracting their preview image and storing it as a JPEG thumbnail for search indexing.
 */