using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Validate input directory
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all EPS files in the input directory
        string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

        foreach (string epsPath in epsFiles)
        {
            // Verify the EPS file exists
            if (!File.Exists(epsPath))
            {
                Console.Error.WriteLine($"File not found: {epsPath}");
                continue;
            }

            // Prepare output PNG path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(epsPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load, resize, and save the EPS as PNG
            using (EpsImage epsImage = (EpsImage)Image.Load(epsPath))
            {
                int newWidth = (int)(epsImage.Width * 1.5);
                int newHeight = (int)(epsImage.Height * 1.5);

                // Resize with high-quality Lanczos resampling
                epsImage.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Save as PNG preserving transparency
                epsImage.Save(outputPath, new PngOptions());
            }
        }
    }
}