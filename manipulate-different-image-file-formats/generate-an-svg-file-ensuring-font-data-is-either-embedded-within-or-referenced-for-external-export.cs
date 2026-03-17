using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

// Custom callback to control how fonts and the final SVG document are stored
class MySvgResourceKeeperCallback : SvgResourceKeeperCallback
{
    // Embed fonts directly into the SVG as base64 data
    public override void OnFontResourceReady(FontStoringArgs args)
    {
        // Ensure fonts are embedded; other options are None or Stream
        args.FontStoreType = FontStoreType.Embedded;
    }

    // Save the generated SVG data to a file and return its path
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Use the suggested file name (or modify as needed)
        string outputPath = Path.Combine(Environment.CurrentDirectory, suggestedFileName);
        File.WriteAllBytes(outputPath, htmlData);
        return outputPath;
    }
}

class SvgExportExample
{
    static void Main()
    {
        // Input vector image (e.g., WMF, EMF, CDR, etc.)
        string inputPath = @"C:\Temp\example.wmf";
        // Desired output SVG file name (the callback will receive this)
        string outputFileName = "example_output.svg";

        // Load the source image using Aspose.Imaging's unified loader
        using (Image image = Image.Load(inputPath))
        {
            // Prepare SVG export options
            SvgOptions svgOptions = new SvgOptions
            {
                // Keep text as text (fonts will be embedded via the callback)
                TextAsShapes = false,
                // Assign our custom callback to handle font embedding and final saving
                Callback = new MySvgResourceKeeperCallback()
            };

            // Configure rasterization options required for vector images
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Set the page size to match the source image dimensions
                PageSize = image.Size,
                // Optional: background color, rendering mode, etc.
                BackgroundColor = Color.White
            };

            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save the image as SVG; the callback will embed fonts and write the file
            image.Save(outputFileName, svgOptions);
        }

        Console.WriteLine("SVG export completed with embedded fonts.");
    }
}