using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully.
        try
        {
            // Hard‑coded input and output file paths.
            string inputPath = @"C:\Input\sample.otg";
            string outputPath = @"C:\Output\sample.svg";

            // Verify that the input OTG file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary).
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image.
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG export options.
                SvgOptions svgOptions = new SvgOptions
                {
                    // Preserve original metadata (including layer names) in the SVG.
                    KeepMetadata = true,

                    // Configure rasterization options specific to OTG files.
                    VectorRasterizationOptions = new OtgRasterizationOptions
                    {
                        // Use the original image size for the SVG page.
                        PageSize = image.Size
                    }
                };

                // Save the image as SVG.
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any runtime error without crashing the program.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}