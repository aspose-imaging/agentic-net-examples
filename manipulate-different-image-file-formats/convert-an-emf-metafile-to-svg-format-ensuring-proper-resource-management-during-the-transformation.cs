using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\test.emf";
        string outputPath = @"C:\Temp\test.output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image and convert it to SVG
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            // Configure SVG save options
            SvgOptions saveOptions = new SvgOptions
            {
                TextAsShapes = true // Render text as shapes
            };

            // Configure rasterization options specific to EMF
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                BackgroundColor = Color.WhiteSmoke,
                PageSize = emfImage.Size,
                RenderMode = EmfRenderMode.Auto,
                BorderX = 50,
                BorderY = 50
            };

            // Attach rasterization options to the SVG options
            saveOptions.VectorRasterizationOptions = rasterOptions;

            // Save the image as SVG
            emfImage.Save(outputPath, saveOptions);
        }
    }
}