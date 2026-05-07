using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Temp\input.wmf";
            string outputPath = @"C:\Temp\output.svg";

            // Verify that the input WMF file exists
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
                    // Preserve text as text (do not convert to shapes) to keep font information
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

                // Save the image as SVG
                wmfImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}