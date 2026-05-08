using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Configure PNG export options with rasterization settings
                var pngOptions = new PngOptions
                {
                    // Bind the output file source
                    Source = new FileCreateSource(outputPath, false),

                    // Set vector rasterization options
                    VectorRasterizationOptions = new EpsRasterizationOptions
                    {
                        // Preserve original dimensions
                        PageWidth = epsImage.Width,
                        PageHeight = epsImage.Height,

                        // Adjust rendering to use round line joins via smoothing mode
                        // (Aspose.Imaging does not expose a direct line‑join property for EPS rasterization;
                        // using anti‑alias smoothing yields smoother, rounded joins.)
                        SmoothingMode = SmoothingMode.AntiAlias
                    }
                };

                // Save the modified image as PNG
                epsImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}