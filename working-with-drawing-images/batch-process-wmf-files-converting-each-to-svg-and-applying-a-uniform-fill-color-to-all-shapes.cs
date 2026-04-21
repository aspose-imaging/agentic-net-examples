using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hard‑coded input directory and list of WMF files to process
        string inputFolder = @"C:\Images\Input";
        string[] inputFiles = new[] { "file1.wmf", "file2.wmf", "file3.wmf" };

        // Uniform fill color that will be applied as the background during rasterization
        Aspose.Imaging.Color uniformFillColor = Aspose.Imaging.Color.Red;

        foreach (var fileName in inputFiles)
        {
            // Build full input path
            string inputPath = Path.Combine(inputFolder, fileName);

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue; // Skip to next file
            }

            // Determine output path (same folder, .svg extension)
            string outputPath = Path.ChangeExtension(inputPath, ".svg");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Prepare SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true // Render text as shapes
                };

                // Configure rasterization options with the uniform fill color
                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = uniformFillColor, // Apply uniform fill
                    PageSize = wmfImage.Size,           // Preserve original size
                    RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                };

                // Attach rasterization options to the SVG options
                saveOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG
                wmfImage.Save(outputPath, saveOptions);
            }
        }
    }
}