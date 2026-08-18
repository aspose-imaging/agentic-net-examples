// HOW-TO: Extract EPS Preview and Save as JPEG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.eps";
        string outputPath = "preview.jpg";

        try
        {
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
                // Retrieve the preview image (default format)
                var preview = epsImage.GetPreviewImage();

                if (preview == null)
                {
                    Console.Error.WriteLine("No preview image found in the EPS file.");
                    return;
                }

                // Save preview as JPEG using default settings
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
 * 1. When you need to generate a thumbnail JPEG from an EPS file for a web gallery.
 * 2. When you want to quickly display a preview of a vector EPS logo in a Windows application without rendering the full vector.
 * 3. When an automated workflow must convert embedded EPS previews to JPEG for email attachments.
 * 4. When a document processing service extracts the low‑resolution preview from EPS files to create preview pages in a PDF viewer.
 * 5. When a batch job validates that EPS files contain a preview image by saving it as JPEG for further analysis.
 */
