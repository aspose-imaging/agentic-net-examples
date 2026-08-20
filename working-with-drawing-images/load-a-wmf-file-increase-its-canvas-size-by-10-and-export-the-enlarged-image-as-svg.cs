// HOW-TO: Increase WMF Canvas Size by 10% and Export to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.wmf";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Increase canvas size by 10%
                int newWidth = (int)(wmfImage.Width * 1.1);
                int newHeight = (int)(wmfImage.Height * 1.1);
                var newRect = new Aspose.Imaging.Rectangle(0, 0, newWidth, newHeight);
                wmfImage.ResizeCanvas(newRect);

                // Prepare SVG save options
                var saveOptions = new SvgOptions
                {
                    TextAsShapes = true,
                    VectorRasterizationOptions = new WmfRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.WhiteSmoke,
                        PageSize = wmfImage.Size,
                        RenderMode = WmfRenderMode.Auto
                    }
                };

                // Save as SVG
                wmfImage.Save(outputPath, saveOptions);
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
 * 1. When you need to embed a WMF diagram in a web page that only supports SVG, you can enlarge the canvas and convert it to SVG.
 * 2. When preparing print‑ready assets, increasing the WMF canvas prevents clipping after scaling and allows loss‑less SVG export.
 * 3. When integrating legacy Windows Metafile graphics into a modern vector‑based reporting tool, you can resize the canvas and save as SVG for compatibility.
 * 4. When automating batch processing of WMF icons to match a new UI layout, you can programmatically enlarge each image and output SVG files.
 * 5. When a designer requires a 10 % margin around existing WMF artwork for branding guidelines, the code adds the margin and converts the result to scalable SVG.
 */
