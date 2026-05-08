using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.djvu";
        string outputDir = @"c:\temp\output";

        // Check input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the DjVu document
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DjvuImage to access pages
                DjvuImage djvuImage = (DjvuImage)image;

                // Iterate through each page
                foreach (Image page in djvuImage.Pages)
                {
                    // Cast to DjvuPage to obtain page number
                    DjvuPage djvuPage = (DjvuPage)page;

                    // Apply dithering (using Floyd‑Steinberg with 8‑bit palette)
                    djvuPage.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 8, null);

                    // Build output file path for the GIF
                    string outputPath = Path.Combine(outputDir, $"page{djvuPage.PageNumber}.gif");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as a GIF image
                    djvuPage.Save(outputPath, new GifOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}