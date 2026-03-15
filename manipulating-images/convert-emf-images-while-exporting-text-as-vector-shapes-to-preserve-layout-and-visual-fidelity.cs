using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Folder containing the source EMF file
        string dir = @"c:\temp\";
        string inputPath = System.IO.Path.Combine(dir, "test.emf");
        string outputPath = System.IO.Path.Combine(dir, "test.output.svg");

        // Load the EMF image using the unified Image.Load method
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            // Create SVG save options and enable conversion of all text to vector shapes
            SvgOptions svgOptions = new SvgOptions
            {
                TextAsShapes = true
            };

            // Configure rasterization options specific to EMF
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                // Set a light background for the drawing surface
                BackgroundColor = Color.WhiteSmoke,

                // Use the original EMF size as the page size
                PageSize = emfImage.Size,

                // Automatically choose the appropriate render mode (EMF or WMF)
                RenderMode = EmfRenderMode.Auto,

                // Optional margins around the drawing
                BorderX = 50,
                BorderY = 50
            };

            // Attach the rasterization options to the SVG options
            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save the EMF as SVG while preserving text as vector shapes
            emfImage.Save(outputPath, svgOptions);
        }
    }
}