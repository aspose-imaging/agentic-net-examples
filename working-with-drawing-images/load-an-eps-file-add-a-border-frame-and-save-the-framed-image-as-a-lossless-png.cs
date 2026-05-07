using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch unexpected errors
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "input.eps";
            string outputPath = "output.png";

            // Verify that the EPS source file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Configure PNG save options with rasterization settings that add a border
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new EpsRasterizationOptions
                    {
                        // Add a 10‑pixel border on each side
                        BorderX = 10,
                        BorderY = 10,
                        // Increase page size to accommodate the border
                        PageWidth = epsImage.Width + 20,
                        PageHeight = epsImage.Height + 20,
                        // Optional: set background and drawing colors
                        BackgroundColor = Color.White,
                        DrawColor = Color.Black
                    }
                };

                // Save the framed image as a lossless PNG
                epsImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}