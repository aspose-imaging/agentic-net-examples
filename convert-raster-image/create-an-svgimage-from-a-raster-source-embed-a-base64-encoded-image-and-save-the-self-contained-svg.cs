using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load raster image to obtain its dimensions
            using (Image rasterImage = Image.Load(inputPath))
            {
                int width = rasterImage.Width;
                int height = rasterImage.Height;

                // Read raster image bytes and convert to Base64
                byte[] rasterBytes = File.ReadAllBytes(inputPath);
                string base64Data = Convert.ToBase64String(rasterBytes);

                // Build a simple SVG document that embeds the raster image as a Base64 data URI
                string svgContent = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg xmlns=""http://www.w3.org/2000/svg"" width=""{width}"" height=""{height}"">
    <image href=""data:image/png;base64,{base64Data}"" width=""{width}"" height=""{height}"" />
</svg>";

                // Create an SvgImage from the SVG XML string
                using (MemoryStream svgStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(svgContent)))
                using (SvgImage svgImage = new SvgImage(svgStream))
                {
                    // Save the self‑contained SVG file
                    svgImage.Save(outputPath);
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
 * 1. When a developer needs to embed a PNG logo into an SVG for a web page without external image files, this code creates a self‑contained SVG with a base64‑encoded raster image.
 * 2. When generating printable vector graphics that must include a raster photograph, the snippet wraps the photo as a data URI inside an SVG, ensuring the output file is portable across systems.
 * 3. When building an email template that requires a single SVG attachment containing a raster chart, this approach converts the chart PNG to base64 and embeds it directly in the SVG.
 * 4. When creating a responsive UI component that loads images from a database as byte arrays, the example shows how to construct an SVG on‑the‑fly in C# using Aspose.Imaging and save it as a standalone file.
 * 5. When automating a batch process that converts a folder of PNG assets into self‑contained SVG icons for a mobile app, the code demonstrates loading raster dimensions, encoding to base64, and saving the SVG with Aspose.Imaging for .NET.
 */