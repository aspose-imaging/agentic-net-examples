using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to EmfImage to access size property
            EmfImage emfImage = (EmfImage)image;

            // Configure APNG options with vector rasterization settings
            using (ApngOptions apngOptions = new ApngOptions())
            {
                // Set the source for the output file
                apngOptions.Source = new FileCreateSource(outputPath, false);

                // Configure vector rasterization to render text as shapes
                EmfRasterizationOptions vectorOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = emfImage.Size,
                    RenderMode = EmfRenderMode.Auto
                };
                apngOptions.VectorRasterizationOptions = vectorOptions;

                // Save the EMF as APNG (text will be rendered as vector shapes)
                emfImage.Save(outputPath, apngOptions);
            }
        }
    }
}