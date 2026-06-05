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
                WmfRasterizationOptions rasterizationOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = wmfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                };

                saveOptions.VectorRasterizationOptions = rasterizationOptions;

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
 * 1. When a developer needs to convert legacy Windows Metafile (WMF) graphics to scalable SVG for web display while ensuring a white background for consistent rendering across browsers.
 * 2. When integrating a document processing pipeline that extracts vector icons from WMF files and saves them as SVG with a uniform white canvas to match corporate branding guidelines.
 * 3. When building a C# desktop application that allows users to import WMF diagrams, automatically replace any transparent or colored background with white, and export them as SVG for inclusion in reports.
 * 4. When migrating an old Windows‑based catalog that stores product illustrations as WMF and requires batch conversion to SVG with a white background to improve print quality and scalability.
 * 5. When creating an automated CI/CD step that validates WMF assets, rasterizes them with a white background, and generates SVG files for responsive UI components in a .NET web project.
 */