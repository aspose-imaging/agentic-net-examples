// HOW-TO: Batch Convert BMP to SVG with Timestamped Filenames in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = @"C:\InputBmp";
            string outputDirectory = @"C:\OutputSvg";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp", SearchOption.TopDirectoryOnly);

            int index = 0;
            foreach (string bmpPath in bmpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(bmpPath))
                {
                    Console.Error.WriteLine($"File not found: {bmpPath}");
                    return;
                }

                // Create a unique timestamp prefix
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                // Increment index to avoid identical timestamps when loop runs quickly
                string uniquePrefix = $"{timestamp}_{index++}";

                // Build the output SVG file path
                string outputFileName = $"{uniquePrefix}_{Path.GetFileNameWithoutExtension(bmpPath)}.svg";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image and save it as SVG
                using (Image image = Image.Load(bmpPath))
                {
                    SvgOptions svgOptions = new SvgOptions();
                    // Optional: configure vector rasterization options if needed
                    // svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = image.Size };

                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to automatically convert a folder of legacy BMP assets into scalable SVG graphics for a web application while ensuring each output file has a unique timestamped name.
 * 2. When a build pipeline must generate vector versions of design mock‑ups stored as BMPs and avoid filename collisions by prefixing each SVG with a precise timestamp.
 * 3. When an image‑processing service processes user‑uploaded BMP files in bulk and saves the resulting SVGs with unique identifiers for later retrieval or auditing.
 * 4. When migrating a desktop application's bitmap icons to SVG format and you want to keep a chronological record of each conversion run in the filenames.
 * 5. When creating a nightly batch job that transforms scanned BMP documents into SVG for lightweight storage, using timestamps to track when each file was produced.
 */
