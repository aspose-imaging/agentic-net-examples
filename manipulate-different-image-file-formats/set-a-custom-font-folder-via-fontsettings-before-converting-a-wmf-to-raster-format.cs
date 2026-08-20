// HOW-TO: Convert WMF to PNG with Custom Font Folder in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.wmf";
            string outputPath = "Output\\sample.png";
            // Custom font folder
            string fontFolder = "Fonts";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set custom font folder for Aspose.Imaging
            FontSettings.SetFontsFolders(new[] { fontFolder }, true);

            // Load WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to WmfImage to access size property
                WmfImage wmfImage = (WmfImage)image;

                // Configure rasterization options
                var rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = wmfImage.Size,
                    RenderMode = WmfRenderMode.Auto
                };

                // Set PNG save options with vector rasterization
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as raster PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to render a WMF diagram that uses fonts not installed on the server, you can point Aspose.Imaging to a custom font directory before converting it to PNG.
 * 2. When generating thumbnails of legacy vector graphics in a web application and the fonts are stored in a specific folder, this code ensures the text appears correctly in the raster image.
 * 3. When automating batch conversion of WMF files to PNG in a CI pipeline on a machine without the required fonts, setting FontSettings avoids missing‑glyph errors.
 * 4. When creating printable PNG assets from WMF logos that rely on corporate brand fonts located in a shared repository, the code loads those fonts before rasterization.
 * 5. When developing a desktop tool that converts user‑uploaded WMF files to PNG on a client PC with limited font installations, you can supply a custom font folder to preserve text layout.
 */
