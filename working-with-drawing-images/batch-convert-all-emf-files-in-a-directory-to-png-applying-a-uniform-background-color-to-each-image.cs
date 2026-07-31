using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\EmfInput";
            string outputDirectory = @"C:\PngOutput";

            // Get all EMF files in the input directory
            string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (same name with .png extension in output directory)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare rasterization options with a uniform background color
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.LightGray,
                        PageSize = image.Size
                    };

                    // Prepare PNG save options and attach rasterization options
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save the image as PNG
                    image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to migrate a legacy collection of vector EMF diagrams to web‑friendly PNG images while applying a consistent background color for branding.
 * 2. When an automated build script must generate thumbnail previews of EMF reports stored in a folder, converting them to PNG with a uniform light‑gray canvas for UI display.
 * 3. When a Windows desktop application has to export user‑created EMF charts to PNG files for email attachment, ensuring all images share the same background shade.
 * 4. When a document‑processing pipeline processes batches of EMF graphics from a shared network drive and converts them to PNG for inclusion in PDF reports, using Aspose.Imaging’s rasterization options.
 * 5. When a migration tool needs to bulk‑convert EMF assets in a legacy asset library to PNG format with a predefined background color to maintain visual consistency across a new mobile app.
 */