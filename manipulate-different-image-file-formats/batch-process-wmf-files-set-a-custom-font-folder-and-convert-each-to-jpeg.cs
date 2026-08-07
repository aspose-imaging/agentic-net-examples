// HOW-TO: Batch Convert WMF to JPEG with Custom Font Folder in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputFolder = @"C:\InputWmf";
            string outputFolder = @"C:\OutputJpeg";
            string customFontFolder = @"C:\CustomFonts";

            // Set custom font folder for vector rendering
            FontSettings.SetFontsFolder(customFontFolder);

            // Get all WMF files in the input folder
            string[] wmfFiles = Directory.GetFiles(inputFolder, "*.wmf");

            foreach (string inputPath in wmfFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path (same file name with .jpg extension)
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure rasterization options based on the source image size
                    var rasterOptions = new WmfRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // JPEG save options with vector rasterization
                    var jpegOptions = new JpegOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to convert a large collection of legacy WMF vector drawings into JPEG thumbnails for web preview while ensuring the drawings use fonts stored in a private directory.
 * 2. When an application must render WMF reports that rely on custom corporate fonts and then save them as raster JPEG images for email attachments.
 * 3. When automating migration of design assets from WMF to a more widely supported bitmap format across multiple files in a folder structure.
 * 4. When generating JPEG previews of WMF icons for a mobile app, and the icons use fonts that are not installed on the target device.
 * 5. When processing batch WMF files on a server that does not have the required fonts installed system‑wide, so you point Aspose.Imaging to a custom font folder before conversion.
 */
