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

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG save options with WMF rasterization settings
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true,
                    VectorRasterizationOptions = new WmfRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.WhiteSmoke,
                        PageSize = ((WmfImage)image).Size,
                        RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                    }
                };

                // Save as SVG
                image.Save(outputPath, saveOptions);
            }

            // Post‑process the SVG to replace black strokes with blue
            string svgContent = File.ReadAllText(outputPath);
            // Replace common black stroke representations
            svgContent = svgContent.Replace("stroke=\"black\"", "stroke=\"blue\"");
            svgContent = svgContent.Replace("stroke:#000000", "stroke:#0000FF");
            svgContent = svgContent.Replace("stroke:#000", "stroke:#00F");
            File.WriteAllText(outputPath, svgContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}