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
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\InputBmp";
            string outputDirectory = @"C:\Images\OutputSvg";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Custom XML namespace to add to each SVG
            const string customNamespace = "http://example.com/custom";

            // Process each BMP file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.bmp"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output SVG file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare SVG save options with default rasterization settings
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions,
                        // Keep metadata if needed
                        KeepMetadata = true
                    };

                    // Save the image as SVG
                    image.Save(outputPath, svgOptions);
                }

                // Insert the custom XML namespace into the generated SVG file
                try
                {
                    string svgContent = File.ReadAllText(outputPath);
                    // Find the first occurrence of the <svg tag
                    int svgTagEnd = svgContent.IndexOf('>');
                    if (svgTagEnd > 0)
                    {
                        // Insert the namespace attribute before the closing '>'
                        string before = svgContent.Substring(0, svgTagEnd);
                        string after = svgContent.Substring(svgTagEnd);
                        string namespaceAttribute = $" xmlns:custom=\"{customNamespace}\"";
                        // Avoid duplicate insertion
                        if (!before.Contains("xmlns:custom"))
                        {
                            svgContent = before + namespaceAttribute + after;
                            File.WriteAllText(outputPath, svgContent);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Failed to add namespace to {outputPath}: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}