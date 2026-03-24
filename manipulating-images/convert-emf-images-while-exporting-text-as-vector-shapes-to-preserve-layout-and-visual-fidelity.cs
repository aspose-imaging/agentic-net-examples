using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

namespace EmfToSvgConverter
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\input.emf";
            string outputPath = @"C:\temp\output.svg";

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
                // Prepare SVG save options with text rendered as shapes
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true
                };

                // Configure rasterization options for the EMF source
                EmfRasterizationOptions rasterizationOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = emfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                    // Optional margins; adjust as needed
                    BorderX = 0,
                    BorderY = 0
                };

                // Attach rasterization options to the SVG options
                saveOptions.VectorRasterizationOptions = rasterizationOptions;

                // Save the image as SVG using the configured options
                emfImage.Save(outputPath, saveOptions);
            }
        }
    }
}