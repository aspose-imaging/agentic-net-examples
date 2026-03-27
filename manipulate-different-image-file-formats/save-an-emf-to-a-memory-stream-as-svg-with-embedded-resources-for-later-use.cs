using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input path
        string inputPath = @"C:\temp\input.emf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Memory stream to hold the resulting SVG
        using (MemoryStream outputStream = new MemoryStream())
        {
            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Configure SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true
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

                // Save EMF as SVG into the memory stream
                emfImage.Save(outputStream, saveOptions);
            }

            // Reset stream position for further use
            outputStream.Position = 0;

            // Example: write the SVG to a file (optional)
            // string outputPath = @"C:\temp\output.svg";
            // Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            // File.WriteAllBytes(outputPath, outputStream.ToArray());
        }
    }
}