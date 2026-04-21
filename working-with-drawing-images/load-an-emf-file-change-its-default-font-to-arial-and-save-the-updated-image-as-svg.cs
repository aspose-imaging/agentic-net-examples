using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output.svg";

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
                // Keep text as text (default font will be used; Arial is the system default for many EMFs)
                TextAsShapes = false
            };

            // Configure rasterization options for the EMF source
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = emfImage.Size,
                RenderMode = EmfRenderMode.Auto
            };

            saveOptions.VectorRasterizationOptions = rasterOptions;

            // Save as SVG
            emfImage.Save(outputPath, saveOptions);
        }
    }
}