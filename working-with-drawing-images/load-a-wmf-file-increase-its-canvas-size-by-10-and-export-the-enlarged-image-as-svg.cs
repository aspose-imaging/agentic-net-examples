using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.svg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Calculate new canvas size (increase by 10%)
                int newWidth = (int)(wmfImage.Width * 1.10);
                int newHeight = (int)(wmfImage.Height * 1.10);

                // Resize the canvas
                wmfImage.ResizeCanvas(new Rectangle(0, 0, newWidth, newHeight));

                // Prepare SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true,
                    VectorRasterizationOptions = new WmfRasterizationOptions
                    {
                        BackgroundColor = Color.WhiteSmoke,
                        PageSize = new Size(newWidth, newHeight),
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
 * 1. When a developer needs to increase the canvas of an old WMF diagram by 10 % and convert it to SVG for scalable web graphics using Aspose.Imaging in C#.
 * 2. When a C# application must batch‑process WMF icons, add a uniform margin, and output them as SVG files for modern UI toolkits.
 * 3. When a software solution has to preserve vector quality while enlarging a WMF chart and exporting it to SVG for inclusion in PDF reports.
 * 4. When an automated build script must validate WMF assets, expand their canvas size, and generate SVG versions for cross‑platform mobile apps.
 * 5. When a developer wants to programmatically resize the drawing area of a WMF floor plan and save it as an SVG to enable interactive browser‑based viewing.
 */