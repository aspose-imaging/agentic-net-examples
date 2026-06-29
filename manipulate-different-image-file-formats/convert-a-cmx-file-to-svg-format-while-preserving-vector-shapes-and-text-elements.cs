using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.cmx";
            string outputPath = @"C:\temp\sample.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Configure SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    // Render text as vector shapes to preserve appearance
                    TextAsShapes = true,
                    // Set CMX-specific rasterization options
                    VectorRasterizationOptions = new CmxRasterizationOptions
                    {
                        // Use the source image size for the SVG page size
                        PageSize = cmxImage.Size,
                        // Optional: set a background color
                        BackgroundColor = Color.White
                    }
                };

                // Save the image as SVG
                cmxImage.Save(outputPath, svgOptions);
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
 * 1. When a CAD engineer needs to embed legacy CorelDRAW CMX drawings into a web page that only supports SVG, they can use this code to convert the CMX file while preserving vector shapes and text.
 * 2. When a document management system must archive design assets in a resolution‑independent format, developers can run this conversion to store CMX files as SVG with text rendered as shapes.
 * 3. When a print‑to‑PDF workflow requires an intermediate SVG representation of a CMX illustration to apply further transformations, the code provides a reliable C# method to generate that SVG.
 * 4. When a mobile app needs to display CMX graphics on devices that lack CorelDRAW support, the conversion to SVG ensures the vector artwork and text appear correctly on any screen.
 * 5. When a batch processing script must standardize a collection of CMX assets for a branding portal, this snippet automates the conversion to SVG while keeping the original layout and colors.
 */