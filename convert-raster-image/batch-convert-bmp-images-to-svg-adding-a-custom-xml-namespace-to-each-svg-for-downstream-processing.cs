using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        // List of BMP files to process (add or modify as needed)
        string[] bmpFiles = new[]
        {
            Path.Combine(inputFolder, "image1.bmp"),
            Path.Combine(inputFolder, "image2.bmp"),
            Path.Combine(inputFolder, "image3.bmp")
        };

        foreach (string inputPath in bmpFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output SVG path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".svg");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG rasterization options (use original image size)
                var vectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Save as SVG using SvgOptions
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = vectorRasterizationOptions,
                    // No compression for plain SVG
                    Compress = false
                };

                image.Save(outputPath, svgOptions);
            }

            // Add custom XML namespace to the generated SVG
            try
            {
                string svgContent = File.ReadAllText(outputPath);
                // Insert custom namespace into the root <svg> element
                // Example namespace: xmlns:custom="http://example.com/custom"
                const string customNamespace = "xmlns:custom=\"http://example.com/custom\"";
                int insertPos = svgContent.IndexOf('>');
                if (insertPos > 0)
                {
                    // Find the position before the closing '>' of the opening <svg ...> tag
                    int tagStart = svgContent.LastIndexOf("<svg", insertPos);
                    if (tagStart >= 0)
                    {
                        // Insert the namespace before the closing '>'
                        svgContent = svgContent.Insert(insertPos, " " + customNamespace);
                        File.WriteAllText(outputPath, svgContent);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log but do not throw
                Console.Error.WriteLine($"Failed to add namespace to {outputPath}: {ex.Message}");
            }
        }
    }
}