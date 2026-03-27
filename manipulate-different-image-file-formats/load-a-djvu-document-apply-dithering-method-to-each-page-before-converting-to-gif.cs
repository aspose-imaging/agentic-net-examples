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
        string inputPath = @"C:\temp\sample.djvu";
        string outputDirectory = @"C:\temp\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the DjVu document
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DjvuImage to access pages
            DjvuImage djvuImage = (DjvuImage)image;

            // Iterate through each page
            foreach (DjvuPage page in djvuImage.Pages)
            {
                // Apply dithering to the page (using Floyd‑Steinberg dithering with 8‑bit palette)
                page.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                // Prepare output file path for this page
                string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.gif");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the dithered page as a GIF image
                page.Save(outputPath, new GifOptions());
            }
        }
    }
}