using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Define input and output directories (relative paths)
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Get all EPS files in the input directory
        string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

        foreach (string inputPath in epsFiles)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Load the EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Gather image details
                int width = epsImage.Width;
                int height = epsImage.Height;
                var format = epsImage.FileFormat;
                string title = epsImage.Title;
                string creator = epsImage.Creator;
                int previewCount = epsImage.PreviewImageCount;

                // Prepare output PNG path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set PNG options with rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new EpsRasterizationOptions
                    {
                        PageWidth = width,
                        PageHeight = height,
                        BackgroundColor = Color.White
                    }
                };

                // Save PNG preview
                epsImage.Save(outputPath, pngOptions);

                // Output report line
                Console.WriteLine($"Processed '{Path.GetFileName(inputPath)}': {width}x{height}, Format={format}, Title='{title}', Creator='{creator}', Previews={previewCount}, PNG saved to '{outputPath}'");
            }
        }
    }
}