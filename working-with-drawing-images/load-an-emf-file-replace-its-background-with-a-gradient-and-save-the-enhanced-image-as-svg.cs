using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            // Prepare SVG save options
            SvgOptions svgOptions = new SvgOptions
            {
                // Render all text as vector shapes
                TextAsShapes = true
            };

            // Configure rasterization options.
            // Aspose.Imaging does not expose a direct gradient brush for the background,
            // so we set a solid background color here. To achieve a true gradient,
            // custom SVG definitions would be required, which is beyond the scope of this example.
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size,
                RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                BackgroundColor = Aspose.Imaging.Color.White // Placeholder for gradient background
            };

            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save the enhanced image as SVG
            emfImage.Save(outputPath, svgOptions);
        }
    }
}