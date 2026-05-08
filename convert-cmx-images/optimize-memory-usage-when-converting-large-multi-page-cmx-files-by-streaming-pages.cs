using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.cmx";
            string outputDirectory = "Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load CMX image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                int pageIndex = 0;
                foreach (Image page in cmx.Pages)
                {
                    pageIndex++;
                    string pageOutputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.png");

                    // Ensure directory for the page exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(pageOutputPath));

                    // Configure rasterization options for the page
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new CmxRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = page.Width,
                            PageHeight = page.Height,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        }
                    };

                    // Save the page as PNG
                    page.Save(pageOutputPath, pngOptions);

                    // Release resources for the current page
                    page.Dispose();
                    GC.Collect();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}