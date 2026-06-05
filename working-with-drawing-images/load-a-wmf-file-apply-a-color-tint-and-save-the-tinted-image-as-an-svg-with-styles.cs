using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\input.wmf";
            string outputPath = @"C:\Images\output.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Prepare SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true // render text as shapes
                };

                // Configure rasterization with a color tint (background color)
                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.LightBlue, // tint color
                    PageSize = wmfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                };

                saveOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG
                wmfImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to convert legacy WMF vector graphics into modern SVG files while applying a light‑blue background tint for consistent branding across web pages.
 * 2. When an application must batch‑process Windows Metafile (WMF) icons and add a color overlay before embedding them as scalable SVG assets in a responsive UI.
 * 3. When a reporting tool generates charts as WMF and the developer wants to render them as SVG with text converted to shapes to preserve font fidelity and add a background color for print‑ready PDFs.
 * 4. When a migration script updates old Windows‑based documentation by converting WMF illustrations to SVG with a custom tint to match the new corporate color palette.
 * 5. When a C# service automates the creation of SVG thumbnails from WMF files, using Aspose.Imaging to rasterize the vector with a specified background hue for preview galleries.
 */