using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure font substitution:
                // Load system font folders so missing fonts can be resolved
                string[] systemFontFolders = FontSettings.GetDefaultFontsFolders();
                FontSettings.SetFontsFolders(systemFontFolders, true);
                // Set a default fallback font name
                FontSettings.DefaultFontName = "Arial";

                // Prepare rasterization options for PNG output
                var rasterOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = image.Size
                    }
                };

                // Save the image with the configured options
                image.Save(outputPath, rasterOptions);
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
 * 1. When a company needs to convert OpenDocument graphics (ODG) created with proprietary fonts into PNG thumbnails for a web portal, and the target machines may not have those fonts installed.
 * 2. When an automated document processing pipeline must render ODG diagrams to PNG images on a server that lacks the original font files, requiring fallback to a standard font like Arial.
 * 3. When a developer builds a C# desktop application that allows users to preview ODG drawings as PNGs, and the app must handle missing fonts gracefully by substituting system fonts.
 * 4. When migrating legacy ODG assets to a cloud storage solution that only supports raster formats, and the conversion code must ensure consistent text appearance despite absent custom fonts.
 * 5. When generating printable PNG reports from ODG charts in a batch job, and the job must guarantee that any missing fonts are replaced with a default font to avoid rendering errors.
 */