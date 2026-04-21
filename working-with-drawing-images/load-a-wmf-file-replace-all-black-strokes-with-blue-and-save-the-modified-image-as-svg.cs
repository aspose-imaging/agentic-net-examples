using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.wmf";
        string tempSvgPath = @"C:\Images\temp.svg";
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
        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            // Prepare SVG save options
            SvgOptions saveOptions = new SvgOptions
            {
                TextAsShapes = true
            };

            // Configure rasterization options for WMF to SVG conversion
            WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = wmfImage.Size,
                RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
            };

            saveOptions.VectorRasterizationOptions = rasterOptions;

            // Save the WMF as an intermediate SVG file
            wmfImage.Save(tempSvgPath, saveOptions);
        }

        // Read the intermediate SVG content
        string svgContent = File.ReadAllText(tempSvgPath);

        // Replace black stroke definitions with blue
        svgContent = svgContent.Replace("stroke=\"black\"", "stroke=\"blue\"");
        svgContent = svgContent.Replace("#000000", "#0000FF");
        svgContent = svgContent.Replace("stroke:#000000", "stroke:#0000FF");

        // Write the modified SVG to the final output path
        File.WriteAllText(outputPath, svgContent);

        // Optionally delete the temporary SVG file
        try
        {
            File.Delete(tempSvgPath);
        }
        catch
        {
            // Ignore any errors during cleanup
        }
    }
}