using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.wmf";
        string outputPath = @"C:\temp\output.svg";

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
            // Set up SVG save options
            SvgOptions saveOptions = new SvgOptions
            {
                // Render all text as shapes to preserve layout and embedded fonts
                TextAsShapes = true
            };

            // Configure rasterization options for WMF
            WmfRasterizationOptions rasterizationOptions = new WmfRasterizationOptions
            {
                // Background color for the drawing surface
                BackgroundColor = Aspose.Imaging.Color.WhiteSmoke,
                // Use the original WMF size as the page size
                PageSize = wmfImage.Size,
                // Automatically choose rendering mode (EMF or WMF)
                RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
            };

            // Assign rasterization options to the SVG options
            saveOptions.VectorRasterizationOptions = rasterizationOptions;

            // Save the image as SVG
            wmfImage.Save(outputPath, saveOptions);
        }
    }
}