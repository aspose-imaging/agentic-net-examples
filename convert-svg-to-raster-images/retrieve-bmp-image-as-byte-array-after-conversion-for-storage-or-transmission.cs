using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.bmp";
            string outputPath = @"C:\Images\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to BmpImage to access BMP‑specific operations
                BmpImage bmpImage = (BmpImage)image;

                // Example conversion: binarize using Otsu's method
                bmpImage.BinarizeOtsu();

                // Prepare BMP save options (monochrome palette)
                BmpOptions saveOptions = new BmpOptions
                {
                    Palette = ColorPaletteHelper.CreateMonochrome(),
                    BitsPerPixel = 1
                };

                // Save to a memory stream to obtain the byte array
                byte[] imageBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, saveOptions);
                    imageBytes = ms.ToArray();
                }

                // Optionally also save to a physical file
                image.Save(outputPath, saveOptions);

                // Demonstrate that we have the byte array
                Console.WriteLine($"Byte array length: {imageBytes.Length}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}