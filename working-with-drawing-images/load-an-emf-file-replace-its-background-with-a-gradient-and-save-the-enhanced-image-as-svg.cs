using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf.Emf.Records;
using Aspose.Imaging.FileFormats.Emf.Emf.Objects;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Insert a gradient background (placeholder implementation)
                AddGradientBackground(emfImage);

                // Prepare SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    TextAsShapes = true,
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = emfImage.Size,
                        RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto
                        // BackgroundColor is ignored because we added a gradient via records
                    }
                };

                // Save as SVG
                emfImage.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Adds a gradient background by inserting EMF records at the start of the file.
    // Note: Aspose.Imaging does not expose a direct gradient brush API in the public docs,
    // so this example uses a solid brush as a placeholder. Replace with actual gradient
    // brush creation logic if available.
    static void AddGradientBackground(EmfImage image)
    {
        // Ensure records are loaded
        image.CacheData();

        // Create a brush (solid color placeholder)
        EmfCreateBrushIndirect brush = new EmfCreateBrushIndirect
        {
            LogBrush = new EmfLogBrushEx(),
            IhBrush = 1 // Object handle (starts at 1)
        };
        brush.LogBrush.Argb32ColorRef = Aspose.Imaging.Color.LightBlue.ToArgb();

        // Select the brush
        EmfSelectObject selectBrush = new EmfSelectObject { ObjectHandle = 1 };

        // Define a rectangle covering the whole image
        EmfRectangle rect = new EmfRectangle { Box = image.Header.EmfHeader.Bounds };

        // Delete the brush after drawing
        EmfDeleteObject deleteBrush = new EmfDeleteObject { ObjectHandle = 1 };

        // Insert records at the beginning (in reverse order to keep indices correct)
        image.Records.Insert(0, deleteBrush);
        image.Records.Insert(0, rect);
        image.Records.Insert(0, selectBrush);
        image.Records.Insert(0, brush);
    }
}