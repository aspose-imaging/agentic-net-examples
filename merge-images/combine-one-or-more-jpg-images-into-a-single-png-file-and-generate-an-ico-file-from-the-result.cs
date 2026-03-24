using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Ico;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputPaths = new string[]
        {
            @"C:\temp\img1.jpg",
            @"C:\temp\img2.jpg"
        };

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Combine the JPGs into a multipage image
        using (Image multiPage = Image.Create(inputPaths))
        {
            // Output PNG path
            string pngPath = @"C:\temp\combined.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

            // Save the combined image as PNG
            multiPage.Save(pngPath, new PngOptions());

            // Load the PNG we just saved
            using (Image pngImage = Image.Load(pngPath))
            {
                // Prepare ICO creation options (default: PNG format, 32 bpp)
                IcoOptions icoOptions = new IcoOptions();

                // Create an ICO image from the PNG
                using (IcoImage icoImage = new IcoImage(pngImage, icoOptions))
                {
                    // Output ICO path
                    string icoPath = @"C:\temp\combined.ico";

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(icoPath));

                    // Save the ICO file
                    icoImage.Save(icoPath);
                }
            }
        }
    }
}