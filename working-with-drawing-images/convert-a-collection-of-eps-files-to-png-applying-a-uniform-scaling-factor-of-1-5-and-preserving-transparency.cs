// HOW-TO: Batch Convert EPS to PNG with 1.5 Scaling and Transparency in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "InputEps";
        string outputDirectory = "OutputPng";

        try
        {
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

            // Get all EPS files
            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

            foreach (string inputPath in epsFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                // Ensure output directory for the file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS, resize, and save as PNG
                using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
                {
                    int newWidth = (int)(epsImage.Width * 1.5);
                    int newHeight = (int)(epsImage.Height * 1.5);

                    epsImage.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                    var pngOptions = new PngOptions();
                    epsImage.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate higher‑resolution PNG previews of vector EPS logos for a web catalog while keeping the transparent background.
 * 2. When an automated build process must batch‑process design assets, converting all EPS files in a folder to PNGs scaled by 1.5 for use in mobile applications.
 * 3. When a reporting tool requires PNG images of EPS charts at a larger size to improve readability in PDF reports.
 * 4. When migrating legacy EPS artwork to a modern CMS that only accepts PNG files with preserved alpha channels.
 * 5. When creating thumbnails for an e‑commerce platform, scaling EPS product drawings by 150 % and saving them as transparent PNGs for fast loading.
 */
