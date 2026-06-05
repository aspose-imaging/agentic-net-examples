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

            // Load the EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Get the best available preview image
                var preview = epsImage.GetPreviewImage();

                if (preview == null)
                {
                    Console.Error.WriteLine("No preview image found in the EPS file.");
                    return;
                }

                // Save the preview as JPEG
                var jpegOptions = new JpegOptions();
                preview.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to generate a quick thumbnail of an EPS vector graphic for a web preview, they can extract the low‑resolution preview and save it as a JPEG using Aspose.Imaging for .NET.
 * 2. When integrating a document management system that stores EPS files, the code can be used to create JPEG preview images for file listings without rendering the full vector content.
 * 3. When building an email attachment preview feature, the developer can convert the embedded EPS preview to a JPEG so that email clients that only support raster images can display it.
 * 4. When a batch‑processing tool must produce low‑resolution snapshots of many EPS files for a catalog, this snippet shows how to load each EPS, get its preview, and save it as a JPEG.
 * 5. When a legacy workflow requires converting EPS artwork into a format compatible with image‑only APIs, extracting the EPS preview and saving it as JPEG provides a simple raster fallback.
 */