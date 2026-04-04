using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            // Prepare SVG save options
            SvgOptions svgOptions = new SvgOptions
            {
                TextAsShapes = true // Convert text to shapes for better compatibility
            };

            // Configure rasterization options.
            // Aspose.Imaging does not provide a direct gradient brush for vector rasterization,
            // so we set a solid background color here. To achieve a true gradient,
            // one would need to manipulate EMF records manually (e.g., insert multiple
            // rectangles with varying colors) before saving.
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size,
                BackgroundColor = Color.LightGray, // Placeholder for gradient background
                RenderMode = EmfRenderMode.Auto,
                BorderX = 0,
                BorderY = 0
            };

            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save the enhanced image as SVG
            emfImage.Save(outputPath, svgOptions);
        }
    }
}