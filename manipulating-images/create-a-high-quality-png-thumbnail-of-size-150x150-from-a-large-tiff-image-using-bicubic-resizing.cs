using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\large.tif";
        string outputPath = @"C:\Images\thumbnail.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                // Resize to 150x150 using bicubic (CubicConvolution) resampling
                image.Resize(150, 150, ResizeType.CubicConvolution);

                // Save the result as a PNG thumbnail
                image.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to generate fast‑loading preview images from high‑resolution TIFF scans, a developer can use this C# code to create 150 × 150 PNG thumbnails with bicubic resizing.
 * 2. When an e‑commerce platform stores product photos as TIFF files for archival quality but displays them as small PNG previews on catalog pages, this snippet resizes and converts the images efficiently.
 * 3. When a document management system must produce thumbnail icons for large multi‑page TIFF documents to show in a file explorer UI, the code provides a reliable way to generate 150 × 150 PNG thumbnails using Aspose.Imaging for .NET.
 * 4. When a medical imaging workflow requires quick visual summaries of high‑resolution TIFF radiology images for clinicians, developers can employ this example to create bicubic‑scaled PNG thumbnails for dashboards.
 * 5. When a digital asset management tool needs to batch‑process thousands of TIFF files into uniform 150 × 150 PNG thumbnails for search indexing, this C# routine demonstrates the necessary resizing and format conversion steps.
 */