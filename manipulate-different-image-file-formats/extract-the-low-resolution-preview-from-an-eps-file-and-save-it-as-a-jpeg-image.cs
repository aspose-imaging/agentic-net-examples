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
            string outputPath = "output/preview.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Retrieve the preview image (default format)
                var preview = epsImage.GetPreviewImage();

                if (preview == null)
                {
                    Console.Error.WriteLine("No preview image found in the EPS file.");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save preview as JPEG
                preview.Save(outputPath, new JpegOptions());
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
 * 1. When a web application needs to display a quick thumbnail of an uploaded EPS vector file without rendering the full vector, the developer can extract the low‑resolution preview and save it as a JPEG using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform wants to generate product preview images from supplier‑provided EPS logos for catalog listings, the code can pull the embedded preview and convert it to a JPEG thumbnail.
 * 3. When a document management system must index EPS files by creating searchable image previews for search results, developers can use this snippet to obtain the preview and store it as a JPEG.
 * 4. When a batch processing script has to convert a large collection of EPS artwork into low‑resolution JPEG previews for offline review, the code demonstrates how to load each EPS, get the preview, and save it.
 * 5. When a mobile app backend needs to send a lightweight JPEG snapshot of an EPS diagram to clients with limited bandwidth, this C# example shows how to extract and save the preview image efficiently.
 */