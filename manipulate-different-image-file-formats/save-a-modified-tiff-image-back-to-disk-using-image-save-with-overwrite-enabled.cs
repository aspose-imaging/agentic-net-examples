// HOW-TO: Save Modified TIFF Overwrite Existing File Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                // Modify the image: fill a rectangle with a red gradient
                Graphics graphics = new Graphics(image);
                LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(image.Width, image.Height),
                    Color.Red,
                    Color.Transparent);
                Rectangle rect = new Rectangle(10, 10, image.Width - 20, image.Height - 20);
                graphics.FillRectangle(brush, rect);

                // Prepare save options (default format)
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the modified image, overwriting if the file exists
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to programmatically add a gradient overlay to a TIFF and replace the original file on disk.
 * 2. When a batch process must edit multi‑page TIFF documents and save the changes without creating duplicate files.
 * 3. When an application generates watermarks on scanned TIFF images and must overwrite the source to conserve storage.
 * 4. When a server‑side service updates TIFF metadata or graphics and needs to write the updated image back safely.
 * 5. When you want to automate image preprocessing, such as drawing shapes on TIFFs, and ensure the output overwrites any previous version.
 */
