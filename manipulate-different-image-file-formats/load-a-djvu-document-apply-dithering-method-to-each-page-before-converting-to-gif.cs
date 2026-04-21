using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input DjVu file path
        string inputPath = @"C:\temp\sample.djvu";

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

            // Iterate through each page in the DjVu document
            foreach (DjvuPage page in djvuImage.Pages)
            {
                // Apply dithering to the page (using Floyd‑Steinberg and 8‑bit palette)
                page.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 8, null);

                // Prepare output file name for the current page
                string outputPath = $@"C:\temp\output\page_{page.PageNumber}.gif";

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the dithered page as a GIF image
                page.Save(outputPath, new GifOptions());
            }
        }
    }
}