using System;
using System.IO;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Replace every black pen stroke with blue
                var records = wmfImage.Records;
                if (records != null)
                {
                    foreach (var record in records)
                    {
                        // Many record types expose a PenColor property; use reflection to handle them safely
                        PropertyInfo penColorProp = record.GetType().GetProperty("PenColor");
                        if (penColorProp != null && penColorProp.CanRead && penColorProp.CanWrite)
                        {
                            var currentColor = (Color)penColorProp.GetValue(record);
                            if (currentColor.ToArgb() == Color.Black.ToArgb())
                            {
                                penColorProp.SetValue(record, Color.Blue);
                            }
                        }
                    }
                }

                // Prepare SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    TextAsShapes = true
                };

                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = wmfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                };

                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG
                wmfImage.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to convert legacy WMF diagrams to scalable SVG files while changing black line colors to brand‑specific blue for web display.
 * 2. When an automation script must batch‑process engineering drawings stored as WMF, replace all black strokes with a corporate color, and output SVG for responsive UI integration.
 * 3. When a reporting tool generates vector charts in WMF and the developer wants to recolor the outlines to improve accessibility before embedding the graphics as SVG in PDF reports.
 * 4. When a migration project requires updating old Windows Metafile assets by programmatically swapping black pen colors for blue and saving them as SVG to support modern browsers.
 * 5. When a C# application needs to load a WMF logo, replace its black outlines with a brand‑approved blue hue, and export the result as SVG for use in responsive web pages.
 */