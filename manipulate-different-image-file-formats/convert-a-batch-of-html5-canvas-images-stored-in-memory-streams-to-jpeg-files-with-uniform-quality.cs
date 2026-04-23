using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded list of HTML5 Canvas source files
            string[] inputPaths = new string[]
            {
                @"C:\Images\canvas1.html",
                @"C:\Images\canvas2.html",
                @"C:\Images\canvas3.html"
            };

            // Hard‑coded output directory
            string outputDir = @"C:\Images\JpegOutput";

            // Ensure the output directory exists (rule 3)
            Directory.CreateDirectory(outputDir);

            // Uniform JPEG quality for all images
            int jpegQuality = 80;

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists (rule 2)
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the canvas image (using the provided load rule)
                using (Image image = Image.Load(inputPath))
                {
                    // Build the output JPEG file path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".jpg";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Ensure the output directory exists before saving (rule 3)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure JPEG options with the desired quality
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = jpegQuality
                    };

                    // Save the image as JPEG (using the provided save rule)
                    image.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Global error handling (rule 4)
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}