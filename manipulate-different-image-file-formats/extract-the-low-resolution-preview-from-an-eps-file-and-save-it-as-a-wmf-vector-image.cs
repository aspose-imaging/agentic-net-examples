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

        try
        {
            // Load the EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Retrieve the WMF preview image
                Image preview = epsImage.GetPreviewImage(EpsPreviewFormat.WMF);

                if (preview != null)
                {
                    // Save the preview as a WMF file
                    preview.Save(outputPath, new WmfOptions());
                }
                else
                {
                    Console.Error.WriteLine("No WMF preview found in the EPS file.");
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
 * 1. When a developer needs to generate a quick low‑resolution preview of an EPS illustration for display in a Windows Forms UI, they can extract the WMF preview and save it as a vector image.
 * 2. When integrating a document management system that lists EPS files, a developer can use this code to create a lightweight WMF thumbnail for faster rendering in web browsers.
 * 3. When converting legacy EPS assets to a format compatible with Microsoft Office applications, a developer can extract the embedded WMF preview to embed directly into Word or PowerPoint.
 * 4. When building an automated batch process that validates EPS files, a developer can extract the WMF preview to verify that the file contains a renderable preview before further processing.
 * 5. When providing a preview feature in a CAD or GIS application that only supports WMF vectors, a developer can use this code to pull the EPS preview and display it without loading the full high‑resolution EPS data.
 */