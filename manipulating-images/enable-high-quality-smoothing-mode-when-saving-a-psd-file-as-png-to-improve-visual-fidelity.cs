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
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG options with high‑quality smoothing
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        SmoothingMode = SmoothingMode.AntiAlias,
                        TextRenderingHint = TextRenderingHint.AntiAlias
                    }
                };

                // Save as PNG with the specified options
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
 * 1. When a web designer needs to convert layered Photoshop PSD files to PNG for responsive websites while preserving smooth edges and anti‑aliased text, this code ensures high‑quality visual fidelity.
 * 2. When an e‑learning platform generates PNG thumbnails from PSD lesson assets and wants crisp graphics without jagged lines, the smoothing mode improves the thumbnail appearance.
 * 3. When a digital marketing agency automates batch conversion of PSD logos to PNG for social media posts, enabling anti‑aliasing prevents pixelated edges on various screen resolutions.
 * 4. When a print‑to‑screen workflow requires exporting PSD artwork as PNG for proofing on client devices, the high‑quality smoothing maintains the original design’s smooth curves and text rendering.
 * 5. When a desktop application creates PNG previews of PSD files for a file explorer preview pane, using SmoothingMode.AntiAlias ensures the previews look professional and clear.
 */