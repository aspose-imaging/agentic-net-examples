// HOW-TO: Convert EMF to PNG with Custom DPI in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Configure rasterization options for EMF to PNG conversion
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    // Set page size based on source image dimensions
                    PageSize = new SizeF(emfImage.Width, emfImage.Height)
                };

                // Set PNG export options, including DPI via ResolutionSettings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    // Example DPI setting: 300x300
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                // Save as PNG with specified DPI
                emfImage.Save(outputPath, pngOptions);
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
 * 1. When you need to embed a vector EMF logo into a high‑resolution PDF or print layout, you can rasterize it to a PNG at 300 dpi using Aspose.Imaging in C#.
 * 2. When a desktop application must display legacy EMF diagrams on screens that only support raster images, converting them to PNG with a specific DPI ensures consistent visual quality.
 * 3. When generating thumbnails for an asset‑management system, you may convert EMF files to PNG files sized for web use while preserving the required DPI for accurate scaling.
 * 4. When preparing graphics for a marketing campaign that requires PNG images with exact DPI settings for print vendors, this code automates the EMF‑to‑PNG conversion in a .NET workflow.
 * 5. When migrating a legacy document repository that stores drawings as EMF, you can batch‑process them to DPI‑controlled PNGs for compatibility with modern browsers and mobile devices.
 */
