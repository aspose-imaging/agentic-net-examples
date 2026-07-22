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

            // Configure font substitution: use a default fallback font
            FontSettings.DefaultFontName = "Arial";

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options for vector formats
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Prepare PNG save options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image with font substitution applied
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
 * 1. When converting OpenDocument graphics (ODG) files to PNG thumbnails in a C# web service and the source document uses fonts that are not installed on the server, developers can configure FontSettings.DefaultFontName to substitute missing fonts and ensure the output image renders correctly.
 * 2. When automating batch processing of design assets stored as ODG files and needing to generate high‑resolution PNG previews on a build server that lacks the original typefaces, the code provides a reliable way to replace absent fonts with a fallback like Arial.
 * 3. When building a desktop application that lets users import ODG diagrams and export them as PNG for reporting, the code handles cases where the ODG contains custom fonts not present on the client machine by applying font substitution during rasterization.
 * 4. When integrating Aspose.Imaging into a document management system that archives ODG drawings and must produce PNG previews for indexing, developers can use this snippet to guarantee consistent rendering even when the source fonts are missing from the hosting environment.
 * 5. When creating a CI/CD pipeline that validates visual quality of ODG assets by converting them to PNG for pixel‑by‑pixel comparison, the code ensures missing fonts are replaced with a known default, preventing false failures due to unavailable typefaces.
 */