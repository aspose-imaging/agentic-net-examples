using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Graphics;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.wmf";
            string outputPath = @"C:\Images\sample.svg";

            // Verify that the input WMF file exists
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
                    // Preserve text as text (do not convert to shapes)
                    TextAsShapes = false
                };

                // Configure rasterization options for WMF
                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    // Keep background transparent to retain original appearance
                    BackgroundColor = Color.Transparent,
                    // Use the original WMF page size
                    PageSize = wmfImage.Size,
                    // Let Aspose decide the best render mode (preserves embedded fonts)
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
 * 1. When a legacy Windows Metafile (WMF) diagram must be displayed on modern web pages, a developer can convert it to scalable SVG while preserving embedded fonts and exact text positioning.
 * 2. When an automated document‑generation pipeline needs to transform vector assets from old CAD tools into SVG for responsive UI components, this code ensures the original text remains selectable and searchable.
 * 3. When a batch‑processing job migrates a corporate archive of WMF icons to SVG for high‑resolution printing, the conversion retains transparent backgrounds and font fidelity without rasterizing the text.
 * 4. When a desktop application imports user‑provided WMF logos and needs to export them as SVG for further editing in vector‑graphics editors, the code keeps the text as editable text rather than converting it to shapes.
 * 5. When a cloud‑based service converts uploaded WMF files to SVG for accessibility compliance, preserving the text layout and embedded fonts enables screen readers to read the content correctly.
 */