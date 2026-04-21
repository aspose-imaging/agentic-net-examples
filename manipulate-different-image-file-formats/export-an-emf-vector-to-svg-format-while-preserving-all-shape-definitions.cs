using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\test.emf";
        string outputPath = @"c:\temp\test.output.svg";

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
            // Configure SVG save options
            SvgOptions saveOptions = new SvgOptions
            {
                TextAsShapes = true // Preserve text as shapes
            };

            // Configure EMF rasterization options for SVG conversion
            EmfRasterizationOptions rasterizationOptions = new EmfRasterizationOptions
            {
                BackgroundColor = Color.WhiteSmoke,
                PageSize = emfImage.Size,
                RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto
                // Optional margins can be set here:
                // BorderX = 50,
                // BorderY = 50
            };

            saveOptions.VectorRasterizationOptions = rasterizationOptions;

            // Save the image as SVG
            emfImage.Save(outputPath, saveOptions);
        }
    }
}