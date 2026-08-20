// HOW-TO: Check If PNG Converted From TIFF Contains Alpha Channel In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\source.tif";
            string outputPath = @"c:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image tiffImage = Image.Load(inputPath))
            {
                // Save as PNG
                PngOptions pngOptions = new PngOptions();
                tiffImage.Save(outputPath, pngOptions);
            }

            // Load the generated PNG image
            using (Image pngImage = Image.Load(outputPath))
            {
                PngImage png = (PngImage)pngImage;
                bool hasAlpha = png.HasAlpha;
                Console.WriteLine($"PNG generated from TIFF has alpha channel: {hasAlpha}");
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
 * 1. When you need to verify whether a TIFF image that was converted to PNG retains transparency before using it in a web UI.
 * 2. When automating a batch process that converts scanned TIFF documents to PNG and you must log which files have an alpha channel for downstream compositing.
 * 3. When integrating Aspose.Imaging into a C# service that generates thumbnails and you need to know if the resulting PNG includes an alpha channel to decide background filling.
 * 4. When troubleshooting image import pipelines and you want to confirm that the conversion step does not unintentionally add or remove transparency information.
 * 5. When building a reporting tool that audits image assets, and you need to record the presence of an alpha channel for PNGs created from legacy TIFF sources.
 */
