using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input folder containing BMP files
        string inputFolder = @"C:\Images\InputBmp";
        // Hard‑coded output folder for generated SVG files
        string outputFolder = @"C:\Images\OutputSvg";

        // Ensure the output directory exists (unconditional per requirements)
        Directory.CreateDirectory(outputFolder);

        // Define BMP files to process (could be extended or discovered dynamically)
        string[] bmpFiles = new[]
        {
            Path.Combine(inputFolder, "image1.bmp"),
            Path.Combine(inputFolder, "image2.bmp"),
            Path.Combine(inputFolder, "image3.bmp")
        };

        foreach (string inputPath in bmpFiles)
        {
            // Verify input file existence; on failure write error and stop processing this file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build corresponding SVG output path
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".svg";
            string outputPath = Path.Combine(outputFolder, outputFileName);

            // Ensure the directory for the output file exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options required for SVG export
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Prepare SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions,
                    // No compression for plain SVG
                    Compress = false
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }

            // After saving, inject a custom XML namespace into the SVG file
            // Example namespace: xmlns:custom="http://example.com/custom"
            try
            {
                string svgContent = File.ReadAllText(outputPath);
                // Insert the custom namespace right after the opening <svg tag
                if (svgContent.Contains("<svg") && !svgContent.Contains("xmlns:custom"))
                {
                    svgContent = svgContent.Replace("<svg", "<svg xmlns:custom=\"http://example.com/custom\"");
                    File.WriteAllText(outputPath, svgContent);
                }
            }
            catch (Exception ex)
            {
                // Log any I/O errors but do not throw
                Console.Error.WriteLine($"Error processing SVG namespace for {outputPath}: {ex.Message}");
            }
        }
    }
}