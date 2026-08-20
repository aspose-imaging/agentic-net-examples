// HOW-TO: Convert Transparent EMF to JPEG with Custom Background Color in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.jpg";

            // Verify input file exists
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
                // Cast to EmfImage to access size and other EMF-specific properties
                EmfImage emfImage = (EmfImage)image;

                // Configure rasterization options with a custom background color
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size,
                    BackgroundColor = Color.LightGray // custom background color
                };

                // Set JPEG save options and attach the rasterization options
                JpegOptions jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as JPEG with the specified background
                emfImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate JPEG thumbnails from EMF logos that contain transparent areas and want a specific background shade.
 * 2. When exporting vector diagrams from a Windows application to JPEG for web display while ensuring a consistent background color.
 * 3. When batch‑processing EMF reports to JPEG for email attachments and must replace transparency with a corporate brand color.
 * 4. When converting EMF charts to JPEG for printing on a light‑colored paper and need to set a matching background.
 * 5. When integrating Aspose.Imaging into a C# service that transforms user‑uploaded EMF files to JPEG with a predefined background for preview images.
 */
