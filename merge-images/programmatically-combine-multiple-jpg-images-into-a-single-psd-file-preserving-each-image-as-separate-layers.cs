using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd; // For PSD specific enums if needed

class CombineJpgToPsd
{
    static void Main()
    {
        // Folder containing the source JPG images
        string inputFolder = @"C:\Images\Jpgs";
        // Output PSD file path
        string outputPsdPath = @"C:\Images\Combined.psd";

        // Get all JPG files in the folder (order can be adjusted as needed)
        string[] jpgFiles = Directory.GetFiles(inputFolder, "*.jpg");

        if (jpgFiles.Length == 0)
        {
            Console.WriteLine("No JPG files found in the specified folder.");
            return;
        }

        // Load the first JPG – it will become the base layer of the PSD
        using (Image baseImage = Image.Load(jpgFiles[0]))
        {
            // Ensure the base image supports adding pages (layers)
            // Most raster formats (including PSD) expose AddPage method.
            // Cast to dynamic to invoke AddPage without compile‑time knowledge of the exact type.
            dynamic psdImage = baseImage;

            // Add remaining JPGs as separate layers
            for (int i = 1; i < jpgFiles.Length; i++)
            {
                using (Image layer = Image.Load(jpgFiles[i]))
                {
                    // Each call adds a new page/layer to the PSD image
                    psdImage.AddPage(layer);
                }
            }

            // Prepare PSD save options (you can customize compression, color mode, etc.)
            PsdOptions psdOptions = new PsdOptions
            {
                // Example: use RLE compression
                CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                // Example: keep the original color mode (RGB)
                ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb
            };

            // Save the combined image as a PSD file
            psdImage.Save(outputPsdPath, psdOptions);
        }

        Console.WriteLine($"Combined PSD saved to: {outputPsdPath}");
    }
}