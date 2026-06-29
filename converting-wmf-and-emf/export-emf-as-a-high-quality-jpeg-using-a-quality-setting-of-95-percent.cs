using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output\\output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for EMF
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                // Configure JPEG options with high quality
                var jpegOptions = new JpegOptions
                {
                    Quality = 95,
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
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
 * 1. When a Windows desktop application must convert vector‑based EMF reports into high‑quality JPEG thumbnails for display in a web portal, a developer can use this code to rasterize the EMF with a 95 % quality setting.
 * 2. When an automated document‑processing service needs to archive legacy EMF diagrams as compressed JPEG images while preserving visual fidelity, this snippet provides the C# logic to load, rasterize, and save with Aspose.Imaging.
 * 3. When a batch‑processing tool generates printable PDFs from EMF logos and also requires JPEG versions for email attachments, the code demonstrates how to export each EMF to a JPEG with a configurable quality level.
 * 4. When a migration script moves graphic assets from a Windows‑only format to a cross‑platform image format, developers can employ this example to ensure the EMF files are rendered with a white background and saved as 95‑percent quality JPEGs.
 * 5. When a content‑management system imports user‑uploaded EMF files and needs to create fast‑loading preview images for browsers, this C# routine shows how to produce high‑resolution JPEG previews using Aspose.Imaging’s rasterization options.
 */