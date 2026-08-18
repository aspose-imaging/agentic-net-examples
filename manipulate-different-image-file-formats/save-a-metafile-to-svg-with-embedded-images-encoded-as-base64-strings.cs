// HOW-TO: Convert EMF to SVG with Embedded Base64 Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class MySvgCallback : SvgResourceKeeperCallback
{
    // Embed all image resources as Base64 strings.
    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
        string suggestedFileName, ref bool useEmbeddedImage)
    {
        useEmbeddedImage = true;               // Request embedding.
        return null;                           // No external file needed.
    }

    // No special handling for the SVG document itself.
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        return null;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths.
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\sample.svg";

            // Verify input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the metafile.
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG options with the custom callback for embedding images.
                var svgOptions = new SvgOptions
                {
                    Callback = new MySvgCallback()
                };

                // Optional: set vector rasterization options to preserve page size.
                if (image is VectorImage vectorImage)
                {
                    svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = vectorImage.Size
                    };
                }

                // Save as SVG with embedded images.
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to embed raster images from an EMF file directly into an SVG for web delivery without external image files.
 * 2. When you want to preserve the original page size of a vector metafile while converting it to scalable SVG for printing or reporting.
 * 3. When you are building a C# application that must generate self‑contained SVG assets for email newsletters or offline documentation.
 * 4. When you need to ensure that all image resources inside a metafile are encoded as Base64 so that the SVG can be stored in a database as a single string.
 * 5. When you are automating batch conversion of multiple EMF graphics to SVG and want each output file to be portable across different platforms.
 */
