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
        string inputPath = @"C:\temp\input.emf";
        string outputPath = @"C:\temp\output.svg";

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
            // Configure SVG save options
            SvgOptions saveOptions = new SvgOptions
            {
                TextAsShapes = true // Preserve text as shapes
            };

            // Configure rasterization options for EMF
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                BackgroundColor = Color.WhiteSmoke,
                PageSize = emfImage.Size,
                RenderMode = EmfRenderMode.Auto,
                BorderX = 0,
                BorderY = 0
            };

            saveOptions.VectorRasterizationOptions = rasterOptions;

            // Save as SVG
            emfImage.Save(outputPath, saveOptions);
        }
    }
}