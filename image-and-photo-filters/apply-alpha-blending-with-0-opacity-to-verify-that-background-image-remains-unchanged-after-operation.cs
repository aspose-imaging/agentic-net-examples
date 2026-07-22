using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string backgroundPath = "background.png";
        string overlayPath = "overlay.png";
        string outputPath = "result.png";

        try
        {
            if (!File.Exists(backgroundPath))
            {
                Console.Error.WriteLine($"File not found: {backgroundPath}");
                return;
            }

            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                // Blend overlay onto background with 0 opacity (no change expected)
                background.Blend(new Point(0, 0), overlay, 0);

                // Save the result as PNG
                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                background.Save(outputPath, options);
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
 * 1. When a developer wants to unit‑test that the Aspose.Imaging Blend method respects an opacity value of 0, they can overlay a PNG image onto a background PNG and verify the output is identical to the original background.
 * 2. When building a CI/CD pipeline that validates image‑processing steps, the code can be used to confirm that a zero‑opacity blend does not unintentionally modify the source raster image.
 * 3. When creating a graphics editor that offers a “preview without applying changes” feature, the developer can run this blend with 0 opacity to ensure the preview layer leaves the underlying JPEG or PNG unchanged.
 * 4. When troubleshooting a custom watermarking workflow, a programmer can use the sample to check whether the overlay PNG is being applied correctly by first blending with 0 opacity as a control test.
 * 5. When documenting API behavior for Aspose.Imaging’s Blend function, the example demonstrates how to programmatically confirm that a transparent overlay (opacity 0) preserves the original background image file.
 */