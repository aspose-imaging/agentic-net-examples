using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            // Prepare SVG save options
            SvgOptions saveOptions = new SvgOptions
            {
                // Render all text as shapes for better portability
                TextAsShapes = true
            };

            // Configure rasterization options for WMF to SVG conversion
            WmfRasterizationOptions rasterizationOptions = new WmfRasterizationOptions
            {
                // Apply a semi‑transparent red tint as the background color (acts as a tint)
                BackgroundColor = Aspose.Imaging.Color.FromArgb(128, 255, 0, 0),

                // Use the original WMF size as the page size
                PageSize = wmfImage.Size,

                // Let the renderer decide the best mode (auto)
                RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
            };

            // Attach rasterization options to the SVG options
            saveOptions.VectorRasterizationOptions = rasterizationOptions;

            // Save the tinted image as SVG
            wmfImage.Save(outputPath, saveOptions);
        }
    }
}