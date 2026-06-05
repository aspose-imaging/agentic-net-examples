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
            string inputDirectory = @"C:\Images\Svg";
            string outputDirectory = @"C:\Images\Jpeg";

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output JPEG path
                string outputPath = Path.Combine(
                    outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure rasterization options for high‑resolution output
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        // Use the original image size; you can adjust DPI or scaling here if needed
                        PageSize = image.Size
                    };

                    // Configure JPEG options with quality set to 95%
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 95,
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save the rasterized image as JPEG
                    image.Save(outputPath, jpegOptions);
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
 * 1. When a web application needs to generate high‑resolution product thumbnails by converting a batch of SVG icons to JPEGs with 95 % quality for fast loading on e‑commerce sites.
 * 2. When a desktop publishing workflow requires rasterizing vector logos stored as SVG files into print‑ready JPEG images at the original dimensions while preserving visual fidelity.
 * 3. When an automated CI/CD pipeline must convert SVG diagrams into JPEG screenshots for inclusion in documentation PDFs, ensuring consistent DPI and high quality.
 * 4. When a mobile app backend processes user‑uploaded SVG avatars and creates compressed JPEG previews at 95 % quality to reduce bandwidth while maintaining clarity.
 * 5. When a digital asset management system needs to batch‑process SVG illustrations into JPEG assets for legacy systems that only support raster formats, using C# and Aspose.Imaging.
 */