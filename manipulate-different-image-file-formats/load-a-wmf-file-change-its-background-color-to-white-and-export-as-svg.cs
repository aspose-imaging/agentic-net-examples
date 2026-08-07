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
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.wmf";
        string outputPath = @"C:\temp\output.svg";

        try
        {
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
                    TextAsShapes = true // optional: render text as shapes
                };

                // Configure rasterization options with a white background
                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = wmfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
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

/*
 * Real-World Use Cases:
 * 1. When converting legacy Windows Metafile (WMF) diagrams to scalable SVG for web display, developers use this code to ensure a consistent white background across browsers.
 * 2. When an engineering application needs to process WMF schematics in C# and export them as SVG with a uniform white canvas for high‑quality printing, this code provides the solution.
 * 3. When automating batch conversion of WMF icons to SVG assets for a UI redesign, developers employ this code to set the background color to white and avoid unwanted transparency.
 * 4. When building a document generation tool that embeds WMF charts into SVG reports, this code forces the background to white so the charts match the report’s theme.
 * 5. When creating a .NET service that receives user‑uploaded WMF files, rasterizes them with a white background, and returns SVG files for compatibility with modern vector editors, developers rely on this code.
 */