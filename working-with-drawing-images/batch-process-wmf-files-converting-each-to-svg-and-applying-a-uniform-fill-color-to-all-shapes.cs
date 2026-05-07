using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\InputWmf";
            string outputDir = @"C:\OutputSvg";

            // Get all WMF files in the input directory
            string[] wmfFiles = Directory.GetFiles(inputDir, "*.wmf");

            foreach (string inputPath in wmfFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build the output SVG path
                string outputPath = Path.Combine(outputDir,
                    Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WMF image
                using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
                {
                    // Prepare SVG save options
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true // Render text as shapes
                    };

                    // Configure rasterization options with a uniform fill color
                    WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                    {
                        // Uniform fill color for the drawing surface (applied to all shapes)
                        BackgroundColor = Aspose.Imaging.Color.LightBlue,
                        PageSize = wmfImage.Size,
                        RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                    };

                    saveOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as SVG
                    wmfImage.Save(outputPath, saveOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}