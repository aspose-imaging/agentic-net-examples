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
        string outputPath = @"C:\Images\Output\sample.wmf";

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
            // Load EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Retrieve WMF preview
                var preview = epsImage.GetPreviewImage(EpsPreviewFormat.WMF);
                if (preview == null)
                {
                    Console.Error.WriteLine("WMF preview not available in the EPS file.");
                    return;
                }

                // Save preview as WMF vector image
                preview.Save(outputPath, new WmfOptions());
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
 * 1. When a developer needs to generate a low‑resolution WMF preview of an EPS artwork for quick display in a Windows Forms UI without loading the full vector data.
 * 2. When a document‑conversion service must extract the embedded WMF thumbnail from EPS files to embed into PDF/A metadata for faster indexing.
 * 3. When an automated publishing pipeline has to create lightweight WMF icons from EPS logos for use in legacy reporting tools that only accept WMF graphics.
 * 4. When a batch‑processing script has to verify that EPS files contain a preview image and save it as a separate WMF file for quality‑control reviewers.
 * 5. When a web application needs to serve a small vector preview of uploaded EPS files to browsers that support WMF via an ActiveX control, reducing bandwidth compared to the full EPS.
 */