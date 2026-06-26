using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.otg";
            string outputPath = "Output/sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options
                using (PngOptions pngOptions = new PngOptions())
                {
                    // Configure rasterization options with anti‑aliasing
                    OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                    {
                        PageSize = image.Size,
                        SmoothingMode = SmoothingMode.AntiAlias,
                        TextRenderingHint = TextRenderingHint.AntiAlias
                    };

                    pngOptions.VectorRasterizationOptions = otgOptions;

                    // Save the image as PNG
                    image.Save(outputPath, pngOptions);
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
 * 1. When converting vector‑based OTG drawings to PNG thumbnails for a web gallery, enabling anti‑aliasing ensures smooth edges.
 * 2. When generating printable PNG assets from OTG CAD files in a C# batch job, anti‑aliasing improves visual fidelity.
 * 3. When creating PNG previews of OTG diagrams for email attachments, rasterization with smoothing prevents jagged lines.
 * 4. When integrating OTG to PNG conversion into a .NET reporting tool, anti‑aliasing makes charts and text appear crisp.
 * 5. When automating the migration of legacy OTG assets to PNG for a mobile app, enabling anti‑aliasing reduces pixelation on high‑resolution screens.
 */