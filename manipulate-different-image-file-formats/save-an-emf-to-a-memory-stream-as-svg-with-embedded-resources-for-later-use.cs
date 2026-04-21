using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\input.emf";
            string outputPath = @"C:\Temp\output.svg";

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
                // Configure SVG save options with embedded resources
                var svgOptions = new SvgOptions
                {
                    TextAsShapes = true,
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.WhiteSmoke,
                        PageSize = emfImage.Size,
                        RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                        BorderX = 50,
                        BorderY = 50
                    }
                };

                // Save to a memory stream
                using (var memoryStream = new MemoryStream())
                {
                    emfImage.Save(memoryStream, svgOptions);

                    // Optionally write the SVG data to a file for later use
                    File.WriteAllBytes(outputPath, memoryStream.ToArray());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}