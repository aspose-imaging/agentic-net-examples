// HOW-TO: How to Substitute Missing Fonts When Converting ODG to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Folder that contains substitute fonts
            string substituteFontsFolder = @"C:\Fonts\Substitutes";

            // Configure Aspose.Imaging to use the substitute fonts folder
            FontSettings.SetFontsFolder(substituteFontsFolder);

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options for PNG output
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save the image with the configured font substitution
                image.Save(outputPath, pngOptions);
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
 * 1. When an ODG diagram contains fonts that are not installed on the server, you can configure a substitute fonts folder to ensure the image renders correctly when converting it to PNG with Aspose.Imaging in C#.
 * 2. When automating batch conversion of OpenDocument graphics to web‑friendly PNG files, you need to handle missing typefaces by setting up font substitution to avoid broken text in the output.
 * 3. When generating thumbnails of ODG files in a cloud service where the original fonts are unavailable, configuring FontSettings lets you produce accurate previews without manual font installation.
 * 4. When integrating Aspose.Imaging into a document‑processing pipeline that receives ODG uploads from various users, you can replace unknown fonts with local substitutes to maintain visual fidelity during rasterization.
 * 5. When building a C# application that converts vector drawings to raster images on machines with limited font libraries, setting a custom fonts folder ensures consistent rendering across different environments.
 */
