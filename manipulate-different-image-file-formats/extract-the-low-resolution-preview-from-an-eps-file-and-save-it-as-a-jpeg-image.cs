// HOW-TO: Extract EPS Preview Image and Save as JPEG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "sample.eps";
            string outputPath = "preview.jpg";

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
                // Try to get the default preview image
                using (Image preview = epsImage.GetPreviewImage())
                {
                    if (preview == null)
                    {
                        Console.Error.WriteLine("No preview image found in the EPS file.");
                        return;
                    }

                    // Save preview as JPEG
                    var jpegOptions = new JpegOptions();
                    preview.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate a quick thumbnail of an EPS artwork for a web gallery without rendering the full vector file.
 * 2. When a document management system must display a low‑resolution preview of uploaded EPS files in a preview pane.
 * 3. When converting batch EPS files to JPEG previews for email attachments where the recipient cannot view EPS.
 * 4. When creating a catalog of design assets and you want to store a small JPEG snapshot alongside the original EPS for faster loading.
 * 5. When integrating EPS files into a C# application that only supports raster images, you can extract the embedded preview and convert it to JPEG for display.
 */
