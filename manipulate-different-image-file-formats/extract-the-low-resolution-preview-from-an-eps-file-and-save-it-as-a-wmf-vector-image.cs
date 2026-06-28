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
            string inputPath = @"C:\Images\sample.eps";
            string outputPath = @"C:\Images\sample_preview.wmf";

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
                // Retrieve WMF preview (low‑resolution vector preview)
                Image preview = epsImage.GetPreviewImage(EpsPreviewFormat.WMF);
                if (preview == null)
                {
                    Console.Error.WriteLine("No WMF preview found in the EPS file.");
                    return;
                }

                // Save the preview as WMF
                preview.Save(outputPath);
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
 * 1. When a developer needs to generate a quick thumbnail of an EPS artwork for display in a Windows Forms UI, they can extract the WMF preview and save it as a lightweight vector image.
 * 2. When integrating EPS files into a legacy reporting system that only supports WMF graphics, extracting the low‑resolution preview enables seamless inclusion of the artwork without full EPS rendering.
 * 3. When creating a batch process that indexes graphic assets and stores preview images for fast search results, the code can pull the WMF preview from each EPS and save it for quick retrieval.
 * 4. When a document conversion pipeline must embed EPS illustrations into a Microsoft Word document that accepts WMF, extracting the preview provides a compatible vector representation.
 * 5. When a web application needs to show a low‑resolution preview of an EPS file in a browser that cannot render EPS directly, converting the preview to WMF allows the image to be displayed via a server‑side conversion step.
 */