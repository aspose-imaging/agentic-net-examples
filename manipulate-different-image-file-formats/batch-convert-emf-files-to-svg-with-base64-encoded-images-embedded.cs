using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input directory and list of EMF files to process
        string inputDir = @"C:\InputEmf";
        string[] emfFiles = new[] { "sample1.emf", "sample2.emf", "sample3.emf" };

        foreach (string fileName in emfFiles)
        {
            // Build full input path
            string inputPath = Path.Combine(inputDir, fileName);

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Define output path (same name with .svg extension)
            string outputPath = inputPath + ".svg";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Configure SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    // Render all text as shapes to preserve appearance
                    TextAsShapes = true
                };

                // Configure rasterization options for EMF
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    // Use the original EMF size
                    PageSize = emfImage.Size,
                    // White background for the SVG canvas
                    BackgroundColor = Color.White,
                    // Let Aspose decide whether to render embedded EMF or WMF
                    RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                    // Optional margins (set to zero for no extra border)
                    BorderX = 0,
                    BorderY = 0
                };

                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG; raster images inside the EMF will be embedded as Base64 automatically
                emfImage.Save(outputPath, svgOptions);
            }
        }
    }
}