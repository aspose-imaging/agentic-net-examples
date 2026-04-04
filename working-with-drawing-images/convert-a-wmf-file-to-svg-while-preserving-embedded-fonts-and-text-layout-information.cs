using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.wmf";
        string outputPath = @"C:\temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            // Set up SVG save options
            SvgOptions saveOptions = new SvgOptions
            {
                // Preserve text as text (fonts will be embedded if possible)
                TextAsShapes = false
            };

            // Configure rasterization options for WMF
            WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
            {
                BackgroundColor = Color.WhiteSmoke,
                PageSize = wmfImage.Size,
                RenderMode = WmfRenderMode.Auto
            };

            saveOptions.VectorRasterizationOptions = rasterOptions;

            // Save as SVG
            wmfImage.Save(outputPath, saveOptions);
        }
    }
}