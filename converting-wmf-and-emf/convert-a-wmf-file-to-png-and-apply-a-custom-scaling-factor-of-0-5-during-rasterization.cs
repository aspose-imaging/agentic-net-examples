using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.wmf";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Wmf.WmfImage wmfImage = (Aspose.Imaging.FileFormats.Wmf.WmfImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = new Aspose.Imaging.SizeF(wmfImage.Width * 0.5f, wmfImage.Height * 0.5f)
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                wmfImage.Save(outputPath, pngOptions);
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
 * 1. When a legacy Windows Metafile (WMF) diagram needs to be displayed on a web page, a developer can convert it to a PNG thumbnail at half size to reduce bandwidth.
 * 2. When generating printable reports that embed vector graphics, a developer may rasterize the WMF at a 0.5 scaling factor to create a lower‑resolution PNG for preview purposes.
 * 3. When migrating an old CAD system’s WMF assets to a modern image repository, a developer can use this code to batch‑convert each file to a PNG with reduced dimensions for faster indexing.
 * 4. When building a C# desktop application that lets users import WMF icons and automatically resize them for UI buttons, the developer can apply the 0.5 scaling during rasterization to fit the required icon size.
 * 5. When creating automated documentation pipelines that need to embed WMF charts as PNG images in PDFs, a developer can use this snippet to shrink the chart while preserving visual fidelity.
 */