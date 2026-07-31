using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputJpegs";

            // Validate input directory existence
            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify each input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output JPEG path
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                // Ensure the output directory exists before saving
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure rasterization options for high‑resolution rendering
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    };

                    // Set JPEG export options with quality 95 and 300 DPI
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 95,
                        ResolutionSettings = new ResolutionSetting(300, 300),
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑convert a library of SVG logos into high‑resolution JPEGs with 95 % quality for use in email newsletters or marketing collateral.
 * 2. When an e‑commerce platform must automatically transform product SVG illustrations into printable 300 DPI JPEG images for catalog generation using C# and Aspose.Imaging.
 * 3. When a web application requires on‑the‑fly rasterization of user‑uploaded SVG icons into optimized JPEG thumbnails for faster page loading.
 * 4. When a legacy system only accepts JPEG files, prompting a developer to convert archived SVG diagrams into high‑clarity JPEGs while preserving dimensions and background color.
 * 5. When a digital asset management workflow needs to ensure consistent image quality by processing multiple SVG assets into 95 % quality JPEGs for archival and distribution.
 */