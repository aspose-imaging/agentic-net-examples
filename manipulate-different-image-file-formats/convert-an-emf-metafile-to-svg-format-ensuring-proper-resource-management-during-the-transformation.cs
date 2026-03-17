using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Path to the directory containing the EMF file.
        string dir = @"c:\temp\";

        // Full path of the source EMF file.
        string inputPath = System.IO.Path.Combine(dir, "input.emf");

        // Full path for the resulting SVG file.
        string outputPath = System.IO.Path.Combine(dir, "output.svg");

        // Load the EMF image using the unified Image.Load method.
        // Cast the loaded image to EmfImage to access EMF‑specific properties.
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            // Create SVG save options.
            SvgOptions svgOptions = new SvgOptions
            {
                // Render all text as vector shapes to preserve appearance.
                TextAsShapes = true
            };

            // Configure rasterization options specific to EMF.
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                // Set the background of the drawing surface.
                BackgroundColor = Color.WhiteSmoke,

                // Use the original EMF size as the page size.
                PageSize = emfImage.Size,

                // Automatically choose the appropriate render mode (EMF or WMF).
                RenderMode = EmfRenderMode.Auto,

                // Optional: set margins if needed.
                BorderX = 0,
                BorderY = 0
            };

            // Attach the rasterization options to the SVG options.
            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save the EMF image as SVG using the configured options.
            emfImage.Save(outputPath, svgOptions);
        }

        // At this point the using block has disposed the EmfImage,
        // ensuring all resources are released properly.
        Console.WriteLine("Conversion completed: " + outputPath);
    }
}